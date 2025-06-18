using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS_New.Model;

namespace UMS_New.Controller
{
    internal class userController
    {
        public void CreateUser(User user, SQLiteConnection conn)
        {
            string insertUser = @"INSERT INTO Users (Username, Password, Role) VALUES (@Username, @Password, @Role)";
            using (var cmd = new SQLiteCommand(insertUser, conn))
            {
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Role", user.Role);
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable GetAllUsers(SQLiteConnection conn)
        {
            DataTable dt = new DataTable();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Users";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }

        public void UpdateUser(User user, SQLiteConnection conn)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE Users SET Username = @username, Password = @password, Role = @role WHERE Id = @id";
            cmd.Parameters.AddWithValue("@username", user.Username);
            cmd.Parameters.AddWithValue("@password", user.Password);
            cmd.Parameters.AddWithValue("@role", user.Role);
            cmd.Parameters.AddWithValue("@id", user.Id);
            cmd.ExecuteNonQuery();
        }

        public void DeleteUser(int id, SQLiteConnection conn)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM Users WHERE Id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }



    }
}
