using EcommerceWebApi.Dtos.Request;
using FluentValidation;

namespace EcommerceWebApi.Validators
{
    public class RefreshVerificationValidator : AbstractValidator<RefreshVerificationReqDto>
    {
        public RefreshVerificationValidator()
        {
            RuleFor(e => e.Email)
                .NotEmpty()
                .EmailAddress();
        }
    }
}
