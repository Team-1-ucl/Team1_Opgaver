using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace WeatherApp.Models
{
	public class WeatherServices
	{
		private readonly HttpClient _httpClient;

		public WeatherServices(IHttpClientFactory httpClientFactory)
		{
			_httpClient = httpClientFactory.CreateClient("WeatherClient");
		}

		public async Task<IActionResult> Index()
		{
            Weather weather = await GetWeatherDataAsync();
			return View(weather);
        }

        public async Task<Weather> GetWeatherDataAsync()
		{
			HttpClient client = new()
			{
				BaseAddress = new Uri("https://api.openweathermap.org/data/3.0/")
			};
				
			var response = await client.GetStringAsync(client.BaseAddress + "forecast?lat=90&lon=90&appid=0f139d5ac964cb89e2a5b912793d3704");

			Weather? weatherResponse = JsonConvert.DeserializeObject<Weather?>(response);
			return weatherResponse ?? new Weather();
		}
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore =true)]
		public async Task<IActionResult> Error()
		{
			Weather weather = await GetWeatherDataAsync();
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		public IActionResult Privacy()
		{
			return View();
		}
	}
}
