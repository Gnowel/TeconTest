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
    public class UserControllerTest
    {
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


        [Fact]
        public void UserController_Register_ReturnOk()
        {
            //Arrange
            var registerDto = A.Fake<RegisterDto>();
            registerDto = UserData.NewUserOk();
            var controller = new UserController();

            //Act
            var result = controller.Register(registerDto);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));

        }

        [Fact]
        public void UserController_Register_ReturnBad()
        {
            //Arrange
            var registerDto = A.Fake<RegisterDto>();
            registerDto = UserData.NewUserBad();
            var controller = new UserController();

            //Act
            var result = controller.Register(registerDto);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(BadRequestObjectResult));

        }

        [Fact]
        public void UserController_Login_ReturnOk()
        {
            //Arrange
            var loginDto = A.Fake<LoginDto>();
            loginDto = UserData.LoginOk();
            var controller = new UserController();

            //Act
            var result = controller.Login(loginDto);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));

            var dto = (result as ObjectResult);
            dto.Value.Should().BeOfType(typeof(User));

        }

        [Fact]
        public void UserController_Login_ReturnBad()
        {
            //Arrange
            var loginDto = A.Fake<LoginDto>();
            loginDto = UserData.LoginBad();
            var controller = new UserController();

            //Act
            var result = controller.Login(loginDto);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(UnauthorizedObjectResult));

        }

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
