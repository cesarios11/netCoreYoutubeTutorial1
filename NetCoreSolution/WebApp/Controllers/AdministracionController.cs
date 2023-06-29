using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApp.Models;
using WebApp.ViewModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebApp.Controllers
{
    //TODO: Este controlador registra los usuarios que se almacenan en la tabla '[dbo].[AspNetRoles]' de base de datos.
    //TODO: Este controlador registra los usuarios que se almacenan en la tabla '[dbo].[AspNetUserRoles]' de base de datos.
    //TODO: Solo los usuarios con rol 'Administrador' puede acceder a los métodos de este controlador.
    //TODO: [Authorize(Roles = "Administrador, Usuario")] permite a los roles Administrador, Usuario acceder  a los métodos de este controlador.
    //TODO:  También se puede restringir en 2 líneas asi:
    //[Authorize(Roles = "Administrador")]
    //[Authorize(Roles = "Usuario")]
    //TODO: Restringir el acceso por rol se puede hacer a nivel de clase y también a nivel de método
    [Authorize(Roles = "Super Administrador, Administrador, Usuario")]
    public class AdministracionController : Controller
    {
        private readonly RoleManager<IdentityRole> _gestionRoles;
        //TODO:
        //UserManager:Permite administrar y gestionar usuario;
        private readonly UserManager<UsuarioAplicacion> _gestionUsuarios;

        private readonly ILogger<AdministracionController> _logger;

        public AdministracionController(RoleManager<IdentityRole> gestionRoles, UserManager<UsuarioAplicacion> gestionUsuarios, ILogger<AdministracionController> logger)
        {
            this._gestionRoles = gestionRoles;
            this._gestionUsuarios = gestionUsuarios;
            this._logger = logger;
        }

        //[dbo].[AspNetRoles]
        [HttpGet]
        //TODO:Se aplica la política 'CrearRolPolicy' establecida en el startup.cs
        //El usuario que quiera utilizar este método tiene que tener asignado
        //el claim 'Crear Rol' para poder utilizar el método.
        [Authorize(Policy = "CrearRolPolicy")]
        [Route("Administracion/CrearRol")]
        public IActionResult CrearRol()
        {
            return View();
        }

        //[dbo].[AspNetRoles]
        [HttpPost]
        //TODO:Se aplica la política 'CrearRolPolicy' establecida en el startup.cs
        //El usuario que quiera utilizar este método tiene que tener asignado
        //el claim 'Crear Rol' para poder utilizar el método.
        [Authorize(Policy = "CrearRolPolicy")]
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
        //TODO:Se aplica la política 'LeerRolPolicy' establecida en el startup.cs
        //El usuario que quiera utilizar este método tiene que tener asignado
        //el claim 'Leer Rol' para poder utilizar el método.
        [Authorize(Policy = "LeerRolPolicy")]
        public IActionResult ListaRoles()
        {
            var roles = _gestionRoles.Roles;
            return View(roles);
        }

        //[dbo].[AspNetRoles]
        [HttpGet]
        [Route("Administracion/EditarRol")]
        //TODO:Se aplica la política 'EditarRolPolicy' establecida en el startup.cs
        //El usuario que quiera utilizar este método tiene que tener asignado
        //el claim 'Editar Rol' para poder utilizar el método.
        [Authorize(Policy = "EditarRolPolicy")]
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
        //TODO:Se aplica la política 'EditarRolPolicy' establecida en el startup.cs
        //El usuario que quiera utilizar este método tiene que tener asignado
        //el claim 'Editar Rol' para poder utilizar el método.
        [Authorize(Policy = "EditarRolPolicy")]       
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
                        return RedirectToAction("EditarRol", new { Id = roleId });
                    }
                }
            }
            return RedirectToAction("EditarRol", new { Id = roleId });
        }

        //[dbo].[AspNetUsers]
        [HttpGet]
        [Route("Administracion/ListaUsuarios")]
        public IActionResult ListaUsuarios()
        {
            var usuarios = this._gestionUsuarios.Users;
            return View(usuarios);
        }

        //[dbo].[AspNetUsers]
        [HttpGet]
        [Route("Administracion/EditarUsuario")]
        public async Task<IActionResult> EditarUsuario(string id)
        {
            var usuario = await this._gestionUsuarios.FindByIdAsync(id);
            if (usuario == null)
            {
                ViewBag.ErrorMessage = $"Usuario con id {id} no fue encontrado";
                return View("Error");
            }
            //TODO:Lista de las notificaciones
            //TODO: Claims nos permite la autenticación basada en notificaciones.
            //Donde la identidad del usuario se representa como un conjunto de notificaciones
            var usuarioClaims = await this._gestionUsuarios.GetClaimsAsync(usuario);
            //TODO: Lista de los roles de usuario.
            var usuarioRoles = await this._gestionUsuarios.GetRolesAsync(usuario);
            var model = new EditarUsuarioModel
            {
                Id = usuario.Id,
                Email = usuario.Email,
                NombreUsuario = usuario.UserName,
                ayudaPass = usuario.ayudaPass,
                Notificaciones = usuarioClaims.Select(x => (x.Type + ":" + x.Value)).ToList(),
                Roles = usuarioRoles
            };

            return View(model);
        }

        //[dbo].[AspNetUsers]
        [HttpPost]
        [Route("Administracion/EditarUsuario")]
        public async Task<IActionResult> EditarUsuario(EditarUsuarioModel model)
        {
            var usuario = await this._gestionUsuarios.FindByIdAsync(model.Id);
            if (usuario == null)
            {
                ViewBag.ErrorMessage = $"Usuario con id {model.Id} no fue encontrado";
                return View("Error");
            }
            else
            {
                usuario.Email = model.Email;
                usuario.UserName = model.NombreUsuario;
                usuario.ayudaPass = model.ayudaPass;

                var resultado = await this._gestionUsuarios.UpdateAsync(usuario);
                if (resultado.Succeeded)
                {
                    return RedirectToAction("ListaUsuarios");
                }

                foreach (var error in resultado.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(model);
            }

        }

        //[dbo].[AspNetUsers]
        [HttpPost]
        [Route("Administracion/BorrarUsuario")]
        public async Task<IActionResult> BorrarUsuario(string id)
        {
            var user = await this._gestionUsuarios.FindByIdAsync(id);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"Usuario con id {id} no fue encontrado";
                return View("Error");
            }
            else
            {
                var resultado = await this._gestionUsuarios.DeleteAsync(user);
                if (resultado.Succeeded)
                {
                    return RedirectToAction("ListaUsuarios");
                }

                foreach (var error in resultado.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View("ListaUsuarios");
            }
        }

        //[dbo].[AspNetRoles]
        [HttpPost]
        [Route("Administracion/BorrarRol")]
        //TODO:Se aplica la política 'BorrarRolPolicy' establecida en el startup.cs
        //El usuario que quiera utilizar este método tiene que tener asignado
        //el claim 'Borrar Rol' para poder utilizar el método.
        [Authorize(Policy = "BorrarRolPolicy")]
        public async Task<IActionResult> BorrarRol(string id)
        {
            var rol = await this._gestionRoles.FindByIdAsync(id);
            if (rol == null)
            {
                ViewBag.ErrorMessage = $"Rol con id {id} no fue encontrado";
                return View("Error");
            }
            else
            {
                try
                {
                    var result = await this._gestionRoles.DeleteAsync(rol);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("ListaRoles");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }

                    return View("ListaRoles");
                }
                catch (DbUpdateException ex)
                {
                    this._logger.LogError($"Se produjo un error al borrar el  rol: {ex}");
                    ViewBag.ErrorTitle = $"El rol {rol.Name} esta siendo utilizado";
                    ViewBag.ErrorMessage = $"El rol {rol.Name} no puede ser borrado porque contiene usuarios. Antes de borar el rol debe quitar los usuarios de dicho rol.";
                    return View("ErrorGenerico");
                }

            }
        }

        [HttpGet]
        [Route("Administracion/GestionarRolesUsuario")]
        public async Task<IActionResult> GestionarRolesUsuario(string idUsuario)
        {
            ViewBag.IdUsuario = idUsuario;
            var user = await this._gestionUsuarios.FindByIdAsync(idUsuario);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"Usuario con id {idUsuario} no fue encontrado";
                return View("Error");
            }

            var model = new List<RolUsuarioModel>();

            foreach (var rol in this._gestionRoles.Roles)
            {
                var rolUsuarioModel = new RolUsuarioModel
                {
                    RolId = rol.Id,
                    RolNombre = rol.Name
                };

                if (await this._gestionUsuarios.IsInRoleAsync(user, rol.Name))
                {
                    rolUsuarioModel.EstaSeleccionado = true;
                }
                else
                {
                    rolUsuarioModel.EstaSeleccionado = false;
                }
                model.Add(rolUsuarioModel);
            }

            return View(model);
        }

        [HttpPost]
        [Route("Administracion/GestionarRolesUsuario")]
        public async Task<IActionResult> GestionarRolesUsuario(List<RolUsuarioModel> model, string idUsuario)
        {
            var usuario = await this._gestionUsuarios.FindByIdAsync(idUsuario);
            if (usuario == null)
            {
                ViewBag.ErrorMessage = $"Usuario con id {usuario} no fue encontrado";
                return View("Error");
            }

            var roles = await this._gestionUsuarios.GetRolesAsync(usuario);
            var result = await this._gestionUsuarios.RemoveFromRolesAsync(usuario, roles);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "No se pudo borrar usuario con roles");
                return View(model);
            }

            result = await this._gestionUsuarios.AddToRolesAsync(usuario, model.Where(x => x.EstaSeleccionado).Select(y => y.RolNombre));

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "No se pudo añadir roles al usuario");
                return View(model);
            }

            return RedirectToAction("EditarUsuario", new { id = idUsuario });
        }

        //[dbo].[AspNetUserClaims] 
        [HttpGet]
        [Route("Administracion/GestionarClaimsUsuario")]
        public async Task<IActionResult> GestionarClaimsUsuario(string idUsuario)
        {
            var usuario = await this._gestionUsuarios.FindByIdAsync(idUsuario);
            if (usuario == null)
            {
                ViewBag.ErrorMessage = $"Usuario con id {usuario} no fue encontrado";
                return View("Error");
            }

            //TODO: Se obtienen todos los claims del usuario
            var existingUserClaims = await this._gestionUsuarios.GetClaimsAsync(usuario);
            var modelo = new UsuarioClaimsViewModel 
            {
                idUsuario = usuario.Id
            };

            //TODO: Se recorren los claims de la aplicación.
            foreach (Claim claim in AlmacenClaims.todosLosClaims)
            {
                UsuarioClaim usuarioClaim = new UsuarioClaim
                {
                    tipoClaim = claim.Type
                };

                //TODO: Si el usuario tiene el claim que se está recorriendo, entonces se selecciona.
                if (existingUserClaims.Any(x => x.Type == claim.Type && x.Value == "true"))
                {
                    usuarioClaim.estaSeleccionado = true;
                }

                modelo.Claims.Add(usuarioClaim);
            }

            return View(modelo);
        }

        //[dbo].[AspNetUserClaims] 
        [HttpPost]
        [Route("Administracion/GestionarClaimsUsuario")]
        public async Task<IActionResult> GestionarClaimsUsuario(UsuarioClaimsViewModel model)
        {
            var usuario = await this._gestionUsuarios.FindByIdAsync(model.idUsuario);
            if (usuario == null)
            {
                ViewBag.ErrorMessage = $"Usuario con id {model.idUsuario} no fue encontrado";
                return View("Error");
            }

            //TODO:Consulta los claims del usuario y se eliminan
            var claims = await this._gestionUsuarios.GetClaimsAsync(usuario);
            var result = await this._gestionUsuarios.RemoveClaimsAsync(usuario, claims);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "No se pudo borrar los claims del usuario");
                return View(model);
            }

            //TODO: Se asocian los nuevos claims
            result = await this._gestionUsuarios.AddClaimsAsync(usuario, model.Claims.Where(x => x.estaSeleccionado).Select(y => new Claim(y.tipoClaim, y.estaSeleccionado? "true":"false")));
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "No se pudo agregar claims al usuario");
                return View(model);
            }

            return RedirectToAction("EditarUsuario", new { id = model.idUsuario});
        }
    }
}
