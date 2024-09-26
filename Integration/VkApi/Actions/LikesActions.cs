using Framework.Managers;
using Framework.Serializers;
using Integration.VkApi.Models;
using Integration.VkApi.Utils.Enums;
using Integration.VkApi.VkApiExecuter;
using RestSharp;

namespace Integration.VkApi.Actions
{
    public class LikesActions
    {
        private const string wallGetLikes = "wall.getLikes";
        private VkExecutionWithVersion VkExecutionWithVersions => new();

        public string GetLikes(string postId)
        {
            var dict = new Dictionary<string, object>
            {
                {"owner_id", ApiConfigManager.UserId},
                {"post_id",  postId},
            };

            RestResponse response = VkExecutionWithVersions.ExecuteGet(wallGetLikes, dict);

            var deserializedModel = JsonConverterUtil.DeserializeObject<LikeModel>(response.Content);
            return deserializedModel.Response.Users[(int)Indexes.ElementsIndexes.First].Uid.ToString();
        }
    }
}
