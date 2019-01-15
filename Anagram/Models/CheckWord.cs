using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anagram.Models
{
    public interface ICheckWord
    {
        string Word { get; set; }
        string UserText { get; set; }
        void Populate_DataForCheckWord(string MyText, string MyWord);
        bool CheckThisWord();
    }

    public class CheckWord : ICheckWord
    {
        public string Word { get; set; }
        public string UserText { get; set; }

        public readonly IDataForCheckWord _dataForCheckWord;

        public CheckWord(IDataForCheckWord DFCW)
        {
            _dataForCheckWord = DFCW;
        }

        public void Populate_DataForCheckWord(string MyText, string MyWord)
        {
            _dataForCheckWord.UserText = MyText;
            _dataForCheckWord.Word = MyWord;
        }

        public bool CheckThisWord()
        {
            UserText = _dataForCheckWord.UserText;
            Word = _dataForCheckWord.Word;

            for (int i = 0; i < Word.Length; i++)
            {
                int index = UserText.IndexOf(Word[i]);

                if (index == -1) // character cannot be found in UserText, so return false
                {
                    return false;
                }

                else
                {
                    UserText = UserText.Remove(index, 1);

                    if (i == Word.Length - 1)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
