using TeconTest.WebAPI.DTOs;
using TeconTest.WebAPI.Models;

namespace TeconTest.Tests.Data
{
    /// <summary>
    /// Класс генерирует разные данные для тестов
    /// </summary>
    public class UserData
    {
        /// <summary>
        /// Создаёт данные для успешной регистрации.
        /// </summary>
        /// <returns>Данные для регистрации</returns>
        public static RegisterDto NewUserOk() => 
            new RegisterDto()
            {
                Email = "Aboba@gmail.com",
                Password = "Password1",
                LastName = "Нестеров",
                FistName = "Дима",
                MiddleName = "Алексеевич",
                Address = new Address()
                {
                    City = "Иваново",
                    Street = "3-я Нагорная",
                    HouseNumber = "24A"
                }
            };

        /// <summary>
        /// Создаёт данные для неуспешной регистрации.
        /// </summary>
        /// <returns>Данные для регистрации</returns>
        public static RegisterDto NewUserBad() =>
            new RegisterDto()
            {
                Email = "aladin@gmail.com",
                Password = "Password1",
                LastName = "Нестеров",
                FistName = "Дима",
                MiddleName = "Алексеевич",
                Address = new Address()
                {
                    City = "Иваново",
                    Street = "3-я Нагорная",
                    HouseNumber = "24A"
                }
            };

        /// <summary>
        /// Создаёт данные для успешной аутентификации.
        /// </summary>
        /// <returns>Пароль и почта</returns>
        public static LoginDto LoginOk() =>
            new LoginDto()
            {
                Email = "Foo@gmail.com",
                Password = "Qwert1",
            };

        /// <summary>
        /// Создаёт данные для неуспешной аутентификации.
        /// </summary>
        /// <returns></returns>
        public static LoginDto LoginUnauthorized() =>
            new LoginDto()
            {
                Email = "",
                Password = "Qwert1",
            };
    }
}
