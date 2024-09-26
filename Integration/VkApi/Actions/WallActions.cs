using Framework.Managers;
using Framework.Serializers;
using Integration.VkApi.Models;
using Integration.VkApi.VkApiExecuter;
using RestSharp;

namespace Integration.VkApi.Actions
{
    public class WallActions
    {
        private const string wallPost = "wall.post";
        private const string wallEdit = "wall.edit";
        private const string wallCreateComment = "wall.createComment";
        private const string wallDelete = "wall.delete";
        private VkExecutionWithVersion VkExecution => new();
        private PhotosActions PhotosActions => new();


        public string MakePostOnWall(string postMessage)
        {
            var dict = new Dictionary<string, object>
            {
                {"message", postMessage},
            };

            RestResponse response = VkExecution.ExecutePost(wallPost, dict);

            var deserializedModel = JsonConverterUtil.DeserializeObject<Root>(response.Content.ToString());
            return deserializedModel.Response.PostId.ToString();
        }

        public string EditPostOnWall(string postId, string message, string photoPath)
        {
            var photoId = PhotosActions.GetPhotoId(photoPath);

            var dict = new Dictionary<string, object>
            {
                {"post_id", postId},
                {"message", message},
                {"attachments", $"photo{ApiConfigManager.UserId}_{photoId}"},
            };

            VkExecution.ExecutePost(wallEdit, dict);

            return photoId;
        }

        public void CreateComment(string postId, string message)
        {
            var dict = new Dictionary<string, object>
            {
                {"owner_id", ApiConfigManager.UserId},
                {"post_id", postId},
                {"message", message},
            };

            VkExecution.ExecutePost(wallCreateComment, dict);
        }

        public void DeletePostOnWall(string postId)
        {
            var dict = new Dictionary<string, object>
            {
                {"owner_id", ApiConfigManager.UserId},
                {"post_id", postId},
            };

            VkExecution.ExecutePost(wallDelete, dict);
        }
    }
}
