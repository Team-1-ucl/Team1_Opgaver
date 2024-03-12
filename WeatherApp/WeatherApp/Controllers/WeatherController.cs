using Microsoft.AspNetCore.Mvc;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
	public class WeatherController : Controller
	{
		private const string ApiKey = "0f139d5ac964cb89e2a5b912793d3704";

		private const string BaseUrl = "http://api.openweathermap.org/data/3.0/weather";

		private readonly WeatherServices _weatherServices;
        public WeatherController(WeatherServices weatherServices)
        {
            _weatherServices = weatherServices;
        }

		public async Task<IActionResult> Index()
		{
			var WeatherData = await _weatherServices.GetWeatherDataAsync("WeatherClient");
			return View(WeatherData);
		}

		public async Task<IActionResult> GetWeather()
		{
			
			return OK();
		}

	}
}
