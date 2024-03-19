using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using WebApplication2.Models;
using WebApplication2.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApplication2.Controllers.v2
{
    [ApiController]
    [ApiVersion("2")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMyWeatherService _myWeatherService;
        private readonly IStormGlassService _stormGlassService;

        public HomeController(ILogger<HomeController> logger, IMyWeatherService myWeatherService, IStormGlassService stormGlassService)
        {
            _logger = logger;
            _myWeatherService = myWeatherService;
            _stormGlassService = stormGlassService;
        }


        public async Task<IActionResult> Index(string city, int daysToShow, string units, double lat, double lng)
        {
            ViewData["DaysToShow"] = daysToShow;
            Root openWeatherMapData = await _myWeatherService.GetWeatherAsync(city, units);
            Root stormGlassData = await _stormGlassService.GetStormglassDataAsync(lat, lng);

            ViewBag.OpenWeatherMapData = openWeatherMapData;
            ViewBag.StormGlassData = stormGlassData;
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
