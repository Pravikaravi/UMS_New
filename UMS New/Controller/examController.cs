using System;
using System.Data;
using System.Data.SQLite;
using UMS_New.Model;

namespace UMS_New.Controller
{
    internal class examController
    {
        public DataTable GetAllExams(SQLiteConnection conn)
        {
            DataTable dt = new DataTable();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                SELECT Exam.Id, ExamName, ExamDate, StartTime, DurationMinutes, RoomId, SubjectId,
                       Room.RoomName, Subject.SubjectName
                FROM Exam
                LEFT JOIN Room ON Exam.RoomId = Room.Id
                LEFT JOIN Subject ON Exam.SubjectId = Subject.Id";
            using (var adapter = new SQLiteDataAdapter(cmd))
            {
                adapter.Fill(dt);
            }
            return dt;
        }
        public DataTable GetExamsByLecturerUsername(string username, SQLiteConnection conn)
        {
            string sql = @"
                SELECT Exam.* FROM Exam
                INNER JOIN Lecturer_Subject ls ON Exam.SubjectId = ls.SubjectID
                INNER JOIN Lecturer l ON ls.LecturerID = l.Id
                INNER JOIN Users u ON l.UserID = u.Id
                WHERE u.UserName = @username";

            using (var cmd = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@username", username);

                using (var adapter = new SQLiteDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }



        public void UpdateExam(Exam exam, SQLiteConnection conn)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                UPDATE Exam SET 
                    ExamName = @examName,
                    ExamDate = @examDate,
                    StartTime = @startTime,
                    DurationMinutes = @duration,
                    RoomId = @roomId,
                    SubjectId = @subjectId
                WHERE Id = @id";
            cmd.Parameters.AddWithValue("@examName", exam.ExamName);
            cmd.Parameters.AddWithValue("@examDate", exam.ExamDate);
            cmd.Parameters.AddWithValue("@startTime", exam.StartTime);
            cmd.Parameters.AddWithValue("@duration", exam.DurationMinutes);
            cmd.Parameters.AddWithValue("@roomId", exam.RoomId);
            cmd.Parameters.AddWithValue("@subjectId", exam.SubjectId);
            cmd.Parameters.AddWithValue("@id", exam.Id);
            cmd.ExecuteNonQuery();
        }

        public void DeleteExam(int id, SQLiteConnection conn)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM Exam WHERE Id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        public void CreateExam(Exam exam, SQLiteConnection conn)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                INSERT INTO Exam (ExamName, ExamDate, StartTime, DurationMinutes, RoomId, SubjectId)
                VALUES (@examName, @examDate, @startTime, @duration, @roomId, @subjectId)";
            cmd.Parameters.AddWithValue("@examName", exam.ExamName);
            cmd.Parameters.AddWithValue("@examDate", exam.ExamDate);
            cmd.Parameters.AddWithValue("@startTime", exam.StartTime);
            cmd.Parameters.AddWithValue("@duration", exam.DurationMinutes);
            cmd.Parameters.AddWithValue("@roomId", exam.RoomId);
            cmd.Parameters.AddWithValue("@subjectId", exam.SubjectId);
            cmd.ExecuteNonQuery();
        }

        public DataTable GetExamsByStudentUsername(string username, SQLiteConnection conn)
        {
            string sql = @"
                SELECT DISTINCT e.*
                FROM Exam e
                INNER JOIN ExamResults er ON e.Id = er.ExamId
                INNER JOIN Student s ON er.StudentId = s.Id
                INNER JOIN Users u ON s.UserID = u.Id
                WHERE u.UserName = @username
    ";

            using (var cmd = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@username", username);

                using (var adapter = new SQLiteDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }


        public DataRow GetExamById(int examId, SQLiteConnection conn)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Exam WHERE Id = @id";
            cmd.Parameters.AddWithValue("@id", examId);

            var dt = new DataTable();
            using (var adapter = new SQLiteDataAdapter(cmd))
            {
                adapter.Fill(dt);
            }
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }
    }
}
