using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace WeatherApp.Models
{
	public class Weather
	{
		[JsonProperty("list")]
		public List<WeeklyForecast>? WeatherList { get; set; }

	}
}
