using Aquality.Selenium.Browsers;
using DataBases.Framework.Utils;
using DataBases.Framework.Views;
using DataBases.Integration.Models;
using DataBases.Integration.TestData;

namespace DataBases.Integration.Tests
{
    public class Tests : BaseTest
    {
        private static readonly string authorId = CrudUtils.GetAuthorId();
        private static readonly string projectId = CrudUtils.GetProjectId();
        private static readonly string sessionId = CrudUtils.GetSessionId();

        [Test]
        public void AddNewTestToDatabase()
        {
            Status testStatus;
            var logContent = TestDataManager.LogContent;
            var testName = TestContext.CurrentContext.Test.Name;
            var methodFullName = TestContext.CurrentContext.Test.FullName;

            var response = TestExecution.GetResponse();
            AqualityServices.Logger.Info($"Result recieved - {response.Content}");
            Assert.That(response.IsSuccessStatusCode, "Status code is not 200");

            if (response.IsSuccessStatusCode)
            {
                testStatus = Status.Passed;
            }
            else
            {
                testStatus = Status.Failed;
                logContent = "Response status code is not 200";
            }

            var testDict = new Dictionary<string, object>
            {
                {"name", testName},
                {"status_id", testStatus},
                {"method_name", methodFullName},
                {"project_id", int.Parse(projectId)},
                {"session_id", int.Parse(sessionId)},
                {"start_time", String.Format(TestDataManager.Format, DateTime.Now)},
                {"end_time", String.Format(TestDataManager.Format, DateTime.Now)},
                {"env", TestDataManager.Env},
                {"browser", TestDataManager.Browser},
                {"author_id", int.Parse(authorId)},
            };

            CrudUtils.AddTest(testDict);
            Assert.NotNull(CrudUtils.GetTest(sessionId), $"Did not add test with session_id - {sessionId}");
        }

        [Test]
        public void UpdateTestsFromDatabase()
        {
            var randomNumber = RandomGenerator.GetRandomNumber();
            var limit = TestDataManager.TestsQuantity;
            var sqlTests = CrudUtils.GetTestsByRandomIdWithLimit(randomNumber, limit);

            foreach (var sqlResult in sqlTests)
            {
                sqlResult.Project = int.Parse(projectId);
                sqlResult.AuthorId = int.Parse(authorId);
            }
            AqualityServices.Logger.Info($"Set project and authorId in each test");

            var addedRows = new List<TestModel>();

            foreach (var sqlResult in sqlTests)
            {
                string startDate = String.Format(TestDataManager.Format, sqlResult.StartTime);
                string endDate = String.Format(TestDataManager.Format, sqlResult.EndTime);
                AqualityServices.Logger.Info("Formated startTime and endTime");

                var testDict = new Dictionary<string, object>
            {
                {"name", sqlResult.Name},
                {"status_id", sqlResult.Status},
                {"method_name", sqlResult.MethodName},
                {"project_id", sqlResult.Project},
                {"session_id", sessionId},
                {"start_time", startDate},
                {"end_time", endDate},
                {"env", sqlResult.Env},
                {"browser", sqlResult.Browser},
                {"author_id", sqlResult.AuthorId},
            };

                CrudUtils.AddTest(testDict);
                AqualityServices.Logger.Info($"Add test {testDict} to database as copy");
                addedRows.Add(CrudUtils.GetTest(sessionId));
                AqualityServices.Logger.Info("Added test to setted list of tests ");
            }

            foreach (var row in addedRows)
            {
                CrudUtils.UpdateTest(row.Id);
                AqualityServices.Logger.Info($"Updated env of test {row}");

            }
            foreach (var row in addedRows)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(CrudUtils.GetTest(row.Session.ToString()).Env, Is.EqualTo(TestDataManager.UpdatedEnv), $"Updated env is not - {TestDataManager.UpdatedEnv}");
                });
            }

            foreach (var row in addedRows)
            {
                CrudUtils.DeleteTest(row.Id.ToString());
                AqualityServices.Logger.Info($"Delete test {row} from database");

            }
            foreach (var row in addedRows)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(CrudUtils.GetTest(row.Session.ToString()).Id, Is.EqualTo(0), "Delete queries did not passed");
                });
            }
        }

        public enum Status
        {
            Passed = 1,
            Failed = 2,
            Skipped = 3
        }
    }
}