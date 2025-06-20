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
    public partial class StudentActions : UserControl
    {
        private studentController studentController;
        private int selectedStudentId = -1;

        public StudentActions()
        {
            InitializeComponent();
            studentController = new studentController();
            LoadStudents();
            dgvStudents.SelectionChanged += DgvStudents_SelectionChanged;
            dgvStudents.CellClick += DgvStudents_CellClick;
        }

        private void StudentActions_Load(object sender, EventArgs e)
        {
            LoadStudents();
        }

        private void LoadStudents()
        {
            using (var conn = DBConfig.GetConnection())
            {
                DataTable dt = studentController.GetAllStudents(conn);
                dgvStudents.DataSource = dt;
                dgvStudents.ClearSelection();
                selectedStudentId = -1;

                // Hide Id and UserID
                if (dgvStudents.Columns.Contains("Id"))
                    dgvStudents.Columns["Id"].Visible = false;
                if (dgvStudents.Columns.Contains("UserID"))
                    dgvStudents.Columns["UserID"].Visible = false;

                // Hide CourseID since we show CourseName
                if (dgvStudents.Columns.Contains("CourseID"))
                    dgvStudents.Columns["CourseID"].Visible = false;

                // Adjust visible columns width and headers
                if (dgvStudents.Columns.Contains("StudentName"))
                    dgvStudents.Columns["StudentName"].Width = 100;

                if (dgvStudents.Columns.Contains("UT_Number"))
                    dgvStudents.Columns["UT_Number"].Width = 70;

                if (dgvStudents.Columns.Contains("Phone_Number"))
                    dgvStudents.Columns["Phone_Number"].Width = 80;

                if (dgvStudents.Columns.Contains("Email"))
                    dgvStudents.Columns["Email"].Width = 120;

                if (dgvStudents.Columns.Contains("CourseName"))
                {
                    dgvStudents.Columns["CourseName"].HeaderText = "Course";
                    dgvStudents.Columns["CourseName"].Width = 120;
                }

                // Add Edit button if not present
                if (!dgvStudents.Columns.Contains("Edit"))
                {
                    var editBtn = new DataGridViewButtonColumn();
                    editBtn.HeaderText = "Edit";
                    editBtn.Name = "Edit";
                    editBtn.Text = "✏️";
                    editBtn.UseColumnTextForButtonValue = true;
                    editBtn.Width = 50;
                    dgvStudents.Columns.Add(editBtn);
                }

                // Add Delete button if not present
                if (!dgvStudents.Columns.Contains("Delete"))
                {
                    var deleteBtn = new DataGridViewButtonColumn();
                    deleteBtn.HeaderText = "Delete";
                    deleteBtn.Name = "Delete";
                    deleteBtn.Text = "🗑️";
                    deleteBtn.UseColumnTextForButtonValue = true;
                    deleteBtn.Width = 50;
                    dgvStudents.Columns.Add(deleteBtn);
                }
            }
        }

        private void DgvStudents_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count > 0)
                selectedStudentId = Convert.ToInt32(dgvStudents.SelectedRows[0].Cells["Id"].Value);
            else
                selectedStudentId = -1;
        }

        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional for future logic
        }

        private void DgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(dgvStudents.Rows[e.RowIndex].Cells["Id"].Value);

            if (dgvStudents.Columns[e.ColumnIndex].Name == "Edit")
            {
                string name = Interaction.InputBox("Edit Name:", "Edit Student", dgvStudents.Rows[e.RowIndex].Cells["StudentName"].Value.ToString());
                if (string.IsNullOrWhiteSpace(name)) return;

                string phone = Interaction.InputBox("Edit Phone Number:", "Edit Student", dgvStudents.Rows[e.RowIndex].Cells["Phone_Number"].Value.ToString());
                if (string.IsNullOrWhiteSpace(phone)) return;

                string email = Interaction.InputBox("Edit Email:", "Edit Student", dgvStudents.Rows[e.RowIndex].Cells["Email"].Value.ToString());
                if (string.IsNullOrWhiteSpace(email)) return;

                // For UT_Number and UserID, get values from the grid directly
                string utNumber = dgvStudents.Rows[e.RowIndex].Cells["UT_Number"].Value.ToString();
                int userId = Convert.ToInt32(dgvStudents.Rows[e.RowIndex].Cells["UserID"].Value);

                // CourseID is hidden but present in data source
                int courseId = Convert.ToInt32(dgvStudents.Rows[e.RowIndex].Cells["CourseID"].Value);

                var updatedStudent = new Student
                {
                    Id = id,
                    StudentName = name,
                    Phone_Number = phone,
                    Email = email,
                    UT_Number = utNumber,
                    CourseID = courseId,
                    UserID = userId
                };

                using (var conn = DBConfig.GetConnection())
                {
                    studentController.UpdateStudent(updatedStudent, conn);
                    MessageBox.Show("Student updated successfully");
                    LoadStudents();
                }
            }
            else if (dgvStudents.Columns[e.ColumnIndex].Name == "Delete")
            {
                var confirm = MessageBox.Show("Are you sure to delete this student?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    using (var conn = DBConfig.GetConnection())
                    {
                        studentController.DeleteStudent(id, conn);
                        MessageBox.Show("Student deleted successfully");
                        LoadStudents();
                    }
                }
            }
        }
    }
}
