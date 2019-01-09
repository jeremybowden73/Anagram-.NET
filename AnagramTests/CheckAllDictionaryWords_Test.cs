using Microsoft.VisualStudio.TestTools.UnitTesting;
using Anagram;
using Moq;
using System.Collections.Generic;
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
            List<string> AllDictionaryWords = new List<string>();
            AllDictionaryWords.Add("cat");
            AllDictionaryWords.Add("mouse");
            AllDictionaryWords.Add("dog");

            List<string> AvailableWords = new List<string>();

            string UserText = "catxdogz";

            var expectedResponse = new List<string>();
            expectedResponse.Add("cat");
            expectedResponse.Add("dog");

            // Act
            var testResultObj = CheckDictionaryWords.CheckAllDictionaryWords
               (AllDictionaryWords,
               AvailableWords,
               UserText);

            // Assert
            CollectionAssert.AreEqual(expectedResponse, testResultObj);
        }
    }
}
