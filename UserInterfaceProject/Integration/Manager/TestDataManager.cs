using Microsoft.Extensions.Configuration;

namespace UserInterfaceProject.Integration.IntegrationManager
{
    public class TestDataManager
    {
        private static string testDataPath = "Integration\\Manager\\TestData.json";
        private static string testPictureDirectory = "Integration\\Manager\\";
        private static IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile(testDataPath, false, true);

        public static string Timer => builder.Build()["timer"];
        public static string PicturePath => Path.GetFullPath(@testPictureDirectory + builder.Build()["pictureName"]);
        public static int InterestsQuantity => int.Parse(builder.Build()["interestsQuantity"]);
        public static string UploadOpenedTime => builder.Build()["expectUploadOpenedTime"];
        public static string UploadClosedTime => builder.Build()["expectUploadClosedTime"];
    }
}
