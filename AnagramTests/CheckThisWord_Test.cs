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
            var testDataForCheckWord = new DataForCheckWord();
            testDataForCheckWord.UserText = "cat";
            testDataForCheckWord.Word = "at";
            var testResObj = new CheckWord(testDataForCheckWord);

            // Act
            var result = testResObj.CheckThisWord();

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void CheckThisWord_invalid_word_is_not_found()
        {
            // Arrange
            var testDataForCheckWord = new DataForCheckWord();
            testDataForCheckWord.UserText = "cat";
            testDataForCheckWord.Word = "superman";
            var testResObj = new CheckWord(testDataForCheckWord);

            // Act
            var result = testResObj.CheckThisWord();

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void CheckThisWord_invalid_word_containing_valid_letters_is_not_found()
        {
            // Arrange

            // using Moq is not working because the mock object (mockIDataForCheckWord) is not mutated
            // when the method-on-test (CheckThisWord) finds a letter in mockIDataForCheckWord.Word that
            // is in mockIDataForCheckWord.UserText. The algorithm in CheckThisWord() should mutate the
            // UserText when a letter if found. Works OK in the program, but not in this test.
            //var mockIDataForCheckWord = new Mock<IDataForCheckWord>();
            //mockIDataForCheckWord.Setup(m => m.UserText).Returns("to");
            //mockIDataForCheckWord.Setup(m => m.Word).Returns("toototot");
            //var testResObj = new CheckWord(mockIDataForCheckWord.Object);

            // So do it the simple way instead
            var testDataForCheckWord = new DataForCheckWord();
            testDataForCheckWord.UserText = "to";
            testDataForCheckWord.Word = "tot"; // invalid because each letter in UserText can only be use once
            var testResObj = new CheckWord(testDataForCheckWord);

            // Act
            var result = testResObj.CheckThisWord();

            // Assert
            Assert.AreEqual(false, result);
        }
    }
}
