using AutoMapper;
using EcommerceWebApi.Data;
using EcommerceWebApi.Dtos.Request;
using EcommerceWebApi.Dtos.Response;
using EcommerceWebApi.Models;
using EcommerceWebApi.Utils;
using EcommerceWebApi.Utils.QueryParams;
using EcommerceWebApi.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EcommerceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController(EcommerceDbContext db, IMapper mapper, IConfiguration config) : ControllerBase
    {
        private readonly EcommerceDbContext _db = db;
        private readonly IMapper _mapper = mapper;
        private readonly IConfiguration _config = config;

        [Authorize(Roles = ConstConfig.UserRoleName)]
        [HttpGet("confirm")]
        [SwaggerOperation(
            Summary = "Xác nhận thanh toán đơn hàng (role user)")]
        public async Task<ActionResult<PaymentResDto>> GetOrderInfo([FromQuery] VnpayResQuery vnpayResQuery)
        {
            string rspCode = string.Empty;
            string message = string.Empty;

            string vnp_HashSecret = _config.GetSection("vnp_HashSecret").Value!; //Chuoi bi mat
            VnPayLib vnpay = new();

            vnpay.AddResponseData("vnp_TmnCode", vnpayResQuery.vnp_TmnCode);
            vnpay.AddResponseData("vnp_Amount", vnpayResQuery.vnp_Amount);
            vnpay.AddResponseData("vnp_BankCode", vnpayResQuery.vnp_BankCode);

            if (!string.IsNullOrEmpty(vnpayResQuery.vnp_BankTranNo))
            {
                vnpay.AddResponseData("vnp_BankTranNo", vnpayResQuery.vnp_BankTranNo);
            }

            if (!string.IsNullOrEmpty(vnpayResQuery.vnp_CardType))
            {
                vnpay.AddResponseData("vnp_CardType", vnpayResQuery.vnp_CardType);
            }

            if (!string.IsNullOrEmpty(vnpayResQuery.vnp_PayDate))
            {
                vnpay.AddResponseData("vnp_PayDate", vnpayResQuery.vnp_PayDate);
            }

            vnpay.AddResponseData("vnp_OrderInfo", vnpayResQuery.vnp_OrderInfo);
            vnpay.AddResponseData("vnp_TransactionNo", vnpayResQuery.vnp_TransactionNo);
            vnpay.AddResponseData("vnp_ResponseCode", vnpayResQuery.vnp_ResponseCode);
            vnpay.AddResponseData("vnp_TransactionStatus", vnpayResQuery.vnp_TransactionStatus);
            vnpay.AddResponseData("vnp_TxnRef", vnpayResQuery.vnp_TxnRef);

            if (!string.IsNullOrEmpty(vnpayResQuery.vnp_SecureHashType))
            {
                vnpay.AddResponseData("vnp_SecureHashType", vnpayResQuery.vnp_SecureHashType);
            }
            vnpay.AddResponseData("vnp_SecureHash", vnpayResQuery.vnp_SecureHash);

            int orderId = int.TryParse(vnpay.GetResponseData("vnp_TxnRef"), out int outputOrderId) ? outputOrderId : -1;
            long vnpayTranId = long.TryParse(vnpay.GetResponseData("vnp_TransactionNo"), out long outputVnpayTranId) ? outputVnpayTranId : -1;
            long paymentAmount = long.TryParse(vnpay.GetResponseData("vnp_Amount"), out long outputVnpAmount) ? outputVnpAmount / 100 : -1;
            bool checkSignature = vnpay.ValidateSignature(vnpayResQuery.vnp_SecureHash, vnp_HashSecret);

            try
            {
                var order = await _db.Orders.FirstOrDefaultAsync(o => o.Id == orderId);

                if (checkSignature)
                {
                    if (order != null)
                    {
                        if (order.Total == (paymentAmount / 1000))
                        {
                            if (order.PaymentStatus == Utils.EnumTypes.PaymentStatus.Pending)
                            {
                                if (vnpayResQuery.vnp_ResponseCode == "00" && vnpayResQuery.vnp_TransactionStatus == "00")
                                {
                                    //Thanh toan thanh cong
                                    order.PaymentStatus = Utils.EnumTypes.PaymentStatus.Completed;
                                }
                                else
                                {
                                    //Thanh toan khong thanh cong. Ma loi: vnp_ResponseCode
                                    //  displayMsg.InnerText = "Có lỗi xảy ra trong quá trình xử lý.Mã lỗi: " + vnp_ResponseCode;
                                    order.PaymentStatus = Utils.EnumTypes.PaymentStatus.Pending;

                                    message = "Failed in payment process";
                                    rspCode = vnpayResQuery.vnp_ResponseCode;
                                }

                                //Thêm code Thực hiện cập nhật vào Database 
                                //Update Database
                                await _db.SaveChangesAsync();

                                message = "Confirm Success";
                                rspCode = "00";

                                return Ok(new { message, rspCode });
                            }
                            else
                            {
                                message = "Order already confirmed";
                                rspCode = "02";

                                return Ok(new { message, rspCode });
                            }
                        }
                        else
                        {
                            message = "Invalid amount";
                            rspCode = "04";

                            return Ok(new { message, rspCode });
                        }
                    }
                    else
                    {
                        message = "Order not found";
                        rspCode = "01";

                        return Ok(new { message, rspCode });
                    }
                }
                else
                {
                    message = "Invalid signature";
                    rspCode = "97";

                    return Ok(new { message, rspCode });
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = e.Message
                });
            }
        }

        [Authorize(Roles = ConstConfig.UserRoleName)]
        [HttpPost]
        [SwaggerOperation(
            Summary = "Thanh toán đơn hàng (role user)")]
        public async Task<ActionResult> CreateOrder([FromBody] CreateOrderReqDto createOrderDtos)
        {
            int customerId = int.TryParse(HttpContext.User.FindFirst(ConstConfig.UserIdClaimType)?.Value, out int output) ? output : -1;

            var productsOnSale = GetAllProductOnSale();
            List<CreateDetailOrderReqDto> listDetailOrderDto = createOrderDtos.DetailOrderReqDtos;

            // Validation input
            if (listDetailOrderDto.Count == 0)
                return BadRequest(new { message = "Order must have at least one product!" });

            var validator = new CreateDetailOrderValidator();

            for (int i = 0; i < listDetailOrderDto.Count; i++)
            {
                var validationResult = validator.Validate(listDetailOrderDto.ElementAt(i));
                if (!validationResult.IsValid)
                    return BadRequest(validationResult.ToDictionary());
            }

            var firstProduct = await _db.Products.FirstOrDefaultAsync(p => p.Id == listDetailOrderDto.ElementAt(0).ProductId);
            if (firstProduct is null)
                return NotFound(Helper.ErrorResponse(ConstConfig.NotFound));

            int shopId = firstProduct.ShopId;

            List<HandleDetailOrderReqDto> handleDetails = [];
            decimal total = 0;

            for (int i = 0; i < listDetailOrderDto.Count; i++)
            {
                var reqProductId = listDetailOrderDto.ElementAt(i).ProductId;

                if (productsOnSale.Any(p => p.Id == reqProductId))
                {
                    var product = productsOnSale.First(p => p.Id == reqProductId);

                    if (product.ShopId != shopId)
                        return BadRequest(new { message = "Product is not belong to one shop!" });

                    var unitPrice = product.Price - ((decimal)product.DiscountPercent * product.Price);
                    var quantity = listDetailOrderDto.ElementAt(i).Quantity;

                    handleDetails.Add(new HandleDetailOrderReqDto()
                    {
                        ProductId = reqProductId,
                        Quantity = quantity,
                        UnitPrice = unitPrice
                    });

                    total += quantity * unitPrice;
                }
                else
                {
                    var product = _db.Products.FirstOrDefault(p => p.Id == reqProductId);
                    if (product is not null)
                    {
                        if (product.ShopId != shopId)
                            return BadRequest(new { message = "Product is not belong to one shop!" });

                        var unitPrice = product.Price;
                        var quantity = listDetailOrderDto.ElementAt(i).Quantity;

                        handleDetails.Add(new HandleDetailOrderReqDto()
                        {
                            ProductId = reqProductId,
                            Quantity = quantity,
                            UnitPrice = product.Price
                        });

                        total += quantity * unitPrice;
                    }
                }
            }

            List<DetailOrder> detailOrders = _mapper.Map<List<DetailOrder>>(handleDetails);

            try
            {
                string vnp_Returnurl = _config.GetSection("vnp_Returnurl").Value!; //URL nhan ket qua tra ve 
                string vnp_Url = _config.GetSection("vnp_Url").Value!; //URL thanh toan cua VNPAY 
                string vnp_TmnCode = _config.GetSection("vnp_TmnCode").Value!; //Ma website
                string vnp_HashSecret = _config.GetSection("vnp_HashSecret").Value!; //Chuoi bi mat

                VnPayLib vnpay = new();

                // Create and save new Order
                Order order = new()
                {
                    AddressId = createOrderDtos.AddressId,
                    CustomerId = customerId,
                    DetailOrders = detailOrders,
                    Total = total
                };

                await _db.Orders.AddAsync(order);
                await _db.SaveChangesAsync();

                vnpay.AddRequestData("vnp_Version", VnPayLib.VERSION);
                vnpay.AddRequestData("vnp_Command", "pay");
                vnpay.AddRequestData("vnp_TmnCode", vnp_TmnCode);
                vnpay.AddRequestData("vnp_Amount", Convert.ToUInt64(order.Total * 1000 * 100).ToString());

                vnpay.AddRequestData("vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss"));
                vnpay.AddRequestData("vnp_CurrCode", "VND");
                vnpay.AddRequestData("vnp_IpAddr", HttpContext.Connection.RemoteIpAddress!.ToString());

                vnpay.AddRequestData("vnp_Locale", "vn");
                vnpay.AddRequestData("vnp_OrderInfo", $"Thanh toan don hang: {order.Id}");
                vnpay.AddRequestData("vnp_OrderType", "Thanh toan");

                vnpay.AddRequestData("vnp_ReturnUrl", vnp_Returnurl);
                vnpay.AddRequestData("vnp_TxnRef", order.Id.ToString());

                string paymentUrl = vnpay.CreateRequestUrl(vnp_Url, vnp_HashSecret);

                return Ok(new { paymentUrl });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Helper.ErrorResponse(ConstConfig.InternalServer));
            }
        }

        private List<ProductResDto> GetAllProductOnSale()
        {
            var products = _db.Products
                .Include(p => p.ProductImages)
                .Include(p => p.SaleEvents)
                .Include(p => p.Shop)
                .Include(p => p.Ratings)
                .Where(p => p.SaleEvents.Any(s => DateTime.Now >= s.StartDate && DateTime.Now <= s.EndDate))
                .ToList();

            var result = _mapper.Map<List<ProductResDto>>(products);

            return result;
        }
    }
}
