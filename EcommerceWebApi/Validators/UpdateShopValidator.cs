using EcommerceWebApi.Dtos.Request;
using EcommerceWebApi.Utils;
using FluentValidation;

namespace EcommerceWebApi.Validators
{
    public class UpdateShopValidator : AbstractValidator<UpdateShopReqDto>
    {
        public UpdateShopValidator()
        {
            RuleFor(s => s.Name)
                .MaximumLength(ConstConfig.LongNameLength);

            RuleFor(s => s.Description)
                .MaximumLength(ConstConfig.LongDescriptionLength);
        }
    }
}
