using DataBases.Framework.Config;
using DataBases.Integration.TestData;

namespace DataBases.Integration.Tests
{
    public class TestExecution
    {
        public static HttpResponseMessage GetResponse()
        {
            HttpClient client = new()
            { BaseAddress = new Uri(ConfigManager.TestUrl) };

            return client.GetAsync(TestDataManager.Url).Result;
        }
    }
}
