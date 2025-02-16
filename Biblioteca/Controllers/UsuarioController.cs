using Biblioteca.Context;
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

        public UsuarioController(IUsuarioServices usuaarioServices, IRolServices rolServices)
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

        [HttpPost]
        public IActionResult Editar(Usuario usuario)
        {
            try
            {
                if (usuario == null)
                {
                    ModelState.AddModelError("", "Datos inválidos.");
                    return View(usuario);
                }

                var editado = _usuaarioServices.Editar(usuario);

                if (editado != null)
                {
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", "Error al editar el usuario.");
                return View(usuario);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al editar: " + ex.Message);
                return View(usuario);
            }
        }

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            var result = _usuaarioServices.EliminarUsuario(id);

            if (result)
            {
                TempData["SuccessMessage"] = "Usuario Eliminado Correctamenete";
            }
            else
            {
                TempData["ErrorMessage"] = "No se Pudo Eliminar el Usuario";
            }

            return RedirectToAction("Index");
        }
    }
}
