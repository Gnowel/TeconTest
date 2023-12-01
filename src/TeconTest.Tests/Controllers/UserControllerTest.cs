using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TeconTest.Tests.Data;
using TeconTest.WebAPI.Controllers;
using TeconTest.WebAPI.DTOs;
using TeconTest.WebAPI.Models;

namespace TeconTest.Tests.Controllers
{
    /// <summary>
    /// Класс для тестирования UserController
    /// </summary>
    public class UserControllerTest
    {
        /// <summary>
        /// Тест метода получения пользователей.
        /// Метод должен возвращать Ok().
        /// </summary>
        [Fact]
        public void UserController_GetUser_ReturnOk()
        {
            //Arrange
            var controller = new UserController();

            //Act
            var result = controller.GetUsers();
    
            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        /// <summary>
        /// Тест регистрации пользователя.
        /// Метод должен возвращать Ok().
        /// </summary>
        [Fact]
        public void UserController_Register_ReturnOk()
        {
            //Arrange
            var registerDto = UserData.NewUserOk();
            var controller = new UserController();

            //Act
            var result = controller.Register(registerDto);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        /// <summary>
        /// Тест регистрации пользователя.
        /// Метод должен возвращать BadRequest().
        /// </summary>
        [Fact]
        public void UserController_Register_ReturnBad()
        {
            //Arrange
            var registerDto = UserData.NewUserBad();
            var controller = new UserController();

            //Act
            var result = controller.Register(registerDto);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(BadRequestObjectResult));
        }

        /// <summary>
        /// Тест аутентификации пользователя.
        /// Метод должен возвращать Ok().
        /// </summary>
        [Fact]
        public void UserController_Login_ReturnOk()
        {
            //Arrange
            var loginDto = UserData.LoginOk();
            var controller = new UserController();

            //Act
            var result = controller.Login(loginDto);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));

            var dto = (result as ObjectResult);
            dto.Value.Should().BeOfType(typeof(User));
        }

        /// <summary>
        /// Тест аутентификации пользователя.
        /// Метод должен возвращать Unauthorized().
        /// </summary>
        [Fact]
        public void UserController_Login_ReturnUnauthorized()
        {
            //Arrange
            var loginDto = UserData.LoginUnauthorized();
            var controller = new UserController();

            //Act
            var result = controller.Login(loginDto);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(UnauthorizedObjectResult));
        }

        /// <summary>
        /// Тест смены пароля пользователя.
        /// Метод должен возвращать Ok().
        /// </summary>
        [Fact]
        public void UserController_UpdatePassword_ReturnOk()
        {
            //Arrange
            var passwordDto = A.Fake<UpdatePasswordDto>();

            passwordDto.Password = "Qwert1DSDS";
            Guid guid = Guid.Parse("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4");
            
            var controller = new UserController();

            //Act
            var result = controller.UpdatePassword(guid, passwordDto);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        /// <summary>
        /// Тест смены пароля пользователя.
        /// Метод должен возвращать NotFound().
        /// </summary>
        [Fact]
        public void UserController_UpdatePassword_ReturnNotFound()
        {
            //Arrange
            var passwordDto = A.Fake<UpdatePasswordDto>();

            passwordDto.Password = "Qwert1DSDS";
            Guid guid = Guid.NewGuid();

            var controller = new UserController();

            //Act
            var result = controller.UpdatePassword(guid, passwordDto);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(NotFoundObjectResult));
        }

        /// <summary>
        /// Тест смены данных пользователя.
        /// Метод должен возвращать Ok().
        /// </summary>
        [Fact]
        public void UserController_UpdateUser_ReturnOk()
        {
            //Arrange
            var user = A.Fake<JsonPatchDocument<UserDto>>();

            user.Replace(u => u.FirstName, "ббббббббб")
                .Replace(u => u.MiddleName, "aaaaaaaa");

            Guid guid = Guid.Parse("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4");

            var controller = new UserController();

            //Act
            var result = controller.UpdateUser(guid, user);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));

            var dto = (result as ObjectResult);
            dto.Value.Should().BeOfType(typeof(User));
        }

        /// <summary>
        /// Тест смены данных пользователя.
        /// Метод должен возвращать NotFound().
        /// </summary>
        [Fact]
        public void UserController_UpdateUser_ReturnNotFound()
        {
            //Arrange
            var user = A.Fake<JsonPatchDocument<UserDto>>();

            user.Replace(u => u.FirstName, "ббббббббб")
                .Replace(u => u.MiddleName, "aaaaaaaa");

            var controller = new UserController();

            //Act
            var result = controller.UpdateUser(Guid.Empty, user);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(NotFoundObjectResult));
        }
    }
}
