using UserInterfaceProject.Framework.FrameworkUtils;
using UserInterfaceProject.Integration.IntegrationManager;
using UserInterfaceProject.Integration.Pages;
using WindowsInput;
using WindowsInput.Native;

namespace UserInterfaceProject.Integration.Tests
{
    public class UserInterfaceTest : BaseTest
    {
        public HomePage HomePage => new();
        public GamePage GamePage => new();
        public InputSimulator InputSimulator => new();
        public RandomInputs RandomInputs = new();

        [Test]
        public void OpeningCards()
        {
            Assert.That(HomePage.State.IsDisplayed, "Home page is not opened");
            HomePage.ClickToGameLink();
            Assert.That(GamePage.State.IsDisplayed, "Game page is not displayed");
            Assert.That(GamePage.FirstCard.IsFirstCardOpened(), "First card is not opened");

            while (GamePage.IsPasswordCorrect() != true)
            {
                GamePage.FirstCard.SendRandomPassword(RandomInputs.GetRandomPassword());
            }
            GamePage.FirstCard.SendRandomEmail(RandomInputs.GetRandomEmail());
            GamePage.FirstCard.SendRandomDomain(RandomInputs.GetRandomDomain());
            GamePage.FirstCard.ClickToDropDownMenu();
            GamePage.FirstCard.ClickToRandomDropdownChoice();
            GamePage.FirstCard.ClickToAcceptTermsCheckbox();
            GamePage.FirstCard.ClickToNextFormButton();
            Assert.That(GamePage.SecondCard.IsSecondCardOpened(), "Second card is not opened");

            GamePage.SecondCard.ClickToUnselectAllInterests();
            GamePage.SecondCard.ClickToRandomInterest(TestDataManager.InterestsQuantity);
            GamePage.SecondCard.ClickToUploadImage();
            GamePage.WaitForTimerValue(TestDataManager.UploadOpenedTime);
            InputSimulator.Keyboard.TextEntry(TestDataManager.PicturePath);
            InputSimulator.Keyboard.KeyPress(VirtualKeyCode.RETURN);
            GamePage.WaitForTimerValue(TestDataManager.UploadClosedTime);
            GamePage.SecondCard.ClickToNextFormButton();
            Assert.That(GamePage.ThirdCard.IsThirdCardOpened(), "Third card is not opened");
        }

        [Test]
        public void HideHelpForm()
        {
            Assert.That(HomePage.State.IsDisplayed);

            HomePage.ClickToGameLink();
            Assert.That(GamePage.State.IsDisplayed, "Game page is not displayed");

            GamePage.ClickToHideHelpFormButton();
            Assert.That(GamePage.IsHelpFormHidden(), "Help form is not hiden");
        }

        [Test]
        public void AcceptCookies()
        {
            Assert.That(HomePage.State.WaitForDisplayed(), "Home page is not displayed");

            HomePage.ClickToGameLink();
            Assert.That(GamePage.State.WaitForDisplayed(), "Game page is not displayed");

            GamePage.ClickToAcceptCookies();
            Assert.That(GamePage.IsCookiesAccepted(), "Cookies are not accepted");
        }

        [Test]
        public void IsTimerStarted()
        {
            Assert.That(HomePage.State.WaitForDisplayed(), "Home page is not displayed");

            HomePage.ClickToGameLink();
            Assert.That(GamePage.State.WaitForDisplayed(), "Game page is not displayed");

            Assert.That(TestDataManager.Timer == GamePage.GetTextFromTimer(), "Timer text is not 00:00:00");
        }
    }
}