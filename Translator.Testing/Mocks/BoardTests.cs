using System;
using Xunit;
using Translator.Domain.Models;

namespace Translator.Testing.Mocks
{
    public class MessageTests
    {
        [Fact]
        public void MessageisValidString()
        {
          //Arrange
          string testMessage = "valid message";
          string spanishMessage = "mensaje válido";
          Message input = new Message(testMessage); 

          //Act out
          input.TranslateTo("Spanish");

          //Assert
          string translatedMessage = input.TranslatedContent;
          Assert.StrictEqual(spanishMessage, translatedMessage);

        }
        [Fact]
        public void SpecifiedLanguageIsValid()
        {
          //Arrange
          string testMessage = "hello";
          string spanishMessage = null;
          Message input = new Message(testMessage);

          //Act out
          input.TranslateTo("dummy language");

          //Assert
          string translatedMessage = input.TranslatedContent;
          Assert.StrictEqual(spanishMessage, translatedMessage);

        }
    }
}