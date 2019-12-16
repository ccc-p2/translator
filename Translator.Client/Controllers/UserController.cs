using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Translator.Client.Models;
using Translator.Storing.Models;
using Translator.Storing.Repositories;

namespace Translator.Client.Controllers
{ 
  [Route("/[controller]/[action]")]
    public class UserController : Controller
    {
        private UserRepository _user = new UserRepository();
        private readonly ILogger<HomeController> _logger;

        public UserController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Home(int userId)
        {
          if(HttpContext.Session.GetInt32("SessionKeyUserId") != null)
          {
            ViewBag.UserId = userId;
            return RedirectToAction("Index", "home", new { accountID = userId});
          }         
          
          return RedirectToAction("Login", "User");
        }

        public IActionResult SignUp()
        {
          ViewBag.Message = "User Sign Up";
          UserViewModel model = new UserViewModel();

          if(HttpContext.Session.GetInt32("SessionKeyUserId") != null)
          {
            HttpContext.Session.Remove("SessionKeyUserId");
          }

          return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignUp(UserViewModel model)
        {
          if(HttpContext.Session.GetInt32("SessionKeyUserId") != null)
          {
            HttpContext.Session.Remove("SessionKeyUserId");
          }        

          if(ModelState.IsValid)
          {    
            User tempUser = new User();
            tempUser.Username = model.Username;
            tempUser.Password = model.Password;
            tempUser.Language = model.Language;
            _user.AddNewUser(tempUser);
            return RedirectToAction("Home", "User");
          }
          return View();
        }

        public IActionResult Login()
        {
          if(HttpContext.Session.GetInt32("SessionKeyUserId") !=null)
          {
            return RedirectToAction("Home", "User", new { userID = HttpContext.Session.GetInt32("SessionKeyUserId")  });
          }
          
          return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(UserViewModel user)
        {
          User isUserValid = new User();
          isUserValid = _user.CheckForUser(user.Username, user.Password);         
          
          if(isUserValid != null)
          {
            HttpContext.Session.SetInt32("SessionKeyUserId", isUserValid.UserId);

            return RedirectToAction("home", "User", new { userId = isUserValid.UserId});
          }
          ViewBag.Prompt = "Invalid Username or Password";
            return View(new UserViewModel());
        }       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
