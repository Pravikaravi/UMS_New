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
using UMS_New.Data;
using UMS_New.Model;

namespace UMS_New.Views.LecturerDashboardFiles
{
    public partial class AddStudyMaterials : UserControl
    {
        private string selectedMaterialPath = "";

        private int currentLecturerId = 1; // Replace with actual logged-in lecturer ID (you can pass it from login/session)

        public AddStudyMaterials()
        {
            InitializeComponent();
        }

        private void cmbCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Make sure something is selected and it’s a valid int
            if (cmbCourses.SelectedValue != null && int.TryParse(cmbCourses.SelectedValue.ToString(), out int courseId))
            {
                // Load subjects related to the selected course
                
                cmbSubject.DisplayMember = "SubjectName";
                cmbSubject.ValueMember = "Id";
                cmbSubject.DataSource = GetSubjectsByCourse(courseId);
            }

        }

        private List<Subject> GetSubjectsByCourse(int courseId)
        {
            List<Subject> subjectList = new List<Subject>();
            using (var conn = DBConfig.GetConnection())
            {
              
                string query = "SELECT Id, SubjectName FROM Subject WHERE CourseID = @courseId";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@courseId", courseId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            subjectList.Add(new Subject
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                SubjectName = reader["SubjectName"].ToString()
                            });
                        }
                    }
                }
            }
            return subjectList;
        }




        private void cmbSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSubject.SelectedValue != null)
            {
                int subjectId = Convert.ToInt32(cmbSubject.SelectedValue);
                // Optional: fetch or show subject details
            }

        }

        private List<Course> GetAllCourses()
        {
            List<Course> courseList = new List<Course>();
            using (var conn = DBConfig.GetConnection())
            {
                
                string query = "SELECT Id, CourseName FROM Course";
                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        courseList.Add(new Course
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            CourseName = reader["CourseName"].ToString()
                        });
                    }
                }
            }
            return courseList;
        }


        private void AddStudyMaterials_Load(object sender, EventArgs e)
        {
            cmbCourses.DataSource = GetAllCourses();
            cmbCourses.DisplayMember = "CourseName";
            cmbCourses.ValueMember = "Id";
        }

        private void btnupload_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PDF files|*.pdf|Word Documents|*.docx|All files|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                selectedMaterialPath = ofd.FileName;
                lblFilePath.Text = selectedMaterialPath; // You need a label to show the path
            }

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text) || string.IsNullOrWhiteSpace(selectedMaterialPath) || cmbSubject.SelectedValue == null)
            {
                MessageBox.Show("Please fill in all fields and select a file.");
                return;
            }

            try
            {
                string fileName = System.IO.Path.GetFileName(selectedMaterialPath);
                string targetFolder = System.IO.Path.Combine(Application.StartupPath, "StudyMaterials");
                System.IO.Directory.CreateDirectory(targetFolder);

                string savedFilePath = System.IO.Path.Combine(targetFolder, fileName);
                System.IO.File.Copy(selectedMaterialPath, savedFilePath, true);

                StudyMaterial material = new StudyMaterial
                {
                    Title = txtTitle.Text,
                    Description = txtDescription.Text,
                    FilePath = savedFilePath,
                    UploadDate = DateTime.Now.ToString("yyyy-MM-dd"),
                    SubjectID = Convert.ToInt32(cmbSubject.SelectedValue),
                    LecturerID = currentLecturerId
                };

                var controller = new UMS_New.Controller.StudyMaterialController();
                controller.AddMaterial(material);

                MessageBox.Show("Study material uploaded successfully!");
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ClearForm()
        {
            txtTitle.Text = "";
            txtDescription.Text = "";
            lblFilePath.Text = "";
            selectedMaterialPath = "";
            cmbCourses.SelectedIndex = 0;
            cmbSubject.SelectedIndex = 0;
        }


    }
}
