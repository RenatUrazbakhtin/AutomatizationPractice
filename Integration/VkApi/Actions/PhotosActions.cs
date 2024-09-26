using Framework.Managers;
using Framework.Serializers;
using Integration.VkApi.Models;
using Integration.VkApi.Utils.Enums;
using Integration.VkApi.VkApiExecuter;
using RestSharp;

namespace Integration.VkApi.Actions
{
    public class PhotosActions
    {
        private const string getPhotoServer = "photos.getWallUploadServer";
        private const string saveWallPhoto = "photos.saveWallPhoto";
        private VkExecutionWithVersion VkExecution => new();

        public string GetPhotoId(string photoPath)
        {
            var result = UploadPhotoOnTheWall(GetWallPhotoUploadServer(), photoPath);
            return SaveUploadWallPhoto(result);
        }

        private string GetWallPhotoUploadServer()
        {
            var dict = new Dictionary<string, object>
            {
                {"user_id", ApiConfigManager.UserId},
            };

            RestResponse response = VkExecution.ExecuteGet(getPhotoServer, dict);

            var deserializedModel = JsonConverterUtil.DeserializeObject<WallUploadModel>(response.Content);
            return deserializedModel.Response.UploadUrl;
        }

        private PhotoModel UploadPhotoOnTheWall(string url, string filePath)
        {
            RestResponse response = VkExecution.ExecutePostWithFile(url, filePath, "photo", "multipart/form-data");

            var deserializedModel = JsonConverterUtil.DeserializeObject<PhotoModel>(response.Content);

            return deserializedModel;
        }

        private string SaveUploadWallPhoto(PhotoModel model)
        {
            var dict = new Dictionary<string, object>
            {
                {"user_id", ApiConfigManager.UserId},
                {"photo", model.Photo},
                {"server", model.Server},
                {"hash", model.Hash},
            };

            RestResponse response = VkExecution.ExecutePost(saveWallPhoto, dict);

            var deserializedList = JsonConverterUtil.DeserializeObject<SavedUploadModel>(response.Content);
            return deserializedList.Response[(int)Indexes.ElementsIndexes.First].Id.ToString();
        }
    }
}
