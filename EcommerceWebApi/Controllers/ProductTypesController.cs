using AutoMapper;
using EcommerceWebApi.Data;
using EcommerceWebApi.Dtos.Request;
using EcommerceWebApi.Dtos.Response;
using EcommerceWebApi.Models;
using EcommerceWebApi.Utils;
using EcommerceWebApi.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypesController : ControllerBase
    {
        private readonly EcommerceDbContext _db;
        private readonly IMapper _mapper;

        public ProductTypesController(EcommerceDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        // GET: api/<ProductTypes>
        [HttpGet]
        public async Task<ActionResult<ProductTypeResDto>> GetAll()
        {
            List<ProductType> listProductType = await _db.ProductTypes
                .ToListAsync();
            var result = _mapper.Map<List<ProductTypeResDto>>(listProductType);

            return Ok(new { data = result });
        }

        // GET api/<ProductTypes>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductTypeResDto>> GetDetail(int id)
        {
            if (id <= 0) return BadRequest(Helper.ErrorResponse(ConstConfig.InvalidId));
            var productType = await _db.ProductTypes
                .FirstOrDefaultAsync(pt => pt.Id == id);
            if (productType == null) return NotFound(Helper.ErrorResponse(ConstConfig.NotFound));

            var result = _mapper.Map<ProductTypeResDto>(productType);

            return Ok(result);
        }

        // POST api/<ProductTypes>
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] ProductTypeReqDto productType)
        {
            var validator = new ProductTypeValidator();
            try
            {
                var validationResult = await validator.ValidateAsync(productType);
                if (!validationResult.IsValid)
                    return BadRequest(validationResult.ToDictionary());

                var newProductType = _mapper.Map<ProductType>(productType);

                await _db.ProductTypes.AddAsync(newProductType);
                await _db.SaveChangesAsync();

                return Created();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Helper.ErrorResponse(ConstConfig.InternalServer));
            }
        }

        // PUT api/<ProductTypes>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody] ProductTypeReqDto updateProductType)
        {
            if (id <= 0) return BadRequest(Helper.ErrorResponse(ConstConfig.InvalidId));

            try
            {
                var productType = await _db.ProductTypes.FirstOrDefaultAsync(pt => pt.Id == id);
                if (productType is null)
                    return NotFound(Helper.ErrorResponse(ConstConfig.NotFound));

                var validator = new ProductTypeValidator();
                var validationResult = await validator.ValidateAsync(updateProductType);
                if (!validationResult.IsValid)
                    return BadRequest(validationResult.ToDictionary());

                _mapper.Map(updateProductType, productType);
                await _db.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Helper.ErrorResponse(ConstConfig.InternalServer));
            }
        }

        // DELETE api/<ProductType>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            if (id <= 0) return BadRequest(Helper.ErrorResponse(ConstConfig.InvalidId));

            try
            {
                var productType = await _db.ProductTypes.FirstOrDefaultAsync(pt => pt.Id == id);
                if (productType is null)
                    return NotFound(Helper.ErrorResponse(ConstConfig.NotFound));

                _db.ProductTypes.Remove(productType);
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
