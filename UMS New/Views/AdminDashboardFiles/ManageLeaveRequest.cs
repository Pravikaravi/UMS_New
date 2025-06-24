using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using UMS_New.Controller;
using UMS_New.Data;
using UMS_New.Model;

namespace UMS_New.Views.DashboardFiles
{
    public partial class ManageLeaveRequest : UserControl
    {
        private leaverequestController leaveRequestController = new leaverequestController();
        private int selectedLeaveRequestId = -1;

        public ManageLeaveRequest()
        {
            InitializeComponent();
            LoadLeaveRequests();

            dgvLeaveRequests.SelectionChanged += DgvLeaveRequests_SelectionChanged;
            dgvLeaveRequests.CellClick += DgvLeaveRequests_CellClick;
        }

        private void ManageLeaveRequest_Load(object sender, EventArgs e)
        {
            LoadLeaveRequests();
        }

        private void LoadLeaveRequests()
        {
            using (var conn = DBConfig.GetConnection())
            {
                string query = @"
                SELECT 
                    lr.Id, 
                    lr.UserID,
                    lr.UT_Number,  
                    lr.Start_Date, 
                    lr.End_Date, 
                    lr.Reason
                FROM LeaveRequests lr";

                var dt = new DataTable();

                using (var cmd = new SQLiteCommand(query, conn))
                using (var adapter = new SQLiteDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }

                dgvLeaveRequests.DataSource = dt;

                
                if (dgvLeaveRequests.Columns.Contains("Id"))
                    dgvLeaveRequests.Columns["Id"].Visible = false;

                if (dgvLeaveRequests.Columns.Contains("UserID"))
                    dgvLeaveRequests.Columns["UserID"].Visible = false;

                // Set column widths (adjust as needed)
                if (dgvLeaveRequests.Columns.Contains("StudentName"))
                    dgvLeaveRequests.Columns["StudentName"].Width = 132;

                if (dgvLeaveRequests.Columns.Contains("UT_Number"))
                    dgvLeaveRequests.Columns["UT_Number"].Width = 100;

                if (dgvLeaveRequests.Columns.Contains("Phone_Number"))
                    dgvLeaveRequests.Columns["Phone_Number"].Width = 110;

                if (dgvLeaveRequests.Columns.Contains("Start_Date"))
                    dgvLeaveRequests.Columns["Start_Date"].Width = 130;

                if (dgvLeaveRequests.Columns.Contains("End_Date"))
                    dgvLeaveRequests.Columns["End_Date"].Width = 130;

                dgvLeaveRequests.ClearSelection();
                selectedLeaveRequestId = -1;

                if (!dgvLeaveRequests.Columns.Contains("Accept"))
                {
                    var acceptBtn = new DataGridViewButtonColumn
                    {
                        HeaderText = "Accept",
                        Name = "Accept",
                        Text = "✔️",
                        UseColumnTextForButtonValue = true,
                        Width = 67
                    };
                    dgvLeaveRequests.Columns.Add(acceptBtn);
                }

                if (!dgvLeaveRequests.Columns.Contains("Reject"))
                {
                    var rejectBtn = new DataGridViewButtonColumn
                    {
                        HeaderText = "Reject",
                        Name = "Reject",
                        Text = "❌",
                        UseColumnTextForButtonValue = true,
                        Width = 67
                    };
                    dgvLeaveRequests.Columns.Add(rejectBtn);
                }
            }
        }

