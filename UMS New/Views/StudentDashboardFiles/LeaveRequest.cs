using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using UMS_New.Data;
using UMS_New.Session;

namespace UMS_New.Views.StudentDashboardFiles
{
    public partial class LeaveRequest : UserControl
    {
        public LeaveRequest()
        {
            InitializeComponent();
        }

        // Auto-fill student details (UT Number and Name) when form loads
        private void AutoFillStudentDetails()
        {
            
            // Auto-fill the UT Number
            txtUT_Number.Text = UserSession.Username;

            // Optionally, you can fill in more details, like Name if needed
            //using (var conn = DBConfig.GetConnection())
            //{
            //    string query = "SELECT UserName FROM Users WHERE UserID = @userID";
            //    using (var cmd = new SQLiteCommand(query, conn))
            //    {
            //        cmd.Parameters.AddWithValue("@userID", UserSession.UserID);
            //        using (var reader = cmd.ExecuteReader())
            //        {
            //            if (reader.Read())
            //            {
            //                txtUT_Number.Text = reader["UserName"].ToString();
            //                txtUT_Number.ReadOnly = true; // Make Name field read-only since it's auto-filled
            //            }
            //            else
            //            {
            //                MessageBox.Show("Student data not found!");
            //            }
            //        }
            //    }
            //}
        }

        // Event that triggers when the form loads
        private void LeaveRequest_Load(object sender, EventArgs e)
        {
            txtUT_Number.Text = UserSession.Username;
        }

        // Event when leave request button is clicked
        private void btnLeave_Click(object sender, EventArgs e)
        {
            // Validate the form inputs
            if (string.IsNullOrEmpty(txtUT_Number.Text) || string.IsNullOrEmpty(dtpFirst.Text) ||
                string.IsNullOrEmpty(dtpLastday.Text) || string.IsNullOrEmpty(txtReason.Text))
            {
                MessageBox.Show("Please fill in all the required fields.");
                return;
            }

            try
            {
                using (var conn = DBConfig.GetConnection())
                {
                    // Prepare the query to insert leave request
                    string insertLeaveQuery = @"
                        INSERT INTO LeaveRequests (UserID, UT_Number, Start_Date, End_Date, Reason)
                        VALUES (@UserID, @UTNumber, @StartDate, @EndDate, @Reason)";

                    using (var cmd = new SQLiteCommand(insertLeaveQuery, conn))
                    {
                        // Parameters for the query
                        cmd.Parameters.AddWithValue("@UserID", UserSession.UserID); 
                        cmd.Parameters.AddWithValue("@UTNumber", txtUT_Number.Text);
                        cmd.Parameters.AddWithValue("@StartDate", dtpFirst.Text);   
                        cmd.Parameters.AddWithValue("@EndDate", dtpLastday.Text); 
                        cmd.Parameters.AddWithValue("@Reason", txtReason.Text);

                        // Execute the insert command
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Leave request submitted successfully.");
                    // Optionally, reset the form or close the dialog
                    ResetForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while submitting the leave request: " + ex.Message);
            }
        }

        // Helper method to reset the form fields
        private void ResetForm()
        {
            dtpFirst.Value = DateTime.Today; 
            dtpLastday.Value = DateTime.Today;
            txtReason.Clear();
        }

        // Event to handle any changes in the 'Name' field (if needed for validation)
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            // Any code to handle name changes can be added here
        }

        // Event to handle changes in 'UT Number' field (if needed for validation)
        private void txtUT_Number_TextChanged(object sender, EventArgs e)
        {
            // Any code to handle UT number changes can be added here
        }
    }
}
