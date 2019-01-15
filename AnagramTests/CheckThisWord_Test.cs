using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Anagram.Models;

namespace AnagramTests
{
    [TestClass]
    public class CheckThisWord_Test
    {
        [TestMethod]
        public void CheckThisWord_valid_word_is_found()
        {
            // Arrange
            var mockIDataForCheckWord = new Mock<IDataForCheckWord>();
            mockIDataForCheckWord.SetupProperty(m => m.UserText, "cat"); // SetupProperty allows this property to be accessed during the program runtime
            mockIDataForCheckWord.Setup(m => m.Word).Returns("at");

            var testResObj = new CheckWord(mockIDataForCheckWord.Object);

            // Act
            var result = testResObj.CheckThisWord();

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void CheckThisWord_invalid_word_is_not_found()
        {
            // Arrange
            var mockIDataForCheckWord = new Mock<IDataForCheckWord>();
            mockIDataForCheckWord.SetupProperty(m => m.UserText, "cat");
            mockIDataForCheckWord.Setup(m => m.Word).Returns("superman");

            var testResObj = new CheckWord(mockIDataForCheckWord.Object);

            // Act
            var result = testResObj.CheckThisWord();

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void CheckThisWord_invalid_word_containing_all_valid_letters_is_not_found()
        {
            // Arrange
            var mockIDataForCheckWord = new Mock<IDataForCheckWord>();
            mockIDataForCheckWord.SetupProperty(m => m.UserText, "to");
            mockIDataForCheckWord.Setup(m => m.Word).Returns("tot");

            var testResObj = new CheckWord(mockIDataForCheckWord.Object);

            // Act
            var result = testResObj.CheckThisWord();

            // Assert
            Assert.AreEqual(false, result);
        }
    }
}
