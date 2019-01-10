using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Anagram.Models;
using Anagram.ViewModels;

namespace Anagram.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IHomeServices _homeServices;
        private readonly ICheckDictionaryWords _checkDictionaryWords;

        public HomeController(ICheckDictionaryWords CDW)
        {
            //_homeServices = HS;
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

            // if the returned model is good,
            // invoke the MainService method on the HomeServices object that was injected when the current
            // HomeController was created (it is Transient), passing along userLetters which contains the user's inputted text

            //var HomeServicesViewModel = _homeServices.MainService(userLetters);

            _checkDictionaryWords.UserText = userLetters.UserInputtedText;

            var ResultsViewData = new ResultsViewModel
            {
                AvailableWords = _checkDictionaryWords.CheckAllDictionaryWords()
            };

            return View("ResultsPage", ResultsViewData);

            // if the returned viewmodel's UserData property is populated, use it with the ReturnViewName property for the View
            //if (HomeServicesViewModel.UserData != null)
            //{
            //    //return View(HomeServicesViewModel.ReturnViewName,
            //    //HomeServicesViewModel.UserData);
            //    return View("ResultsPage", );
            //}
            // otherwise, an exception was caught, so use the ReturnViewMessage property instead of UserData
            //else
            //{
            //    //return View(HomeServicesViewModel.ReturnViewName,
            //    //HomeServicesViewModel.ReturnViewMessage);
            //    return View("Exception", "big error!");
            //}

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
