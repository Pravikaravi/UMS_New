using System;
using System.Data;
using System.Windows.Forms;
using UMS_New.Session;
using UMS_New.Data;
using UMS_New.Controller;

namespace UMS_New.Views.StudentDashboardFiles
{
    public partial class myProfile : UserControl
    {
        private studentController studentController;

        public myProfile()
        {
            InitializeComponent();
            studentController = new studentController();
            this.Load += myProfile_Load;
            btnSave.Click += btnSave_Click;
        }

        private void myProfile_Load(object sender, EventArgs e)
        {
            LoadStudentInfo();
        }

        private void LoadStudentInfo()
        {
            using (var conn = DBConfig.GetConnection())
            {
                string username = UserSession.Username;
                DataTable studentData = studentController.GetStudentByUsername(username, conn);

                if (studentData.Rows.Count > 0)
                {
                    var student = studentData.Rows[0];

                    txtName.Text = student["StudentName"].ToString();
                    txtUT_Number.Text = student["UT_Number"].ToString();
                    txtEmail.Text = student["Email"].ToString();
                    txtPhone_Number.Text = student["Phone_Number"].ToString();
                    txtCourse.Text = student["CourseName"].ToString();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (var conn = DBConfig.GetConnection())
            {
                string username = UserSession.Username;
                DataTable studentData = studentController.GetStudentByUsername(username, conn);

                if (studentData.Rows.Count > 0)
                {
                    var studentRow = studentData.Rows[0];
                    int studentId = Convert.ToInt32(studentRow["Id"]);

                    var updatedStudent = new UMS_New.Model.Student
                    {
                        Id = studentId,
                        StudentName = studentRow["StudentName"].ToString(),
                        UT_Number = studentRow["UT_Number"].ToString(),
                        Email = txtEmail.Text.Trim(),
                        Phone_Number = txtPhone_Number.Text.Trim(),
                        CourseID = Convert.ToInt32(studentRow["CourseID"]),
                        UserID = Convert.ToInt32(studentRow["UserID"])
                    };

                    studentController.UpdateStudent(updatedStudent, conn);
                    MessageBox.Show("Profile updated successfully!");
                }
            }
        }
    }
}
