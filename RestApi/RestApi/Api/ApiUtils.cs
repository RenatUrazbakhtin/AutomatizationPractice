using Aquality.Selenium.Browsers;
using RestApi.RestApi.ConfigData;
using RestApi.RestApi.Deserializing;
using RestApi.RestApi.Models.Posts;
using System.Text;

namespace RestApi.RestApi.Api
{
    public class ApiUtils
    {
        private static string posts = "/posts/";
        private static string users = "/users/";
        private static HttpClient client => new()
        { BaseAddress = new Uri(ConfigurationManager.Url) };

        public static HttpResponseMessage GetAllPosts()
        {
            AqualityServices.Logger.Info($"Getting all posts from {ConfigurationManager.Url}");
            AqualityServices.Logger.Info($"Result received: {client.GetAsync(posts).Result}");
            return client.GetAsync(posts).Result;
        }

        public static HttpResponseMessage GetPostById(string postId)
        {
            AqualityServices.Logger.Info($"Getting post{postId} from {ConfigurationManager.Url}");
            AqualityServices.Logger.Info($"Result received: {client.GetAsync(posts + postId).Result}");
            return client.GetAsync(posts + postId).Result;
        }

        public static HttpResponseMessage PostRandomPost(PostDataModel randomPost)
        {
            var content = new StringContent(SerializeObject.Serialize(randomPost), Encoding.UTF8, "application/json");
            AqualityServices.Logger.Info($"Postring random post with content - {content}");
            return client.PostAsync(posts, content).Result;
        }

        public static HttpResponseMessage GetAllUsers()
        {
            AqualityServices.Logger.Info($"Getting all users from {ConfigurationManager.Url}");
            AqualityServices.Logger.Info($"Result received: {client.GetAsync(users).Result}");
            return client.GetAsync(users).Result;
        }

        public static HttpResponseMessage GetUserByUserId(string userId)
        {
            AqualityServices.Logger.Info($"Getting user{userId} from {ConfigurationManager.Url}");
            AqualityServices.Logger.Info($"Result received: {client.GetAsync(users + userId).Result}");
            return client.GetAsync(users + userId).Result;
        }
    }
}