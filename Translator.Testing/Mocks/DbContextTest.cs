using System;
using Xunit;
using Translator.Storing;

namespace Translator.Testing.Mocks
{
    public class DbContextTest
    {
        [Fact]
        public void Test_DbCreation()
        {
          //Arrange
          var dbContext = new TranslatorDbContext();

          //Act out
          

          //Assert
          Assert.NotNull(dbContext);

        }
    }
}