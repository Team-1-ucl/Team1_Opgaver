using Newtonsoft.Json;

namespace WebApplication2.Models
{
    public class List
    {
        [JsonProperty("dt")]
        public int dt { get; set; }
        
        public DayOfWeek Date => DateTime.UnixEpoch.AddSeconds(dt).DayOfWeek;

        public string Time => DateTime.UnixEpoch.AddSeconds(dt).ToShortTimeString();

        [JsonProperty("main")]
        public Main main { get; set; }

        [JsonProperty("weather")]
        public List<Weather> weather { get; set; }

        [JsonProperty("clouds")]
        public Clouds clouds { get; set; }

        [JsonProperty("wind")]
        public Wind wind { get; set; }

        [JsonProperty("visibility")]
        public int visibility { get; set; }

        [JsonProperty("pop")]
        public double pop { get; set; }

        [JsonProperty("sys")]
        public Sys sys { get; set; }

        [JsonProperty("dt_txt")]
        public string dt_txt { get; set; }

        [JsonProperty("rain")]
        public Rain rain { get; set; }
    }



}
