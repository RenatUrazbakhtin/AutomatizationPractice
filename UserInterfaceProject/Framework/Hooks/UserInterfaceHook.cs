using Aquality.Selenium.Browsers;

namespace UserInterfaceProject.Framework.Hooks
{
    public class UserInterfaceHook
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
