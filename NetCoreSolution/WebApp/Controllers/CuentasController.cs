using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class CuentasController : Controller
    {
        //TODO:
        //UserManager:Permite administrar y gestionar usuario;
        private readonly UserManager<IdentityUser> _gestionUsuarios;

        //TODO:
        //SignInManager:Contiene los métodos necesarios para que el usuario inicie sesión.
        private readonly SignInManager<IdentityUser> _gestionLogin;

        public CuentasController(UserManager<IdentityUser> gestionUsuarios, SignInManager<IdentityUser> gestionLogin)
        {
            this._gestionUsuarios = gestionUsuarios;
            this._gestionLogin = gestionLogin;
        }

        [HttpGet]
        [Route("Cuentas/Registro")]
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        [Route("Cuentas/Registro")]
        public async Task<IActionResult> Registro(RegistroModelo model)
        {
            //Valida que cumpla las expresiones regulares definidas en el modelo.
            if (ModelState.IsValid)
            {
                //Volcamos los datos de la clase Registro Modelo a la clase IdentityUSer.
                var usuario = new IdentityUser
                {
                    UserName = model.Email,
                    Email = model.Email
                };

                //Guardamos datos de usuario en la tabla 'AspNetUsers' de base de datos .
                var resultado = await this._gestionUsuarios.CreateAsync(usuario, model.Password);

                //Si el usuario se creó correctamente se redirige a la página de inicio.
                if (resultado.Succeeded)
                {
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
        public IActionResult Login()
        {
            return View();
        }
    }
}
