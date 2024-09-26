using Aquality.Selenium.Browsers;
using DataBases.Integration.DataBaseQueries;
using DataBases.Integration.Models;
using DataBases.Integration.TestData;
using DataBases.Integration.Tests;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlTypes;
using static DataBases.Integration.Tests.Tests;

namespace DataBases.Framework.Views
{
    public class CrudUtils
    {
        private static MySqlConnection connection = DatabaseConnection.Connection;

        public static TestModel GetTest(string sessionId)
        {
            var dict = new Dictionary<string, object>
            {
                {"session_id", sessionId}
            };
            return ExecuteTestReader(SqlScripts.SelectTestBySessionId, dict);
        }

        public static List<TestModel> GetTestsByRandomIdWithLimit(string randomNumber, int limit)
        {
            var dict = new Dictionary<string, object>
            {
                {"random", TestDataManager.RegularRandom.Replace("{value}", randomNumber) },
                {"limit", limit}
            };
            return ExecuteTestsReader(SqlScripts.SelectTestsByRandomId, dict);
        }

        public static string GetAuthorId()
        {
            var dict = new Dictionary<string, object>
            {
                {"author_name", TestDataManager.UserName}
            };
            return ExecuteIdReader(SqlScripts.SelectAuthorIdByName, dict);
        }

        public static string GetProjectId()
        {
            var dict = new Dictionary<string, object>
            {
                {"project_name", TestDataManager.Project}
            };
            return ExecuteIdReader(SqlScripts.SelectProjectIdByName, dict);
        }

        public static string GetSessionId()
        {
            var dict = new Dictionary<string, object>
            {
                {"session_key", BaseTest.sessionKey}
            };
            return ExecuteIdReader(SqlScripts.SelectSessionIdBySessionKey, dict);
        }

        public static void UpdateTest(int testId)
        {
            var dict = new Dictionary<string, object>
            {
                {"test_id", testId}
            };
            ExecuteNonQuery(SqlScripts.UpdateEnvTest, dict);
        }

        public static void DeleteTest(string testId)
        {
            var dict = new Dictionary<string, object>
            {
                {"test_id", testId}
            };
            ExecuteNonQuery(SqlScripts.DeleteTestById, dict);
        }

        public static void AddTest(Dictionary<string, object> dict) => ExecuteNonQuery(SqlScripts.InsertFullTest, dict);

        public static void AddAuthor()
        {
            var dict = new Dictionary<string, object>
            {
                {"author_name", TestDataManager.UserName},
                {"login", TestDataManager.Login},
                {"email", TestDataManager.Email}

            };
            ExecuteNonQuery(SqlScripts.AddAuthor, dict);
        }

        public static void AddProject()
        {
            var dict = new Dictionary<string, object>
            {
                {"project_name", TestDataManager.Project}
            };
            ExecuteNonQuery(SqlScripts.AddProject, dict);
        }

        public static void AddSession()
        {
            var dict = new Dictionary<string, object>
            {
                {"session_key", BaseTest.sessionKey},
                {"build_number", TestDataManager.BuildNumber}
            };
            ExecuteNonQuery(SqlScripts.AddSession, dict);
        }

        private static TestModel ExecuteTestReader(string sql, Dictionary<string, object> dict)
        {
            connection.Open();
            AqualityServices.Logger.Info("Connection opened");
            MySqlCommand cmd = new(sql, connection);

            AddParametersToSqlCommand(cmd, dict);

            MySqlDataReader reader = cmd.ExecuteReader();
            AqualityServices.Logger.Info("Reader executed");
            TestModel test = new();

            while (reader.Read())
            {
                test = GetTestFromReader(reader);
            }

            reader.Close();
            connection.Close();
            AqualityServices.Logger.Info($"Connection closed");
            return test;
        }

        private static List<TestModel> ExecuteTestsReader(string sql, Dictionary<string, object> dict)
        {
            var sqlDataList = new List<TestModel>();

            connection.Open();
            AqualityServices.Logger.Info("Connection opened");
            MySqlCommand cmd = new(sql, connection);

            AddParametersToSqlCommand(cmd, dict);

            MySqlDataReader reader = cmd.ExecuteReader();
            AqualityServices.Logger.Info("Reader executed");

            while (reader.Read())
            {
                var test = GetTestFromReader(reader);
                sqlDataList.Add(test);
                AqualityServices.Logger.Info($"List now have test with id- {test.Id}");
            }

            reader.Close();
            connection.Close();
            AqualityServices.Logger.Info($"Connection closed");

            return sqlDataList;
        }

        private static string ExecuteIdReader(string sql, Dictionary<string, object> dict)
        {
            connection.Open();
            AqualityServices.Logger.Info("Connection opened");
            string id = string.Empty;
            MySqlCommand cmd = new(sql, connection);

            AddParametersToSqlCommand(cmd, dict);

            MySqlDataReader reader = cmd.ExecuteReader();
            AqualityServices.Logger.Info("Reader executed");

            while (reader.Read())
            {
                id += reader.GetInt16("id").ToString();
                AqualityServices.Logger.Info($"Got id - {id} of record");
            }
            reader.Close();
            connection.Close();
            AqualityServices.Logger.Info($"Connection closed");

            return id;
        }

        private static void ExecuteNonQuery(string sql, Dictionary<string, object> dict)
        {
            connection.Open();
            AqualityServices.Logger.Info("Connection opened");
            MySqlCommand cmd = new(sql, connection);

            AddParametersToSqlCommand(cmd, dict);

            AqualityServices.Logger.Info($"Executing {sql}");
            cmd.ExecuteNonQuery();
            connection.Close();
            AqualityServices.Logger.Info($"Connection closed");
        }

        private static TestModel GetTestFromReader(MySqlDataReader reader)
        {
            var test = new TestModel();

            try
            {
                test = new TestModel
                {
                    Id = reader.GetInt16("id"),
                    Name = reader.GetString("name"),
                    Status = reader.GetInt16("status_id"),
                    MethodName = reader.GetString("method_name"),
                    Project = reader.GetInt16("project_id"),
                    Session = reader.GetInt16("session_id"),
                    StartTime = reader.GetDateTime("start_time"),
                    EndTime = reader.GetDateTime("end_time"),
                    Env = reader.GetString("env"),
                    Browser = reader.GetString("browser"),
                    AuthorId = reader.GetValue("author_id")

                };
                return test;
            }
            catch (SqlNullValueException ex)
            {
                test.Status = Status.Skipped;
                test.EndTime = test.StartTime;
                return test;
            }
        }

        private static void AddParametersToSqlCommand(MySqlCommand cmd, Dictionary<string, object> dict)
        {
            foreach (var key in dict.Keys)
            {
                cmd.Parameters.AddWithValue($"@{key}", dict[key]);
            }
        }
    }
}
