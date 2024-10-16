using AutoMapper;
using EcommerceWebApi.Data;
using EcommerceWebApi.Dtos.Request;
using EcommerceWebApi.Models;
using EcommerceWebApi.Services.Email;
using EcommerceWebApi.Utils;
using EcommerceWebApi.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EcommerceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(EcommerceDbContext db, IMapper mapper, IConfiguration configuration, IEmailService emailService) : ControllerBase
    {
        private readonly EcommerceDbContext _db = db;
        private readonly IMapper _mapper = mapper;
        private readonly IConfiguration _configuration = configuration;
        private readonly IEmailService _emailService = emailService;

        // POST: api/<AuthController>/login
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login([FromBody] LoginReqDto loginReq)
        {
            var validator = new LoginValidator();
            try
            {
                var validationResult = await validator.ValidateAsync(loginReq);
                if (!validationResult.IsValid)
                    return BadRequest(validationResult.ToDictionary());

                var account = await _db.Accounts
                    .Include(a => a.Role)
                    .Include(a => a.Shop)
                    .Include(a => a.Customer)
                    .FirstOrDefaultAsync(a => a.Email == loginReq.Email);
                if (account is null)
                    return Unauthorized(new { message = "Email or password is incorrect!" });

                if (!BCrypt.Net.BCrypt.Verify(loginReq.Password, account.Password))
                    return Unauthorized(new { message = "Email or password is incorrect!" });

                if (account.VerifiedAt is null)
                    return Unauthorized(new { message = "Account is not verified!" });


                Claim[] claims = [
                    new Claim(ConstConfig.AccountIdClaimType, account.Id.ToString()),
                    new Claim(ConstConfig.AvatarClaimType, account.Avatar),
                    new Claim(ClaimTypes.Email, account.Email),
                    new Claim(ClaimTypes.Role, account.Role.Name.ToLower())
                ];

                if (account.Customer is not null)
                {
                    Claim userId = new(ConstConfig.UserIdClaimType, account.Customer.Id.ToString());
                    Claim username = new(ClaimTypes.Name, account.Customer.Name);

                    claims = [.. claims, userId, username];

                }
                else if (account.Shop is not null)
                {
                    Claim userId = new(ConstConfig.UserIdClaimType, account.Shop.Id.ToString());
                    Claim username = new(ClaimTypes.Name, account.Shop.Name);
                    claims = [.. claims, userId, username];
                }

                var token = new JwtSecurityToken
                (
                    issuer: _configuration.GetSection("Jwt")["Issuer"],
                    audience: _configuration.GetSection("Jwt")["Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(ConstConfig.ExperyTimeJwtToken),
                    notBefore: DateTime.UtcNow,
                    signingCredentials: new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("Jwt")["Key"]!)),
                        SecurityAlgorithms.HmacSha256)
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(new { token = tokenString });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Helper.ErrorResponse(ConstConfig.InternalServer));
            }
        }

        // POST: api/<AuthController>/register
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register([FromBody] RegisterReqDto registerReq)
        {
            try
            {
                var validation = new RegisterValidator();
                var validationResult = await validation.ValidateAsync(registerReq);
                if (!validationResult.IsValid)
                    return BadRequest(validationResult.ToDictionary());

                var existingAccount = await _db.Accounts.FirstOrDefaultAsync(a => a.Email == registerReq.Email);
                if (existingAccount is not null)
                    return BadRequest(new { message = "Email account is registerd!" });

                var newAccount = _mapper.Map<Account>(registerReq);

                // verify token 5 digit
                var random = new Random();
                newAccount.VerifyToken = random
                    .Next((int)Math.Pow(10, ConstConfig.VerifyEmailTokenLength - 1),
                        (int)Math.Pow(10, ConstConfig.VerifyEmailTokenLength))
                    .ToString();

                await _db.AddAsync(newAccount);
                await _db.SaveChangesAsync();

                string emailBody = $"<h1>Đây là email xác thực đăng ký tài khoản tại trang web thương mại điện tử</h1><p>Mã xác thực đăng ký tài khoản của bạn là:</p><h2>{newAccount.VerifyToken}</h2><p>Chúng tôi xin chân thành cảm ơn</p>";
                var emailRequest = new EmailReqDto()
                {
                    To = newAccount.Email,
                    Body = emailBody,
                    Subject = "RSVP: Xác thực đăng ký tài khoản tại Website thương mại điện tử"
                };

                _emailService.SendEmail(emailRequest);

                return Created();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Helper.ErrorResponse(ConstConfig.InternalServer));
            }
        }

        // POST: api/<AuthController>/register
        [HttpPost]
        [Route("register/shop")]
        public async Task<ActionResult> RegisterShop([FromBody] RegisterShopReqDto registerShopReq)
        {
            try
            {
                var validation = new RegisterShopValidator();
                var validationResult = await validation.ValidateAsync(registerShopReq);
                if (!validationResult.IsValid)
                    return BadRequest(validationResult.ToDictionary());

                var existingAccount = await _db.Accounts.FirstOrDefaultAsync(a => a.Email == registerShopReq.Email);
                if (existingAccount is not null)
                    return BadRequest(new { message = "Email account is registerd!" });

                var newAccount = _mapper.Map<Account>(registerShopReq);

                // verify token 5 digit
                var random = new Random();
                newAccount.VerifyToken = random
                    .Next((int)Math.Pow(10, ConstConfig.VerifyEmailTokenLength - 1),
                        (int)Math.Pow(10, ConstConfig.VerifyEmailTokenLength))
                    .ToString();

                await _db.AddAsync(newAccount);
                await _db.SaveChangesAsync();

                string emailBody = $"<h1>Đây là email xác thực đăng ký tài khoản bán hàng tại trang web thương mại điện tử</h1><p>Mã xác thực đăng ký tài khoản của bạn là:</p><h2>{newAccount.VerifyToken}</h2><p>Chúng tôi xin chân thành cảm ơn</p>";
                var emailRequest = new EmailReqDto()
                {
                    To = newAccount.Email,
                    Body = emailBody,
                    Subject = "RSVP: Xác thực đăng ký tài khoản bán hàng tại Website thương mại điện tử"
                };

                _emailService.SendEmail(emailRequest);

                return Created();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Helper.ErrorResponse(ConstConfig.InternalServer));
            }
        }

        // POST: api/<AuthController>/verify-email
        [HttpPost]
        [Route("verify-email")]
        public async Task<ActionResult> VerifyEmail([FromBody] VerifyEmailReqDto verifyEmailReq)
        {
            try
            {
                var validation = new VerifyEmailValidator();
                var validationResult = await validation.ValidateAsync(verifyEmailReq);
                if (!validationResult.IsValid)
                    return BadRequest(validationResult.ToDictionary());

                var existingAccount = await db.Accounts.FirstOrDefaultAsync(a => a.Email == verifyEmailReq.Email);
                if (existingAccount is null)
                    return NotFound(Helper.ErrorResponse(ConstConfig.NotFound));

                if (existingAccount.VerifiedAt is not null)
                    return BadRequest(new { message = "Account has already been verified!" });

                if (verifyEmailReq.Token.Equals(existingAccount.VerifyToken))
                {
                    existingAccount.VerifiedAt = DateTime.Now;
                    await _db.SaveChangesAsync();
                    return Ok(new { message = "Verify email successfully!" });
                }
                else
                {
                    return BadRequest(new { message = "The verified token is invalid!" });
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Helper.ErrorResponse(ConstConfig.InternalServer));
            }
        }

        // POST: api/<AuthController>/refresh-verification
        [HttpPost]
        [Route("refresh-verification")]
        public async Task<ActionResult> RefreshVerifyEmail([FromBody] RefreshVerificationReqDto refreshVerificationReq)
        {
            try
            {
                var validation = new RefreshVerificationValidator();
                var validationResult = await validation.ValidateAsync(refreshVerificationReq);
                if (!validationResult.IsValid)
                    return BadRequest(validationResult.ToDictionary());

                var existingAccount = await db.Accounts.FirstOrDefaultAsync(a => a.Email == refreshVerificationReq.Email);
                if (existingAccount is null)
                    return NotFound(Helper.ErrorResponse(ConstConfig.NotFound));

                if (existingAccount.VerifiedAt is not null)
                    return BadRequest(new { message = "Account has already been verified!" });

                // verify token 5 digit
                var random = new Random();
                existingAccount.VerifyToken = random
                    .Next((int)Math.Pow(10, ConstConfig.VerifyEmailTokenLength - 1),
                        (int)Math.Pow(10, ConstConfig.VerifyEmailTokenLength))
                    .ToString();

                await _db.SaveChangesAsync();

                string emailBody = $"<h1>Đây là email xác thực đăng ký tài khoản tại trang web thương mại điện tử</h1><p>Mã xác thực đăng ký tài khoản của bạn là:</p><h2>{existingAccount.VerifyToken}</h2><p>Chúng tôi xin chân thành cảm ơn</p>";
                var emailRequest = new EmailReqDto()
                {
                    To = existingAccount.Email,
                    Body = emailBody,
                    Subject = "RSVP: Xác thực đăng ký tài khoản tại Website thương mại điện tử"
                };

                _emailService.SendEmail(emailRequest);

                return Ok(new { message = "Refresh verification token successfully!" });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Helper.ErrorResponse(ConstConfig.InternalServer));
            }
        }
    }
}
