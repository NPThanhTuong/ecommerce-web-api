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
    public class ShopsController(EcommerceDbContext db, IMapper mapper) : ControllerBase
    {
        private readonly EcommerceDbContext _db = db;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        [SwaggerOperation(Summary =
            "Lấy thông tin tất cả các shop")]
        public async Task<ActionResult<PaginationDto<List<ShopResDto>>>> GetAllShops([FromQuery] ShopReqQuery shopReqQuery)
        {
            IQueryable<Shop> query = _db.Shops;

            if (!string.IsNullOrWhiteSpace(shopReqQuery.Search))
            {
                query = query
                     .Where(s => s.Name.ToLower().Contains(shopReqQuery.Search.ToLower()) ||
                         s.Description.ToLower().Contains(shopReqQuery.Search.ToLower()));
            }

            int count = await query.CountAsync();

            switch (shopReqQuery.SortBy.ToLower())
            {
                case "id":
                    if (shopReqQuery.SortType.Equals("desc"))
                        query = query.OrderByDescending(s => s.Id);
                    else
                        query = query.OrderBy(s => s.Id);
                    break;
                case "name":
                    if (shopReqQuery.SortType.Equals("desc"))
                        query = query.OrderByDescending(s => s.Name);
                    else
                        query = query.OrderBy(s => s.Name);
                    break;
                default:
                    break;
            }

            var shops = await query
                .Skip((shopReqQuery.Page - 1) * ConstConfig.PageSize)
                .Take(ConstConfig.PageSize)
                .ToListAsync();

            var result = _mapper.Map<List<ShopResDto>>(shops);

            return Ok(Helper.GetPaginationResult(result, count));
        }

        // GET api/<ShopsController>/5
        [HttpGet("{id}")]
        [SwaggerOperation(Summary =
            "Lấy thông tin chi tiết 1 shop")]
        public async Task<ActionResult<ShopResDto>> GetDetailShop(int id)
        {
            if (id <= 0)
                return Ok(Helper.ErrorResponse(ConstConfig.InvalidId));

            var shop = await _db.Shops
                .FirstOrDefaultAsync(s => s.Id == id);
            if (shop is null)
                return NotFound(Helper.ErrorResponse(ConstConfig.NotFound));

            var result = _mapper.Map<ShopResDto>(shop);

            return Ok(result);
        }

        [Authorize(Policy = ConstConfig.ShopPolicy)]
        [HttpPut("{id}")]
        [SwaggerOperation(Summary =
            "Chỉnh sửa thông tin của shop (role shop, admin)")]
        public async Task<ActionResult> UpdateShop(int id, [FromBody] UpdateShopReqDto updateShopReq)
        {
            if (id <= 0)
                return BadRequest(Helper.ErrorResponse(ConstConfig.InvalidId));
            int shopId = int.TryParse(HttpContext.User.FindFirst(ConstConfig.UserIdClaimType)?.Value, out int output) ? output : -1;

            try
            {
                var validator = new UpdateShopValidator();
                var validationResult = await validator.ValidateAsync(updateShopReq);
                if (!validationResult.IsValid)
                    return BadRequest(validationResult.ToDictionary());

                if (HttpContext.User.IsInRole(ConstConfig.ShopRoleName) && id != shopId)
                    return Forbid();

                var shop = await _db.Shops.FirstOrDefaultAsync(s => s.Id == id);
                if (shop is null)
                    return NotFound(Helper.ErrorResponse(ConstConfig.NotFound));

                _mapper.Map(updateShopReq, shop);

                await _db.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Helper.ErrorResponse(ConstConfig.InternalServer));
            }
        }

        [Authorize(Roles = ConstConfig.AdminRoleName)]
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary =
            "Xóa shop và tài khoản bán hàng (role admin)")]
        public async Task<ActionResult> DeleteShop(int id)
        {
            if (id <= 0)
                return BadRequest(Helper.ErrorResponse(ConstConfig.InvalidId));

            try
            {
                var shop = await _db.Shops
                    .Include(s => s.Account)
                    .Include(s => s.Products)
                        .ThenInclude(p => p.DetailOrders)
                    .Include(s => s.Products)
                        .ThenInclude(p => p.Likes)
                    .Include(s => s.Products)
                        .ThenInclude(p => p.Ratings)
                    .FirstOrDefaultAsync(s => s.Id == id);
                if (shop is null)
                    return NotFound(Helper.ErrorResponse(ConstConfig.NotFound));

                for (int i = 0; i < shop.Products.Count; i++)
                {
                    if (shop.Products[i].DetailOrders.Count > 0)
                        _db.DetailOrders.RemoveRange(shop.Products[i].DetailOrders);

                    if (shop.Products[i].Likes.Count > 0)
                        _db.Likes.RemoveRange(shop.Products[i].Likes);

                    if (shop.Products[i].Ratings.Count > 0)
                        _db.Ratings.RemoveRange(shop.Products[i].Ratings);
                }

                _db.Products.RemoveRange(shop.Products);
                _db.Shops.Remove(shop);
                _db.Accounts.Remove(shop.Account);

                await _db.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Helper.ErrorResponse(ConstConfig.InternalServer));
            }
        }
    }
}
