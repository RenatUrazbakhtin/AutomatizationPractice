using Aquality.Selenium.Browsers;
using Newtonsoft.Json;
using RestApi.RestApi.Models.Posts;

namespace RestApi.RestApi.Deserializing
{
    public class SerializeObject
    {
        public static string Serialize(PostDataModel data)
        {
            AqualityServices.Logger.Info($"Serializing {data} to PostModelData");
            return JsonConvert.SerializeObject(data);
        }
    }
}
