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
            List<User> user = AddUserViewModel.UserList;
            return View(user);
        }
        
        public IActionResult Add()
        {
            User user = new User();
            ViewBag.Title = "Add User";
            AddUserViewModel addUserViewModel = new AddUserViewModel();
            return View(addUserViewModel);
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
                if (newUser.Password == null)
                {
                    ViewBag.error = "Please enter a password";
                    return View();
                } else
                {
                    if (verify != newUser.Password)
                    {
                        ViewBag.error = "Passwords need to match";
                        return View();
                    };
                    AddUserViewModel.UserList.Add(newUser);
                    return Redirect("/User");
                }
            }
            return View(user);
        }
    }
}