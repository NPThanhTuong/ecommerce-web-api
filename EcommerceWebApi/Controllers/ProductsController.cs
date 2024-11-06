using AutoMapper;
using EcommerceWebApi.Data;
using EcommerceWebApi.Dtos.Request;
using EcommerceWebApi.Dtos.Response;
using EcommerceWebApi.Models;
using EcommerceWebApi.Utils;
using EcommerceWebApi.Utils.QueryParams;
using EcommerceWebApi.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EcommerceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(EcommerceDbContext db, IMapper mapper) : ControllerBase
    {
        private readonly EcommerceDbContext _db = db;
        private readonly IMapper _mapper = mapper;

        // GET: api/<ProductsController>
        [HttpGet]
        [SwaggerOperation(Summary = "Lấy tất cả sản phẩm")]
        public async Task<ActionResult<PaginationDto<List<ProductResDto>>>> GetAll([FromQuery] ProductQP queryParams)
        {
            IQueryable<Product> query = _db.Products
                .Include(p => p.DetailOrders)
                .Include(p => p.Likes)
                .Include(p => p.Ratings)
                .Include(p => p.SaleEvents)
                .Include(p => p.ProductImages);

            // Xử lý các tham số filter
            if (!string.IsNullOrEmpty(queryParams.FByPrice))
            {
                decimal minPrice = decimal.TryParse(queryParams.FByPrice.Split('_')[0], out decimal minOutput) ? minOutput : 0m;
                decimal maxPrice = decimal.TryParse(queryParams.FByPrice.Split('_')[1], out decimal maxOutput) ? maxOutput : decimal.MaxValue;

                query = query
                    .Where(p => p.Price >= minPrice)
                    .Where(p => p.Price <= maxPrice);
            }

            if (!string.IsNullOrEmpty(queryParams.FByType))
            {
                string[] filterTypesInput = queryParams.FByType.Split(',');
                List<int> filterTypesId = [];
                foreach (string filterType in filterTypesInput)
                {
                    if (int.TryParse(filterType.Trim(), out int typeOutput))
                        filterTypesId.Add(typeOutput);
                }

                query = query.Where(p => filterTypesId.Contains(p.ProductTypeId));
            }

            if (!string.IsNullOrEmpty(queryParams.Search))
                query = query
                    .Where(p => p.Name.ToLower().Contains(queryParams.Search.ToLower()) ||
                        p.Description.ToLower().Contains(queryParams.Search.ToLower()));

            // đếm số lượng phần tử sau khi filter
            int count = await query.CountAsync();

            // Sắp sếp theo các thuộc tính
            switch (queryParams.SortBy.ToLower())
            {
                case "id":
                    if (queryParams.SortType.Equals("desc"))
                        query = query.OrderByDescending(p => p.Id);
                    else
                        query = query.OrderBy(p => p.Id);
                    break;
                case "rating":
                    if (queryParams.SortType.Equals("desc"))
                        query = query.OrderByDescending(p => p.Ratings.Count > 0
                        ? Math.Round((decimal)p.Ratings.Sum(r => r.Score) / p.Ratings.Count, 1)
                        : 0m);
                    else
                        query = query.OrderBy(p => p.Ratings.Count > 0
                        ? Math.Round((decimal)p.Ratings.Sum(r => r.Score) / p.Ratings.Count, 1)
                        : 0m);
                    break;
                case "like":
                    if (queryParams.SortType.Equals("desc"))
                        query = query.OrderByDescending(p => p.Likes.Count);
                    else
                        query = query.OrderBy(p => p.Likes.Count);
                    break;
                case "sold":
                    if (queryParams.SortType.Equals("desc"))
                        query = query.OrderByDescending(p => p.DetailOrders.Sum(dt => dt.Quantity));
                    else
                        query = query.OrderBy(p => p.DetailOrders.Sum(dt => dt.Quantity));
                    break;
                case "price":
                    if (queryParams.SortType.Equals("desc"))
                        query = query.OrderByDescending(p => p.Price);
                    else
                        query = query.OrderBy(p => p.Price);
                    break;
                default:
                    break;
            }

            List<Product> productList = [];

            if (queryParams.Pagination)
            {
                productList = await query
                    .Skip((queryParams.Page - 1) * ConstConfig.PageSize)
                    .Take(ConstConfig.PageSize)
                    .ToListAsync();
            }
            else
            {
                productList = await query.ToListAsync();
            }

            // map từ product sang DTO
            var result = _mapper.Map<List<ProductResDto>>(productList);

            return Ok(Helper.GetPaginationResult(result, count));
        }

        [HttpGet("{id}/related")]
        [SwaggerOperation(Summary = "Lấy tất cả sản phẩm liên quan")]
        public async Task<ActionResult<List<ProductResDto>>> GetAllRelatedProducts(
            int id,
            [SwaggerParameter("Số lượng sản phẩm liên quan")]
            int? top)
        {
            int takeProduct = top ?? ConstConfig.NumberRelatedItem;

            if (id <= 0)
                return BadRequest(Helper.ErrorResponse(ConstConfig.InvalidId));

            var product = await _db.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product is null)
                return NotFound(Helper.ErrorResponse(ConstConfig.NotFound));

            IQueryable<Product> query = _db.Products
                .Include(p => p.DetailOrders)
                .Include(p => p.Likes)
                .Include(p => p.Ratings)
                .Include(p => p.SaleEvents)
                .Include(p => p.ProductImages)
                .Where(p => p.ProductTypeId == product.ProductTypeId)
                .Where(p => p.Id != id);


            var productList = await query
                .Take(takeProduct)
                .ToListAsync();

            // map từ product sang DTO
            var result = _mapper.Map<List<ProductResDto>>(productList);

            return Ok(new { data = result });
        }

        [HttpGet("shop/{shopId}")]
        [SwaggerOperation(Summary = "Lấy tất cả sản phẩm của một shop")]
        public async Task<ActionResult<PaginationDto<List<ProductResDto>>>> GetAllShopShop(int shopId, [FromQuery] ProductQP queryParams)
        {
            IQueryable<Product> query = _db.Products
                .Include(p => p.DetailOrders)
                .Include(p => p.Likes)
                .Include(p => p.Ratings)
                .Include(p => p.SaleEvents)
                .Include(p => p.ProductImages)
                .Where(p => p.ShopId == shopId);

            // Xử lý các tham số filter
            if (!string.IsNullOrEmpty(queryParams.FByPrice))
            {
                decimal minPrice = decimal.TryParse(queryParams.FByPrice.Split('_')[0], out decimal minOutput) ? minOutput : 0m;
                decimal maxPrice = decimal.TryParse(queryParams.FByPrice.Split('_')[1], out decimal maxOutput) ? maxOutput : decimal.MaxValue;

                query = query
                    .Where(p => p.Price >= minPrice)
                    .Where(p => p.Price <= maxPrice);
            }

            if (!string.IsNullOrEmpty(queryParams.FByType))
            {
                string[] filterTypesInput = queryParams.FByType.Split(',');
                List<int> filterTypesId = [];
                foreach (string filterType in filterTypesInput)
                {
                    if (int.TryParse(filterType.Trim(), out int typeOutput))
                        filterTypesId.Add(typeOutput);
                }

                query = query.Where(p => filterTypesId.Contains(p.ProductTypeId));
            }

            if (!string.IsNullOrEmpty(queryParams.Search))
                query = query
                    .Where(p => p.Name.ToLower().Contains(queryParams.Search.ToLower()) ||
                        p.Description.ToLower().Contains(queryParams.Search.ToLower()));

            // đếm số lượng phần tử sau khi filter
            int count = await query.CountAsync();

            // Sắp sếp theo các thuộc tính
            switch (queryParams.SortBy.ToLower())
            {
                case "id":
                    if (queryParams.SortType.Equals("desc"))
                        query = query.OrderByDescending(p => p.Id);
                    else
                        query = query.OrderBy(p => p.Id);
                    break;
                case "rating":
                    if (queryParams.SortType.Equals("desc"))
                        query = query.OrderByDescending(p => p.Ratings.Count > 0
                        ? Math.Round((decimal)p.Ratings.Sum(r => r.Score) / p.Ratings.Count, 1)
                        : 0m);
                    else
                        query = query.OrderBy(p => p.Ratings.Count > 0
                        ? Math.Round((decimal)p.Ratings.Sum(r => r.Score) / p.Ratings.Count, 1)
                        : 0m);
                    break;
                case "like":
                    if (queryParams.SortType.Equals("desc"))
                        query = query.OrderByDescending(p => p.Likes.Count);
                    else
                        query = query.OrderBy(p => p.Likes.Count);
                    break;
                case "sold":
                    if (queryParams.SortType.Equals("desc"))
                        query = query.OrderByDescending(p => p.DetailOrders.Sum(dt => dt.Quantity));
                    else
                        query = query.OrderBy(p => p.DetailOrders.Sum(dt => dt.Quantity));
                    break;
                case "price":
                    if (queryParams.SortType.Equals("desc"))
                        query = query.OrderByDescending(p => p.Price);
                    else
                        query = query.OrderBy(p => p.Price);
                    break;
                default:
                    break;
            }

            var productList = await query
                .Skip((queryParams.Page - 1) * ConstConfig.PageSize)
                .Take(ConstConfig.PageSize)
                .ToListAsync();
            // map từ product sang DTO
            var result = _mapper.Map<List<ProductResDto>>(productList);

            return Ok(Helper.GetPaginationResult(result, count));
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Lấy chi tiết 1 sản phẩm theo ID")]
        public async Task<ActionResult<DetailProductResDto>> GetDetail(int id)
        {
            if (id <= 0)
                return Ok(Helper.ErrorResponse(ConstConfig.InvalidId));

            IQueryable<Product> query = _db.Products
                .Include(p => p.DetailOrders)
                .Include(p => p.Likes)
                .Include(p => p.Ratings)
                .Include(p => p.SaleEvents)
                .Include(p => p.ProductType)
                .Include(p => p.Shop)
                .Include(p => p.ProductImages);

            var product = await query
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product is null)
                return NotFound(Helper.ErrorResponse(ConstConfig.NotFound));

            var result = _mapper.Map<DetailProductResDto>(product);

            return Ok(result);
        }

        // POST api/<ProductsController>
        [Authorize(Roles = ConstConfig.ShopRoleName)]
        [HttpPost]
        [SwaggerOperation(Summary = "Thêm 1 sản phẩm mới (role shop)")]
        public async Task<ActionResult> Post([FromBody] ProductReqDto product)
        {
            int shopId = int.TryParse(HttpContext.User.FindFirst(ConstConfig.UserIdClaimType)?.Value, out int output) ? output : -1;
            var validator = new ProductValidator();
            try
            {
                var validationResult = await validator.ValidateAsync(product);
                if (!validationResult.IsValid)
                    return BadRequest(validationResult.ToDictionary());

                var productType = await _db.ProductTypes.FirstOrDefaultAsync(s => s.Id == product.ProductTypeId);
                if (productType is null)
                    return NotFound(new { message = "Product type is not found!" });

                var newProduct = _mapper.Map<Product>(product);
                newProduct.ShopId = shopId;

                await _db.Products.AddAsync(newProduct);
                await _db.SaveChangesAsync();

                return Created();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Helper.ErrorResponse(ConstConfig.InternalServer));
            }
        }

        // PUT api/<ProductsController>/5
        [Authorize(Policy = ConstConfig.ShopPolicy)]
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Cập nhật 1 sản phẩm theo ID (role shop, admin)")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateProductReqDto updatProduct)
        {
            if (id <= 0) return BadRequest(Helper.ErrorResponse(ConstConfig.InvalidId));
            int shopId = int.TryParse(HttpContext.User.FindFirst(ConstConfig.UserIdClaimType)?.Value, out int output) ? output : -1;
            try
            {
                var query = _db.Products.Where(p => p.Id == id);

                if (HttpContext.User.IsInRole(ConstConfig.ShopRoleName))
                {
                    query = query.Where(p => p.ShopId == shopId);
                }
                var product = await query.FirstOrDefaultAsync();
                if (product is null)
                    return NotFound(Helper.ErrorResponse(ConstConfig.NotFound));

                var validator = new UpdateProductValidator();
                var validationResult = await validator.ValidateAsync(updatProduct);
                if (!validationResult.IsValid)
                    return BadRequest(validationResult.ToDictionary());

                var productType = await _db.ProductTypes.FirstOrDefaultAsync(s => s.Id == product.ProductTypeId);
                if (productType is null)
                    return NotFound(new { message = "Product type is not found!" });

                _mapper.Map(updatProduct, product);
                await _db.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Helper.ErrorResponse(ConstConfig.InternalServer));
            }
        }

        // DELETE api/<ProductsController>/5
        [Authorize(Policy = ConstConfig.ShopPolicy)]
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Xóa 1 sản phẩm theo ID (role shop, admin)")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest(Helper.ErrorResponse(ConstConfig.InvalidId));

            int shopId = int.TryParse(HttpContext.User.FindFirst(ConstConfig.UserIdClaimType)?.Value, out int output) ? output : -1;
            try
            {
                var query = _db.Products.Where(p => p.Id == id);

                if (HttpContext.User.IsInRole(ConstConfig.ShopRoleName))
                {
                    query = query.Where(p => p.ShopId == shopId);
                }
                var product = await query.FirstOrDefaultAsync();
                if (product is null)
                    return NotFound(Helper.ErrorResponse(ConstConfig.NotFound));

                _db.Products.Remove(product);
                await _db.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Helper.ErrorResponse(ConstConfig.InternalServer));
            }
        }

        // POST api/<ProductsController>/2/Images
        [Authorize(Policy = ConstConfig.ShopPolicy)]
        [HttpPost("{id}/Images")]
        [SwaggerOperation(Summary = "Thêm 1 mảng các hình ảnh cho 1 sản phẩm theo ID (role shop, admin)")]
        public async Task<ActionResult> PostImage(int id, [FromBody] List<ProductImageReqDto> images)
        {
            if (id <= 0) return BadRequest(Helper.ErrorResponse(ConstConfig.InvalidId));
            int shopId = int.TryParse(HttpContext.User.FindFirst(ConstConfig.UserIdClaimType)?.Value, out int output) ? output : -1;

            if (images.Count == 0)
                return BadRequest(Helper.ErrorResponse(ConstConfig.InvalidBody));

            var validator = new ProductImageValidator();
            try
            {
                foreach (var item in images)
                {
                    var validationResult = await validator.ValidateAsync(item);
                    if (!validationResult.IsValid)
                        return BadRequest(validationResult.ToDictionary());
                }

                var query = _db.Products.Where(p => p.Id == id);

                if (HttpContext.User.IsInRole(ConstConfig.ShopRoleName))
                {
                    query = query.Where(p => p.ShopId == shopId);
                }
                var product = await query.FirstOrDefaultAsync();
                if (product is null)
                    return NotFound(Helper.ErrorResponse(ConstConfig.NotFound));

                var newListImage = _mapper.Map<List<ProductImage>>(images);

                product.ProductImages.AddRange(newListImage);
                await _db.SaveChangesAsync();

                return Created();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Helper.ErrorResponse(ConstConfig.InternalServer));
            }
        }

        // DELETE api/<ProductsController>/2/Images/3
        [Authorize(Policy = ConstConfig.ShopPolicy)]
        [HttpDelete("{productId}/Images/{imageId}")]
        [SwaggerOperation(Summary = "Xóa 1 hình ảnh theo ID của sản phẩm và hình ảnh (role shop, admin)")]
        public async Task<ActionResult> PostImage(int productId, int imageId)
        {
            if (productId <= 0 || imageId <= 0) return BadRequest(Helper.ErrorResponse(ConstConfig.InvalidId));
            int shopId = int.TryParse(HttpContext.User.FindFirst(ConstConfig.UserIdClaimType)?.Value, out int output) ? output : -1;
            try
            {
                var query = _db.ProductImages
                    .Where(i => i.Id == imageId && i.ProductId == productId);

                if (HttpContext.User.IsInRole(ConstConfig.ShopRoleName))
                {
                    query = query.Where(i => i.Product.ShopId == shopId);
                }
                var image = await query.FirstOrDefaultAsync();

                if (image is null)
                    return NotFound(new { message = "Image of product is not found!" });

                _db.ProductImages.Remove(image);
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
