using Aquality.Selenium.Browsers;
using VkApi.Framework.Hooks;
using VkApi.Framework.Manager;

namespace VkApi.Integration.Tests
{
    public class BaseTest : VkApiHook
    {
        [SetUp]
        public void GoToUrl()
        {
            AqualityServices.Browser.GoTo(ConfigManager.Url);
        }
    }
}
