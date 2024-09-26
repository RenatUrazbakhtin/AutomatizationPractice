using Aquality.Selenium.Browsers;
using UserInterfaceProject.Framework.FrameworkManager;
using UserInterfaceProject.Framework.Hooks;

namespace UserInterfaceProject.Integration.Tests
{
    [TestFixture]
    public class BaseTest : UserInterfaceHook
    {
        [SetUp]
        public void GoToUrl()
        {
            AqualityServices.Browser.GoTo(ConfigManager.Url);
        }
    }
}
