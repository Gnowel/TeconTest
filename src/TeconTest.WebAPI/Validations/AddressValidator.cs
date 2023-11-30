using FluentValidation;
using TeconTest.WebAPI.Models;

namespace TeconTest.WebAPI.Validations
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(x => x.City).NotEmpty().WithMessage("Введите город.");
            RuleFor(x => x.Street).NotEmpty().WithMessage("Введите улицу.");
            RuleFor(x => x.HouseNumber).NotEmpty().WithMessage("Введите номер дома.");

        }
    }
}
