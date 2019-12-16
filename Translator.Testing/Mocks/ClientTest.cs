using System;
using Xunit;
using Translator.Client.Controllers;
using Microsoft.Extensions.Logging;
using Translator.Client.Models;

namespace Translator.Testing
{
    public class ClientTest
    {
        private readonly ILogger<HomeController> logger = LoggerFactory.Create(o => o.SetMinimumLevel(LogLevel.Debug)).CreateLogger<HomeController>();
        [Fact]
        public void Test_IndexPage()
        {
          //Arrange
          var home = new HomeController(logger);

          //Act Out
          var index = home.Index(1);

          //Assert
          Assert.NotNull(index);

        }

        [Fact]
        public void Test_PrivacyPage()
        {
          //Arrange
          var home = new HomeController(logger);

          //Act Out
          var index = home.Privacy();

          //Assert
          Assert.NotNull(index);

        }
        
        [Fact]
        public void Test_GrabMessageById()
        {
          //Arrange
          var home = new HomeController(logger);
          var messageId = 2;

          //Act Out
          var messageGrabbed = home.Message(messageId);

          //Assert
          Assert.NotNull(messageGrabbed);
        }
        [Fact]
        public void Test_UserViewModelPropagation()
        {
          //Arrange
          var user = new UserViewModel();

          //Act Out
          user.Username = "test";
          user.Password = "testing123";
          user.ConfirmPassword = "testing123";
          user.Language = "german";
          

          //Assert
          Assert.Matches("test", user.Username);
          Assert.Matches("testing123", user.Password);
          Assert.Matches("testing123", user.ConfirmPassword);
          Assert.Matches("german", user.Language);
        }
    }
}