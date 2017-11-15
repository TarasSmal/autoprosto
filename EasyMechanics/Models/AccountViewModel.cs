using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EasyMachanics.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "*")]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        public string Login { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "*")]
        public string Name { get; set; }

        [Required(ErrorMessage = "*")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "*")]
        public string Organization { get; set; }

        [Required(ErrorMessage = "*")]
        public string Country { get; set; }

        [Required(ErrorMessage = "*")]
        public string City { get; set; }

        [Required(ErrorMessage = "*")]
        public string Adress { get; set; }

        [Required(ErrorMessage = "*")]
        //[DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "*")]
        //[DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "*")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "*")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }

    public class RestorePasswordViewModel
    {
        [Required(ErrorMessage = "*")]
        [DisplayName("Enter your email to restore")]
        [DataType(DataType.EmailAddress)]
        public string EmailRestore { get; set; }
    }

    public class PasswordViewModel
    {
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [System.ComponentModel.DataAnnotations.Compare("NewPassword", ErrorMessage = "*")]
        [DataType(DataType.Password)]
        public string COnfirmPassword { get; set; }
    }
}