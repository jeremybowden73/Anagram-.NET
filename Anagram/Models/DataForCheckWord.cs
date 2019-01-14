using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anagram.Models
{
    public interface IDataForCheckWord
    {
        string Word { get; set; }
        string UserText { get; set; }
    }

    public class DataForCheckWord : IDataForCheckWord
    {
        public string Word { get; set; }
        public string UserText { get; set; }
    }
}
