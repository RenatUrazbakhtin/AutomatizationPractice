using Microsoft.Extensions.Configuration;

namespace DataBases.Framework.Config
{
    public class ConfigManager
    {
        private static string configPath = "Framework\\Config\\Config.json";

        public static string Server => Builder.Build()["server"];
        public static string Uid => Builder.Build()["uid"];
        public static string Pwd => Builder.Build()["pwd"];
        public static string DatabaseName => Builder.Build()["database"];
        public static string TestUrl => Builder.Build()["url"];

        private static IConfigurationBuilder Builder => new ConfigurationBuilder()
            .AddJsonFile(Path.Combine(configPath), false, false);
    }
}
