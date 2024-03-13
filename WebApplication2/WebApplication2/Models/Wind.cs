using System.Text.Json.Serialization;

namespace WebApplication2.Models
{

    public class Wind
    {
        [JsonPropertyName("speed")]
        public double speed { get; set; }

        [JsonPropertyName("deg")]
        public int deg { get; set; }

        [JsonPropertyName("gust")]
        public double gust { get; set; }

       

          public string GetWindDirection(int degree)
        {
            string[] directions = ["Nord", "Nordøst", "Øst", "Sydøst", "Syd", "Sydvest", "Vest", "Nordvest"];
            int index = (int)((degree / 45) + 0.5) % 8;
            return directions[index];
        }
    }



}
