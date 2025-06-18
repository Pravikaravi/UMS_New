using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS_New.Data;

namespace UMS_New.Repository
{
    public class userRepository
    {
        public static bool ValidateAdminLogin(string username, string password)
        {
            using (var conn = DBConfig.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @username AND Password = @password AND Role = 'Admin'";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    long count = (long)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public static bool ValidateUserLogin(string username, string password)
        {
            using (var connection = DBConfig.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @username AND Password = @password";
                using (var command = new System.Data.SQLite.SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }
    }

}
