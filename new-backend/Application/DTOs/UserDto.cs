﻿namespace Application.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string CPF { get; set; }

        public string? Phone { get; set; }

        public string Name { get; set; }

    }
}
