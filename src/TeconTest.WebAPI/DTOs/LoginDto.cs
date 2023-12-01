namespace TeconTest.WebAPI.DTOs
{
    /// <summary>
    /// Dto для аутентификации пользователя.
    /// </summary>
    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
