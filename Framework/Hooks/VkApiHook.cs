using Aquality.Selenium.Browsers;

namespace VkApi.Framework.Hooks
{
    public class VkApiHook
    {
        [SetUp]
        public void Setup()
        {
            AqualityServices.Browser.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            AqualityServices.Browser.Quit();
        }
    }
}
