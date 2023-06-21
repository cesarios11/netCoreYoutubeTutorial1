using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApp.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> _logger;
        public ErrorController(ILogger<ErrorController> logger)
        {
                this._logger = logger;
        }

        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "El recurso solicitado no existe";
                    break;
            }
            return View("Error");
        }

        [AllowAnonymous]
        [Route("Error")]
        public IActionResult Error()
        {
            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewBag.ExceptionPath = exceptionHandlerPathFeature.Path;
            ViewBag.ExceptionMessage = exceptionHandlerPathFeature.Error.Message;
            ViewBag.ExceptionStackTrace = exceptionHandlerPathFeature.Error.StackTrace;
            this._logger.LogError($"Ruta del error: {exceptionHandlerPathFeature.Path}" + $" Excepcion: {exceptionHandlerPathFeature.Error.Message}" + $" Traza del error: {exceptionHandlerPathFeature.Error.StackTrace}");

            return View("ErrorGenerico");
        }

    }
}
