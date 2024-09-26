using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Integration.Pages
{
    public class MyProfilePage : Form
    {
        private ILabel ProfileAction => ElementFactory.GetLabel(By.XPath("//div[contains(@class, 'ActionLink')]"), "Profile action");
        private IList<ILabel> Posts => ElementFactory.FindElements<ILabel>(By.XPath("//div[contains(@id, 'posts')]/div[contains(@id, 'post')]"), "Posts");
        private IList<ILabel> PostsTexts => ElementFactory.FindElements<ILabel>(By.XPath("//div[contains(@class, 'wall_post_cont')]"), "Posts texts");
        private IList<ILabel> PostsPhotos => ElementFactory.FindElements<ILabel>(By.XPath("//div[contains(@class, 'page_post_sized_thumbs')]//a"), "Posts photos");
        private IList<ILabel> PostsLikes => ElementFactory.FindElements<ILabel>(By.XPath("//div[contains(@data-reaction-set-id, 'reactions')]"), "Posts likes");
        private By Comments => By.XPath("//div[contains(@class, 'wall_reply_text')]");
        private By ShowComment => By.XPath("//span[contains(@class, 'js-replies_next_label')]");

        public MyProfilePage() : base(By.XPath("//*[@id='profile_wall']"), "Profile page")
        {
        }

        public string GetUserIdFromAddedPost(string postId)
        {
            var addedPostUserId = string.Empty;
            foreach (var post in Posts)
            {
                if (post.GetAttribute("data-post-id").Split("_").Last() == postId)
                {
                    addedPostUserId = post.GetAttribute("data-post-id").Split("_").First();
                }
            }

            return addedPostUserId;
        }

        public string GetTextFromAddedPost(string userId, string postId)
        {
            var addedPostText = string.Empty;

            foreach (var postText in PostsTexts)
            {
                if (postText.GetAttribute("id") == $"wpt{userId}_{postId}")
                {
                    addedPostText = postText.Text;
                }
            }

            return addedPostText;
        }

        public bool IsPhotoUploaded(string photoId)
        {
            foreach (var photo in PostsPhotos)
            {
                if (photo.GetAttribute("href").Split("_").Last() == photoId)
                {
                    return true;
                }
            }
            return false;
        }

        public string GetCommentText(string userId, string postId)
        {
            var commentText = String.Empty;

            foreach (var post in Posts)
            {
                if (post.GetAttribute("data-post-id") == $"{userId}_{postId}")
                {
                    post.FindChildElement<IButton>(ShowComment, "Show comments button").Click();
                    commentText = post.FindChildElement<ILabel>(Comments, "Comments of post").Text;
                }
            }
            return commentText;
        }

        public void LikePost(string userId, string postId)
        {
            foreach (var like in PostsLikes)
            {
                if (like.GetAttribute("data-reaction-target-object") == $"wall{userId}_{postId}")
                {
                    like.ClickAndWait();
                }
            }
        }

        public bool IsPostExist()
        {

            foreach (var post in PostsTexts)
            {
                if (!post.State.IsExist)
                {
                    return true;
                }
            }

            return false;
        }


        public bool IsPageDisplayed() => ProfileAction.State.WaitForDisplayed();

    }
}
