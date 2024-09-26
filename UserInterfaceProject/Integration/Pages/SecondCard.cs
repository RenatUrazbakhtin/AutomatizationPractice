using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace UserInterfaceProject.Integration.Pages
{
    public class SecondCard : Form
    {
        public SecondCard() : base(By.XPath("//*[contains(text(), 'upload')]"), "Second card")
        {
        }

        private List<ICheckBox> ListInterests => (List<ICheckBox>)ElementFactory.FindElements<ICheckBox>(By.XPath("//label[not(contains(@for, 'select'))]"), "Interests");
        private static ICheckBox UnselectAll => ElementFactory.GetCheckBox(By.XPath("//*[contains(@for, 'unselectall')]"), "Unselect all interests checkbox");
        private static IElement UploadImage => ElementFactory.GetButton(By.XPath("//*[contains(text(), 'upload')]"), "Upload image link");
        private static IButton NextFormButton => ElementFactory.GetButton(By.XPath("//*[text()='Next']"), "Next form button");

        public void ClickToUnselectAllInterests() => UnselectAll.Click();

        public void ClickToNextFormButton() => NextFormButton.Click();

        public void ClickToRandomInterest(int interestsQuantity)
        {
            List<int> clickedElements = [];
            for (int i = 0; i < interestsQuantity; i++)
            {
                Random rnd = new Random();
                int number = rnd.Next(ListInterests.Count);
                if (clickedElements.Contains(number) == false)
                {
                    clickedElements.Add(number);
                    ListInterests[number].Click();
                }
            }
        }

        public bool IsSecondCardOpened()
        {
            UploadImage.State.WaitForDisplayed();
            return UploadImage.State.IsDisplayed;
        }

        public void ClickToUploadImage()
        {
            UploadImage.Click();
        }
    }
}
