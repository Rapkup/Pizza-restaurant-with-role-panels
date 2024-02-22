using System.ComponentModel.DataAnnotations;

namespace WEBKITTER.UI.Models
{
    public class ViewUserBase
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "User name is required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Wrong Email adress.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Role is not specified.")]
        [AllowedRoles("Client", "ClientManager", "Administrator", ErrorMessage = "Invalid role.")]
        public string Role { get; set; }
    }

    public class ViewUser : ViewUserBase
    {

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords aren't similar to each other")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }



    public class AllowedRolesAttribute : ValidationAttribute
    {
        private readonly string[] _allowedRoles;

        public AllowedRolesAttribute(params string[] allowedRoles)
        {
            _allowedRoles = allowedRoles;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var role = value.ToString();
                if (!_allowedRoles.Contains(role))
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
            return ValidationResult.Success;
        }
    }
}
