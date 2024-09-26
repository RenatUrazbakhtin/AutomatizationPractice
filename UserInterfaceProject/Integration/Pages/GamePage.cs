using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace UserInterfaceProject.Integration.Pages
{
    public class GamePage : Form
    {
        public GamePage() : base(By.XPath("//*[@class='login-form']"), "Game page")
        {
        }

        public FirstCard FirstCard => new();
        public SecondCard SecondCard => new();
        public ThirdCard ThirdCard => new();

        private static IElement CorrectPassword => ElementFactory.GetTextBox(By.XPath("//*[contains(@class, 'correct')]"), "Is password correct string");
        private static IButton HideHelpFormButton => ElementFactory.GetButton(By.XPath("//button[contains(@class, 'bottom')]"), "Hide help form button");
        private static IButton AcceptCookiesButton => ElementFactory.GetButton(By.XPath("//button[contains(text(), 'Not')]"), "Accept cookies button");
        private static ITextBox Timer => ElementFactory.GetTextBox(By.XPath("//*[contains(@class, 'timer')]"), "Timer");
        private static IElement HelpFormTitle => ElementFactory.GetTextBox(By.XPath("//*[contains(text(), 'help')]"), "Help form title");

        public bool IsCookiesAccepted() => AcceptCookiesButton.State.WaitForNotDisplayed();

        public void ClickToHideHelpFormButton() => HideHelpFormButton.Click();

        public bool IsHelpFormHidden() => HelpFormTitle.State.WaitForNotDisplayed();

        public string GetTextFromTimer() => Timer.GetText();

        public bool IsPasswordCorrect() => CorrectPassword.State.IsDisplayed;

        public void ClickToAcceptCookies()
        {
            AcceptCookiesButton.State.WaitForDisplayed();
            AcceptCookiesButton.Click();
        }

        public void WaitForTimerValue(string timer)
        {
            while (timer != GetTextFromTimer())
            {
                if (timer == GetTextFromTimer())
                {
                    break;
                }
            }
        }
    }
}
