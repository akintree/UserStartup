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
            //User user = new User();
            ViewBag.Title = "Add User";
            AddUserViewModel addUserViewModel = new AddUserViewModel();
            return View(addUserViewModel);
        }
        [HttpPost]
        public IActionResult Add(AddUserViewModel addUserViewModel)
        {           
            if (ModelState.IsValid)
            {
                User newUser = new User
                {
                    Username = addUserViewModel.Username,
                    Email = addUserViewModel.Email,
                    Password = addUserViewModel.Password
                };             
                    AddUserViewModel.UserList.Add(newUser);
                    return Redirect("/User");  
            }
            return View(addUserViewModel);
        }
    }
}