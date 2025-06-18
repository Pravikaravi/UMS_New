using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Data.SQLite;
using UMS_New.Controller;
using UMS_New.Data;
using UMS_New.Model;


namespace UMS_New.Views.DashboardFiles
{
    public partial class CourseActions : UserControl
    {
        private courseController controller;
        private int selectedCourseId = -1;

        public CourseActions()
        {
            InitializeComponent();
            controller = new courseController();
            LoadCourses(); // Call directly here
            dgvCourses.SelectionChanged += DgvCourses_SelectionChanged;
            dgvCourses.CellClick += DgvCourses_CellClick;
        }


        private void CourseActions_Load(object sender, EventArgs e)
        {
            LoadCourses();
        }

        private void LoadCourses()
        {
            using (var conn = DBConfig.GetConnection())
            {
                var dt = controller.GetAllCourses(conn);
                dgvCourses.DataSource = dt;
                dgvCourses.ClearSelection();
                selectedCourseId = -1;

                if (!dgvCourses.Columns.Contains("Edit"))
                {
                    DataGridViewButtonColumn editBtn = new DataGridViewButtonColumn();
                    editBtn.HeaderText = "Edit";
                    editBtn.Name = "Edit";
                    editBtn.Text = "✏️";
                    editBtn.UseColumnTextForButtonValue = true;
                    dgvCourses.Columns.Add(editBtn);
                }

                if (!dgvCourses.Columns.Contains("Delete"))
                {
                    DataGridViewButtonColumn deleteBtn = new DataGridViewButtonColumn();
                    deleteBtn.HeaderText = "Delete";
                    deleteBtn.Name = "Delete";
                    deleteBtn.Text = "🗑️";
                    deleteBtn.UseColumnTextForButtonValue = true;
                    dgvCourses.Columns.Add(deleteBtn);
                }
            }
        }

        private void DgvCourses_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCourses.SelectedRows.Count > 0)
            {
                selectedCourseId = Convert.ToInt32(dgvCourses.SelectedRows[0].Cells["Id"].Value);
            }
            else
            {
                selectedCourseId = -1;
            }
        }

        private void DgvCourses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int id = Convert.ToInt32(dgvCourses.Rows[e.RowIndex].Cells["Id"].Value);

                if (dgvCourses.Columns[e.ColumnIndex].Name == "Edit")
                {
                    string coursename = Interaction.InputBox("Edit Course Name:", "Edit Course", dgvCourses.Rows[e.RowIndex].Cells["CourseName"].Value.ToString());
                    if (string.IsNullOrWhiteSpace(coursename)) return;

                    string duration = Interaction.InputBox("Edit Duration:", "Edit Course", dgvCourses.Rows[e.RowIndex].Cells["Duration"].Value.ToString());
                    if (string.IsNullOrWhiteSpace(duration)) return;

                    string description = Interaction.InputBox("Edit Description:", "Edit Course", dgvCourses.Rows[e.RowIndex].Cells["Description"].Value.ToString());
                    if (string.IsNullOrWhiteSpace(description)) return;

                    var updatedCourse = new Course
                    {
                        Id = id,
                        CourseName = coursename,
                        Duration = duration,
                        Description = description
                    };

                    using (var conn = DBConfig.GetConnection())
                    {
                        controller.UpdateCourse(updatedCourse, conn);
                        MessageBox.Show("Course updated successfully");
                        LoadCourses();
                    }
                }
                else if (dgvCourses.Columns[e.ColumnIndex].Name == "Delete")
                {
                    var confirm = MessageBox.Show("Are you sure to delete this course?", "Confirm Delete", MessageBoxButtons.YesNo);
                    if (confirm == DialogResult.Yes)
                    {
                        using (var conn = DBConfig.GetConnection())
                        {
                            controller.DeleteCourse(id, conn);
                            MessageBox.Show("Course deleted successfully");
                            LoadCourses();
                        }
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string coursename = Interaction.InputBox("Enter Course Name:", "Add Course");
            if (string.IsNullOrWhiteSpace(coursename)) return;

            string duration = Interaction.InputBox("Enter Duration:", "Add Course");
            if (string.IsNullOrWhiteSpace(duration)) return;

            string description = Interaction.InputBox("Enter Description:", "Add Course");
            if (string.IsNullOrWhiteSpace(description)) return;

            var course = new Course
            {
                CourseName = coursename,
                Duration = duration,
                Description = description
            };

            using (var conn = DBConfig.GetConnection())
            {
                controller.CreateCourse(course, conn);
                MessageBox.Show("Course added successfully");
                LoadCourses();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please use the ✏️ Edit button in the table to update.");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please use the 🗑️ Delete button in the table to remove a course.");
        }

        private void dgvCourses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // You can call the existing CellClick logic here if needed
            DgvCourses_CellClick(sender, e);
        }
    }
}