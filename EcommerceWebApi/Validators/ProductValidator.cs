using EcommerceWebApi.Dtos.Request;
using EcommerceWebApi.Utils;
using FluentValidation;

namespace EcommerceWebApi.Validators
{
    public class ProductValidator : AbstractValidator<ProductReqDto>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .MaximumLength(ConstConfig.MediumNameLength);

            RuleFor(p => p.Description)
                .NotEmpty()
                .MaximumLength(ConstConfig.DescriptionLength);

            RuleFor(p => p.Price)
                .GreaterThanOrEqualTo(0m);

            RuleFor(p => p.Quantity)
                .GreaterThanOrEqualTo(0);

            RuleFor(p => p.ProductTypeId)
                .GreaterThanOrEqualTo(0);

            RuleFor(p => p.ShopId)
                .GreaterThanOrEqualTo(0);
        }
    }
}
