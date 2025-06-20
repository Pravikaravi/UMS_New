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
    public partial class AddStudent : UserControl
    {
        private courseController courseController;
        private studentController studentController = new studentController();
        private userController userController = new userController();

        public AddStudent()
        {
            InitializeComponent();
            courseController = new courseController();
            LoadCoursesToComboBox();
        }

        private void LoadCoursesToComboBox()
        {
            using (var conn = DBConfig.GetConnection())
            {
                DataTable dt = courseController.GetAllCourses(conn);
                cmbCourses.DisplayMember = "CourseName";
                cmbCourses.ValueMember = "Id"; 
                cmbCourses.DataSource = dt;
                cmbCourses.SelectedIndex = -1;
            }
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtUT_Number.Text) ||
                string.IsNullOrWhiteSpace(txtPhone_Number.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                cmbCourses.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill all fields and select a course", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var user = new User
            {
                Username = txtUT_Number.Text,
                Password = txtPassword.Text,
                Role = "Student"
            };

            using (var conn = DBConfig.GetConnection())
            {
                using (var transaction = conn.BeginTransaction())
                {
                    userController.CreateUser(user, conn);

                    string getUserIdQuery = "SELECT last_insert_rowid();";
                    using (var cmd = new SQLiteCommand(getUserIdQuery, conn))
                    {
                        long userId = (long)cmd.ExecuteScalar();

                        var student = new Student
                        {
                            StudentName = txtName.Text,
                            UT_Number = txtUT_Number.Text,
                            Phone_Number = txtPhone_Number.Text,
                            Email = txtEmail.Text,
                            UserID = (int)userId,
                            CourseID = Convert.ToInt32(cmbCourses.SelectedValue)
                        };

                        studentController.CreateStudent(student, conn);
                    }

                    transaction.Commit();
                }
            }

            MessageBox.Show("Student added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearForm();
        }


        private void ClearForm()
        {
            txtName.Clear();
            txtUT_Number.Clear();
            txtPhone_Number.Clear();
            txtPassword.Clear();
            txtEmail.Clear();
            cmbCourses.SelectedIndex = -1;
        }

        private void AddStudent_Load(object sender, EventArgs e)
        {
            // Optionally refresh course list here
        }

        private void cmbCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Optional event if needed
        }
    }
}
