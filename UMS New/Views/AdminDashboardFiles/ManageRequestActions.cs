using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using UMS_New.Controller;
using UMS_New.Data;
using UMS_New.Model;
using UUMS_New.Model;

namespace UMS_New.Views.DashboardFiles
{
    public partial class ManageRequestActions : UserControl
    {
        private userController userController = new userController();
        private studentController studentController = new studentController();
        private int selectedRequestId = -1;

        public ManageRequestActions()
        {
            InitializeComponent();
            LoadManageRequests();

            dgvManageRequests.SelectionChanged += DgvManageRequests_SelectionChanged;
            dgvManageRequests.CellClick += DgvManageRequests_CellClick;
        }

        private void ManageRequestActions_Load(object sender, EventArgs e)
        {
            LoadManageRequests();
        }

        private void LoadManageRequests()
        {
            using (var conn = DBConfig.GetConnection())
            {
                string query = @"
            SELECT 
                sr.Id, 
                sr.StudentName, 
                sr.UT_Number, 
                sr.Phone_Number, 
                sr.Email, 
                sr.Password, 
                sr.CourseID,
                c.CourseName
            FROM SignupRequests sr
            JOIN Course c ON sr.CourseID = c.Id";

                var dt = new DataTable();

                using (var cmd = new SQLiteCommand(query, conn))
                using (var adapter = new SQLiteDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }

                dgvManageRequests.DataSource = dt;

                // Hide Id, CourseID, Password, and Email columns
                if (dgvManageRequests.Columns.Contains("Id"))
                    dgvManageRequests.Columns["Id"].Visible = false;

                if (dgvManageRequests.Columns.Contains("CourseID"))
                    dgvManageRequests.Columns["CourseID"].Visible = false;

                if (dgvManageRequests.Columns.Contains("Password"))
                    dgvManageRequests.Columns["Password"].Visible = false;

                if (dgvManageRequests.Columns.Contains("Email"))
                    dgvManageRequests.Columns["Email"].Visible = false;

                // Set column widths (adjust as needed)
                if (dgvManageRequests.Columns.Contains("StudentName"))
                    dgvManageRequests.Columns["StudentName"].Width = 132;

                if (dgvManageRequests.Columns.Contains("UT_Number"))
                    dgvManageRequests.Columns["UT_Number"].Width = 100;

                if (dgvManageRequests.Columns.Contains("Phone_Number"))
                    dgvManageRequests.Columns["Phone_Number"].Width = 110;

                if (dgvManageRequests.Columns.Contains("CourseName"))
                    dgvManageRequests.Columns["CourseName"].Width = 130;

                dgvManageRequests.ClearSelection();
                selectedRequestId = -1;

                if (!dgvManageRequests.Columns.Contains("Accept"))
                {
                    var acceptBtn = new DataGridViewButtonColumn
                    {
                        HeaderText = "Accept",
                        Name = "Accept",
                        Text = "✔️",
                        UseColumnTextForButtonValue = true,
                        Width = 60
                    };
                    dgvManageRequests.Columns.Add(acceptBtn);
                }

                if (!dgvManageRequests.Columns.Contains("Reject"))
                {
                    var rejectBtn = new DataGridViewButtonColumn
                    {
                        HeaderText = "Reject",
                        Name = "Reject",
                        Text = "❌",
                        UseColumnTextForButtonValue = true,
                        Width = 60
                    };
                    dgvManageRequests.Columns.Add(rejectBtn);
                }
            }
        }

        private void DgvManageRequests_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvManageRequests.SelectedRows.Count > 0)
            {
                selectedRequestId = Convert.ToInt32(dgvManageRequests.SelectedRows[0].Cells["Id"].Value);
            }
            else
            {
                selectedRequestId = -1;
            }
        }

        private void dgvManageRequests_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional: leave empty or add logic if needed
        }

        private void DgvManageRequests_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int requestId = Convert.ToInt32(dgvManageRequests.Rows[e.RowIndex].Cells["Id"].Value);

            if (dgvManageRequests.Columns[e.ColumnIndex].Name == "Accept")
            {
                var confirm = MessageBox.Show("Accept this signup request?", "Confirm Accept", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    AcceptRequest(requestId);
                }
            }
            else if (dgvManageRequests.Columns[e.ColumnIndex].Name == "Reject")
            {
                var confirm = MessageBox.Show("Reject and delete this signup request?", "Confirm Reject", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    RejectRequest(requestId);
                }
            }
        }

        private void AcceptRequest(int requestId)
        {
            using (var conn = DBConfig.GetConnection())
            {
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Get request data
                        string selectQuery = "SELECT StudentName, UT_Number, Phone_Number, Email, Password, CourseID FROM SignupRequests WHERE Id = @id";
                        string name = "", ut = "", phone = "", email = "", password = "";
                        int courseId = 0;

                        using (var cmd = new SQLiteCommand(selectQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", requestId);
                            using (var reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    name = reader.GetString(0);
                                    ut = reader.GetString(1);
                                    phone = reader.GetString(2);
                                    email = reader.GetString(3);
                                    password = reader.GetString(4);
                                    courseId = reader.GetInt32(5);
                                }
                                else
                                {
                                    MessageBox.Show("Request data not found.");
                                    return;
                                }
                            }
                        }

                        // Insert into User table
                        var user = new User
                        {
                            Username = ut,
                            Password = password,
                            Role = "Student"
                        };
                        userController.CreateUser(user, conn);

                        long userId = (long)new SQLiteCommand("SELECT last_insert_rowid();", conn).ExecuteScalar();

                        // Insert into Student table
                        var student = new Student
                        {
                            StudentName = name,
                            UT_Number = ut,
                            Phone_Number = phone,
                            Email = email,
                            UserID = (int)userId,
                            CourseID = courseId
                        };
                        studentController.CreateStudent(student, conn);

                        // Delete from SignupRequests
                        string deleteQuery = "DELETE FROM SignupRequests WHERE Id = @id";
                        using (var delCmd = new SQLiteCommand(deleteQuery, conn))
                        {
                            delCmd.Parameters.AddWithValue("@id", requestId);
                            delCmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("Signup request accepted and user created successfully!");
                        LoadManageRequests();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error processing acceptance: " + ex.Message);
                    }
                }
            }
        }

        private void RejectRequest(int requestId)
        {
            using (var conn = DBConfig.GetConnection())
            {
                string deleteQuery = "DELETE FROM SignupRequests WHERE Id = @id";
                using (var cmd = new SQLiteCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@id", requestId);
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Signup request rejected and deleted.");
                        LoadManageRequests();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete signup request.");
                    }
                }
            }
        }
    }
}
