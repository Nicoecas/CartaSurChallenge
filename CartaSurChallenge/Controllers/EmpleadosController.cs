using CartaSurChallenge.Models;
using CartaSurChallenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace CartaSurChallenge.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly IEmpleadoService _empleadoService;

        public EmpleadosController(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var date = await _empleadoService.GetEmpleados();
            return View(date);
        }


        [HttpPost]
        public async Task<IActionResult> CargarEmpleado(EmpleadosModel model)
        {
            if (ModelState.IsValid)
            {
                await _empleadoService.GuardarEmpleado(model);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
