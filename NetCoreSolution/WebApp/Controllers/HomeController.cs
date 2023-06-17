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

        [Route("")]
        [Route("Home")]
        [Route("Home/Index")]
        public string Index()
        {
            return _amigoAlmacen.dameDatosAmigo(1).Email;
        }

        [Route("Home/Index1")]
        public string Index1()
        {
            return _amigoAlmacen.dameDatosAmigo(1).Email;
        }

        [Route("Home/Index2")]
        public JsonResult Index2()
        {
            return Json(new { id = 2, nombre = "Cesar" });
        }

        [Route("Home/Index3")]
        public ViewResult Index3()
        {
            Amigo modelo = _amigoAlmacen.dameDatosAmigo(3);
            return View("~/MisVistas/Index.cshtml");
        }

        [Route("Home/Index4")]
        public ViewResult Index4()
        {
            var modelo = _amigoAlmacen.dameTodosLosAmigos();
            return View(modelo);
        }

        [Route("Home/Details1")]
        public JsonResult Details1()
        {
            Amigo modelo = _amigoAlmacen.dameDatosAmigo(1);
            return Json(modelo);
        }

        [Route("Home/Details2")]
        public ViewResult Details2()
        {
            Amigo modelo = _amigoAlmacen.dameDatosAmigo(1);
            return View(modelo);
        }

        [Route("Home/Details3")]
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

        [Route("Home/Details4")]
        public ViewResult Details4()
        {            
            DetallesView detalles = new DetallesView();
            detalles.Titulo = "Lista Amigos View Models";
            detalles.Subtitulo = "Mis detalles";
            detalles.Amigo = _amigoAlmacen.dameDatosAmigo(3);

            return View(detalles);
        }

        [Route("Home/Details5/{id?}")]
        public ViewResult Details5(int? id)
        {
            DetallesView detalles = new DetallesView();
            detalles.Titulo = "Lista Amigos View Models";
            detalles.Subtitulo = "Mis detalles";
            detalles.Amigo = _amigoAlmacen.dameDatosAmigo(id?? 1);

            return View(detalles);
        }

        [Route("Home/Create")]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Home/Create")]
        public IActionResult Create(Amigo amigo)
        {
            //TODO: Se realiza la validacion de modelo respecto a las etiquetas establecidas en el modelo 
            if (ModelState.IsValid)
            {
                Amigo amigoModel = _amigoAlmacen.nuevo(amigo);
                return RedirectToAction("Details5", new { id = amigo.Id });
            }
            return View();
        }
    }
}
