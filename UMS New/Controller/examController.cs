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
