using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS_New.Model;

namespace UMS_New.Controller
{
    internal class staffController
    {

        public void CreateStaff(Staff staff, SQLiteConnection conn)
        {
            string insert = "INSERT INTO Staff (StaffName, Phone_Number, Email) VALUES (@Name, @Phone, @Email)";
            using (var cmd = new SQLiteCommand(insert, conn))
            {
                cmd.Parameters.AddWithValue("@Name", staff.StaffName);
                cmd.Parameters.AddWithValue("@Phone", staff.Phone_Number);
                cmd.Parameters.AddWithValue("@Email", staff.Email);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
