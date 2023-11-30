using TeconTest.WebAPI.DTOs;
using TeconTest.WebAPI.Models;

namespace TeconTest.Tests.Data
{
    public class UserData
    {
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

        public static LoginDto LoginOk() =>
            new LoginDto()
            {
                Email = "Foo@gmail.com",
                Password = "Qwert1",
            };

        public static LoginDto LoginBad() =>
            new LoginDto()
            {
                Email = "",
                Password = "Qwert1",
            };

        public static User CheckUser() =>
            new User()
            {
                Id = Guid.Parse("F9168C2E-CEB3-4faa-B6BF-329BF39FA1E4"),
                Email = "Foo@gmail.com",
                Password = "Qwert1",
                LastName = "Шухтин",
                FirstName = "Михаил",
                MiddleName = "Андреевич",
                Address = new Address()
                {
                    City = "Иваново",
                    Street = "ул. Кузнецова",
                    HouseNumber = "124"
                }
            };
    }
}
