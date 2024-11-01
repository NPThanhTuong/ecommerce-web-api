using AutoMapper;
using EcommerceWebApi.Data;
using EcommerceWebApi.Dtos.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EcommerceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerTypesController(EcommerceDbContext db, IMapper mapper) : ControllerBase
    {
        private readonly EcommerceDbContext _db = db;
        private readonly IMapper _mapper = mapper;
        // GET: api/<CustomerTypesController>
        [HttpGet]
        public async Task<ActionResult<List<CustomerTypeResDto>>> GetCustomerTypes()
        {
            var customerTypes = await _db.CustomerTypes.ToListAsync();

            var result = _mapper.Map<List<CustomerTypeResDto>>(customerTypes);

            return Ok(result);
        }

        //// GET api/<CustomerTypesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<CustomerTypesController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<CustomerTypesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<CustomerTypesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
