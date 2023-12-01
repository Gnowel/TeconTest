using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TeconTest.WebAPI.DTOs;
using TeconTest.WebAPI.Models;

namespace TeconTest.WebAPI.Controllers
{
    /// <summary>
    /// Контроллер для пользователей.
    /// </summary>
    [ApiController]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Список пользователей.
        /// </summary>
        private static List<User> _users = new List<User>
        {
             new User()
             {
                 Id = Guid.Parse("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"),
                 Email = "aladin@gmail.com",
                 Password = "Qwert1",
                 LastName = "Прокофьев",
                 FirstName = "Андрей",
                 MiddleName = "Александрович",
                 Address = new Address()
                 {
                     City = "Иваново",
                     Street = "3-я Нагорная",
                     HouseNumber = "24A"
                 }
             },
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
             }
        };

        /// <summary>
        /// Получение списка пользователей (для проверки).
        /// </summary>
        /// <returns>Список пользователей</returns>
        [HttpGet]
        [Route("api/users")]
        public IActionResult GetUsers()
        {
            return Ok(_users.ToList());
        }

        /// <summary>
        /// Регистрация пользователя. 
        /// </summary>
        /// <param name="request"></param>
        /// <returns>При успешной регистрации возвращает Ok,
        /// иначе ошибку</returns>
        [HttpPost]
        [Route("api/user/register")]
        public IActionResult Register([FromBody] RegisterDto request)
        {
            if (_users.Any(x => x.Email == request.Email))
            {
                return BadRequest("Пользователь с такой почтой уже зарегистрирован.");
            }

            _users.Add(new User()
            {
                Id = Guid.NewGuid(),    
                Email = request.Email,
                Password = request.Password,
                LastName = request.LastName,
                FirstName = request.FistName,
                MiddleName = request.MiddleName,
                Address = request.Address
            });

            return Ok($"Пользователь {request.Email} успешно добавлен.");
        }

        /// <summary>
        /// Аутентификация пользователя.
        /// </summary>
        /// <param name="request">Почта и пароль</param>
        /// <returns>При успешной аутентификации возвращает пользователя, 
        /// иначе ошибку</returns>
        [HttpPost]
        [Route("api/user/login")]
        public IActionResult Login([FromBody] LoginDto request)
        {
            var user = _users.SingleOrDefault(x => x.Email == request.Email && x.Password == request.Password);

            if (user != null)
            {
                return Ok(user);
            }

            return Unauthorized("Неправильная почта и (или) пароль.");
        }

        /// <summary>
        /// Смена пароля пользователя. 
        /// </summary>
        /// <param name="id">Id пользователя</param>
        /// <param name="request">Пароль</param>
        /// <returns>При успешном смене пароли возвращает Ok,
        /// иначе ошибку</returns>
        [HttpPut]
        [Route("api/user/update-password/{id:guid}")]
        public IActionResult UpdatePassword(Guid id, [FromBody] UpdatePasswordDto request)
        {
            var userIndex = _users.FindIndex(x => x.Id == id);

            if (userIndex == -1)
            {
                return NotFound("Такого пользователя в системе нет.");
            }

            _users[userIndex].Password = request.Password;

            return Ok("Пароль успешно изменен.");
        }

        /// <summary>
        /// Смена данных пользователя.
        /// </summary>
        /// <param name="id">Id пользователя</param>
        /// <param name="request">Данные,которые нужно менять</param>
        /// <returns>При успешной смене данных возвращает пользователя, 
        /// иначе ошибку</returns>
        [HttpPatch]
        [Route("api/user/update-user/{id:guid}")]
        public IActionResult UpdateUser(Guid id, [FromBody] JsonPatchDocument<UserDto> request)
        {
            if(request == null || id  == Guid.Empty)
            {
                BadRequest("Пустая сущность или id.");
            }

            var userIndex = _users.FindIndex(x => x.Id == id);

            if(userIndex == -1)
            {
                return NotFound("Такого пользователя в системе нет.");
            }

            var userDto = new UserDto()
            {
                FirstName = _users[userIndex].FirstName,
                LastName = _users[userIndex].LastName,
                MiddleName = _users[userIndex].MiddleName,
                Address = _users[userIndex].Address,
            };

            request.ApplyTo(userDto);

            _users[userIndex].FirstName = userDto.FirstName;
            _users[userIndex].LastName = userDto.LastName;
            _users[userIndex].MiddleName = userDto.MiddleName;
            _users[userIndex].Address = userDto.Address;

            return Ok(_users[userIndex]);
        }
    }
}
