using Aquality.Selenium.Browsers;
using Newtonsoft.Json;
using RestApi.RestApi.Models.Posts;
using RestApi.RestApi.Models.Users;

namespace RestApi.RestApi.Deserializing
{
    public class DeserializeObject
    {
        public static List<PostModel> DeserializeIntoListPostModel(string data)
        {
            AqualityServices.Logger.Info($"Desirializing {data} to list of PostModel");
            return JsonConvert.DeserializeObject<List<PostModel>>(data);
        }

        public static PostModel DeserializeIntoPostModel(string data)
        {
            AqualityServices.Logger.Info($"Desirializing {data} to PostModel");
            return JsonConvert.DeserializeObject<PostModel>(data);
        }

        public static UserModel DeserializeIntoUserModel(string data)
        {
            AqualityServices.Logger.Info($"Desirializing {data} to UserModel");
            return JsonConvert.DeserializeObject<UserModel>(data);
        }

        public static List<UserModel> DeserializeIntoListUserModel(string data)
        {
            AqualityServices.Logger.Info($"Desirializing {data} to list of UserModel");
            return JsonConvert.DeserializeObject<List<UserModel>>(data);
        }
    }
}
