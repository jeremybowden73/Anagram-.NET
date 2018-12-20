using System.Collections.Generic;

namespace Anagram.Models
{
    public interface IUserData
    {
        string UserText { get; set;  }
        List<string> AllDictionaryWords { get; set; }
        List<string> AvailableWords { get; set; }
    }

    public class UserData : IUserData
    {
        public string UserText { get; set; }
        public List<string> AllDictionaryWords { get; set; } = new List<string>();
        public List<string> AvailableWords { get; set; } = new List<string>();
    }
}
