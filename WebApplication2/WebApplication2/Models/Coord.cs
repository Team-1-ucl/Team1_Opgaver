using Newtonsoft.Json;

namespace WebApplication2.Models
{
    public class Coord
    {
        [JsonProperty("lat")]
        public double lat { get; set; }

        [JsonProperty("lon")]
        public double lon { get; set; }
    }



}
