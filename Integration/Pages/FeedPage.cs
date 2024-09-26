using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Integration.Pages
{
    public class FeedPage : Form
    {
        private ILink MyProfileLink => ElementFactory.GetLink(By.XPath("//*[@id='l_pr']"), "Link to my profile page");

        public FeedPage() : base(By.XPath("//*[@id='feed_filters']"), "Feed page")
        {
        }

        public bool IsFeedPageDisplayed() => MyProfileLink.State.WaitForDisplayed();

        public void ClickToMyProfile() => MyProfileLink.ClickAndWait();

    }
}
