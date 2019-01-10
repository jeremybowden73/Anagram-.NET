using Anagram.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Anagram.Models
{
    public interface ICheckDictionaryWords
    {
        string UserText { get; set; }

        IResultsViewModel CheckAllDictionaryWords();
    }

    public class CheckDictionaryWords : ICheckDictionaryWords
    {
        private readonly IResultsViewModel _resultsViewModel;

        public CheckDictionaryWords(IResultsViewModel RVM)
        {
            _resultsViewModel = RVM;
        }

        public List<string> AllDictionaryWords =  new List<string>();
        public string UserText { get; set; }
        
        // method to populate the List AllDictionaryWords from a text-file dictionary, then iterate
        // through each string and check if it can be made from the characters in UserText. If it can, add it to the AvailableWords list.
        public IResultsViewModel CheckAllDictionaryWords()
        {
            // initialize a new empty List to store the found words
            _resultsViewModel.AvailableWords = new List<string>();
            // set the view model's UserText property to that which was supplied (this is just so it is
            // available in _resultsViewModel when it's returned to the Razor page)
            _resultsViewModel.UserText = UserText;

            // try to open the dictionary text file
            try
            {
                AllDictionaryWords = System.IO.File.ReadLines("Data/corncob.txt").ToList();
            }
            catch (IOException ex)
            {
                _resultsViewModel.ReturnViewName = "Exception";
                _resultsViewModel.ReturnViewMessage = ex.Message.ToString();
                return _resultsViewModel;
            }

            // try to populate AvailableWords with all the words from AllDictionaryWords that can
            // be made from the user-inputted letters
            try
            {
                foreach (string word in AllDictionaryWords)
                {
                    // create a copy of UserText for use while checking the current 'word'
                    var tempUserText = UserText;

                    for (int i = 0; i < word.Length; i++)
                    {
                        int index = tempUserText.IndexOf(word[i]);

                        if (index == -1) // character cannot be found in tempUserText, so break to the next 'word' in AllDictionaryWords
                        {
                            break;
                        }

                        else
                        {
                            tempUserText = tempUserText.Remove(index, 1);

                            if (i == word.Length - 1)
                            {
                                _resultsViewModel.AvailableWords.Add(word);
                            }
                        }
                    }
                }

                _resultsViewModel.ReturnViewName = "ResultsPage";

                return _resultsViewModel;
            }
            catch (Exception ex)
            {
                _resultsViewModel.ReturnViewName = "Exception";
                _resultsViewModel.ReturnViewMessage = "Looks like it's an 'Unspecified' error, sorry.";
                return _resultsViewModel;
            }
        }
    }
}
