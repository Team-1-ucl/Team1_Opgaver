﻿using Newtonsoft.Json;

namespace WebApplication2.Models
{
    public class Main
    {
        [JsonProperty("temp")]
        public double temp { get; set; }

        [JsonProperty("feels_like")]
        public double feels_like { get; set; }

        [JsonProperty("temp_min")]
        public double temp_min { get; set; }

        [JsonProperty("temp_max")]
        public double temp_max { get; set; }

        [JsonProperty("pressure")]
        public int pressure { get; set; }

        [JsonProperty("sea_level")]
        public int sea_level { get; set; }

        [JsonProperty("grnd_level")]
        public int grnd_level { get; set; }

        [JsonProperty("humidity")]
        public int humidity { get; set; }

        [JsonProperty("temp_kf")]
        public double temp_kf { get; set; }
    }



}
