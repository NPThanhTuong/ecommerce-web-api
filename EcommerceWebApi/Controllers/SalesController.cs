using AutoMapper;
using EcommerceWebApi.Data;
using EcommerceWebApi.Dtos.Response;
using EcommerceWebApi.Models;
using EcommerceWebApi.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EcommerceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController(
        EcommerceDbContext db,
        IMapper mapper) : ControllerBase
    {
        private readonly EcommerceDbContext _db = db;
        private readonly IMapper _mapper = mapper;

        // GET: api/<SalesController>
        [HttpGet]
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

        // GET: api/<SalesController>/current
        [HttpGet("current")]
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

        // GET: api/<SalesController>/upcoming
        [HttpGet("upcoming")]
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

        // GET: api/<SalesController>/products/current
        [HttpGet("current/products")]
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

        // GET: api/<SalesController>/products/upcoming
        [HttpGet("upcoming/products")]
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

        // GET: api/<SalesController>/3
        [HttpGet("{id}")]
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

        //// POST api/<SalesController>
        //[HttpPost]
        //public async Task<ActionResult> Post([FromBody] string value)
        //{


        //    return Ok();
        //}

        //// PUT api/<SalesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<SalesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
