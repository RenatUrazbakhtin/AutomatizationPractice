using DataBases.Framework.Config;
using MySql.Data.MySqlClient;

namespace DataBases.Framework.Views
{
    public class DatabaseConnection
    {
        public static MySqlConnection Connection => new(connectionString);
        private static string connectionString = $"server={ConfigManager.Server};uid={ConfigManager.Uid};" + $"pwd={ConfigManager.Pwd};database={ConfigManager.DatabaseName}";
    }
}