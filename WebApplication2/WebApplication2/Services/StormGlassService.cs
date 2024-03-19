using Newtonsoft.Json;
using System.Net.Http;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public class StormGlassService : IStormGlassService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public StormGlassService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<Root> GetStormglassDataAsync(double lat, double lng)
        {
            HttpClient client = _httpClientFactory.CreateClient("Stormglass");
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress + $"?lat={lat}&lng={lng}");
           
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                Root root = JsonConvert.DeserializeObject<Root>(responseBody);
                return root;
            }
            else
            {
                // Handle error
                return null;
            }
        }
    }
}
