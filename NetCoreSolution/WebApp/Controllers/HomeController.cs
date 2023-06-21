using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private IAmigoAlmacen _amigoAlmacen;
        private IHostingEnvironment _hosting;
        public HomeController(IAmigoAlmacen amigoAlmacen, IHostingEnvironment hosting)
        {
            _amigoAlmacen = amigoAlmacen;
            _hosting = hosting;
        }

        [Route("")]
        [Route("Home")]
        [Route("Home/Index")]
        public string Index()
        {
            Amigo amigo = _amigoAlmacen.dameDatosAmigo(1);
            return amigo != null ? amigo.Email : "sin email";            
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

            if (detalles.Amigo == null)
            {
                Response.StatusCode = 404;
                return View("AmigoNotFound", id);
            }

            return View(detalles);
        }

        [Route("Home/Create")]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Home/Create")]
        public IActionResult Create(CrearAmigoModel amigo)
        {
            //TODO: Se realiza la validacion de modelo respecto a las etiquetas establecidas en el modelo 
            if (ModelState.IsValid)
            {
                string guidImagen = null;
                //TODO: Si se adjunta imagen, entonces se escribe la imagen localmente en wwwroot/images
                if (amigo.Foto != null)
                {
                    string ficherosImagenes = Path.Combine(_hosting.WebRootPath, "images");
                    guidImagen = $"{Guid.NewGuid().ToString()}-{amigo.Foto.FileName}";
                    string rutaDefinitiva = Path.Combine(ficherosImagenes, guidImagen);
                    //amigo.Foto.CopyTo(new FileStream(rutaDefinitiva, FileMode.Create));
                    using (var filestream = new FileStream(rutaDefinitiva, FileMode.Create))
                    {
                        amigo.Foto.CopyTo(filestream);
                    }
                }

                Amigo nuevoAmigo = new Amigo();
                nuevoAmigo.Nombre = amigo.Nombre;
                nuevoAmigo.Email = amigo.Email;
                nuevoAmigo.Ciudad = amigo.Ciudad;
                nuevoAmigo.ProfilePictureUrl = amigo.ProfilePictureUrl;
                nuevoAmigo.LocalPathImage = guidImagen;

                _amigoAlmacen.nuevo(nuevoAmigo);
                return RedirectToAction("Details5", new { id = nuevoAmigo.Id });
            }
            return View();
        }

        [HttpGet]        
        [Route("Home/Edit/{id}")]
        public ViewResult Edit(int id)
        {
            Amigo amigo = _amigoAlmacen.dameDatosAmigo(id);
            EditarAmigoModel amigoEditar = new EditarAmigoModel
            {
                Id = amigo.Id,
                Nombre = amigo.Nombre,
                Email = amigo.Email,
                Ciudad = amigo.Ciudad,
                ProfilePictureUrl = amigo.ProfilePictureUrl,
                rutaFotoLocalExistente = amigo.LocalPathImage
            };

            return View(amigoEditar);
        }

        [HttpPost]
        [Route("Home/Edit")]
        public IActionResult EditFriend(EditarAmigoModel model)
        {
            //TODO: Se realiza la validacion de modelo respecto a las etiquetas establecidas en el modelo 
            if (ModelState.IsValid)
            {
                Amigo amigo = _amigoAlmacen.dameDatosAmigo(model.Id);
                amigo.Nombre = model.Nombre;
                amigo.Email = model.Email;
                amigo.Ciudad = model.Ciudad;
                amigo.ProfilePictureUrl = model.ProfilePictureUrl;
                if (model.Foto != null)
                {
                    if (model.rutaFotoLocalExistente != null)
                    {
                        string ruta = Path.Combine(_hosting.WebRootPath, "images", model.rutaFotoLocalExistente);
                        System.IO.File.Delete(ruta);
                    }
                    amigo.LocalPathImage = SubirImagen(model);
                }
                Amigo amigoModificado = _amigoAlmacen.modificar(amigo);
                return RedirectToAction("Index4");
            }
            return View(model);
        }

        private string SubirImagen(EditarAmigoModel model)
        {
            string nombreFichero = string.Empty;
            if (model.Foto != null)
            {
                string carpetaSubida = Path.Combine(_hosting.WebRootPath, "images");
                nombreFichero = $"{Guid.NewGuid().ToString()}-{model.Foto.FileName}";
                string ruta = Path.Combine(carpetaSubida, nombreFichero);
                using (var filestream = new FileStream(ruta, FileMode.Create))
                {
                    model.Foto.CopyTo(filestream);
                }
            }
            return nombreFichero;
        }
    }
}
