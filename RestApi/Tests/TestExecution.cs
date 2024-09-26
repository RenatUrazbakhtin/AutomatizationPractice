using Aquality.Selenium.Browsers;
using RestApi.RestApi.Models.Posts;
using RestApi.RestApi.Models.Users;

namespace RestApi.Tests
{
    public class TestExecution
    {
        public static void CompareUsers(UserModel firstUser, UserModel secondUser)
        {
            AqualityServices.Logger.Info($"Checking if user {firstUser.Name} and user {secondUser.Name} attribute values are equal");
            Assert.Multiple(() =>
            {
                Assert.That(firstUser.Id, Is.EqualTo(secondUser.Id), "Ids are not the same");
                Assert.That(firstUser.Name, Is.EqualTo(secondUser.Name), "Names are not the same");
                Assert.That(firstUser.Username, Is.EqualTo(secondUser.Username), "Usernames are not the same");
                Assert.That(firstUser.Address.Street, Is.EqualTo(secondUser.Address.Street)
                    , "Streets are not the same");
                Assert.That(firstUser.Address.Suite, Is.EqualTo(secondUser.Address.Suite), "Suites are not the same");
                Assert.That(firstUser.Address.City, Is.EqualTo(secondUser.Address.City), "Cities are not the same");
                Assert.That(firstUser.Address.Zipcode, Is.EqualTo(secondUser.Address.Zipcode)
                    , "Zipcodes are not the same");
                Assert.That(firstUser.Address.Geo.Lng, Is.EqualTo(secondUser.Address.Geo.Lng), "Lngs are not the same");
                Assert.That(firstUser.Address.Geo.Lat, Is.EqualTo(secondUser.Address.Geo.Lat), "Lats are not the same");
                Assert.That(firstUser.Phone, Is.EqualTo(secondUser.Phone), "Phones are not the same");
                Assert.That(firstUser.Website, Is.EqualTo(secondUser.Website), "Websites are not the same");
                Assert.That(firstUser.Company.Name, Is.EqualTo(secondUser.Company.Name)
                    , "Companies names are not the same");
                Assert.That(firstUser.Company.Bs, Is.EqualTo(secondUser.Company.Bs), "Companies bs are not the same");
                Assert.That(firstUser.Company.CatchPhrase, Is.EqualTo(secondUser.Company.CatchPhrase)
                    , "Companies catchPhrases are not the same");
            });
        }

        public static void ComparePosts(PostDataModel firtsPost, PostModel secondPost)
        {
            AqualityServices.Logger.Info($"Checking if post {firtsPost.Title} and post {secondPost.Title} attribute values are equal");
            Assert.Multiple(() =>
            {
                Assert.That(firtsPost.Title, Is.EqualTo(secondPost.Title), "Titles are not the same");
                Assert.That(firtsPost.Body, Is.EqualTo(secondPost.Body), "Bodys are not the same");
                Assert.That(firtsPost.UserId, Is.EqualTo(secondPost.UserId), "UserIds are not the same");
            });
        }
    }
}