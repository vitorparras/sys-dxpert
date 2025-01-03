﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.User
{
    public class CreateUserDto
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string? Phone { get; set; }
        public string CPF { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
