using Microsoft.Extensions.Configuration;

namespace Integration.TestData
{
    public class TestDataManager
    {
        private static string testDataPath = "TestData\\TestData.json";

        public static string Login => TestDataBuilder.Build()["login"];
        public static string Password => TestDataBuilder.Build()["password"];
        public static string PicturePath => Path.Combine(Directory.GetCurrentDirectory(), @"TestData\Files\pictureCat.jpg");

        private static IConfigurationBuilder TestDataBuilder => new ConfigurationBuilder().AddJsonFile(Path.Combine(testDataPath), false, false);
    }
}
