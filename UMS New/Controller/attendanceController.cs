using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS_New.Model;

namespace UMS_New.Controller
{
    internal class attendanceController
    {
        public void MarkAttendance(Attendance attendance, SQLiteConnection conn)
        {
            // Check if attendance already exists for the given student, subject, and date
            string checkQuery = @"
        SELECT COUNT(*) FROM Attendance 
        WHERE StudentID = @studentId AND SubjectID = @subjectId AND Date = @date";
            using (var checkCmd = new SQLiteCommand(checkQuery, conn))
            {
                checkCmd.Parameters.AddWithValue("@studentId", attendance.StudentID);
                checkCmd.Parameters.AddWithValue("@subjectId", attendance.SubjectID);
                checkCmd.Parameters.AddWithValue("@date", attendance.Date);

                long count = (long)checkCmd.ExecuteScalar();

                if (count > 0)
                {
                    // Update existing attendance record
                    string updateQuery = @"
                UPDATE Attendance 
                SET Status = @status
                WHERE StudentID = @studentId AND SubjectID = @subjectId AND Date = @date";
                    using (var updateCmd = new SQLiteCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@status", attendance.Status);
                        updateCmd.Parameters.AddWithValue("@studentId", attendance.StudentID);
                        updateCmd.Parameters.AddWithValue("@subjectId", attendance.SubjectID);
                        updateCmd.Parameters.AddWithValue("@date", attendance.Date);
                        updateCmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    // Insert new attendance record
                    string insertQuery = @"
                INSERT INTO Attendance (StudentID, SubjectID, Date, Status)
                VALUES (@studentId, @subjectId, @date, @status)";
                    using (var insertCmd = new SQLiteCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@studentId", attendance.StudentID);
                        insertCmd.Parameters.AddWithValue("@subjectId", attendance.SubjectID);
                        insertCmd.Parameters.AddWithValue("@date", attendance.Date);
                        insertCmd.Parameters.AddWithValue("@status", attendance.Status);
                        insertCmd.ExecuteNonQuery();
                    }
                }
            }
        }



        // Get attendance by subject and date
        public List<Attendance> GetAttendanceBySubjectDate(int subjectId, string date, SQLiteConnection conn)
        {
            var attendanceList = new List<Attendance>();

            string query = @"
                SELECT * FROM Attendance 
                WHERE SubjectID = @subjectId AND Date = @date";

            using (var cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@subjectId", subjectId);
                cmd.Parameters.AddWithValue("@date", date);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        attendanceList.Add(new Attendance
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            StudentID = Convert.ToInt32(reader["StudentID"]),
                            SubjectID = Convert.ToInt32(reader["SubjectID"]),
                            Date = reader["Date"].ToString(),
                            Status = reader["Status"].ToString()
                        });
                    }
                }
            }

            return attendanceList;
        }
    }
}
