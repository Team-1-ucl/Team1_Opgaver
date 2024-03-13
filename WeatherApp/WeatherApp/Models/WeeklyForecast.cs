using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace WeatherApp.Models
{
    public class WeeklyForecast
    {
        [JsonProperty("dt")]
        public int dt;
        public DayOfWeek Date => DateTime.UnixEpoch.AddSeconds(dt).DayOfWeek;
        public string Time => DateTime.UnixEpoch.AddSeconds(dt).ToShortTimeString();
        [JsonProperty("weather")]
        public List<Description> description;

        [JsonProperty("main")]
        public Temps temp;


    }
    public class Description
    {

    }
    public class Temps
    {

    }
}
