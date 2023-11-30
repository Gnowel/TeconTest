using TeconTest.WebAPI.Models;

namespace TeconTest.WebAPI.DTOs
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public Address Address { get; set; }
    }
}
