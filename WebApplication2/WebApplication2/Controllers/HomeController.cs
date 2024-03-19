using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using WebApplication2.Models;
using WebApplication2.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMyWeatherService _myWeatherService;

        public HomeController(ILogger<HomeController> logger, IMyWeatherService myWeatherService)
        {
            _logger = logger;
            _myWeatherService = myWeatherService;
        }

        
        public async Task<IActionResult> Index(string city, int daysToShow, string units)
        {
            ViewData["DaysToShow"] = daysToShow;
            Root root = await _myWeatherService.GetWeatherAsync(city, units);
            return View(root);
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
