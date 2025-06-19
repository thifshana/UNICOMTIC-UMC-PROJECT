using System.Data.SQLite;

namespace Unicom_TIC_Management_System.Database
{
    public static class DbConfig
    {
        private static string connectionString = "Data Source=StudentDB.db;Version=3;";

        public static SQLiteConnection GetConnection()
        {
           var connection = new SQLiteConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
