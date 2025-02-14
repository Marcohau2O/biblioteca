using Biblioteca.Models.Domain;
using Biblioteca.Models.Servicios.IServices;
using Biblioteca.Models.Servicios.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Biblioteca.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioServices _usuaarioServices;
        private readonly IRolServices _rolServices;

        public UsuarioController (IUsuarioServices usuaarioServices, IRolServices rolServices)
        {
            _usuaarioServices = usuaarioServices;
            _rolServices = rolServices;
        }
        public IActionResult Index()
        {
            var result = _usuaarioServices.GetUsuarios();
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Crear()
        {
            List<Rol> result = await _rolServices.GetAllRol();
            ViewBag.Roles = result.Select(p => new SelectListItem()
            {
                Text = p.Nombre,
                Value = p.PkRol.ToString()
            });

            return View();
        }

        [HttpPost]
        public IActionResult Create(Usuario req)
        {
            var result = _usuaarioServices.Create(req);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            List<Rol> Rol = await _rolServices.GetAllRol();
            ViewBag.Roles = Rol.Select(p => new SelectListItem()
            {
                Text = p.Nombre,
                Value = p.PkRol.ToString()
            });

            var result = _usuaarioServices.GetbyId(id);

            return View(result);
        }
    }
}