        private void DgvLeaveRequests_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLeaveRequests.SelectedRows.Count > 0)
            {
                selectedLeaveRequestId = Convert.ToInt32(dgvLeaveRequests.SelectedRows[0].Cells["Id"].Value);
            }
            else
            {
                selectedLeaveRequestId = -1;
            }
        }

        private void DgvLeaveRequests_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Skip if the clicked row is the header or invalid
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            // Get the value of the "Id" cell from the clicked row
            var cellValue = dgvLeaveRequests.Rows[e.RowIndex].Cells["Id"].Value;

            // Check if the value is null or DBNull
            if (cellValue == null || cellValue == DBNull.Value)
            {
                MessageBox.Show("Invalid leave request ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Safely convert to int
            int leaveRequestId = Convert.ToInt32(cellValue);

            // Get the column name that was clicked
            string columnName = dgvLeaveRequests.Columns[e.ColumnIndex].Name;

            if (columnName == "Accept")
            {
                var confirm = MessageBox.Show("Accept this leave request?", "Confirm Accept", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    AcceptLeaveRequest(leaveRequestId);
                }
            }
            else if (columnName == "Reject")
            {
                var confirm = MessageBox.Show("Reject and delete this leave request?", "Confirm Reject", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    RejectLeaveRequest(leaveRequestId);
                }
            }
        }

        private void AcceptLeaveRequest(int leaveRequestId)
        {
            using (var conn = DBConfig.GetConnection())
            {
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Get leave request data
                        string selectQuery = @"
                    SELECT 
                        UT_Number, 
                        Start_Date, 
                        End_Date, 
                        Reason 
                    FROM LeaveRequests 
                    WHERE Id = @id";

                        string ut = "", reason = "";
                        DateTime startDate = DateTime.MinValue, endDate = DateTime.MinValue;

                        using (var cmd = new SQLiteCommand(selectQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", leaveRequestId);
                            using (var reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    ut = reader.GetString(0); 
                                    reason = reader.GetString(3); 

                                    // Try to parse Start_Date and End_Date, ensuring the format is valid
                                    string startDateStr = reader.GetString(1);
                                    string endDateStr = reader.GetString(2);

                                    if (!DateTime.TryParse(startDateStr, out startDate))
                                    {
                                        MessageBox.Show("Invalid start date format.");
                                        return;
                                    }

                                    if (!DateTime.TryParse(endDateStr, out endDate))
                                    {
                                        MessageBox.Show("Invalid end date format.");
                                        return;
                                    }

                                    // Set the date portion only (ignoring the time)
                                    startDate = startDate.Date;
                                    endDate = endDate.Date;
                                }
                                else
                                {
                                    MessageBox.Show("Leave request data not found.");
                                    return;
                                }
                            }
                        }

                        // Insert into AcceptLeave table without UserID
                        string insertAcceptQuery = @"
                    INSERT INTO AcceptLeave (UT_Number, Start_Date, End_Date, Reason) 
                    VALUES (@utNumber, @startDate, @endDate, @reason)";

                        using (var cmd = new SQLiteCommand(insertAcceptQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@utNumber", ut);
                            cmd.Parameters.AddWithValue("@startDate", startDate);
                            cmd.Parameters.AddWithValue("@endDate", endDate);
                            cmd.Parameters.AddWithValue("@reason", reason);

                            int rowsInserted = cmd.ExecuteNonQuery();
                            if (rowsInserted > 0)
                            {
                                Console.WriteLine("Successfully inserted into AcceptLeave.");
                            }
                            else
                            {
                                Console.WriteLine("Failed to insert into AcceptLeave.");
                            }
                        }

                        // Delete from LeaveRequests table
                        string deleteQuery = "DELETE FROM LeaveRequests WHERE Id = @id";
                        using (var delCmd = new SQLiteCommand(deleteQuery, conn))
                        {
                            delCmd.Parameters.AddWithValue("@id", leaveRequestId);
                            int rowsDeleted = delCmd.ExecuteNonQuery();
                            if (rowsDeleted > 0)
                            {
                                Console.WriteLine("Successfully deleted from LeaveRequests.");
                            }
                            else
                            {
                                Console.WriteLine("Failed to delete from LeaveRequests.");
                            }
                        }

                        // Commit the transaction if both operations succeeded
                        transaction.Commit();
                        MessageBox.Show("Leave request accepted and stored successfully!");
                        LoadLeaveRequests();  // Refresh the data grid
                    }
                    catch (Exception ex)
                    {
                        // Rollback the transaction in case of an error
                        transaction.Rollback();
                        MessageBox.Show("Error processing acceptance: " + ex.Message);
                        Console.WriteLine("Error: " + ex.Message); // Log the error for debugging
                    }
                }
            }
        }




        private void RejectLeaveRequest(int leaveRequestId)
        {
            using (var conn = DBConfig.GetConnection())
            {
                string deleteQuery = "DELETE FROM LeaveRequests WHERE Id = @id";
                using (var cmd = new SQLiteCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@id", leaveRequestId);
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Leave request rejected and deleted.");
                        LoadLeaveRequests();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete leave request.");
                    }
                }
            }
        }

        private void dgvLeaveRequests_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
