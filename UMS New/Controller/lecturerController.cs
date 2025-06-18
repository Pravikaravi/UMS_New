using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS_New.Model;

namespace UMS_New.Controller
{
    internal class lecturerController
    {
        public void CreateLecturer(Lecturer lecturer, SQLiteConnection conn)
        {
            string insert = "INSERT INTO Lecturer (Name, Phone_Number, Email) VALUES (@Name, @Phone, @Email)";
            using (var cmd = new SQLiteCommand(insert, conn))
            {
                cmd.Parameters.AddWithValue("@Name", lecturer.LecturerName);
                cmd.Parameters.AddWithValue("@Phone", lecturer.Phone_Number);
                cmd.Parameters.AddWithValue("@Email", lecturer.Email);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
