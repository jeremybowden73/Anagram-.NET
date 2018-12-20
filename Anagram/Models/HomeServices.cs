using Anagram.ViewModels;
using System;
using System.IO;
using System.Linq;

namespace Anagram.Models
{
    public interface IHomeServices
    {
        IHomeServicesViewModel MainService(UserLetters userLetters);
    }

    //
    // This class contains a method that is the main function of the POST Index route in HomeController.cs
    //
    public class HomeServices : IHomeServices
    {
        // inject "placeholder instances" so they are available later on,
        // when we want to populate their fields. (Instead of creating them using "new" which is bad for unit testing)
        private readonly IHomeServicesViewModel _homeServicesViewModel;
        private readonly IUserData _userData;

        public HomeServices(IHomeServicesViewModel HSVM, IUserData UD)
        {
            _homeServicesViewModel = HSVM;
            _userData = UD;
        }

        //
        // method to action the main process of the HomeController.cs
        public IHomeServicesViewModel MainService(UserLetters userLetters)
        {
            // populate the UserText property of the injected _userData object with the user's inputted text
            _userData.UserText = userLetters.UserInputtedText.ToLower();

            try
            {
                // populate the List that contains all words from the full dictionary
                _userData.AllDictionaryWords = System.IO.File.ReadLines("Data/corncob.txt").ToList();

                try
                {
                    // populate the List the contains all of the "available words" i.e. those from 
                    // the full dictionary that can be made from the user's inputted text
                    _userData.AvailableWords = CheckDictionaryWords.CheckAllDictionaryWords
                        (_userData.AllDictionaryWords,
                        _userData.AvailableWords,
                        _userData.UserText);

                    // populate the injected IHomeServicesViewModel object, ready for returning
                    _homeServicesViewModel.ReturnViewName = "ResultsPage";
                    _homeServicesViewModel.ReturnViewMessage = "";
                    _homeServicesViewModel.UserData = _userData;

                    return _homeServicesViewModel;
                }

                catch (Exception ex)
                {
                    _homeServicesViewModel.ReturnViewName = "Exception";
                    _homeServicesViewModel.ReturnViewMessage = "Looks like it's an 'Unspecified' error, sorry.";

                    return _homeServicesViewModel;
                }

                // more stuff to do before returning ???

            }

            catch (IOException ex)
            {
                _homeServicesViewModel.ReturnViewName = "Exception";
                _homeServicesViewModel.ReturnViewMessage = ex.Message.ToString();

                return _homeServicesViewModel;
            }

            catch (Exception ex)
            {
                _homeServicesViewModel.ReturnViewName = "Exception";
                _homeServicesViewModel.ReturnViewMessage = "Looks like it's an 'Unspecified' error, sorry.";

                return _homeServicesViewModel;
            }
        }
    }
}
