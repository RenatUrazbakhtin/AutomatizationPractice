using Aquality.Selenium.Browsers;
using RestApi.RestApi.Api;
using RestApi.RestApi.Deserializing;
using RestApi.RestApi.TestData;
using RestApi.RestApi.Utils;

namespace RestApi.Tests
{
    public class JsonPlaceHolderTest
    {
        [Test]
        public void GetAllPosts()
        {
            var response = ApiUtils.GetAllPosts();
            Assert.That(response.StatusCode.ToString(), Is.EqualTo(StatusCodeManager.Ok), "Response status code is not 200");

            var responseContent = response.Content.ReadAsStringAsync().Result;
            AqualityServices.Logger.Info($"Got response content - {responseContent}");

            var deserializedPosts = DeserializeObject.DeserializeIntoListPostModel(responseContent);
            Assert.IsNotEmpty(deserializedPosts, "Did not get any posts");
            AqualityServices.Logger.Info($"Sorting {deserializedPosts} by id");

            var sortedPosts = deserializedPosts.OrderBy(post => post.Id);
            AqualityServices.Logger.Info($"Result received: {deserializedPosts}");

            CollectionAssert.AreEqual(deserializedPosts, sortedPosts, "Posts in response are not sorted in ascending order by Id");        }

        [Test]
        public void GetPostById()
        {
            var response = ApiUtils.GetPostById(TestDataManager.TestPostId);
            Assert.That(response.StatusCode.ToString(), Is.EqualTo(StatusCodeManager.Ok), "Response status code is not 200");

            var responseContent = response.Content.ReadAsStringAsync().Result;
            AqualityServices.Logger.Info($"Got response content - {responseContent}");

            var deserializedPost = DeserializeObject.DeserializeIntoPostModel(responseContent);
            var postTest = DeserializeObject.DeserializeIntoPostModel(TestDataManager.TestPostData);
            AqualityServices.Logger.Info($"Checking if {deserializedPost.Id} and {postTest.Id} are equal");
            Assert.Multiple(() =>
            {
                Assert.That(deserializedPost.Id, Is.EqualTo(postTest.Id), "Ids are not the same");
                Assert.That(deserializedPost.UserId, Is.EqualTo(postTest.UserId), "UserIds are not the same");
                Assert.That(deserializedPost.Title, Is.EqualTo(postTest.Title), "Titles are not the same");
                Assert.That(deserializedPost.Body, Is.EqualTo(postTest.Body), "Bodies are not the same");
            });
        }

        [Test]
        public void GetNotExistPost()
        {
            var response = ApiUtils.GetPostById(TestDataManager.TestNotExistPostId);
            Assert.That(response.StatusCode.ToString(), Is.EqualTo(StatusCodeManager.NotFound), "Response status code is not 404");

            var responseContent = response.Content.ReadAsStringAsync().Result;
            AqualityServices.Logger.Info($"Got response content - {responseContent}");

            var deserializedPost = DeserializeObject.DeserializeIntoPostModel(responseContent);
            Assert.Multiple(() =>
            {
                Assert.That(string.IsNullOrEmpty(deserializedPost.Body), "Body is not null");
                Assert.That(string.IsNullOrEmpty(deserializedPost.Title), "Title is not null");
                Assert.That(deserializedPost.Id, Is.EqualTo(0), "Id is not null");
                Assert.That(deserializedPost.UserId, Is.EqualTo(0), "userId is not null");
            });
        }

        [Test]
        public void PostRandomPost()
        {
            AqualityServices.Logger.Info($"Getting random PostDataModel to post");
            var randomPost = RandomGenerator.GetRandomPostAsModel(TestDataManager.TestPostUserId);
            AqualityServices.Logger.Info($"Got PostDataModel - {randomPost}");

            var response = ApiUtils.PostRandomPost(randomPost);
            Assert.That(response.StatusCode.ToString(), Is.EqualTo(StatusCodeManager.Created), "Response status code is not 201");

            var responseContent = response.Content.ReadAsStringAsync().Result;
            AqualityServices.Logger.Info($"Got response content - {responseContent}");

            var deserializedRandomPost = DeserializeObject.DeserializeIntoPostModel(responseContent);
            Assert.NotNull(deserializedRandomPost.Id, "There is no id of random post");
            TestExecution.ComparePosts(randomPost, deserializedRandomPost);
        }

        [Test]
        public void GetAllUsers()
        {
            var response = ApiUtils.GetAllUsers();
            Assert.That(response.StatusCode.ToString(), Is.EqualTo(StatusCodeManager.Ok), "Response status code is not 200");

            var responseContent = response.Content.ReadAsStringAsync().Result;
            AqualityServices.Logger.Info($"Got response content - {responseContent}");

            var deserializedUsers = DeserializeObject.DeserializeIntoListUserModel(responseContent);
            Assert.IsNotEmpty(deserializedUsers, "Did not get any users");

            AqualityServices.Logger.Info($"Finding user with id {TestDataManager.TestUserId}");
            foreach (var user  in deserializedUsers)
            {
                if (user.Id == int.Parse(TestDataManager.TestUserId))
                {
                    var user5Test = DeserializeObject.DeserializeIntoUserModel(TestDataManager.TestUserData);
                    TestExecution.CompareUsers(user, user5Test);
                    break;
                }
            }
        }

        [Test]
        public void GetUserById()
        {
            var response = ApiUtils.GetUserByUserId(TestDataManager.TestUserId);
            Assert.That(response.StatusCode.ToString(), Is.EqualTo(StatusCodeManager.Ok), "Response status code is not 200");

            var responseContent = response.Content.ReadAsStringAsync().Result;
            AqualityServices.Logger.Info($"Got response content - {responseContent}");

            var deserializedUser = DeserializeObject.DeserializeIntoUserModel(responseContent);
            var testUser = DeserializeObject.DeserializeIntoUserModel(TestDataManager.TestUserData);
            TestExecution.CompareUsers(deserializedUser, testUser);
        }
    }
}