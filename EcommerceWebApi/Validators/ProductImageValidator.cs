using EcommerceWebApi.Dtos.Request;
using EcommerceWebApi.Utils;
using FluentValidation;

namespace EcommerceWebApi.Validators
{
    public class ProductImageValidator : AbstractValidator<ProductImageReqDto>
    {
        public ProductImageValidator()
        {
            RuleFor(pi => pi.Path)
                .NotEmpty()
                .MaximumLength(ConstConfig.ImagePathLength);
        }
    }
}
