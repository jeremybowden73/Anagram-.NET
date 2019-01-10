﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anagram.Controllers;
using Anagram.Models;

namespace Anagram.ViewModels
{
    public interface IResultsViewModel
    {
        //string ReturnViewName { get; set; }

        //string ReturnViewMessage { get; set; }

        List<string> AvailableWords { get; set; }
    }

    public class ResultsViewModel : IResultsViewModel
    {
        //public string ReturnViewName { get; set; }

        //public string ReturnViewMessage { get; set; }

        public List<string> AvailableWords { get; set; }
    }
}
