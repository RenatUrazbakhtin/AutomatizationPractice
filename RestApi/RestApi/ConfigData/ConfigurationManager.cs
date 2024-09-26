using Microsoft.Extensions.Configuration;

namespace RestApi.RestApi.ConfigData
{
    public class ConfigurationManager
    {
        private static string configPath = "RestApi\\ConfigData\\ConfigData.json";

        public static string Url => configBuilder.Build()["url"];

        private static IConfigurationBuilder configBuilder => new ConfigurationBuilder().AddJsonFile(Path.Combine(configPath), false, false);
    }
}
