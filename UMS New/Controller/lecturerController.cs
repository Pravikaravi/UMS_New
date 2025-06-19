using System.Data.SQLite;
using UMS_New.Model;

internal class lecturerController
{
    public void CreateLecturer(Lecturer lecturer, SQLiteConnection conn)
    {
        // 1. Insert Lecturer info
        string insert = "INSERT INTO Lecturer (LecturerName, Phone_Number, Email, UserID) VALUES (@LecturerName, @Phone, @Email, @userId)";
        using (var cmd = new SQLiteCommand(insert, conn))
        {
            cmd.Parameters.AddWithValue("@LecturerName", lecturer.LecturerName);
            cmd.Parameters.AddWithValue("@Phone", lecturer.Phone_Number);
            cmd.Parameters.AddWithValue("@Email", lecturer.Email);
            cmd.Parameters.AddWithValue("@userId", lecturer.UserID);
            cmd.ExecuteNonQuery();
        }

        // 2. Get the last inserted lecturer ID
        long lecturerId = (long)new SQLiteCommand("SELECT last_insert_rowid();", conn).ExecuteScalar();

        // 3. Insert entries into Lecturer_Subject table for each selected subject
        foreach (var subjectId in lecturer.SubjectIDs)
        {
            string insertLink = "INSERT INTO Lecturer_Subject (LecturerID, SubjectID) VALUES (@lecturerId, @subjectId)";
            using (var linkCmd = new SQLiteCommand(insertLink, conn))
            {
                linkCmd.Parameters.AddWithValue("@lecturerId", lecturerId);
                linkCmd.Parameters.AddWithValue("@subjectId", subjectId);
                linkCmd.ExecuteNonQuery();
            }
        }
    }
}
