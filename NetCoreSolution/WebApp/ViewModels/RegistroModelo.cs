using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebApp.Utilidades;

namespace WebApp.ViewModels
{
    public class RegistroModelo
    {
        [Required(ErrorMessage = "*Email es obligatorio")]
        [Display(Name = "Email")]        
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "*Formato invalido")]
        [EmailAddress]
        //TODO: [Remote(action: "ComprobarEmail", controller:"Cuentas")] permite que se haga una validación remota de este campo en la vista, sin necesidad de hacer submit
        [Remote(action: "ComprobarEmail", controller:"Cuentas")]
        //TODO: Se crea una validación personalizada
        [ValidarNombreUsuario(usuario: "joder", ErrorMessage = "El correo contiene texto no permitido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "*Password es obligatorio")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Repetir Password")]        
        [Compare("Password", ErrorMessage = "*El password y la confirmacion no coinciden")]
        public string PasswordValidar { get; set; }
    }
}
