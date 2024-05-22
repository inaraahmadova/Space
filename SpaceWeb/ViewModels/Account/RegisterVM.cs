﻿using System.ComponentModel.DataAnnotations;

namespace SpaceWeb.ViewModels.Account
{
    public class RegisterVM
    {
        [MinLength(5),MaxLength(25)]
        public string Name { get; set; }
        [MinLength(5), MaxLength(25)]
        public string Surname { get; set; }
        [MinLength(5), MaxLength(25)]
        public string Username { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

    }
}
