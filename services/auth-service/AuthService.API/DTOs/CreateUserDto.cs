﻿namespace AuthService.API.DTOs
{
    public class CreateUserDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
    }
}
