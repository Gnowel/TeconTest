using FluentValidation;

namespace TeconTest.WebAPI.Extensions
{
    public static class RuleBuilderExtensions
    {
        public static void Password<T>(this IRuleBuilder<T, string> ruleBuilder, int minLenght = 6)
        {
            ruleBuilder
                .MinimumLength(minLenght).WithMessage($"Минимальный размер пароля {minLenght} букв.")
                .Matches("[a-z]").WithMessage("Нужна хотя бы 1 строчная буква.")
                .Matches("[A-Z]").WithMessage("Нужна хотя бы 1 прописная буква.")
                .Matches("[0-9]").WithMessage("Нужна хотя бы 1 цифра.");
        }

    }
}
