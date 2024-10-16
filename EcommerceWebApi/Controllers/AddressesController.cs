using AutoMapper;
using EcommerceWebApi.Data;
using EcommerceWebApi.Dtos.Request;
using EcommerceWebApi.Dtos.Response;
using EcommerceWebApi.Models;
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
    public class AddressesController(EcommerceDbContext db, IMapper mapper) : ControllerBase
    {
        private readonly EcommerceDbContext _db = db;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        [Authorize(Roles = ConstConfig.UserRoleName)]
        [SwaggerOperation(Summary = "Lấy các địa chỉ của người dùng (role user)")]
        public async Task<ActionResult> GetAllCustomerAddresses()
        {
            int customerId = int.TryParse(HttpContext.User.FindFirst(ConstConfig.UserIdClaimType)?.Value, out int output) ? output : -1;
            var addresses = await _db.Addresses
                .Where(a => a.CustomerId == customerId)
                .ToListAsync();

            var result = _mapper.Map<List<AddressResDto>>(addresses);

            return Ok(new { data = result });
        }

        [HttpPost]
        [Authorize(Roles = ConstConfig.UserRoleName)]
        [SwaggerOperation(Summary = "Thêm địa chỉ mới (role user)")]
        public async Task<ActionResult> CreateNewAddress([FromBody] AddressReqDto addressReq)
        {
            int customerId = int.TryParse(HttpContext.User.FindFirst(ConstConfig.UserIdClaimType)?.Value, out int output) ? output : -1;

            try
            {
                var validator = new AddressValidator();
                var validationResult = await validator.ValidateAsync(addressReq);
                if (!validationResult.IsValid)
                    return BadRequest(validationResult.ToDictionary());

                var addressString = $"{addressReq.HouseNumber}, {addressReq.Street}, {addressReq.Ward}, {addressReq.District}, {addressReq.City}";

                var newAddress = new Address()
                {
                    AddressDetail = addressString,
                    CustomerId = customerId
                };

                await _db.Addresses.AddAsync(newAddress);
                await _db.SaveChangesAsync();

                return Created();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    Helper.ErrorResponse(ConstConfig.InternalServer));
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = ConstConfig.UserRoleName)]
        [SwaggerOperation(Summary = "Chỉnh sửa địa chỉ (role user)")]
        public async Task<ActionResult> UpdateAddress(int id, [FromBody] AddressReqDto addressReq)
        {
            if (id <= 0)
                return BadRequest(Helper.ErrorResponse(ConstConfig.InvalidId));

            try
            {

                var validator = new AddressValidator();
                var validationResult = await validator.ValidateAsync(addressReq);
                if (!validationResult.IsValid)
                    return BadRequest(validationResult.ToDictionary());

                var addressString = $"{addressReq.HouseNumber}, {addressReq.Street}, {addressReq.Ward}, {addressReq.District}, {addressReq.City}";

                var address = await _db.Addresses.FirstOrDefaultAsync(a => a.Id == id);
                if (address is null)
                    return NotFound(Helper.ErrorResponse(ConstConfig.NotFound));

                address.AddressDetail = addressString;

                await _db.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    Helper.ErrorResponse(ConstConfig.InternalServer));
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = ConstConfig.UserRoleName)]
        [SwaggerOperation(Summary = "Xóa địa chỉ (role user)")]
        public async Task<ActionResult> DeleteAddress(int id)
        {
            if (id <= 0)
                return BadRequest(Helper.ErrorResponse(ConstConfig.InvalidId));

            try
            {
                var address = await _db.Addresses.FirstOrDefaultAsync(a => a.Id == id);
                if (address is null)
                    return NotFound(Helper.ErrorResponse(ConstConfig.NotFound));

                _db.Addresses.Remove(address);
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
