using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StackOverflow.ViewModels.ViewModels
{
    public class UserPasswordViewModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Email Address")]
        [RegularExpression(@"(\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,6})",
            ErrorMessage = "Email address is not valid!")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Password")]
        public string Password { get; set; }

        [Required]
        [DisplayName("Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords do not match!")]
        public string ConfirmPassword { get; set; }
    }
}
