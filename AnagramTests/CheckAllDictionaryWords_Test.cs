using Microsoft.VisualStudio.TestTools.UnitTesting;
using Anagram;
using Moq;
using System.Collections.Generic;
using Anagram.Models;
using Moq;
using Anagram.ViewModels;
using System.Linq;

namespace AnagramTests
{
    [TestClass]
    public class CheckAllDictionaryWords_Test
    {
        [TestMethod]
        public void CheckAllDictionaryWords_all_words_are_found()
        {
            //// Arrange
            //List<string> AllDictionaryWords = new List<string>();
            //AllDictionaryWords.Add("cat");
            //AllDictionaryWords.Add("mouse");
            //AllDictionaryWords.Add("dog");

            //List<string> AvailableWords = new List<string>();

            //string UserText = "catxdogz";

            //var expectedResponse = new List<string>();
            //expectedResponse.Add("cat");
            //expectedResponse.Add("dog");

            //// Act
            //var testResultObj = "boo";

            //// Assert
            //Assert.AreEqual(expectedResponse[0], testResultObj);





            // Arrange
            var mockIResultsViewModel = new Mock<IResultsViewModel>();

            mockIResultsViewModel.Setup(m => m.UserText).Returns("cat");
            //mockIResultsViewModel.Setup(m => m.AvailableWords).Returns(()=> new List<string>{ "abc"});

            //var testResObj = new CheckDictionaryWords(mockIResultsViewModel.Object);
            var testRVM = new ResultsViewModel();
            testRVM.ReturnViewName = "sfksjfhf";
            testRVM.UserText = "cats";

            var testUT = "cats";

            var testResObj = new CheckDictionaryWords(testRVM);
            
            var expectedResult = new List<string> { "a", "act", "at", "cat" };

            // Act
            testResObj.AllDictionaryWords = System.IO.File.ReadLines("corncob.txt").ToList();
            //testResObj.UserText = "dogs";

            var response1 = testResObj.CheckAllDictionaryWords();
            var response2 = response1.AvailableWords;
            //var fistDicWord = testResObj.AllDictionaryWords[1];
            //var checkFDW = new string("aardvark");

            // Assert
            CollectionAssert.AreEqual(expectedResult, response2);
            //Assert.AreEqual(checkFDW, fistDicWord);





        }
    }
}
