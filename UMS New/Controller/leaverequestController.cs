using System;
using System.Collections.Generic;
using System.Data.SQLite;
using UMS_New.Model;
using UMS_New.Session;

namespace UMS_New.Controller
{
    internal class leaverequestController
    {
        private string connectionString = "Data Source=UMS_New.db;Version=3;";

        // ===================== ADD LEAVE REQUEST ====================
        public void AddLeaveRequest(LeaveRequest leaveRequest)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = @"
                INSERT INTO LeaveRequests (UserID, UT_Number, Start_Date, End_Date, Reason) 
                VALUES (@userID, @utNumber, @startDate, @endDate, @reason)";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userID", leaveRequest.UserID);
                    cmd.Parameters.AddWithValue("@utNumber", leaveRequest.UT_Number);
                    cmd.Parameters.AddWithValue("@startDate", leaveRequest.Start_Date);
                    cmd.Parameters.AddWithValue("@endDate", leaveRequest.End_Date);
                    cmd.Parameters.AddWithValue("@reason", leaveRequest.Reason);

                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        // ===================== GET LEAVE REQUESTS BY USER ====================
        public List<LeaveRequest> GetLeaveRequestsByUser(int userId)
        {
            List<LeaveRequest> leaveRequests = new List<LeaveRequest>();

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM LeaveRequests WHERE UserID = @userID";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userID", userId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            leaveRequests.Add(new LeaveRequest
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                UserID = Convert.ToInt32(reader["UserID"]),
                                UT_Number = reader["UT_Number"].ToString(),
                                Start_Date = reader["Start_Date"].ToString(),
                                End_Date = reader["End_Date"].ToString(),
                                Reason = reader["Reason"].ToString()
                            });
                        }
                    }
                }

                conn.Close();
            }

            return leaveRequests;
        }
    }
}
