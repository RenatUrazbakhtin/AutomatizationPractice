using Microsoft.Extensions.Configuration;

namespace RestApi.RestApi.TestData
{
    public class StatusCodeManager
    {
        private static string configPath = "RestApi\\TestData\\StatusCodes.json";

        public static string Ok => builder.Build()["200"];
        public static string Created => builder.Build()["201"];
        public static string NotFound => builder.Build()["404"];
        private static IConfigurationBuilder builder => new ConfigurationBuilder().AddJsonFile(Path.Combine(configPath), false, false);

    }
}