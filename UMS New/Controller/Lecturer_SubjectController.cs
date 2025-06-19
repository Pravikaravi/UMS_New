using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS_New.Controller
{
    internal class Lecturer_SubjectController
    {
        public void AddLecturerSubject(int lecturerId, int subjectId, SQLiteConnection conn)
        {
            string query = "INSERT INTO Lecturer_Subject (LecturerID, SubjectID) VALUES (@lid, @sid)";
            using (var cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@lid", lecturerId);
                cmd.Parameters.AddWithValue("@sid", subjectId);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteAllSubjectsForLecturer(int lecturerId, SQLiteConnection conn)
        {
            string query = "DELETE FROM Lecturer_Subject WHERE LecturerID = @lid";
            using (var cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@lid", lecturerId);
                cmd.ExecuteNonQuery();
            }
        }

        public List<int> GetSubjectIdsByLecturerId(int lecturerId, SQLiteConnection conn)
        {
            List<int> subjectIds = new List<int>();
            string query = "SELECT SubjectID FROM Lecturer_Subject WHERE LecturerID = @lid";
            using (var cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@lid", lecturerId);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        subjectIds.Add(Convert.ToInt32(reader["SubjectID"]));
                    }
                }
            }
            return subjectIds;
        }
    }
}
