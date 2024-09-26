using DataBases.Framework.Views;

namespace DataBases.Integration.Tests
{
    public class BaseTest
    {
        public static string sessionKey = DateTime.Now.ToString();

        [OneTimeSetUp]
        public void CreateProjectAndAuthor()
        {
            if (CrudUtils.GetAuthorId() == string.Empty)
            {
                CrudUtils.AddAuthor();

            }
            if (CrudUtils.GetProjectId() == string.Empty)
            {
                CrudUtils.AddProject();
            }
            if (CrudUtils.GetSessionId() == string.Empty)
            {
                CrudUtils.AddSession();
            }
        }
    }
}
