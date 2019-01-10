using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Anagram.Models;
using Anagram.ViewModels;

namespace Anagram.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICheckDictionaryWords _checkDictionaryWords;

        public HomeController(ICheckDictionaryWords CDW)
        {
            _checkDictionaryWords = CDW;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(UserLetters userLetters)
        {
            // if ModelState.IsValid returned false there was a problem with the form content, so
            // return the received userLetters object to the GET Index view
            if (!ModelState.IsValid)
            {
                return View(userLetters);
            }

            // if the returned model is good, populate the userText property in the injected _checkDictionaryWords object,
            _checkDictionaryWords.UserText = userLetters.UserInputtedText;

            // create a new ResultsViewData object by invoking the method CheckAllDictionaryWords
            var ResultsViewData = _checkDictionaryWords.CheckAllDictionaryWords();

            // return the appropriate View and object, dependant on the ReturnViewName property of ResultsViewData
            if (ResultsViewData.ReturnViewName == "ResultsPage")
            {
                return View("ResultsPage", ResultsViewData);
            }
            else // exception!!
            {
                return View("Exception", ResultsViewData.ReturnViewMessage);
            }

        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
