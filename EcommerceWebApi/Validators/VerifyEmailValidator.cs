using EcommerceWebApi.Dtos.Request;
using EcommerceWebApi.Utils;
using FluentValidation;

namespace EcommerceWebApi.Validators
{
    public class VerifyEmailValidator : AbstractValidator<VerifyEmailReqDto>
    {
        public VerifyEmailValidator()
        {
            RuleFor(ve => ve.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(ve => ve.Token)
                .NotEmpty()
                .Length(ConstConfig.VerifyEmailTokenLength);
        }
    }
}
