using AutoMapper;
using EcommerceWebApi.Data;
using EcommerceWebApi.Dtos.Request;
using EcommerceWebApi.Dtos.Response;
using EcommerceWebApi.Utils;
using EcommerceWebApi.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace EcommerceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController(EcommerceDbContext db, IMapper mapper) : ControllerBase
    {
        private readonly EcommerceDbContext _db = db;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        [Authorize(Policy = ConstConfig.UserPolicy)]
        [SwaggerOperation(Summary =
            "Lấy thông tin tài khoản (role user, shop, admin)")]
        public async Task<ActionResult<AccountResDto>> GetUserInfo()
        {
            int acccountId = int.TryParse(HttpContext.User.FindFirst(ConstConfig.AccountIdClaimType)?.Value, out int output) ? output : -1;

            var acacount = await _db.Accounts
                .Include(a => a.Customer)
                    .ThenInclude(c => c.CustomerType)
                .Include(a => a.Shop)
                .FirstOrDefaultAsync(a => a.Id == acccountId);
            if (acacount is null)
                return NotFound(Helper.ErrorResponse(ConstConfig.NotFound));

            var result = _mapper.Map<AccountResDto>(acacount);

            return Ok(result);
        }

        [HttpPut]
        [Authorize(Policy = ConstConfig.UserPolicy)]
        [SwaggerOperation(Summary =
            "Chỉnh sửa thông tin tài khoản (role user, shop, admin)")]
        public async Task<ActionResult> UpdateAccountProfile([FromBody] UpdateAccountReqDto updateAccountReq)
        {
            int acccountId = int.TryParse(HttpContext.User.FindFirst(ConstConfig.AccountIdClaimType)?.Value, out int output) ? output : -1;

            try
            {
                var validator = new UpdateAccountValidator();
                var validationResult = await validator.ValidateAsync(updateAccountReq);
                if (!validationResult.IsValid)
                    return BadRequest(validationResult.ToDictionary());

                var acacount = await _db.Accounts.FirstOrDefaultAsync(a => a.Id == acccountId);
                if (acacount is null)
                    return NotFound(Helper.ErrorResponse(ConstConfig.NotFound));

                _mapper.Map(updateAccountReq, acacount);

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
