using Newtonsoft.Json;

namespace WebApplication2.Models
{
    public class Meta
    {
        [JsonProperty("cost")]
        public int cost { get; set; }

        [JsonProperty("dailyQuota")]
        public int dailyQuota { get; set; }

        [JsonProperty("datum")]
        public string datum { get; set; }

        [JsonProperty("end")]
        public string end { get; set; }

        [JsonProperty("lat")]
        public double lat { get; set; }

        [JsonProperty("lng")]
        public double lng { get; set; }

        [JsonProperty("requestCount")]
        public int requestCount { get; set; }

        [JsonProperty("start")]
        public string start { get; set; }

        [JsonProperty("station")]
        public Station station { get; set; }
    }
}
