using System;
using System.Collections.Generic;
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
            string insertUser = @"INSERT INTO Users (Username, Password, Role) 
                          VALUES (@Username, @Password, @Role)";
            using (var cmd = new SQLiteCommand(insertUser, conn))
            {
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Role", user.Role);
                cmd.ExecuteNonQuery();
            }
        }

    }
}
