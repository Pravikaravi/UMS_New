using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UMS_New.Model;

namespace UMS_New.Controller
{
    internal class subjectController
    {
        public void CreateSubject(Subject subject, SQLiteConnection conn)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Subject (SubjectName, Description, CourseID) VALUES (@subjectname, @description,  @courseId)";
            cmd.Parameters.AddWithValue("@subjectname", subject.SubjectName);
            cmd.Parameters.AddWithValue("@description", subject.Description);
            cmd.Parameters.AddWithValue("@courseId", subject.CourseID);
            cmd.ExecuteNonQuery();
        }

        public DataTable GetAllSubjects(SQLiteConnection conn)
        {
            DataTable dt = new DataTable();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                SELECT 
                    s.Id, 
                    s.SubjectName, 
                    s.Description, 
                    c.CourseName
                FROM Subject s
                JOIN Course c ON s.CourseID = c.Id";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }

        public void UpdateSubject(Subject subject, SQLiteConnection conn)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE Subject SET SubjectName = @subjectname, Description = @description WHERE Id = @id";
            cmd.Parameters.AddWithValue("@subjectname", subject.SubjectName);
            cmd.Parameters.AddWithValue("@description", subject.Description);
            cmd.Parameters.AddWithValue("@id", subject.Id);
            cmd.ExecuteNonQuery();
        }

        public void DeleteSubject(int id, SQLiteConnection conn)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM Subject WHERE Id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
