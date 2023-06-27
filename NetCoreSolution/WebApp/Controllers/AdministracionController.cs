using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    //TODO: Este controlador registra los usuarios que se almacenan en la tabla '[dbo].[AspNetRoles]' de base de datos.
    //TODO: Este controlador registra los usuarios que se almacenan en la tabla '[dbo].[AspNetUserRoles]' de base de datos.
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

        //[dbo].[AspNetRoles]
        [HttpGet]
        [Route("Administracion/CrearRol")]        
        public IActionResult CrearRol()
        {
            return View();
        }

        //[dbo].[AspNetRoles]
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
                    return RedirectToAction("ListaRoles", "Administracion");
                }
                foreach (IdentityError error in result.Errors) 
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }

        //[dbo].[AspNetRoles]
        [HttpGet]
        [Route("Administracion/Roles")]
        public IActionResult ListaRoles()
        {
            var roles = _gestionRoles.Roles;
            return View(roles);
        }

        //[dbo].[AspNetRoles]
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

        //[dbo].[AspNetRoles]
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

        //[dbo].[AspNetUserRoles]
        [HttpGet]
        [Route("Administracion/EditarUsuarioRol")]
        public async Task<IActionResult> EditarUsuarioRol(string roleId)
        {
            ViewBag.roleId = roleId;
            var role = await this._gestionRoles.FindByIdAsync(roleId);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Rol con el id {roleId} no fue encontrado";
                return View("Error");
            }
            var model = new List<UsuarioRolModel>();
            foreach (var user in this._gestionUsuarios.Users)
            {
                var usuarioRolModel = new UsuarioRolModel 
                {
                    UsuarioId = user.Id,
                    UsuarioNombre = user.UserName
                };

                if (await this._gestionUsuarios.IsInRoleAsync(user, role.Name))
                {
                    usuarioRolModel.EstaSeleccionado = true;
                }
                else
                {
                    usuarioRolModel.EstaSeleccionado = false;
                }
                model.Add(usuarioRolModel);
            }

            return View(model);
        }

        //[dbo].[AspNetUserRoles]
        [HttpPost]
        [Route("Administracion/EditarUsuarioRol")]
        public async Task<IActionResult> EditarUsuarioRol(List<UsuarioRolModel> model, string roleId)
        {
            var rol = await this._gestionRoles.FindByIdAsync(roleId);
            if (rol == null)
            {
                ViewBag.ErrorMessage = $"Rol con el id {roleId} no fue encontrado";
                return View("Error");
            }

            for (int i = 0; i < model.Count; i++)
            {
                var user = await this._gestionUsuarios.FindByIdAsync(model[i].UsuarioId);
                IdentityResult result = null;
                if (model[i].EstaSeleccionado && !(await this._gestionUsuarios.IsInRoleAsync(user, rol.Name)))
                {
                    result = await this._gestionUsuarios.AddToRoleAsync(user, rol.Name);
                }
                else if (!model[i].EstaSeleccionado && await this._gestionUsuarios.IsInRoleAsync(user, rol.Name))
                {
                    result = await this._gestionUsuarios.RemoveFromRoleAsync(user, rol.Name);
                }
                else
                {
                    continue;
                }
                if (result.Succeeded)
                {
                    if (i < (model.Count - 1))
                    {
                        continue;
                    }
                    else
                    {
                        return RedirectToAction("EditarRol", new { Id= roleId });
                    }
                }
            }
            return RedirectToAction("EditarRol", new { Id = roleId });
        }
    }
}
