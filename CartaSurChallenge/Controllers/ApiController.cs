using CartaSurChallenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace CartaSurChallenge.Controllers
{
    public class ApiController : Controller
    {
        private readonly IApiService _apiService;

        public ApiController(IApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var date = await _apiService.GetApiStatusAsync();
            return View(date);
        }
    }
}
