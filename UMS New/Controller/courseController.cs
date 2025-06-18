using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS_New.Model;

namespace UMS_New.Controller
{
    internal class courseController
    {
        public void CreateCourse(Course course, SQLiteConnection conn)
        {
            string insertCourse = @"INSERT INTO Course (CourseName , Duration, Description) VALUES (@coursename, @duration, @description)";
            using (var cmd = new SQLiteCommand(insertCourse, conn))
            {
                cmd.Parameters.AddWithValue("@coursename", course.CourseName);
                cmd.Parameters.AddWithValue("@duration", course.Duration);
                cmd.Parameters.AddWithValue("@description", course.Description);
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable GetAllCourses(SQLiteConnection conn)
        {
            DataTable dt = new DataTable();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Course"; // singular name here
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }

        public void UpdateCourse(Course course, SQLiteConnection conn)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE Course SET CourseName = @coursename, Duration = @duration, Description = @description WHERE Id = @id";
            cmd.Parameters.AddWithValue("@coursename", course.CourseName);
            cmd.Parameters.AddWithValue("@duration", course.Duration);
            cmd.Parameters.AddWithValue("@description", course.Description);
            cmd.Parameters.AddWithValue("@id", course.Id);
            cmd.ExecuteNonQuery();
        }

        public void DeleteCourse(int id, SQLiteConnection conn)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM Course WHERE Id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
