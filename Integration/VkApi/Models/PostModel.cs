using Newtonsoft.Json;

namespace Integration.VkApi.Models
{
    public class Response
    {
        [JsonProperty("post_id")]
        public int PostId { get; set; }
    }

    public class Root
    {
        [JsonProperty("response")]
        public Response Response { get; set; }
    }
}
