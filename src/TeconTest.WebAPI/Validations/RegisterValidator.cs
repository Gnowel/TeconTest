using FluentValidation;
using TeconTest.WebAPI.DTOs;
using TeconTest.WebAPI.Extensions;

namespace TeconTest.WebAPI.Validations
{
    public class RegisterValidator : AbstractValidator<RegisterDto>
    {
        public RegisterValidator() 
        {
            RuleFor(x => x.Email).EmailAddress().WithMessage("Неправильный формат почты.");

            RuleFor(x => x.Password).Password();

            RuleFor(x => x.FistName).NotEmpty().WithMessage("Введите имя.");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Введите фамилию.");

            RuleFor(x => x.MiddleName).NotEmpty().WithMessage("Введите отчество.");

            RuleFor(x => x.Address).SetValidator(new AddressValidator());
        }
    }
}
