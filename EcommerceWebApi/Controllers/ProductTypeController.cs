using EcommerceWebApi.Data;
using EcommerceWebApi.Dtos.Response;
using EcommerceWebApi.Utils;
using EcommerceWebApi.Utils.QueryParams;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EcommerceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private readonly EcommerceDbContext _db;

        public ProductTypeController(EcommerceDbContext db)
        {
            _db = db;
        }


        // GET: api/<ProductType>
        [HttpGet]
        public async Task<ActionResult<PaginationDto<ProductTypeDto>>> GetAllProductTypes([FromQuery] ProductTypeQP? productTypeQP)
        {
            var query = _db.ProductTypes.AsQueryable();

            int count = await query.CountAsync();

            List<ProductTypeDto> result = await query
                .Select(pt => new ProductTypeDto
                {
                    Id = pt.Id,
                    Name = pt.Name,
                    Description = pt.Description,
                })
                .Skip(((int)productTypeQP.page - 1) * ConstConfig.PageSize)
                .Take(ConstConfig.PageSize)
                .ToListAsync();

            return Ok(Helper.GetPaginationResult(result, count));
        }

        // GET api/<ProductType>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductType>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductType>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductType>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
