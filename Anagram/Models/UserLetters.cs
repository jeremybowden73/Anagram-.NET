using System.ComponentModel.DataAnnotations;

namespace Anagram.Models
{
    public interface IUserLetters
    {
        string UserInputtedText { get; set; }
    }

    public class UserLetters : IUserLetters
    {
        [Required(ErrorMessage = "Enter some letters please!")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{2,12}$", ErrorMessage = "Enter between 2 and 12 alphabetic characters")]
        public string UserInputtedText { get; set; }
    }
}
