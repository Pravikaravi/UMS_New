using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS_New.Model;

namespace UMS_New.Data
{
    internal class DatabaseInitializer
    {
        public static void CreateTables()
        {
            using (var conn = DBConfig.GetConnection())
            {

                // Enable foreign keys
                SQLiteCommand enableFK = new SQLiteCommand("PRAGMA foreign_keys = ON;", conn);
                enableFK.ExecuteNonQuery();

                // Create Users table
                string createUserTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Users (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        UserName TEXT NOT NULL,
                        Password TEXT NOT NULL,
                        Role TEXT NOT NULL
                    );";
                SQLiteCommand cmd = new SQLiteCommand(createUserTableQuery, conn);
                cmd.ExecuteNonQuery();

                // Create Courses table
                string createCourseTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Course (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        CourseName TEXT NOT NULL,
                        Duration TEXT NOT NULL,
                        Description TEXT NOT NULL
                    );";
                cmd = new SQLiteCommand(createCourseTableQuery, conn);
                cmd.ExecuteNonQuery();

                // Create Student table
                string createStudentTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Student (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        StudentName TEXT NOT NULL,
                        UT_Number TEXT NOT NULL,
                        Phone_Number TEXT NOT NULL,
                        Email TEXT NOT NULL,
                        UserID INTEGER NOT NULL,
                        CourseID INTEGER NOT NULL,
                        FOREIGN KEY(UserID) REFERENCES Users(Id),
                        FOREIGN KEY(CourseID) REFERENCES Course(Id)
                    );";
                cmd = new SQLiteCommand(createStudentTableQuery, conn);
                cmd.ExecuteNonQuery();

                // Create Signup request table
                string createSignupRequestTableQuery = @"
                    CREATE TABLE IF NOT EXISTS SignupRequests (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        StudentName TEXT NOT NULL,
                        UT_Number TEXT NOT NULL,
                        Phone_Number TEXT NOT NULL,
                        Email TEXT NOT NULL,
                        Password TEXT NOT NULL,
                        CourseID INTEGER NOT NULL,
                        RequestDate TEXT NOT NULL,
                        FOREIGN KEY(CourseID) REFERENCES Course(Id)
                    );";
                cmd = new SQLiteCommand(createSignupRequestTableQuery, conn);
                cmd.ExecuteNonQuery();


                // Staff table
                string createStaffTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Staff (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        StaffName TEXT NOT NULL,
                        Phone_Number TEXT NOT NULL,
                        Email TEXT NOT NULL,
                        UserID INT NOT NULL,
                        FOREIGN KEY(UserID) REFERENCES Users(Id)
                    );";
                cmd = new SQLiteCommand(createStaffTableQuery, conn);
                cmd.ExecuteNonQuery();

                // Admin table
                string createAdminTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Admin (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        AdminName TEXT NOT NULL,
                        Phone_Number TEXT NOT NULL,
                        Email TEXT NOT NULL,
                        UserID INT NOT NULL,
                        FOREIGN KEY(UserID) REFERENCES Users(Id)
                    );";
                cmd = new SQLiteCommand(createAdminTableQuery, conn);
                cmd.ExecuteNonQuery();

                // Create Subject table
                string createSubjectTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Subject (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        SubjectName TEXT NOT NULL,
                        Description TEXT NOT NULL,
                        CourseID INT NOT NULL,
                        FOREIGN KEY(CourseID) REFERENCES Course(Id)
                    );";
                cmd = new SQLiteCommand(createSubjectTableQuery, conn);
                cmd.ExecuteNonQuery();

                // Lecturer table
                string createLecturerTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Lecturer (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        LecturerName TEXT NOT NULL,
                        Phone_Number TEXT NOT NULL,
                        Email TEXT NOT NULL,
                        UserID INT NOT NULL,
                        FOREIGN KEY(UserID) REFERENCES Users(Id)
                    );";
                cmd = new SQLiteCommand(createLecturerTableQuery, conn);
                cmd.ExecuteNonQuery();

                // Room table
                string createRoomTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Room (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        RoomName TEXT NOT NULL,
                        Capacity INT NOT NULL,
                        IsAvailable TEXT DEFAULT 'Yes'
                    );";
                cmd = new SQLiteCommand(createRoomTableQuery, conn);
                cmd.ExecuteNonQuery();

                string createLecturer_SubjectTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Lecturer_Subject (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        LecturerID INTEGER,
                        SubjectID INTEGER,
                        FOREIGN KEY(LecturerID) REFERENCES Lecturer(Id),
                        FOREIGN KEY(SubjectID) REFERENCES Subject(Id)
                    );";
                cmd = new SQLiteCommand(createLecturer_SubjectTableQuery, conn);
                cmd.ExecuteNonQuery();

                // Create Exam table
                string createExamTableQuery = @"
                CREATE TABLE IF NOT EXISTS Exam (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    ExamName TEXT NOT NULL,
                    ExamDate TEXT NOT NULL,           -- Store date as 'YYYY-MM-DD' string
                    StartTime TEXT NOT NULL,          -- Store time as 'HH:MM:SS' string
                    DurationMinutes INTEGER NOT NULL, -- Integer for duration in minutes
                    RoomId INTEGER NOT NULL,
                    SubjectId INTEGER NOT NULL,
                    FOREIGN KEY(RoomId) REFERENCES Room(Id),
                    FOREIGN KEY(SubjectId) REFERENCES Subject(Id)
                );";
                cmd = new SQLiteCommand(createExamTableQuery, conn);
                cmd.ExecuteNonQuery();


                // 🆕 Check if Admin exists
                string checkAdminQuery = "SELECT COUNT(*) FROM Users WHERE Role = 'Admin'";
                cmd = new SQLiteCommand(checkAdminQuery, conn);
                long adminCount = (long)cmd.ExecuteScalar();

                if (adminCount == 0)
                {
                    // Insert default admin
                    string insertAdminQuery = "INSERT INTO Users (Username, Password, Role) VALUES (@username, @password, @role)";
                    cmd = new SQLiteCommand(insertAdminQuery, conn);
                    cmd.Parameters.AddWithValue("@username", "admin");
                    cmd.Parameters.AddWithValue("@password", "admin123");
                    cmd.Parameters.AddWithValue("@role", "Admin");
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }
        }
    }
}
