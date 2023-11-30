﻿namespace TeconTest.WebAPI.Models
{
    public class User
    {
        public Guid Id { get; set; } 
        public string Email { get; set; }    
        public string Password { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName {  get; set; }
        public Address Address {  get; set; }

    }
}
