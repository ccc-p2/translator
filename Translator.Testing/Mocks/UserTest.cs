using System;
using Xunit;
using Translator.Client.Controllers;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Translator.Client.Models;

namespace Translator.Testing
{
    public class UserTest
    {
        private readonly ILogger<UserController> logger = LoggerFactory.Create(o => o.SetMinimumLevel(LogLevel.Debug)).CreateLogger<UserController>();
        
        
        [Fact]
        public void Test_HomePage()
        {
          //Arrange
          var user = new UserController(logger);

          //Act Out
          var home = user.RedirectToAction("home", "User", 1);

          //Assert
          Assert.NotNull(home);

        }
        [Fact]
        public void Test_SignupPage()
        {
          //Arrange
          var user = new UserController(logger);

          //Act Out
          var signUp = user.RedirectToAction("SignUp", "User");

          //Assert
          Assert.NotNull(signUp);

        }
        [Fact]
        public void Test_SignupPageWithModel()
        {
          //Arrange
          var user = new UserController(logger);
          UserViewModel newUser = new UserViewModel()
          {
            Username = "Joh",
          };

          //Act Out
          var signUp = user.RedirectToAction("SignUp", "User", newUser);

          //Assert
          Assert.NotNull(signUp);
        }
        [Fact]
        public void Test_LoginPage()
        {
          //Arrange
          var user = new UserController(logger);

          //Act Out
          var login = user.RedirectToAction("Login", "User");

          //Assert
          Assert.NotNull(login);
        }
        [Fact]
        public void Test_LoginPageWithModel()
        {
          //Arrange
          var user = new UserController(logger);
          UserViewModel newUser = new UserViewModel()
          {
            Username = "john",
            Password = "12345678"
          };

          //Act Out
          var login = user.RedirectToAction("Login", "User", newUser);

          //Assert
          Assert.NotNull(login);
        }
    }
}