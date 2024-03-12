namespace WeatherApp.Models
{
	public class WeatherServices
	{
		private readonly HttpClient _httpClient;

		public WeatherServices(IHttpClientFactory httpClientFactory)
		{
			_httpClient = httpClientFactory.CreateClient("WeatherClient");
		}

		public async Task<string> GetWeatherDataAsync(string url)
		{
			var response = await _httpClient.GetAsync(url);
			response.EnsureSuccessStatusCode();
			var content = await response.Content.ReadAsStringAsync();
			return content;
		}
	}
}
