using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DZ_LAB1.Models
{
    public class UserProfile
    {
        [Required(ErrorMessage = "A first name is required!")]
        public string _FirstName { get; set; }
        [Required(ErrorMessage = "A last name is required!")]
        public string _LastName { get; set; }
        [Required(ErrorMessage = "An email is required!")]
        public string _EmailAddress { get; set; }
        [Required(ErrorMessage = "A phone number is required!")]
        [RegularExpression(@"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}", ErrorMessage = "Invalid Phone Number!")]
        [DisplayName("Phone number")]
        public string _PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter in a password")]
        public string _Password { get; set; }

        [Required(ErrorMessage = "Please enter in your confirmation password")]
        [Compare("_Password", ErrorMessage = "Unfortunately the passwords do not match.")]
        public string _ConfirmationPassword { get; set; }

    }
}
