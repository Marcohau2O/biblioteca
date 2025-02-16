using Biblioteca.Models.Domain;
using Biblioteca.Models.Servicios.IServices;
using Biblioteca.Models.Servicios.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class RolesController : Controller
    {
        private readonly IRolServices _rolServices;

        public RolesController(IRolServices rolServices)
        {
            _rolServices = rolServices;
        }
        public IActionResult IndexRol()
        {
            var results = _rolServices.GetRol();
            return View(results);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Rol req)
        {
            var result = _rolServices.Create(req);
            return RedirectToAction(nameof(IndexRol));
        }

        //Editar Agusto
        [HttpGet]
        public IActionResult Editar(int id)
        {
            var rol = _rolServices.GetRolById(id);

            return View(rol);
        }

        [HttpPost]
        public IActionResult Editar(Rol rol)
        {
            try
            {
                if (rol == null)
                {
                    ModelState.AddModelError("", "Datos invalidos");
                    return View(rol);
                }

                var editado = _rolServices.Editar(rol);

                if (editado != null)
                {
                    return RedirectToAction("IndexRol");
                }

                ModelState.AddModelError("", "Errol al Editar el Rol");
                return View(rol);

            } catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al editar: " + ex.Message);
                return View(rol);
            }
        }

        //Eliminar
        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            var result = _rolServices.EliminarRol(id);

            if (result)
            {
                TempData["SuccessMessage"] = "Rol Eliminado Correctamente";
            } else
            {
                TempData["ErrorMessage"] = "No se Pudo Eliminar el Rol";
            }

            return RedirectToAction("IndexRol");
        }
    }
}
