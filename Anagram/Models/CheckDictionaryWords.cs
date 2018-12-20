using System.Collections.Generic;

namespace Anagram.Models
{
    public static class CheckDictionaryWords
    {
        // method to iterate over all strings in AllDictionaryWords, and check if the string can be
        // made from the characters in UserText. If it can, add it to the AvailableWords list.
        public static List<string> CheckAllDictionaryWords(List<string> AllDictionaryWords, List<string> AvailableWords, string UserText)
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
                            AvailableWords.Add(word);
                        }
                    }
                }
            }

            return AvailableWords;
        }
    }
}
