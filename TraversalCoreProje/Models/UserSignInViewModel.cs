using System.ComponentModel.DataAnnotations;

namespace TraversalCoreProje.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage = "Please enter a username.")]
        public string username { get; set; }

        [Required(ErrorMessage = "Please enter a password.")]
        public string password { get; set; }
    }
}
