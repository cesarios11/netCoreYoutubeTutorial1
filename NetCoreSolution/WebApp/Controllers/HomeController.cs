using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private IAmigoAlmacen _amigoAlmacen;
        public HomeController(IAmigoAlmacen amigoAlmacen)
        {
            _amigoAlmacen = amigoAlmacen;
        }

        public string Index1()
        {
            return _amigoAlmacen.dameDatosAmigo(1).Email;
        }

        public JsonResult Index2()
        {
            return Json(new { id = 2, nombre = "Cesar" });
        }

        public ViewResult Index3()
        {
            Amigo modelo = _amigoAlmacen.dameDatosAmigo(3);
            return View("~/MisVistas/Index.cshtml");
        }

        public ViewResult Index4()
        {
            var modelo = _amigoAlmacen.dameTodosLosAmigos();
            return View(modelo);
        }

        public JsonResult Details1()
        {
            Amigo modelo = _amigoAlmacen.dameDatosAmigo(1);
            return Json(modelo);
        }

        public ViewResult Details2()
        {
            Amigo modelo = _amigoAlmacen.dameDatosAmigo(1);
            return View(modelo);
        }

        public ViewResult Details3()
        {
            //TODO:Con viewData usamos claves de texto.
            Amigo modelo1 = _amigoAlmacen.dameDatosAmigo(1);
            ViewData["cabecera"] = "Lista Amigos ViewData";
            ViewData["amigo1"] = modelo1;

            //TODO:Con viewbag usamos propiedades dinámicas y no claves de cadena
            Amigo modelo2 = _amigoAlmacen.dameDatosAmigo(2);
            ViewBag.Titulo = "Lista amigos ViewBag";
            ViewBag.Amigo2 = modelo2;

            //TODO:Utilizando un modelo fuertemente tipado.
            Amigo modelo3 = _amigoAlmacen.dameDatosAmigo(3);
            return View(modelo3);
        }

        public ViewResult Details4()
        {            
            DetallesView detalles = new DetallesView();
            detalles.Titulo = "Lista Amigos View Models";
            detalles.Subtitulo = "Mis detalles";
            detalles.Amigo = _amigoAlmacen.dameDatosAmigo(3);

            return View(detalles);
        }
    }
}
