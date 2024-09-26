using Newtonsoft.Json;

namespace Integration.VkApi.Models
{
    public class LikeResponse
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("users")]
        public List<User> Users { get; set; }
    }
    public class LikeModel
    {
        [JsonProperty("response")]
        public LikeResponse Response { get; set; }
    }

    public class User
    {
        [JsonProperty("uid")]
        public int Uid { get; set; }

        [JsonProperty("copied")]
        public int Copied { get; set; }
    }
}
