using FluentValidation;
using TeconTest.WebAPI.DTOs;
using TeconTest.WebAPI.Extensions;

namespace TeconTest.WebAPI.Validations
{
    /// <summary>
    /// Валидатор для смены пароля.
    /// </summary>
    public class UpdatePasswordValidator : AbstractValidator<UpdatePasswordDto>
    {
        public UpdatePasswordValidator()
        {
            RuleFor(x => x.Password).Password();
        }
    }
}
