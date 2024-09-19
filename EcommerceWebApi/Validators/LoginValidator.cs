using EcommerceWebApi.Dtos.Request;
using EcommerceWebApi.Utils;
using FluentValidation;

namespace EcommerceWebApi.Validators
{
    public class LoginValidator : AbstractValidator<LoginReqDto>
    {
        public LoginValidator()
        {
            RuleFor(l => l.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(l => l.Password)
                .NotEmpty()
                .MinimumLength(ConstConfig.MinPasswordLength)
                .MaximumLength(ConstConfig.MaxPasswordLength);
        }
    }
}
