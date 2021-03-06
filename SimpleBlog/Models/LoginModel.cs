﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SimpleBlog.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "User name is required")]
        [Display(Name= "User name (*)")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage= "Password is required")]
        [Display(Name = "Password (*)")]
        public string Password { get; set; }

    }
}