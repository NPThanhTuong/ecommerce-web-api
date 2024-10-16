using EcommerceWebApi.Dtos.Request;
using FluentValidation;

namespace EcommerceWebApi.Validators
{
    public class AddressValidator : AbstractValidator<AddressReqDto>
    {
        public AddressValidator()
        {
            RuleFor(a => a.HouseNumber)
                .NotEmpty();

            RuleFor(a => a.Street)
                .NotEmpty();

            RuleFor(a => a.Ward)
                .NotEmpty();

            RuleFor(a => a.District)
                .NotEmpty();

            RuleFor(a => a.City)
                .NotEmpty();
        }
    }
}
