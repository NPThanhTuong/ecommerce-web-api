using AutoMapper;
using EcommerceWebApi.Data;
using EcommerceWebApi.Dtos.Request;
using EcommerceWebApi.Dtos.Response;
using EcommerceWebApi.Models;
using EcommerceWebApi.Utils;
using EcommerceWebApi.Utils.QueryParams;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EcommerceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController(EcommerceDbContext db, IMapper mapper, IConfiguration config) : ControllerBase
    {
        private readonly EcommerceDbContext _db = db;
        private readonly IMapper _mapper = mapper;
        private readonly IConfiguration _config = config;

        // Client (auth)
        [Authorize(Roles = ConstConfig.UserRoleName)]
        [HttpGet("customer")]
        [SwaggerOperation(Summary = "Lấy các đơn hàng của người dùng (role user)")]
        public async Task<ActionResult<PaginationDto<List<OrderResDto>>>> GetAllCustomerOrder([FromQuery] OrderReqQuery orderReqQuery)
        {
            int customerId = int.TryParse(HttpContext.User.FindFirst(ConstConfig.UserIdClaimType)?.Value, out int output) ? output : -1;

            IQueryable<Order> query = _db.Orders
                .Include(o => o.DetailOrders)
                    .ThenInclude(d => d.Product)
                        .ThenInclude(p => p.ProductImages)
                .Include(o => o.DetailOrders)
                    .ThenInclude(d => d.Product)
                        .ThenInclude(p => p.Shop)
                .Include(o => o.DetailOrders)
                    .ThenInclude(d => d.Product)
                        .ThenInclude(p => p.SaleEvents)
                .Include(o => o.Address)
                .Where(o => o.CustomerId == customerId);

            if (orderReqQuery.Status is not null)
            {
                query = query.Where(o => o.Status == orderReqQuery.Status);
            }

            if (orderReqQuery.PaymentStatus is not null)
            {
                query = query.Where(o => o.PaymentStatus == orderReqQuery.PaymentStatus);
            }

            int count = await query.CountAsync();

            switch (orderReqQuery.SortBy.ToLower())
            {
                case "id":
                    if (orderReqQuery.SortType.Equals("desc"))
                        query = query.OrderByDescending(p => p.Id);
                    else
                        query = query.OrderBy(p => p.Id);
                    break;
                case "date":
                    if (orderReqQuery.SortType.Equals("desc"))
                        query = query.OrderByDescending(o => o.CreatedAt);
                    else
                        query = query.OrderBy(o => o.CreatedAt);
                    break;
                default:
                    break;
            }

            var orders = await query
                .Skip((orderReqQuery.Page - 1) * ConstConfig.PageSize)
                .Take(ConstConfig.PageSize)
                .ToListAsync();

            var result = _mapper.Map<List<OrderResDto>>(orders);

            return Ok(Helper.GetPaginationResult(result, count));
        }

        [Authorize(Roles = ConstConfig.ShopRoleName)]
        [HttpGet("shop")]
        [SwaggerOperation(Summary = "Lấy các đơn hàng của shop được người dùng đặt (role shop)")]
        public async Task<ActionResult<PaginationDto<List<OrderResDto>>>> GetAllShopOrder([FromQuery] OrderReqQuery orderReqQuery)
        {
            int shopId = int.TryParse(HttpContext.User.FindFirst(ConstConfig.UserIdClaimType)?.Value, out int output) ? output : -1;

            IQueryable<Order> query = _db.Orders
                .Include(o => o.DetailOrders)
                    .ThenInclude(d => d.Product)
                        .ThenInclude(p => p.ProductImages)
                .Include(o => o.DetailOrders)
                    .ThenInclude(d => d.Product)
                        .ThenInclude(p => p.Shop)
                .Include(o => o.DetailOrders)
                    .ThenInclude(d => d.Product)
                        .ThenInclude(p => p.SaleEvents)
                .Include(o => o.Customer)
                .Include(o => o.Address)
                .Where(o => o.DetailOrders.All(d => d.Product.ShopId == shopId));

            if (orderReqQuery.Status is not null)
            {
                query = query.Where(o => o.Status == orderReqQuery.Status);
            }

            if (orderReqQuery.PaymentStatus is not null)
            {
                query = query.Where(o => o.PaymentStatus == orderReqQuery.PaymentStatus);
            }

            int count = await query.CountAsync();

            switch (orderReqQuery.SortBy.ToLower())
            {
                case "id":
                    if (orderReqQuery.SortType.Equals("desc"))
                        query = query.OrderByDescending(p => p.Id);
                    else
                        query = query.OrderBy(p => p.Id);
                    break;
                case "date":
                    if (orderReqQuery.SortType.Equals("desc"))
                        query = query.OrderByDescending(o => o.CreatedAt);
                    else
                        query = query.OrderBy(o => o.CreatedAt);
                    break;
                default:
                    break;
            }

            var orders = await query
                .Skip((orderReqQuery.Page - 1) * ConstConfig.PageSize)
                .Take(ConstConfig.PageSize)
                .ToListAsync();

            var result = _mapper.Map<List<OrderResDto>>(orders);

            return Ok(Helper.GetPaginationResult(result, count));
        }

        [Authorize(Roles = ConstConfig.UserRoleName)]
        [HttpGet("{orderId}/customer")]
        [SwaggerOperation(Summary = "Lấy chi tiết 1 đơn hàng của người dùng (role user)")]
        public async Task<ActionResult<OrderResDto>> GetSpecificCustomerOrderInfo(int orderId)
        {
            if (orderId <= 0)
                return BadRequest(Helper.ErrorResponse(ConstConfig.InvalidId));

            int customerId = int.TryParse(HttpContext.User.FindFirst(ConstConfig.UserIdClaimType)?.Value, out int output) ? output : -1;

            IQueryable<Order> query = _db.Orders
                .Include(o => o.DetailOrders)
                    .ThenInclude(d => d.Product)
                        .ThenInclude(p => p.ProductImages)
                .Include(o => o.DetailOrders)
                    .ThenInclude(d => d.Product)
                        .ThenInclude(p => p.Shop)
                .Include(o => o.DetailOrders)
                    .ThenInclude(d => d.Product)
                        .ThenInclude(p => p.SaleEvents)
                .Include(o => o.Address)
                .Where(o => o.CustomerId == customerId);

            var order = await query.FirstOrDefaultAsync(o => o.Id == orderId);
            if (order is null)
                return NotFound(new { message = "Order is not found!" });

            var result = _mapper.Map<OrderResDto>(order);

            return Ok(result);
        }

        [Authorize(Roles = ConstConfig.ShopRoleName)]
        [HttpGet("{orderId}/shop")]
        [SwaggerOperation(Summary = "Lấy chi tiết 1 đơn hàng của shop được người dùng đặt (role shop)")]
        public async Task<ActionResult<OrderResDto>> GetSpecificShopOrderInfo(int orderId)
        {
            if (orderId <= 0)
                return BadRequest(Helper.ErrorResponse(ConstConfig.InvalidId));

            int shopId = int.TryParse(HttpContext.User.FindFirst(ConstConfig.UserIdClaimType)?.Value, out int output) ? output : -1;

            IQueryable<Order> query = _db.Orders
                .Include(o => o.DetailOrders)
                    .ThenInclude(d => d.Product)
                        .ThenInclude(p => p.ProductImages)
                .Include(o => o.DetailOrders)
                    .ThenInclude(d => d.Product)
                        .ThenInclude(p => p.Shop)
                .Include(o => o.DetailOrders)
                    .ThenInclude(d => d.Product)
                        .ThenInclude(p => p.SaleEvents)
                .Include(o => o.Customer)
                .Include(o => o.Address)
                .Where(o => o.DetailOrders.All(d => d.Product.ShopId == shopId));

            var order = await query.FirstOrDefaultAsync(o => o.Id == orderId);
            if (order is null)
                return NotFound(new { message = "Order is not found!" });

            var result = _mapper.Map<OrderResDto>(order);

            return Ok(result);
        }

        [Authorize(Roles = ConstConfig.ShopRoleName)]
        [HttpPut("{orderId}/shop")]
        [SwaggerOperation(Summary = "Điều chỉnh trạng thái của đơn hàng (role shop)")]
        public async Task<ActionResult> UpdateOrderShop(int orderId, [FromBody] UpdateOrderShopReqDto updateOrderReq)
        {
            if (orderId <= 0)
                return BadRequest(Helper.ErrorResponse(ConstConfig.InvalidId));

            int shopId = int.TryParse(HttpContext.User.FindFirst(ConstConfig.UserIdClaimType)?.Value, out int output) ? output : -1;

            try
            {
                var order = await _db.Orders
                    .Where(o => o.DetailOrders.All(d => d.Product.ShopId == shopId))
                    .FirstOrDefaultAsync(o => o.Id == orderId);
                if (order is null)
                    return NotFound(Helper.ErrorResponse(ConstConfig.NotFound));

                order.Status = updateOrderReq.Status;
                order.PaymentStatus = updateOrderReq.PaymentStatus;

                await _db.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    Helper.ErrorResponse(ConstConfig.InternalServer));
            }
        }

        [Authorize(Roles = ConstConfig.UserRoleName)]
        [HttpPut("{orderId}/customer")]
        [SwaggerOperation(
            Summary = "Cập nhật lại địa chỉ cho đơn hàng (đơn hàng trạng thái đang xử lý) (role user)")]
        public async Task<ActionResult> UpdateOrderCustomer(int orderId, [FromBody] UpdateOrderCustomerReqDto updateOrderReq)
        {
            if (orderId <= 0 || updateOrderReq.AddressId <= 0)
                return BadRequest(Helper.ErrorResponse(ConstConfig.InvalidId));

            int customerId = int.TryParse(HttpContext.User.FindFirst(ConstConfig.UserIdClaimType)?.Value, out int output) ? output : -1;

            try
            {
                var order = await _db.Orders.FirstOrDefaultAsync(o => o.Id == orderId);
                if (order is null)
                    return NotFound(Helper.ErrorResponse(ConstConfig.NotFound));

                if (order.Status != Utils.EnumTypes.OrderStatus.Processing)
                    return BadRequest(new { message = "You can not change address of the order!" });

                var address = await _db.Addresses.FirstOrDefaultAsync(a => a.Id == updateOrderReq.AddressId);
                if (address is null)
                    return BadRequest(new { message = "Address is not found!" });

                if (address.CustomerId != customerId)
                    return BadRequest(new { message = "Invalid address" });



                order.AddressId = updateOrderReq.AddressId;

                await _db.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    Helper.ErrorResponse(ConstConfig.InternalServer));
            }
        }

        [Authorize(Policy = ConstConfig.UserPolicy)]
        [HttpPut("{orderId}/customer/cancel")]
        [SwaggerOperation(
            Summary = "Hủy đơn hàng (đơn hàng trạng thái đang xử lý) (role user, shop)")]
        public async Task<ActionResult> CancelOrderCustomer(int orderId)
        {
            if (orderId <= 0)
                return BadRequest(Helper.ErrorResponse(ConstConfig.InvalidId));

            int customerId = int.TryParse(HttpContext.User.FindFirst(ConstConfig.UserIdClaimType)?.Value, out int output) ? output : -1;

            try
            {
                var order = await _db.Orders.FirstOrDefaultAsync(o => o.Id == orderId);
                if (order is null)
                    return NotFound(Helper.ErrorResponse(ConstConfig.NotFound));

                if (order.Status != Utils.EnumTypes.OrderStatus.Processing)
                {
                    return BadRequest(new { message = "You can not cancel the order!" });
                }

                order.Status = Utils.EnumTypes.OrderStatus.Cancelled;

                await _db.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    Helper.ErrorResponse(ConstConfig.InternalServer));
            }
        }

        // Xóa đơn hàng (admin)
        [Authorize(Roles = ConstConfig.AdminRoleName)]
        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Xóa đơn hàng (role admin)")]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            if (id <= 0)
                return BadRequest(Helper.ErrorResponse(ConstConfig.InvalidId));

            try
            {
                var order = await _db.Orders
                    .Include(o => o.Ratings)
                    .FirstOrDefaultAsync(o => o.Id == id);
                if (order is null)
                    return NotFound(Helper.ErrorResponse(ConstConfig.NotFound));

                _db.Ratings.RemoveRange(order.Ratings);
                _db.Orders.Remove(order);

                await _db.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    Helper.ErrorResponse(ConstConfig.InternalServer));
            }
        }
    }
}
