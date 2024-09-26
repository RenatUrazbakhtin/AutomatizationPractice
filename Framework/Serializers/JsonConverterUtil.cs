using Newtonsoft.Json;

namespace Framework.Serializers
{
    public class JsonConverterUtil
    {
        public static T DeserializeObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
