using Microsoft.Extensions.Configuration;

namespace VkApi.Framework.Manager
{
    public class ConfigManager
    {
        private static string configPath = "Managers\\Config.json";
        public static string Url => BrowserBuilder.Build()["url"];
        public static string ApiUrl => BrowserBuilder.Build()["apiUrl"];

        private static IConfigurationBuilder BrowserBuilder => new ConfigurationBuilder().AddJsonFile(Path.Combine(configPath), false, false);
    }
}
