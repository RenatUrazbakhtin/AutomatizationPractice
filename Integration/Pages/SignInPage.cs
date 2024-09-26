using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using Integration.Pages.Forms;
using OpenQA.Selenium;

namespace Integration.Pages
{
    public class SignInPage : Form
    {
        public AuthenticationForm AuthenticationForm => new();
        private ITextBox InputPassword => ElementFactory.GetTextBox(By.XPath("//input[@name='password']"), "Enter password field");
        private IButton EnterPasswordButton => ElementFactory.GetButton(By.XPath("//button[@type='submit']"), "Enter password button");
        private IButton OtherMethodsButton => ElementFactory.GetButton(By.XPath("//button[contains(@data-test-id, 'verification')]"), "Other verification methods button");
        private IButton ChoosePasswordSignInButton => ElementFactory.GetButton(By.XPath("//*[contains(@data-test-id, 'password')]"), "Choose password method");

        public SignInPage() : base(By.XPath("//input[@name='password']"), "Sign in page")
        {
        }

        public bool IsPageDisdplayed() => OtherMethodsButton.State.WaitForDisplayed();

        public void ClickToChoosePasswordSignInButton() => ChoosePasswordSignInButton.WaitAndClick();

        public void InsertPassword(string password) => InputPassword.SendKeys(password);

        public void ClickToEnterPasswordButton() => EnterPasswordButton.ClickAndWait();

        public void ClickToOtherMethodsButton() => OtherMethodsButton.WaitAndClick();

        public void SignIn(string password)
        {
            ClickToOtherMethodsButton();
            ClickToChoosePasswordSignInButton();
            InsertPassword(password);
            ClickToEnterPasswordButton();
        }
    }
}
