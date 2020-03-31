using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserStartup.Models;
using UserStartup.ViewModels;

namespace UserStartup.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()   
        {
            List<User> users = AddUserViewModel.UserList;
            return View(users);
        }
        
        public IActionResult Add()
        {
            User user = new User();
            ViewBag.Title = "Add User";
            AddUserViewModel addUserViewModel = new AddUserViewModel();
            return View(user);
        }
        [HttpPost]
        public IActionResult Add(User user, string verify)
        {           
            if (ModelState.IsValid)
            {
                User newUser = new User
                {
                    Username = user.Username,
                    Email = user.Email,
                    Password = user.Password
                };
                if (newUser.Password is null)
                {
                    ViewBag.error = "Please enter a password";
                    throw ViewBag.error;
                } else
                {
                    if (verify != newUser.Password)
                    {
                        ViewBag.error = "Passwords need to match";
                        throw ViewBag.error;
                    };
                    AddUserViewModel.UserList.Add(newUser);
                    return Redirect("/User");
                }
            }
            return View(user);
        }
    }
}