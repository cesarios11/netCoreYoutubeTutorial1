using Microsoft.AspNetCore.Identity;

namespace WebApp.ViewModels
{
    public class UsuarioAplicacion : IdentityUser
    {
        //TODO: Esta propiedad corresponde a la frase que ayuda a recordar la contraseña
        public string ayudaPass { get; set; }
    }
}
