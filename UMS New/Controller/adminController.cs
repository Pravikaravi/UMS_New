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
            string insert = "INSERT INTO Admin (Name, Phone_Number, Email) VALUES (@Name, @Phone, @Email)";
            using (var cmd = new SQLiteCommand(insert, conn))
            {
                cmd.Parameters.AddWithValue("@Name", admin.AdminName);
                cmd.Parameters.AddWithValue("@Phone", admin.Phone_Number);
                cmd.Parameters.AddWithValue("@Email", admin.Email);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
