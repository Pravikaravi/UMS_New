using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using UMS_New.Model;



namespace UMS_New.Controller
{
    internal class adminController
    {
        public void CreateAdmin(Admin admin, SQLiteConnection conn)
        {
            string insert = "INSERT INTO Admin (AdminName, Phone_Number, Email, UserID) VALUES (@Name, @Phone, @Email, @userId)";
            using (var cmd = new SQLiteCommand(insert, conn))
            {
                cmd.Parameters.AddWithValue("@Name", admin.AdminName);
                cmd.Parameters.AddWithValue("@Phone", admin.Phone_Number);
                cmd.Parameters.AddWithValue("@Email", admin.Email);
                cmd.Parameters.AddWithValue("@userId", admin.UserID);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
