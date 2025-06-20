using System.Data;
using System.Data.SQLite;
using UMS_New.Model;

namespace UMS_New.Controller
{
    internal class marksController
    {
        // Save or update with explicit mark and grade string
        public void SaveOrUpdateMark(int examId, int studentId, string mark, string grade, SQLiteConnection conn)
        {
            var checkCmd = conn.CreateCommand();
            checkCmd.CommandText = "SELECT COUNT(*) FROM ExamResults WHERE StudentId = @sid AND ExamId = @eid";
            checkCmd.Parameters.AddWithValue("@sid", studentId);
            checkCmd.Parameters.AddWithValue("@eid", examId);

            long count = (long)checkCmd.ExecuteScalar();

            SQLiteCommand cmd;
            if (count > 0)
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE ExamResults SET Marks = @marks, Grade = @grade WHERE StudentId = @sid AND ExamId = @eid";
            }
            else
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO ExamResults (StudentId, ExamId, Marks, Grade) VALUES (@sid, @eid, @marks, @grade)";
            }

            cmd.Parameters.AddWithValue("@sid", studentId);
            cmd.Parameters.AddWithValue("@eid", examId);
            cmd.Parameters.AddWithValue("@marks", mark);
            cmd.Parameters.AddWithValue("@grade", grade);

            cmd.ExecuteNonQuery();
        }

        // Save or update using Marks object
        public void SaveOrUpdateMark(Marks markObj, SQLiteConnection conn)
        {
            var checkCmd = conn.CreateCommand();
            checkCmd.CommandText = "SELECT COUNT(*) FROM ExamResults WHERE StudentId = @sid AND ExamId = @eid";
            checkCmd.Parameters.AddWithValue("@sid", markObj.StudentId);
            checkCmd.Parameters.AddWithValue("@eid", markObj.ExamId);

            long count = (long)checkCmd.ExecuteScalar();

            SQLiteCommand cmd;
            if (count > 0)
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE ExamResults SET Marks = @marks, Grade = @grade WHERE StudentId = @sid AND ExamId = @eid";
            }
            else
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO ExamResults (StudentId, ExamId, Marks, Grade) VALUES (@sid, @eid, @marks, @grade)";
            }

            cmd.Parameters.AddWithValue("@sid", markObj.StudentId);
            cmd.Parameters.AddWithValue("@eid", markObj.ExamId);
            cmd.Parameters.AddWithValue("@marks", markObj.Mark);
            cmd.Parameters.AddWithValue("@grade", markObj.Grade);

            cmd.ExecuteNonQuery();
        }

        // Overload method updated to compute Grade
        public void SaveOrUpdateMark(int examId, int studentId, int mark, SQLiteConnection conn)
        {
            var grade = GetGrade(mark);

            var markObj = new Marks
            {
                ExamId = examId,
                StudentId = studentId,
                Mark = mark,
                Grade = grade
            };

            SaveOrUpdateMark(markObj, conn);
        }

        // Grade logic method
        private string GetGrade(int mark)
        {
            if (mark >= 90) return "A";
            if (mark >= 80) return "B";
            if (mark >= 60) return "C";
            if (mark >= 40) return "D";
            return "E";
        }

        public DataTable GetMarksByExamId(int examId, SQLiteConnection conn)
        {
            var dt = new DataTable();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                SELECT 
                    StudentId, 
                    ExamId, 
                    Marks AS Mark,
                    Grade
                FROM ExamResults
                WHERE ExamId = @examId";
            cmd.Parameters.AddWithValue("@examId", examId);

            using (var adapter = new SQLiteDataAdapter(cmd))
            {
                adapter.Fill(dt);
            }
            return dt;
        }

        public void DeleteMark(int examId, int studentId, SQLiteConnection conn)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM ExamResults WHERE ExamId = @eid AND StudentId = @sid";
            cmd.Parameters.AddWithValue("@eid", examId);
            cmd.Parameters.AddWithValue("@sid", studentId);
            cmd.ExecuteNonQuery();
        }
    }
}
