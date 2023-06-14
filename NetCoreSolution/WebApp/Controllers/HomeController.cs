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
        public JsonResult Index2()
        {
            return Json(new { id=2, nombre = "Cesar"});
        }
    }
}
