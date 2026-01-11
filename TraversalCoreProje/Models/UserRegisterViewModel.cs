using System.ComponentModel.DataAnnotations;

namespace TraversalCoreProje.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Please enter your name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your surname.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Please enter your username.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter your mail.")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Please enter your password.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter your password again.")]
        [Compare("Password", ErrorMessage ="Your passwords must match.")]
        public string ConfirmPassword { get; set; }
    }
}
