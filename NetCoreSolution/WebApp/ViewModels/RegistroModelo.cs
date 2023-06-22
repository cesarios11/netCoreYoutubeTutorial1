using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class RegistroModelo
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]        
        [Compare("Password", ErrorMessage = "El password y la confirmacion no coinciden")]
        public string PasswordValidar { get; set; }
    }
}
