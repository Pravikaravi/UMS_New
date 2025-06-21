using System;
using System.Data;
using System.Data.SQLite;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using UMS_New.Controller;
using UMS_New.Data;
using UMS_New.Model;

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

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(txtEmail.Text, emailPattern))
            {
                MessageBox.Show("Please enter a valid email address!");
                return;
            }

            string phonePattern = @"^\d{10}$";
            if (!Regex.IsMatch(txtPhone_Number.Text, phonePattern))
            {
                MessageBox.Show("Phone number must be exactly 10 digits!");
                return;
            }

            string utPattern = @"^UT\d{6}$";
            if (!Regex.IsMatch(txtUT_Number.Text, utPattern))
            {
                MessageBox.Show("UT Number must be 'UT' followed by 6 digits (e.g., UT010008)!");
                return;
            }

            string passwordPattern = @"^[a-zA-Z0-9]{6,12}$";
            if (!Regex.IsMatch(txtPassword.Text, passwordPattern))
            {
                MessageBox.Show("Password must be 6–12 characters with letters and numbers only. No symbols allowed!");
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
               

                // ✅ Check if UT Number already exists
                if (studentController.IsUTNumberExists(txtUT_Number.Text, conn))
                {
                    MessageBox.Show("UT Number already exists! Please enter a unique UT Number.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

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
