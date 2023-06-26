using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    //TODO: Este controlador registra los usuarios que se almacenan en la tabla '[dbo].[AspNetRoles]' de base de datos.
    public class AdministracionController : Controller
    {
        private readonly RoleManager<IdentityRole> _gestionRoles;

        public AdministracionController(RoleManager<IdentityRole>  gestionRoles)
        {
            this._gestionRoles = gestionRoles;
        }

        [HttpGet]
        [Route("Administracion/CrearRol")]        
        public IActionResult CrearRol()
        {
            return View();
        }

        [HttpPost]
        [Route("Administracion/CrearRol")]
        public async Task<IActionResult> CrearRol(CrearRolViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole 
                {
                    Name = model.NombreRol
                };

                IdentityResult result = await _gestionRoles.CreateAsync(identityRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index4", "Home");
                }
                foreach (IdentityError error in result.Errors) 
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        [Route("Administracion/Roles")]
        public IActionResult ListaRoles()
        {
            var roles = _gestionRoles.Roles;
            return View(roles);
        }
    }
}
