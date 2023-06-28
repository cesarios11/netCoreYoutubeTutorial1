using System.Collections.Generic;

namespace WebApp.ViewModels
{
    public class UsuarioClaimsViewModel
    {
        public UsuarioClaimsViewModel()
        {
            this.Claims = new List<UsuarioClaim>();
        }

        public string idUsuario { get; set; }
        public List<UsuarioClaim> Claims { get; set; }
    }
}
