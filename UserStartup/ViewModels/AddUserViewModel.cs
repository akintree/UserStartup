using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using UserStartup.Models;

namespace UserStartup.ViewModels
{
    public class AddUserViewModel
    {
        [Required]
        public string Username { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        //public MinLengthAttribute(int 5);
        [Required, DataType(DataType.Password), MinLength(6)]
        
        public string Password { get; set; }
        [Required, Compare("Password"), DataType(DataType.Password), Display(Name = "Verify Password")]
        public string verify { get; set; }

        public static List<User> UserList { get; set; } = new List<User>();

        public bool IsValidEmail(string email)
        {
            try
            {
                MailAddress testEmail = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        //public void AddUser(User newUser)
        //{
        //    UserList.Add(newUser);
        //}

    }
}
