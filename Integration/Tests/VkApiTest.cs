using Framework.Managers;
using Framework.Utils;
using Integration.Pages;
using Integration.TestData;
using Integration.VkApi.Actions;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace VkApi.Integration.Tests
{
    public class Tests : BaseTest
    {
        private SignInPage signInPage;
        private FeedPage feedPage;
        private MyProfilePage myProfilePage;
        private WallActions wallActions;
        private LikesActions likesActions;

        [OneTimeSetUp]
        public void SetUp()
        {
            signInPage = new SignInPage();
            feedPage = new FeedPage();
            myProfilePage = new MyProfilePage();
            wallActions = new WallActions();
            likesActions = new LikesActions();
        }

        [Test]
        public void Test()
        {
            Assert.That(signInPage.AuthenticationForm.IsPageDisplayed(), "Login page is not displayed");
            signInPage.AuthenticationForm.InputPhoneNumber(TestDataManager.Login);
            signInPage.AuthenticationForm.ClickToSignIn();

            Assert.That(signInPage.IsPageDisdplayed(), "Sign in page is not displayed");

            signInPage.SignIn(TestDataManager.Password);

            Assert.That(feedPage.IsFeedPageDisplayed(), "Feed page is not displayed");
            feedPage.ClickToMyProfile();

            Assert.That(myProfilePage.IsPageDisplayed(), "My profile page is not displayed");

            string rndText = RandomGenerator.GetRandomText();
            string postId = wallActions.MakePostOnWall(rndText);
            Assert.Multiple(() =>
            {
                Assert.That(myProfilePage.GetUserIdFromAddedPost(postId), Is.EqualTo(ApiConfigManager.UserId), "User id from added post is not correct");
                Assert.That(myProfilePage.GetTextFromAddedPost(ApiConfigManager.UserId, postId), Is.EqualTo(rndText), "Text from added post is not the same");
            });

            var newRandomText = RandomGenerator.GetRandomText();
            string photoId = wallActions.EditPostOnWall(postId, newRandomText, TestDataManager.PicturePath);
            Assert.Multiple(() =>
            {
                Assert.That(myProfilePage.GetTextFromAddedPost(ApiConfigManager.UserId, postId), Is.EqualTo(newRandomText), "Updated text is not correct");
                Assert.That(myProfilePage.IsPhotoUploaded(photoId), "Uploaded photo is not the same");
            });

            var randomComment = RandomGenerator.GetRandomText();
            wallActions.CreateComment(postId, randomComment);
            Assert.That(randomComment, Is.EqualTo(myProfilePage.GetCommentText(ApiConfigManager.UserId, postId)), "Comment texts are not the same");

            myProfilePage.LikePost(ApiConfigManager.UserId, postId);
            Assert.That(likesActions.GetLikes(postId), Is.EqualTo(ApiConfigManager.UserId), "There was not like on post from user");

            wallActions.DeletePostOnWall(postId);
            Assert.IsFalse(myProfilePage.IsPostExist(), "Post is not deleted");
        }
    }
}