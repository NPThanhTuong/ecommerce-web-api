using EcommerceWebApi.Dtos.Request;
using EcommerceWebApi.Utils;
using FluentValidation;

namespace EcommerceWebApi.Validators
{
    public class ProductTypeValidator : AbstractValidator<ProductTypeReqDto>
    {
        public ProductTypeValidator()
        {
            RuleFor(pt => pt.Name)
                .NotEmpty()
                .MaximumLength(ConstConfig.MediumNameLength);

            RuleFor(pt => pt.Description)
                .NotEmpty()
                .MaximumLength(ConstConfig.DescriptionLength);
        }
    }
}
