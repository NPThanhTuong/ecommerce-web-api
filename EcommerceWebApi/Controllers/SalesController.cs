using AutoMapper;
using EcommerceWebApi.Data;
using EcommerceWebApi.Dtos.Request;
using EcommerceWebApi.Dtos.Response;
using EcommerceWebApi.Models;
using EcommerceWebApi.Services.Email;
using EcommerceWebApi.Utils;
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
    public class SalesController(
        EcommerceDbContext db,
        IMapper mapper,
        IEmailService emailService
        ) : ControllerBase
    {
        private readonly EcommerceDbContext _db = db;
        private readonly IMapper _mapper = mapper;
        private readonly IEmailService _emailService = emailService;

        [HttpGet]
        [SwaggerOperation(Summary =
            "Lấy thông tin tất cả các chương trình giảm giá")]
        public async Task<ActionResult<List<SaleEventResDto>>> GetAllSales()
        {
            try
            {
                IQueryable<SaleEvent> query = _db.SaleEvents
                .Include(s => s.CustomerTypes);

                var saleEventList = await query.ToListAsync();
                var result = _mapper.Map<List<SaleEventResDto>>(saleEventList);

                return Ok(new { data = result });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Helper.ErrorResponse(ConstConfig.InternalServer));
            }

        }

        [HttpGet("current")]
        [SwaggerOperation(Summary =
            "Lấy thông tin các chương trình giảm giá đang diễn ra")]
        public async Task<ActionResult<List<SaleEventResDto>>> GetAllCurrentSales()
        {
            try
            {
                IQueryable<SaleEvent> query = _db.SaleEvents
                .Include(s => s.CustomerTypes)
                .Where(s => DateTime.Now >= s.StartDate && DateTime.Now <= s.EndDate);

                var saleEventList = await query.ToListAsync();
                var result = _mapper.Map<List<SaleEventResDto>>(saleEventList);

                return Ok(new { data = result });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Helper.ErrorResponse(ConstConfig.InternalServer));
            }

        }

        [HttpGet("upcoming")]
        [SwaggerOperation(Summary =
            "Lấy thông tin các chương trình giảm giá sắp tới")]
        public async Task<ActionResult<List<SaleEventResDto>>> GetAllComingUpSales()
        {
            try
            {
                IQueryable<SaleEvent> query = _db.SaleEvents
                .Include(s => s.CustomerTypes)
                .Where(s => DateTime.Now <= s.StartDate);

                var saleEventList = await query.ToListAsync();
                var result = _mapper.Map<List<SaleEventResDto>>(saleEventList);

                return Ok(new { data = result });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Helper.ErrorResponse(ConstConfig.InternalServer));
            }
        }

        [HttpGet("current/products")]
        [SwaggerOperation(Summary =
            "Lấy thông tin các chương trình và sản phẩm giảm giá đang diễn ra")]
        public async Task<ActionResult<List<SaleEventProductResDto>>> GetAllProductsCurrentSale()
        {
            try
            {
                IQueryable<SaleEvent> query = _db.SaleEvents
                .Include(s => s.CustomerTypes)
                .Include(s => s.Products)
                    .ThenInclude(p => p.ProductImages)
                .Where(s => DateTime.Now >= s.StartDate && DateTime.Now <= s.EndDate);

                var saleEventList = await query.ToListAsync();
                var result = _mapper.Map<List<SaleEventProductResDto>>(saleEventList);

                return Ok(new { data = result });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Helper.ErrorResponse(ConstConfig.InternalServer));
            }
        }

        [HttpGet("upcoming/products")]
        [SwaggerOperation(Summary =
            "Lấy thông tin các chương trình và sản phẩm giảm giá sắp tới")]
        public async Task<ActionResult<List<SaleEventProductResDto>>> GetAllProductsUpComingSale()
        {
            try
            {
                IQueryable<SaleEvent> query = _db.SaleEvents
                .Include(s => s.CustomerTypes)
                .Include(s => s.Products)
                    .ThenInclude(p => p.ProductImages)
                .Where(s => DateTime.Now <= s.StartDate);

                var saleEventList = await query.ToListAsync();
                var result = _mapper.Map<List<SaleEventProductResDto>>(saleEventList);

                return Ok(new { data = result });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Helper.ErrorResponse(ConstConfig.InternalServer));
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary =
            "Lấy thông tin chi tiết chương trình giảm giá")]
        public async Task<ActionResult<SaleEventProductResDto>> GetDetailSaleEvent(int id)
        {
            if (id <= 0) return BadRequest(Helper.ErrorResponse(ConstConfig.InvalidId));

            try
            {
                var saleEvent = await _db.SaleEvents
                .Include(s => s.CustomerTypes)
                .Include(s => s.Products)
                    .ThenInclude(p => p.ProductImages)
                .FirstOrDefaultAsync(s => s.Id == id);

                if (saleEvent is null)
                    return NotFound(Helper.ErrorResponse(ConstConfig.NotFound));

                var result = _mapper.Map<SaleEventProductResDto>(saleEvent);

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Helper.ErrorResponse(ConstConfig.InternalServer));
            }
        }

        [Authorize(Roles = ConstConfig.AdminRoleName)]
        [HttpPost]
        [SwaggerOperation(Summary =
            "Thêm chương trình giảm giá mới (role admin)")]
        public async Task<ActionResult> CreateSaleEvent([FromBody] CreateSaleEventReqDto createSaleEventReq)
        {
            try
            {
                var validator = new CreateSaleEventValidator();
                var validationResult = await validator.ValidateAsync(createSaleEventReq);
                if (!validationResult.IsValid)
                    return BadRequest(validationResult.ToDictionary());

                var newSaleEvent = _mapper.Map<SaleEvent>(createSaleEventReq);

                var customerTypeList = new List<CustomerTypeSaleEvent>();
                var productList = new List<ProductSaleEvent>();

                // Handle customer types
                for (int i = 0; i < createSaleEventReq.CustomerTypeIds.Count; i++)
                {
                    var customeType = await _db.CustomerTypes
                        .FirstOrDefaultAsync(ct => ct.Id == createSaleEventReq.CustomerTypeIds[i]);
                    if (customeType is null)
                        return NotFound(new { message = "Customer type is not found!" });
                    else
                        customerTypeList.Add(new CustomerTypeSaleEvent
                        {
                            CustomerTypeId = customeType.Id,
                        });
                }

                // Handle product
                for (int i = 0; i < createSaleEventReq.ProductIds.Count; i++)
                {
                    var product = await _db.Products
                        .FirstOrDefaultAsync(p => p.Id == createSaleEventReq.ProductIds[i]);
                    if (product is null)
                        return NotFound(new { message = "Product is not found!" });
                    else
                        productList.Add(new ProductSaleEvent
                        {
                            ProductId = product.Id
                        });
                }

                newSaleEvent.CustomerTypeSaleEvents = customerTypeList;
                newSaleEvent.ProductSaleEvents = productList;

                await _db.AddAsync(newSaleEvent);
                await _db.SaveChangesAsync();

                return Created();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    Helper.ErrorResponse(ConstConfig.InternalServer));
            }
        }

        [Authorize(Roles = ConstConfig.AdminRoleName)]
        [HttpPut("{id}")]
        [SwaggerOperation(Summary =
            "Sửa thông tin chương trình giảm giá (role admin)")]
        public async Task<ActionResult> UpdateSaleEventInfo(int id, [FromBody] UpdateSaleEventReqDto updateSaleEventReq)
        {
            try
            {
                if (id <= 0)
                    return BadRequest(Helper.ErrorResponse(ConstConfig.InvalidId));

                var validator = new UpdateSaleEventValidator();
                var validationResult = await validator.ValidateAsync(updateSaleEventReq);
                if (!validationResult.IsValid)
                    return BadRequest(validationResult.ToDictionary());

                var saleEvent = await _db.SaleEvents.FirstOrDefaultAsync(se => se.Id == id);
                if (saleEvent is null)
                    return NotFound(Helper.ErrorResponse(ConstConfig.NotFound));

                _mapper.Map(updateSaleEventReq, saleEvent);

                await _db.SaveChangesAsync();

                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    Helper.ErrorResponse(ConstConfig.InternalServer));
            }

        }

        [Authorize(Roles = ConstConfig.AdminRoleName)]
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary =
            "Xóa chương trình giảm giá (role admin)")]
        public async Task<ActionResult> DeleteSaleEvent(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest(Helper.ErrorResponse(ConstConfig.InvalidId));

                var saleEvent = await _db.SaleEvents.FirstOrDefaultAsync(se => se.Id == id);
                if (saleEvent is null)
                    return NotFound(Helper.ErrorResponse(ConstConfig.NotFound));

                _db.SaleEvents.Remove(saleEvent);
                await _db.SaveChangesAsync();

                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    Helper.ErrorResponse(ConstConfig.InternalServer));
            }
        }

        [Authorize(Roles = ConstConfig.AdminRoleName)]
        [HttpPost("{saleEventId}/customer-types")]
        [SwaggerOperation(Summary =
            "Thêm loại khách hàng được áp dụng chương trình giảm giá (role admin)")]
        public async Task<ActionResult> AddCustomerTypeSaleEvent(int saleEventId, [FromBody] List<int> customerTypeIds)
        {
            try
            {
                if (saleEventId <= 0)
                    return BadRequest(Helper.ErrorResponse(ConstConfig.InvalidId));

                var saleEvent = await _db.SaleEvents.FirstOrDefaultAsync(se => se.Id == saleEventId);
                if (saleEvent is null)
                    return NotFound(Helper.ErrorResponse(ConstConfig.NotFound));

                var customerTypeList = new List<CustomerTypeSaleEvent>();

                for (int i = 0; i < customerTypeIds.Count; i++)
                {
                    var customeType = await _db.CustomerTypes
                        .FirstOrDefaultAsync(ct => ct.Id == customerTypeIds[i]);
                    if (customeType is null)
                        return NotFound(new { message = "Customer type is not found!" });
                    else
                        customerTypeList.Add(new CustomerTypeSaleEvent
                        {
                            CustomerTypeId = customeType.Id,
                        });
                }

                saleEvent.CustomerTypeSaleEvents.AddRange(customerTypeList);

                await _db.SaveChangesAsync();

                return Ok(new { message = "Add customer type for sale event successfully!" });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    Helper.ErrorResponse(ConstConfig.InternalServer));
            }
        }

        [Authorize(Roles = ConstConfig.AdminRoleName)]
        [HttpDelete("{saleEventId}/customer-types/{customerTypeId}")]
        [SwaggerOperation(Summary =
            "Xóa loại khách hàng được áp dụng chương trình giảm giá (role admin)")]
        public async Task<ActionResult> RemoveCustomerTypeSaleEvent(int saleEventId, int customerTypeId)
        {
            try
            {
                if (saleEventId <= 0 || customerTypeId <= 0)
                    return BadRequest(Helper.ErrorResponse(ConstConfig.InvalidId));

                var customerTypeSaleEvent = await _db.CustomerTypeSaleEvents
                    .FirstOrDefaultAsync(cs => cs.SaleEventId == saleEventId && cs.CustomerTypeId == customerTypeId);

                if (customerTypeSaleEvent is null)
                    return NotFound(Helper.ErrorResponse(ConstConfig.NotFound));

                _db.CustomerTypeSaleEvents.Remove(customerTypeSaleEvent);
                await _db.SaveChangesAsync();

                return Ok(new { message = "Remove customer type for sale event successfully!" });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    Helper.ErrorResponse(ConstConfig.InternalServer));
            }
        }

        [Authorize(Roles = ConstConfig.AdminRoleName)]
        [HttpPost("{saleEventId}/products")]
        [SwaggerOperation(Summary =
            "Thêm sản phẩm được áp dụng chương trình giảm giá (role admin)")]
        public async Task<ActionResult> AddProductSaleEvent(int saleEventId, [FromBody] List<int> productIds)
        {
            try
            {
                if (saleEventId <= 0)
                    return BadRequest(Helper.ErrorResponse(ConstConfig.InvalidId));

                var saleEvent = await _db.SaleEvents.FirstOrDefaultAsync(se => se.Id == saleEventId);
                if (saleEvent is null)
                    return NotFound(Helper.ErrorResponse(ConstConfig.NotFound));

                var productList = new List<ProductSaleEvent>();

                for (int i = 0; i < productIds.Count; i++)
                {
                    var product = await _db.Products
                        .FirstOrDefaultAsync(p => p.Id == productIds[i]);
                    if (product is null)
                        return NotFound(new { message = "Product is not found!" });
                    else
                        productList.Add(new ProductSaleEvent
                        {
                            ProductId = product.Id,
                        });
                }

                saleEvent.ProductSaleEvents.AddRange(productList);

                await _db.SaveChangesAsync();

                return Ok(new { message = "Add product for sale event successfully!" });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    Helper.ErrorResponse(ConstConfig.InternalServer));
            }
        }

        [HttpDelete("{saleEventId}/products/{productId}")]
        [Authorize(Roles = ConstConfig.AdminRoleName)]
        [SwaggerOperation(Summary =
            "Xóa sản phẩm được áp dụng chương trình giảm giá (role admin)")]
        public async Task<ActionResult> RemoveProductSaleEvent(int saleEventId, int productId)
        {
            try
            {
                if (saleEventId <= 0 || productId <= 0)
                    return BadRequest(Helper.ErrorResponse(ConstConfig.InvalidId));

                var productSaleEvent = await _db.ProductSaleEvents
                    .FirstOrDefaultAsync(cs => cs.SaleEventId == saleEventId && cs.ProductId == productId);

                if (productSaleEvent is null)
                    return NotFound(Helper.ErrorResponse(ConstConfig.NotFound));

                _db.ProductSaleEvents.Remove(productSaleEvent);
                await _db.SaveChangesAsync();

                return Ok(new { message = "Remove product for sale event successfully!" });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    Helper.ErrorResponse(ConstConfig.InternalServer));
            }
        }

        [HttpPost("{saleEventId}/notify-mail")]
        [Authorize(Roles = ConstConfig.AdminRoleName)]
        [SwaggerOperation(Summary =
            "Gửi email thông báo đến các khách hàng được áp dụng chương trình giảm giá (role admin)")]
        public async Task<ActionResult> SendSaleEventMail(int saleEventId)
        {
            try
            {
                if (saleEventId <= 0)
                    return BadRequest(Helper.ErrorResponse(ConstConfig.InvalidId));

                var saleEvent = await _db.SaleEvents
                    .Include(s => s.CustomerTypes)
                    .Include(s => s.Products)
                        .ThenInclude(p => p.ProductImages)
                    .FirstOrDefaultAsync(s => s.Id == saleEventId);

                if (saleEvent is null)
                    return NotFound(Helper.ErrorResponse(ConstConfig.NotFound));


                var saleEventDto = _mapper.Map<SaleEventResDto>(saleEvent);
                var customerTypeIds = saleEventDto.CustomerTypes.Select(ct => ct.Id).ToList();

                var customerAppliedList = await _db.Customers
                    .Include(c => c.Account)
                    .Where(c => customerTypeIds.Contains(c.CustomerTypeId))
                    .ToListAsync();

                if (customerAppliedList.Count > 0)
                {
                    customerAppliedList.ForEach(customer =>
                    {
                        string emailBody = Helper.GetEmailSaleEventContent(customer.Name, saleEventDto.Name, DateOnly.FromDateTime(saleEventDto.StartDate), DateOnly.FromDateTime(saleEventDto.EndDate), saleEventDto.Discount);

                        var emailRequest = new EmailReqDto()
                        {
                            To = customer.Account.Email,
                            Body = emailBody,
                            Subject = "[TATLN] Sự Kiện Khuyến Mãi Lớn Dành Riêng Cho Bạn!"
                        };

                        _emailService.SendEmail(emailRequest);
                    });
                }

                return Ok(new { message = "Send notification email to customer successfully" });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    Helper.ErrorResponse(ConstConfig.InternalServer));
            }
        }
    }
}
