using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Anagram.Models;

namespace AnagramTests
{
    [TestClass]
    public class CheckAllDictionaryWords_Test
    {
        [TestMethod]
        public void CheckAllDictionaryWords_all_words_are_found()
        {
            // Arrange
            var mockIDataForCheckWord = new Mock<IDataForCheckWord>();
            mockIDataForCheckWord.Setup(m => m.UserText).Returns("to");
            mockIDataForCheckWord.Setup(m => m.Word).Returns("toototot");
            var testResObj = new CheckWord(mockIDataForCheckWord.Object);

            //var testDataForCheckWord = new DataForCheckWord();
            //testDataForCheckWord.UserText = "cat";
            //testDataForCheckWord.Word = "at";
            //var testResObj = new CheckWord(testDataForCheckWord);



            // Act
            var result = testResObj.CheckThisWord();

            // Assert
            Assert.AreEqual(result, true);
        }
    }
}
