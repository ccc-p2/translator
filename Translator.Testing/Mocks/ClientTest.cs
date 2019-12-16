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
    }
}