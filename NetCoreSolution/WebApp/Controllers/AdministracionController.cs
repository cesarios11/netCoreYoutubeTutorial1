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
        //TODO:
        //UserManager:Permite administrar y gestionar usuario;
        private readonly UserManager<UsuarioAplicacion> _gestionUsuarios;

        public AdministracionController(RoleManager<IdentityRole>  gestionRoles, UserManager<UsuarioAplicacion> gestionUsuarios)
        {
            this._gestionRoles = gestionRoles;
            this._gestionUsuarios = gestionUsuarios;
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

        [HttpGet]
        [Route("Administracion/EditarRol")]
        public async Task<IActionResult> EditarRol(string id)
        {
            var rol = await _gestionRoles.FindByIdAsync(id);
            if (rol == null)
            {
                ViewBag.ErrorMessage = $"Rol con el id {id} no fue encontrado";
                return View("Error");
            }
            var model = new EditarRolViewModel
            {
                Id = rol.Id,
                RolNombre = rol.Name
            };
            foreach (var usuario in this._gestionUsuarios.Users)
            {
                if (await this._gestionUsuarios.IsInRoleAsync(usuario, rol.Name))
                {
                    model.Usuarios.Add(usuario.UserName);
                }
            }
            return View(model);
        }

        [HttpPost]
        [Route("Administracion/EditarRol")]
        public async Task<IActionResult> EditarRol(EditarRolViewModel model)
        {
            var rol = await this._gestionRoles.FindByIdAsync(model.Id);
            if (rol == null)
            {
                ViewBag.ErrorMessage = $"Rol con el id {model.Id} no fue encontrado";
                return View("Error");
            }
            else
            {
                rol.Name = model.RolNombre;
                var resultado = await this._gestionRoles.UpdateAsync(rol);
                if (resultado.Succeeded)
                {
                    return RedirectToAction("ListaRoles");
                }

                foreach (var error in resultado.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(model);
            }
        }
    }
}
