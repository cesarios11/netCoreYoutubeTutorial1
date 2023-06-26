using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class CrearRolViewModel
    {
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Display(Name = "Rol")]
        public string NombreRol { get; set; }
    }
}
