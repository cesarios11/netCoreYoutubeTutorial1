using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class EditarUsuarioModel
    {
        public EditarUsuarioModel()
        {
            this.Notificaciones = new List<string>();
            this.Roles = new List<string>();
        }

        public string Id { get; set; }

        [Required]
        public string NombreUsuario { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string ayudaPass { get; set; }

        //TODO: Notificaciones (Claims) nos permite la autenticación basada en notificaciones.
        //Donde la identidad del usuario se representa como un conjunto de notificaciones
        public List<string> Notificaciones { get; set; }
        public IList<string> Roles { get; set; }
    }
}
