using Microsoft.Extensions.Configuration;

namespace UserInterfaceProject.Framework.FrameworkManager
{
    public class ConfigManager
    {
        public static string Url => browserBuilder.Build()["url"];
        private static string configPath = "Framework\\Manager\\ConfigData.json";
        private static IConfigurationBuilder browserBuilder = new ConfigurationBuilder()
            .AddJsonFile(Path.Combine(configPath), false, false);
    }
}
