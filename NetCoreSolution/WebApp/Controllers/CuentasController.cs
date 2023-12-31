﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Threading.Tasks;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    //TODO: Este controlador registra los usuarios que se almacenan en la tabla '[dbo].[AspNetUsers]' de base de datos.
    [Authorize]
    public class CuentasController : Controller
    {
        //TODO:
        //UserManager:Permite administrar y gestionar usuario;
        private readonly UserManager<UsuarioAplicacion> _gestionUsuarios;

        //TODO:
        //SignInManager:Contiene los métodos necesarios para que el usuario inicie sesión.
        private readonly SignInManager<UsuarioAplicacion> _gestionLogin;

        public CuentasController(UserManager<UsuarioAplicacion> gestionUsuarios, SignInManager<UsuarioAplicacion> gestionLogin)
        {
            this._gestionUsuarios = gestionUsuarios;
            this._gestionLogin = gestionLogin;
        }

        [HttpGet]
        [Route("Cuentas/Registro")]
        //TODO: '[AllowAnonymous]' Permite que se acceda a esta funcionalidad así haya una restricción '[Authorize]' a nivel de clase.
        [AllowAnonymous]
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        [Route("Cuentas/Registro")]
        //TODO: '[AllowAnonymous]' Permite que se acceda a esta funcionalidad así haya una restricción '[Authorize]' a nivel de clase.
        [AllowAnonymous]
        public async Task<IActionResult> Registro(RegistroModelo model)
        {
            //Valida que cumpla las expresiones regulares definidas en el modelo.
            if (ModelState.IsValid)
            {
                //Volcamos los datos de la clase Registro Modelo a la clase IdentityUSer.
                var usuario = new UsuarioAplicacion
                {
                    UserName = model.Email,
                    Email = model.Email,
                    ayudaPass = model.ayudaPass
                };

                //Guardamos datos de usuario en la tabla 'AspNetUsers' de base de datos .
                var resultado = await this._gestionUsuarios.CreateAsync(usuario, model.Password);

                //Si el usuario se creó correctamente se redirige a la página de inicio, salvo que sea administrador
                if (resultado.Succeeded)
                {
                    if (this._gestionLogin.IsSignedIn(User) && User.IsInRole("Administrador"))
                    {
                        return RedirectToAction("ListaUsuarios", "Administracion");
                    }
                    await this._gestionLogin.SignInAsync(usuario, isPersistent:false);
                    return RedirectToAction("Index4", "Home");
                }

                //Controlamos el error en el caso que se produzca.
                foreach (var error in resultado.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }

        [HttpPost]
        [Route("Cuentas/CerrarSesion")]
        public async Task<IActionResult> CerrarSesion()
        {
            await this._gestionLogin.SignOutAsync();
            return RedirectToAction("Index4", "Home");
        }

        [HttpGet]
        [Route("Cuentas/Login")]
        //TODO: '[AllowAnonymous]' Permite que se acceda a esta funcionalidad así haya una restricción '[Authorize]' a nivel de clase.
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("Cuentas/Login")]
        //TODO: '[AllowAnonymous]' Permite que se acceda a esta funcionalidad así haya una restricción '[Authorize]' a nivel de clase.
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModelo model)
        {
            if (ModelState.IsValid)
            {
                var result = await _gestionLogin.PasswordSignInAsync(model.Email, model.Password, model.Recuerdame, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index4", "Home");
                }
                ModelState.AddModelError(string.Empty, "Inicio de sesión no valido");
            }
            return View();
        }

        //TODO: Método que valida si ya existe una cuenta de correo para un nuevo registro de usuario.
        //La asociación de esta validación con el campo está en la propiedad 'Email' de la clase 'RegistroModelo'
        [AcceptVerbs("Get", "Post")]
        [Route("Cuentas/ComprobarEmail")]
        [AllowAnonymous]
        public async Task<IActionResult> ComprobarEmail(string email)
        {
            var user = await _gestionUsuarios.FindByEmailAsync(email);
            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"El email {email} no esta disponible.");
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("Cuentas/AccesoDenegado")]
        public IActionResult AccesoDenegado()
        {
            return View();
        }
    }
}
