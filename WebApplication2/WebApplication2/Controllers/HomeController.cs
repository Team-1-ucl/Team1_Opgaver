using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using WebApplication2.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            Root root = await GetWeatherAsync("Borup");
            return View(root);
        }

        public async Task<Root> GetWeatherAsync(string City)
        {
            HttpClient client = new()
            {
                BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/forecast")
            };


            var response = await client.GetStringAsync(client.BaseAddress + $"?q={City}&appid=747bcc2140e625521d195c8cb07c6ef0");

            var weatherData = JsonConvert.DeserializeObject<Root>(response);
            

            return weatherData;
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
