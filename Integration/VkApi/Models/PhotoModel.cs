using Newtonsoft.Json;

namespace Integration.VkApi.Models
{
    public class PhotoModel
    {
        [JsonProperty("server")]
        public string Server { get; set; }

        [JsonProperty("photo")]
        public string Photo { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }
    }
}
