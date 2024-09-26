using Aquality.Selenium.Elements.Interfaces;
using OpenQA.Selenium;
using Aquality.Selenium.Forms;

namespace UserInterfaceProject.Integration.Pages
{
    public class FirstCard : Form
    {
        public FirstCard() : base(By.XPath("//*[@class='login-form']"), "First card")
        {
        }

        private static ITextBox LoginForm => ElementFactory.GetTextBox(By.XPath("//*[@class='login-form']"), "Login form");
        private static ITextBox InputPassword => ElementFactory.GetTextBox(By.XPath("//*[contains(@placeholder, 'Password')]"), "Input password textbox");
        private static ITextBox InputEmail => ElementFactory.GetTextBox(By.XPath("//*[contains(@placeholder, 'email')]"), "Input email textbox");
        private static ITextBox InputDomain => ElementFactory.GetTextBox(By.XPath("//*[contains(@placeholder, 'Domain')]"), "Input domain textbox");
        private static IElement DropdownMenu => ElementFactory.GetMultiChoiceBox(By.XPath("//*[contains(@class, 'header')]"), "Dropdown menu");
        private static List<ICheckBox> ListDropDownChoices => (List<ICheckBox>)ElementFactory.FindElements<ICheckBox>(By.XPath("//*[contains(@class, 'list-item') and not(contains(@class, 'selected'))]"), "Dropdown choices");
        private static IButton NextFormButton => ElementFactory.GetButton(By.XPath("//*[text()='Next']"), "Next form button");
        private static ICheckBox AcceptTerms => ElementFactory.GetCheckBox(By.XPath("//*[contains(@for, 'accept')]"), "Accept terms checkbox");

        public void ClickToDropDownMenu() => DropdownMenu.Click();

        public void SendRandomPassword(string password) => InputPassword.ClearAndType(password);

        public void SendRandomEmail(string email) => InputEmail.ClearAndType(email);

        public void SendRandomDomain(string domain) => InputDomain.ClearAndType(domain);

        public void ClickToAcceptTermsCheckbox() => AcceptTerms.Click();

        public void ClickToNextFormButton() => NextFormButton.Click();

        public bool IsFirstCardOpened()
        {
            LoginForm.State.WaitForDisplayed();
            return LoginForm.State.IsDisplayed;
        }

        public void ClickToRandomDropdownChoice()
        {
            Random rnd = new ();
            int number = rnd.Next(ListDropDownChoices.Count);
            ListDropDownChoices[number].Click();
        }
    }
}