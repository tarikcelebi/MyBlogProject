using System.ComponentModel.DataAnnotations;

namespace MyBlogProject.Models.AccountVMs
{
    public class LoginVM
    {
        [Required(ErrorMessage ="Please enter your E-mail.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your password.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please enter your password again.")]
        [Compare("Password",ErrorMessage = "Passwords didn't match.")]
        public string PasswordCheck { get; set; }
        public string ReturnUrl { get; set; }
    }
}
