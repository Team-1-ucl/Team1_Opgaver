using Newtonsoft.Json;

namespace WebApplication2.Models
{
    public class WeeklyForecast
    {

        //[JsonProperty("weather")]
        //public List<Weather> WeatherList { get; set; }


        [JsonProperty("dt")]
        public int Dt;

        public DayOfWeek Date => DateTime.UnixEpoch.AddSeconds(Dt).DayOfWeek;

        public string Time => DateTime.UnixEpoch.AddSeconds(Dt).ToShortTimeString();

        [JsonProperty("rain")]
        public Rain Rain{ get; set; }

        [JsonProperty("wind")]
        public Wind Wind;

    }





}
