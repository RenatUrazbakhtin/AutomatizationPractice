using Microsoft.Extensions.Configuration;

namespace DataBases.Integration.TestData
{
    public class TestDataManager
    {
        private static string testDataPath = "Integration\\TestData\\TestData.json";

        public static string Browser => TestDataBuilder.Build()["browser"];
        public static string UserName => TestDataBuilder.Build()["userName"];
        public static string Login => TestDataBuilder.Build()["login"];
        public static string Email => TestDataBuilder.Build()["email"];
        public static string Project => TestDataBuilder.Build()["project"];
        public static string Env => TestDataBuilder.Build()["env"];
        public static string BuildNumber => TestDataBuilder.Build()["buildNumber"];
        public static string Format => TestDataBuilder.Build()["format"];
        public static string UpdatedEnv => TestDataBuilder.Build()["updatedEnv"];
        public static string RegularRandom => TestDataBuilder.Build()["regularRandom"];

        public static string LogContent => TestDataBuilder.Build()["logContent"];
        public static int TestsQuantity => int.Parse(TestDataBuilder.Build()["testsQuantity"]);
        public static string Url => TestDataBuilder.Build()["httpTest"];

        private static IConfigurationBuilder TestDataBuilder => new ConfigurationBuilder().AddJsonFile(Path.Combine(testDataPath), false, false);
    }
}
