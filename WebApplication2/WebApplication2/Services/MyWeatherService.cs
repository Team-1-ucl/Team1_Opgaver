using Newtonsoft.Json;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public class MyWeatherService : IMyWeatherService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public MyWeatherService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<Root> GetWeatherAsync(string city, int cnt)
        {
            HttpClient client = _httpClientFactory.CreateClient("Weather");

            
            
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress + $"?&cnt={cnt}&q={city}&appid=747bcc2140e625521d195c8cb07c6ef0");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                Root weatherData = JsonConvert.DeserializeObject<Root>(responseBody);
                return weatherData;
            }
            else
            {
                // Håndter fejl
                return null;
            }
        }
        public async Task<Root> GetWeatherAsync(string city)
        {
            HttpClient client = _httpClientFactory.CreateClient("Weather");


            HttpResponseMessage response = await client.GetAsync(client.BaseAddress + $"?q={city}&appid=747bcc2140e625521d195c8cb07c6ef0");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                Root weatherData = JsonConvert.DeserializeObject<Root>(responseBody);
                return weatherData;
            }
            else
            {
                // Håndter fejl
                return null;
            }
        }
    }
}
