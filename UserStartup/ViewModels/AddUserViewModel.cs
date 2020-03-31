using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UserStartup.Models;

namespace UserStartup.ViewModels
{
    public class AddUserViewModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        [Display(Name = "Password"), Required]
        public string Password { get; set; }

        public string VerifyPassword { get; set; }
        
        public static List<User> UserList  { get; set; }

        //public void AddUser(User newUser)
        //{
        //    UserList.Add(newUser);
        //}
    }
}
