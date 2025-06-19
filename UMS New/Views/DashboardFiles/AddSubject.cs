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
using UMS_New.Controller;
using UMS_New.Data;
using UMS_New.Model;

namespace UMS_New.Views.DashboardFiles
{
    public partial class AddSubject : UserControl
    {
        private courseController courseController;
        private subjectController subjectController = new subjectController();

        public AddSubject()
        {
            InitializeComponent();
            courseController = new courseController();
            LoadCourses();
        }

        private void LoadCourses()
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


        private void cmbCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            
           

        }

        private void ClearForm()
        {
            txtSubjectName.Clear();
            txtDescription.Clear();
            cmbCourses.SelectedIndex = -1;
        }


        private void AddSubject_Load(object sender, EventArgs e)
        {

        }

        private void btnAddSubject_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSubjectName.Text) ||
        string.IsNullOrWhiteSpace(txtDescription.Text) ||
        cmbCourses.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill all fields and select a course", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var conn = DBConfig.GetConnection())
            {

                var subject = new Subject
                {
                    SubjectName = txtSubjectName.Text,
                    Description = txtDescription.Text,
                    CourseID = Convert.ToInt32(cmbCourses.SelectedValue)
                };

                subjectController.CreateSubject(subject, conn);
            }

            MessageBox.Show("Subject added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearForm();
        }
    }
}
