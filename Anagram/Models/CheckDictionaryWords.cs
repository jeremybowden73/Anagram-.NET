using Anagram.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

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
        private readonly ICheckWord _checkWord;

        public CheckDictionaryWords(IResultsViewModel RVM, ICheckWord CW)
        {
            _resultsViewModel = RVM;
            _checkWord = CW;
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

            // try to populate _resultsViewModel.AvailableWords with all the words
            // from AllDictionaryWords that can be made from the user-inputted letters
            try
            {
                foreach (string word in AllDictionaryWords)
                {
                    // populate _checkWord's injected _dataForCheckWord's properties
                    // with UserText and the current 'word'
                    _checkWord.Populate_DataForCheckWord(UserText, word);
                    
                    // check the current 'word' using _checkWord's CheckThisWord method
                    var result = _checkWord.CheckThisWord();

                    if (result == true)
                    {
                        _resultsViewModel.AvailableWords.Add(word);
                    }
                }

                // if the user-inputted text appears in the list, remove it because it's
                // not really an anagram of itself
                _resultsViewModel.AvailableWords.Remove(UserText);
                
                //_resultsViewModel.ReturnViewName = "ResultsPage";

                //return _resultsViewModel;
            }
            catch (Exception ex)
            {
                _resultsViewModel.ReturnViewName = "Exception";
                _resultsViewModel.ReturnViewMessage = "Looks like it's an 'Unspecified' error, sorry.";
                return _resultsViewModel;
            }

            // try to populate _resultsViewModel.LongestWords with the longest words
            // from the List _resultsViewModel.AvailableWords
            try
            {
                var ordered = _resultsViewModel.AvailableWords.OrderByDescending(x => x.Length).ToList<string>();

                // FIND all elements with the Length of ordered[0];

                _resultsViewModel.LongestWords2 = ordered[0];

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
