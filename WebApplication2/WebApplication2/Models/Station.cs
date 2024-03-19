using Newtonsoft.Json;

namespace WebApplication2.Models
{
    public class Station
    {
        [JsonProperty("distance")]
        public int distance { get; set; }

        [JsonProperty("lat")]
        public double lat { get; set; }

        [JsonProperty("lng")]
        public double lng { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("source")]
        public string source { get; set; }
    }
}
