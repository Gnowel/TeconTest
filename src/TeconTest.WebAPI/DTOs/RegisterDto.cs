using TeconTest.WebAPI.Models;

namespace TeconTest.WebAPI.DTOs
{
    /// <summary>
    /// Dto для регистрации пользователя.
    /// </summary>
    public class RegisterDto
    { 
        public string Email { get; set; }
        public string Password { get; set; }
        public string FistName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public Address Address { get; set; }
    }   
}
