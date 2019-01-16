using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anagram.Controllers;
using Anagram.Models;

namespace Anagram.ViewModels
{
    public interface IResultsViewModel
    {
        string ReturnViewName { get; set; }

        string ReturnViewMessage { get; set; }

        string UserText { get; set; }

        List<string> AvailableWords { get; set; }

        IEnumerable<string> LongestWords { get; set; }
        string LongestWords2 { get; set; }
    }

    public class ResultsViewModel : IResultsViewModel
    {
        public string ReturnViewName { get; set; }

        public string ReturnViewMessage { get; set; }

        public string UserText { get; set; }

        public List<string> AvailableWords { get; set; }

        public IEnumerable<string> LongestWords { get; set; }
        public string LongestWords2 { get; set; }
    }
}
