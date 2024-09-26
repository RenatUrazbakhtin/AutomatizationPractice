using Microsoft.Extensions.Configuration;

namespace Framework.Managers
{
    public class ApiConfigManager
    {
        private static string apiConfigPath = "Managers\\ApiConfig.json";

        public static string UserId => ConfigBuilder.Build()["userId"];
        public static string Token => ConfigBuilder.Build()["token"];
        public static string Version => ConfigBuilder.Build()["version"];

        private static IConfigurationBuilder ConfigBuilder => new ConfigurationBuilder().AddJsonFile(Path.Combine(apiConfigPath), false, false);
    }
}
