﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserStartup.ViewModels;

namespace UserStartup.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string VerifyPassword { get; set; }

        public User(){
            
            }


    }
}
