using Microsoft.Extensions.Configuration;

namespace RestApi.RestApi.TestData
{
    public class TestDataManager
    {
        private static string idsPath = "RestApi\\TestData\\TestPostsAndUsersId.json";
        private static string TestUserDataPath = "RestApi\\TestData\\TestUser5.json";
        private static string TestPostDataPath = "RestApi\\TestData\\TestPost99.json";

        public static string TestPostId => builder.Build()["post99"];
        public static string TestNotExistPostId => builder.Build()["post150"];
        public static string TestUserId => builder.Build()["user5"];
        public static int TestPostUserId => int.Parse(builder.Build()["userId"]);
        public static string TestUserData => File.ReadAllText(TestUserDataPath);
        public static string TestPostData => File.ReadAllText(TestPostDataPath);

        private static IConfigurationBuilder builder => new ConfigurationBuilder().AddJsonFile(Path.Combine(idsPath), false, false);
    }
}