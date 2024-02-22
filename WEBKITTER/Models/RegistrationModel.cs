using System.ComponentModel.DataAnnotations;

namespace WEBKITTER.UI.Models
{
    public class RegistrationModel
    {

        [Required]
        public string Email { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords aren't similar to each other")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }

    }
}
