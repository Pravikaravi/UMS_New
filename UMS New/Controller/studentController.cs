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
            cmd.CommandText = @"
                INSERT INTO Student (StudentName, UT_Number, Phone_Number, Email, UserID, CourseID) 
                VALUES (@name, @ut, @phone, @email, @userId, @courseId)";
            cmd.Parameters.AddWithValue("@name", student.StudentName);
            cmd.Parameters.AddWithValue("@ut", student.UT_Number);
            cmd.Parameters.AddWithValue("@phone", student.Phone_Number);
            cmd.Parameters.AddWithValue("@email", student.Email);
            cmd.Parameters.AddWithValue("@userId", student.UserID);
            cmd.Parameters.AddWithValue("@courseId", student.CourseID);
            cmd.ExecuteNonQuery();
        }

        // Updated method to join Course table and get CourseName
        public DataTable GetAllStudents(SQLiteConnection conn)
        {
            DataTable dt = new DataTable();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                SELECT s.Id, s.StudentName, s.UT_Number, s.Phone_Number, s.Email, s.UserID, s.CourseID, c.CourseName
                FROM Student s
                LEFT JOIN Course c ON s.CourseID = c.Id";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }

        public void UpdateStudent(Student student, SQLiteConnection conn)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                UPDATE Student 
                SET StudentName = @name, Phone_Number = @phone, Email = @email, CourseID = @courseId 
                WHERE Id = @id";
            cmd.Parameters.AddWithValue("@name", student.StudentName);
            cmd.Parameters.AddWithValue("@phone", student.Phone_Number);
            cmd.Parameters.AddWithValue("@email", student.Email);
            cmd.Parameters.AddWithValue("@courseId", student.CourseID);
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

       

        public DataTable GetStudentsByCourseId(int courseId, SQLiteConnection conn)
        {
            var dt = new DataTable();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                SELECT Id, StudentName, UT_Number -- Make sure UT_Number is here
                FROM Student
                WHERE CourseID = @courseId";
            cmd.Parameters.AddWithValue("@courseId", courseId);

            using (var adapter = new SQLiteDataAdapter(cmd))
            {
                adapter.Fill(dt);
            }
            return dt;
        }


    }
}
