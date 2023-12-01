using FluentValidation;

namespace TeconTest.WebAPI.Extensions
{
    /// <summary>
    /// Метод расширения для класса RuleBuilder.
    /// </summary>
    public static class RuleBuilderExtensions
    {
        /// <summary>
        /// Устанавливает валидацию для пароля.
        /// </summary>
        /// <typeparam name="T">Тип проверяемого объекта</typeparam>
        /// <param name="ruleBuilder">Определяет валидатор</param>
        /// <param name="minLenght">Минимальный размер пароля</param>
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
