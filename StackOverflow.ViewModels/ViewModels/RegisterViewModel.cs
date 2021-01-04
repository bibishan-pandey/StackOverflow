using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StackOverflow.ViewModels.ViewModels
{
    public class RegisterViewModel
    {
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
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DisplayName("Username")]
        [RegularExpression(@"(^[a-zA-Z]*$)",
            ErrorMessage = "Username should contain only alphabets!")]
        public string UserName { get; set; }

        [Required]
        [DisplayName("Firstname")]
        [RegularExpression(@"(^[a-zA-Z]*$)",
            ErrorMessage = "Firstname should contain only alphabets!")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Lastname")]
        [RegularExpression(@"(^[a-zA-Z]*$)",
            ErrorMessage = "Lastname should contain only alphabets!")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Phone Number")]
        [RegularExpression(@"(^((\+)?(\d{2}[-]))?(\d{10}){1}?$)",
            ErrorMessage = "Phone Number should be 10 digits with country code!")]
        public string Phone { get; set; }
    }
}
