using AutoMapper;
using EcommerceWebApi.Data;
using EcommerceWebApi.Dtos.Request;
using EcommerceWebApi.Dtos.Response;
using EcommerceWebApi.Models;
using EcommerceWebApi.Utils;
using EcommerceWebApi.Utils.QueryParams;
using EcommerceWebApi.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                    if (int.TryParse(filterType, out int typeOutput))
                        filterTypesId.Add(typeOutput);
                }

                query = query.Where(p => filterTypesId.Contains(p.ProductTypeId));
            }

            if (!string.IsNullOrEmpty(queryParams.Search))
                query = query
                    .Where(p => p.Name.Contains(queryParams.Search, StringComparison.CurrentCultureIgnoreCase) ||
                        p.Description.Contains(queryParams.Search, StringComparison.CurrentCultureIgnoreCase));

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

            // map từ product sang DTO
            var productList = await query
                .Skip((queryParams.Page - 1) * ConstConfig.PageSize)
                .Take(ConstConfig.PageSize)
                .ToListAsync();
            var result = _mapper.Map<List<ProductResDto>>(productList);

            return Ok(Helper.GetPaginationResult(result, count));
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
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
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductReqDto product)
        {
            var validator = new ProductValidator();
            try
            {
                var validationResult = await validator.ValidateAsync(product);
                if (!validationResult.IsValid)
                    return BadRequest(validationResult.ToDictionary());

                var shop = await _db.Shops.FirstOrDefaultAsync(s => s.Id == product.ShopId);
                if (shop is null)
                    return NotFound(new { message = "Shop is not found!" });

                var productType = await _db.ProductTypes.FirstOrDefaultAsync(s => s.Id == product.ProductTypeId);
                if (productType is null)
                    return NotFound(new { message = "Product type is not found!" });

                var newProduct = _mapper.Map<Product>(product);

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
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProductReqDto updatProduct)
        {
            if (id <= 0) return BadRequest(Helper.ErrorResponse(ConstConfig.InvalidId));

            try
            {
                var product = await _db.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (product is null)
                    return NotFound(Helper.ErrorResponse(ConstConfig.NotFound));

                var validator = new ProductValidator();
                var validationResult = await validator.ValidateAsync(updatProduct);
                if (!validationResult.IsValid)
                    return BadRequest(validationResult.ToDictionary());

                var shop = await _db.Shops.FirstOrDefaultAsync(s => s.Id == product.ShopId);
                if (shop is null)
                    return NotFound(new { message = "Shop is not found!" });

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
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest(Helper.ErrorResponse(ConstConfig.InvalidId));

            try
            {
                var product = await _db.Products.FirstOrDefaultAsync(p => p.Id == id);
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
        [HttpPost("{id}/Images")]
        public async Task<ActionResult> PostImage(int id, [FromBody] List<ProductImageReqDto> images)
        {
            if (id <= 0) return BadRequest(Helper.ErrorResponse(ConstConfig.InvalidId));

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

                var product = await _db.Products.FirstOrDefaultAsync(p => p.Id == id);
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
        [HttpDelete("{productId}/Images/{imageId}")]
        public async Task<ActionResult> PostImage(int productId, int imageId)
        {
            if (productId <= 0 || imageId <= 0) return BadRequest(Helper.ErrorResponse(ConstConfig.InvalidId));

            try
            {
                var image = await _db.ProductImages.FirstOrDefaultAsync(i => i.Id == imageId && i.ProductId == productId);
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
