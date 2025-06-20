using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using UMS_New.Data;
using UMS_New.Model;

namespace UMS_New.Controller
{
    public class timetableController
    {
        public bool AddTimetableEntry(Timetable timetable, SQLiteConnection conn)
        {
            string query = "INSERT INTO Timetables (DayOfWeek, TimeSlot, SubjectID, RoomID, LecturerID) VALUES (@day, @time, @subjectId, @roomId, @lecturerId)";
            using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@day", timetable.DayOfWeek);
                cmd.Parameters.AddWithValue("@time", timetable.TimeSlot);
                cmd.Parameters.AddWithValue("@subjectId", timetable.SubjectID);
                cmd.Parameters.AddWithValue("@roomId", timetable.RoomID);
                cmd.Parameters.AddWithValue("@lecturerId", timetable.LecturerID);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public DataTable GetAllTimetableEntriesWithDetails(SQLiteConnection conn)
        {
            string query = @"
                SELECT 
                    t.TimetableID,
                    t.DayOfWeek,
                    t.TimeSlot,
                    t.SubjectID,
                    s.SubjectName,
                    t.RoomID,
                    r.RoomName,
                    t.LecturerID,
                    u.UserName AS LecturerName
                FROM Timetables t
                LEFT JOIN Subject s ON t.SubjectID = s.Id
                LEFT JOIN Room r ON t.RoomID = r.Id
                LEFT JOIN Users u ON t.LecturerID = u.Id
                ORDER BY 
                    CASE t.DayOfWeek
                        WHEN 'Monday' THEN 1
                        WHEN 'Tuesday' THEN 2
                        WHEN 'Wednesday' THEN 3
                        WHEN 'Thursday' THEN 4
                        WHEN 'Friday' THEN 5
                        WHEN 'Saturday' THEN 6
                        WHEN 'Sunday' THEN 7
                        ELSE 8
                    END,
                    t.TimeSlot;
            ";

            using (var cmd = new SQLiteCommand(query, conn))
            using (var adapter = new SQLiteDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public bool UpdateTimetableEntry(Timetable timetable, SQLiteConnection conn)
        {
            string sql = @"
                UPDATE Timetables
                SET DayOfWeek = @DayOfWeek,
                    TimeSlot = @TimeSlot,
                    SubjectID = @SubjectID,
                    RoomID = @RoomID,
                    LecturerID = @LecturerID
                WHERE TimetableID = @TimetableID";

            using (var cmd = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@DayOfWeek", timetable.DayOfWeek);
                cmd.Parameters.AddWithValue("@TimeSlot", timetable.TimeSlot);
                cmd.Parameters.AddWithValue("@SubjectID", timetable.SubjectID);
                cmd.Parameters.AddWithValue("@RoomID", timetable.RoomID);
                cmd.Parameters.AddWithValue("@LecturerID", timetable.LecturerID);
                cmd.Parameters.AddWithValue("@TimetableID", timetable.TimetableID);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool DeleteTimetableEntry(int id, SQLiteConnection conn)
        {
            string query = "DELETE FROM Timetables WHERE TimetableID = @id";
            using (var cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool IsRoomFree(int roomID, string day, string time)
        {
            using (var conn = DBConfig.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM Timetables WHERE RoomID = @room AND DayOfWeek = @day AND TimeSlot = @time";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@room", roomID);
                    cmd.Parameters.AddWithValue("@day", day);
                    cmd.Parameters.AddWithValue("@time", time);
                    long count = (long)cmd.ExecuteScalar();
                    return count == 0;
                }
            }
        }

        public bool IsLecturerFree(int lecturerID, string day, string time)
        {
            using (var conn = DBConfig.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM Timetables WHERE LecturerID = @lecturer AND DayOfWeek = @day AND TimeSlot = @time";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@lecturer", lecturerID);
                    cmd.Parameters.AddWithValue("@day", day);
                    cmd.Parameters.AddWithValue("@time", time);
                    long count = (long)cmd.ExecuteScalar();
                    return count == 0;
                }
            }
        }
    }
}
