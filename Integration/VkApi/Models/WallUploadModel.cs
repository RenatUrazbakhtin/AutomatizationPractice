using Newtonsoft.Json;

namespace Integration.VkApi.Models
{
    public class ResponseWallUpload
    {
        [JsonProperty("album_id")]
        public int AlbumId { get; set; }

        [JsonProperty("upload_url")]
        public string UploadUrl { get; set; }

        [JsonProperty("user_id")]
        public int UserId { get; set; }
    }

    public class WallUploadModel
    {
        [JsonProperty("response")]
        public ResponseWallUpload Response { get; set; }
    }
}
