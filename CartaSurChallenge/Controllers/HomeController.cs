using System.Diagnostics;
using System.Threading.Tasks;
using CartaSurChallenge.Models;
using CartaSurChallenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace CartaSurChallenge.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IVentaService _ventaService;

        public HomeController(ILogger<HomeController> logger,
            IVentaService ventaService)
        {
            _logger = logger;
            _ventaService = ventaService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> DiaMasVenta()
        {
            var date = await _ventaService.GetDiaConMasVentas();
            return View(date);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
