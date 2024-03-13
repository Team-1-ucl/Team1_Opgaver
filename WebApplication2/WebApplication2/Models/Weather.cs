using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace WebApplication2.Models
{
    public class Weather
    {
        [JsonProperty("dt")]
        public int Dt;
        [JsonPropertyName("id")]
        public int id { get; set; }

        [JsonPropertyName("main")]
        public string main { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }

        [JsonPropertyName("icon")]
        public string icon { get; set; }

        [JsonProperty("clouds")]
        public Clouds Clouds;

       
      



    }





}
