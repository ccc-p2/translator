using Translator.Domain.Models;
using TR=Translator.Domain.Models.Translator;
using Xunit;

namespace Translator.Testing.Domain
{
  public class TranslatorUnitTest
  {
    [Fact]
    public void Test_ValidMessageResponse()
    {
      // Arrange
      string messageRequest = "valid message";
      string messageResponse = "mensaje válido";

      // Act out
      TR actualResponse = new TR();
      
      // Assert
      Assert.True(actualResponse.Translate(messageRequest, "SPANish").Result.Equals(messageResponse));
    }

    [Fact]
    public void Test_EmptyMessage()
    {
      // Arrange
      string messageRequest = "";

      // Act out
      TR actualResponse = new TR();

      // Assert
      Assert.True(string.IsNullOrEmpty(actualResponse.Translate(messageRequest, "Spanish").Result));
    }

    [Fact]
    public void Test_NonexistingLanguage()
    {
      // Arrange
      string messageRequest = "valid message";
      string dummyLanguage = "dummy language";

      // Act out
      TR actualResponse = new TR();

      // Assert
      Assert.True(string.IsNullOrEmpty(actualResponse.Translate(messageRequest, dummyLanguage).Result));
    }

    [Fact]
    public void Test_EmptyLanguage()
    {
      // Arrange
      string messageRequest = "valid message";
      string emptyLanguage = "";

      // Act out
      TR actualResponse = new TR();

      // Assert
      Assert.True(string.IsNullOrEmpty(actualResponse.Translate(messageRequest, emptyLanguage).Result));
    }

    [Fact]
    public void Test_DummyMessage()
    {
      // Arrange
      string messageRequest = "ABCDEFG";

      // Act out
      TR actualResponse = new TR();

      // Assert
      Assert.True(string.IsNullOrEmpty(actualResponse.Translate(messageRequest, "Spanish").Result));
    }
      
  }
}