using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace UserInterfaceProject.Integration.Pages
{
    public class HomePage : Form
    {
        public HomePage() : base(By.XPath("//a[contains(@class, 'link')]"), "Home page")
        {
        }

        private static ILink LinkToGame => ElementFactory.GetLink(By.XPath("//a[contains(@class, 'link')]"), "Link to game");

        public static void ClickToGameLink()
        {
            LinkToGame.ClickAndWait();
        }
    }
}
