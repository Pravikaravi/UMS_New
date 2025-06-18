using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UUMS_New.Model;

namespace UMS_New.Controller
{
    internal class studentController
    {
        public void CreateStudent(Student student, SQLiteConnection conn)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Student (StudentName, UT_Number, Phone_Number, Email, UserID, CourseID) VALUES (@name, @ut, @phone, @email, @userId, @courseId)";
            cmd.Parameters.AddWithValue("@name", student.StudentName);
            cmd.Parameters.AddWithValue("@ut", student.UT_Number);
            cmd.Parameters.AddWithValue("@phone", student.Phone_Number);
            cmd.Parameters.AddWithValue("@email", student.Email);
            cmd.Parameters.AddWithValue("@userId", student.UserID); 
            cmd.Parameters.AddWithValue("@courseId", student.CourseID); 
            cmd.ExecuteNonQuery();
        }

        public DataTable GetAllStudents(SQLiteConnection conn)
        {
            DataTable dt = new DataTable();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Student";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }

        public void UpdateStudent(Student student, SQLiteConnection conn)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE Student SET StudentName = @name, Phone_Number = @phone, Email = @email WHERE Id = @id";
            cmd.Parameters.AddWithValue("@name", student.StudentName);
            cmd.Parameters.AddWithValue("@phone", student.Phone_Number);
            cmd.Parameters.AddWithValue("@email", student.Email);
            cmd.Parameters.AddWithValue("@id", student.Id);
            cmd.ExecuteNonQuery();
        }

        public void DeleteStudent(int id, SQLiteConnection conn)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM Student WHERE Id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
