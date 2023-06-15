using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private IAmigoAlmacen _amigoAlmacen;
        public HomeController(IAmigoAlmacen amigoAlmacen)
        {
            _amigoAlmacen = amigoAlmacen;
        }

        public string Index()
        {
            return _amigoAlmacen.dameDatosAmigo(1).Email;
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
            Amigo modelo1 = _amigoAlmacen.dameDatosAmigo(1);
            ViewData["cabecera"] = "Lista Amigos ViewData";
            ViewData["amigo1"] = modelo1;

            //Con viewbag usamos propiedades dinámicas y no claves de cadena
            Amigo modelo2 = _amigoAlmacen.dameDatosAmigo(2);
            ViewBag.Titulo = "Lista amigos ViewBag";
            ViewBag.Amigo2 = modelo2;

            Amigo modelo3 = _amigoAlmacen.dameDatosAmigo(3);
            return View(modelo3);
        }

        public JsonResult Index2()
        {
            return Json(new { id=2, nombre = "Cesar"});
        }

        public ViewResult Index3()
        {
            Amigo modelo = _amigoAlmacen.dameDatosAmigo(3);
            return View("~/MisVistas/Index.cshtml");
        }

    }
}
