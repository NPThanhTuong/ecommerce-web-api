using EcommerceWebApi.Dtos.Request;
using EcommerceWebApi.Utils;
using FluentValidation;

namespace EcommerceWebApi.Validators
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductReqDto>
    {

        public UpdateProductValidator()
        {
            RuleFor(p => p.Name)
                .MaximumLength(ConstConfig.MediumNameLength);

            RuleFor(p => p.Description)
                .MaximumLength(ConstConfig.DescriptionLength);

            RuleFor(p => p.Price)
                .GreaterThanOrEqualTo(0m);

            RuleFor(p => p.Quantity)
                .GreaterThanOrEqualTo(0);

            RuleFor(p => p.ProductTypeId)
                .GreaterThanOrEqualTo(0);
        }
    }
}
