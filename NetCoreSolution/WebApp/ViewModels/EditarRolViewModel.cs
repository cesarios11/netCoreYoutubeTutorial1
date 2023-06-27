using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class EditarRolViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "El nombre del rol es obligatorio")]
        public string RolNombre { get; set; }

        public List<string> Usuarios { get; set; }

        public EditarRolViewModel()
        {
                this.Usuarios = new List<string>();
        }
    }
}
