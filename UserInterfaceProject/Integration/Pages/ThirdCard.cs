using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace UserInterfaceProject.Integration.Pages
{
    public class ThirdCard : Form
    {
        public ThirdCard() : base(By.XPath("//*[contains(text(), 'Age')]"), "Third card")
        {
        }

        private static ITextBox Age => ElementFactory.GetTextBox(By.XPath("//*[contains(text(), 'Age')]"), "Age");

        public bool IsThirdCardOpened()
        {
            Age.State.WaitForDisplayed();
            return Age.State.IsDisplayed;
        }
    }
}
