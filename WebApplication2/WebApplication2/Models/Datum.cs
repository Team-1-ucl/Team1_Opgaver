using Newtonsoft.Json;

namespace WebApplication2.Models
{
    public class Datum
    {
        [JsonProperty("height")]
        public double height { get; set; }

        [JsonProperty("time")]
        public DateTime time { get; set; }

        [JsonProperty("type")]
        public string type { get; set; }
    }
}
