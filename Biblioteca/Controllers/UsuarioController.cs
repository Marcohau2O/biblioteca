using Biblioteca.Models.Servicios.IServices;
using Biblioteca.Models.Servicios.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioServices _usuaarioServices;

        public UsuarioController (IUsuarioServices usuaarioServices)
        {
           _usuaarioServices = usuaarioServices;
        }
        public IActionResult Index()
        {
            var result = _usuaarioServices.GetUsuarios();
            return View(result);
        }
    }
}
