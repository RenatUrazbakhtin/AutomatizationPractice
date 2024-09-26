using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Integration.Pages.Forms
{
    public class AuthenticationForm : Form
    {
        private IButton SignInButton => ElementFactory.GetButton(By.XPath("//button[@type='submit']"), "Sign in button");
        private ITextBox LoginInput => ElementFactory.GetTextBox(By.XPath("//input[@name='login']"), "Login input");

        public AuthenticationForm() : base(By.XPath("//*[@class='JoinForm']"), "Login page")
        {
        }

        public bool IsPageDisplayed() => SignInButton.State.WaitForDisplayed();

        public void ClickToSignIn() => SignInButton.Click();

        public void InputPhoneNumber(string login) => LoginInput.SendKeys(login);

    }
}
