using System.ComponentModel.DataAnnotations;

namespace MyBlogProject.Models.AccountVMs
{
    public class SignUpVM
    {

        [Required(ErrorMessage = "Please enter your name.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter your last name.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter your E-mail.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your password.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please enter your password again.")]
        [Compare("Password", ErrorMessage = "Passwords didn't match.")]
        public string CheckPassword { get; set; }
        public string ImageURL { get; set; }
        public int Age { get; set; }
    }
}
