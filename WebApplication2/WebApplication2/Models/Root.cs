using Newtonsoft.Json;

namespace WebApplication2.Models
{
    public class Root
    {
        #region My Weather API
        [JsonProperty("cod")]
        public string cod { get; set; }

        [JsonProperty("message")]
        public int message { get; set; }

        [JsonProperty("cnt")]
        public int cnt { get; set; }

        [JsonProperty("list")]
        public List<List> list { get; set; }

        [JsonProperty("city")]
        public City city { get; set; }

        #endregion


        [JsonProperty("data")]
        public List<Datum> data { get; set; }

        [JsonProperty("meta")]
        public Meta meta { get; set; }


    }



}
