﻿using System.ComponentModel.DataAnnotations;

namespace TodoAPI.Model
{
    public class LoginModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
