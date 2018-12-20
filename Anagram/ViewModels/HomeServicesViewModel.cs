using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anagram.Controllers;
using Anagram.Models;

namespace Anagram.ViewModels
{
    public interface IHomeServicesViewModel
    {
        string ReturnViewName { get; set; }

        string ReturnViewMessage { get; set; }

        IUserData UserData { get; set; }
    }

    public class HomeServicesViewModel : IHomeServicesViewModel
    {
        public string ReturnViewName { get; set; }

        public string ReturnViewMessage { get; set; }

        public IUserData UserData { get; set; }
    }
}
