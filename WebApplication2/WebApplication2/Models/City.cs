using Newtonsoft.Json;

namespace WebApplication2.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class City
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("coord")]
        public Coord coord { get; set; }

        [JsonProperty("country")]
        public string country { get; set; }

        [JsonProperty("population")]
        public int population { get; set; }

        [JsonProperty("timezone")]
        public int timezone { get; set; }

        [JsonProperty("sunrise")]
        public int sunrise { get; set; }

        [JsonProperty("sunset")]
        public int sunset { get; set; }
    }



}
