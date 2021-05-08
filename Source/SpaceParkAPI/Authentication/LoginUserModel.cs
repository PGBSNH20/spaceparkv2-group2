﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceParkAPI.Authentication
{
    public class LoginUserModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        //[Required(ErrorMessage = "Password is required")]
        //public string Password { get; set; }
    }
}