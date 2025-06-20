using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using UMS_New.Controller;
using UMS_New.Data;
using UMS_New.Session;

namespace UMS_New.Views.LecturerDashboardFiles
{
    public partial class viewMarks : UserControl
    {
        private marksController marksController;
        private examController examController;
        private studentController studentController;

        public viewMarks()
        {
            InitializeComponent();

            marksController = new marksController();
            examController = new examController();
            studentController = new studentController();

            this.Load += ViewMarks_Load;

            cmbExams.SelectedIndexChanged += cmbExams_SelectedIndexChanged;
            btnSave.Click += btnSave_Click;

            SetupDataGridView();
        }

        private void ViewMarks_Load(object sender, EventArgs e)
        {
            LoadExams();
        }

        private void LoadExams()
        {
            using (var conn = DBConfig.GetConnection())
            {
                // Load only exams for the logged-in lecturer (by username)
                var dt = examController.GetExamsByLecturerUsername(UserSession.Username, conn);
                cmbExams.DisplayMember = "ExamName";
                cmbExams.ValueMember = "Id";
                cmbExams.DataSource = dt;
                cmbExams.SelectedIndex = -1;
            }
        }

        private void SetupDataGridView()
        {
            dgvMarks.Columns.Clear();

            dgvMarks.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "StudentId",
                HeaderText = "Student Id",
                Visible = false
            });

            dgvMarks.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "StudentName",
                HeaderText = "Student Name",
                ReadOnly = true,
                Width = 150
            });

            dgvMarks.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "UT_Number",
                HeaderText = "UT Number",
                ReadOnly = true,
                Width = 120
            });

            dgvMarks.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Mark",
                HeaderText = "Mark",
                Width = 80
            });

            dgvMarks.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Grade",
                HeaderText = "Grade",
                ReadOnly = true,
                Width = 80
            });

            dgvMarks.AllowUserToAddRows = false;
            dgvMarks.AllowUserToDeleteRows = false;
        }

        private void cmbExams_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbExams.SelectedIndex == -1) return;

            int examId = Convert.ToInt32(cmbExams.SelectedValue);
            LoadStudentsForExam(examId);
        }

        private void LoadStudentsForExam(int examId)
        {
            dgvMarks.Rows.Clear();

            using (var conn = DBConfig.GetConnection())
            {
                var exam = examController.GetExamById(examId, conn);
                if (exam == null) return;

                int subjectId = Convert.ToInt32(exam["SubjectId"]);

                // Get the course ID for the subject
                int courseId = -1;
                using (var cmd = new SQLiteCommand("SELECT CourseID FROM Subject WHERE Id = @subjectId", conn))
                {
                    cmd.Parameters.AddWithValue("@subjectId", subjectId);
                    var result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                        courseId = Convert.ToInt32(result);
                    else
                        return;  // no course found for subject
                }

                // Now get students by courseId
                var students = studentController.GetStudentsByCourseId(courseId, conn);
                var existingMarks = marksController.GetMarksByExamId(examId, conn);

                foreach (DataRow student in students.Rows)
                {
                    int studentId = Convert.ToInt32(student["Id"]);
                    string studentName = student["StudentName"].ToString();
                    string utNumber = student["UT_Number"].ToString();

                    DataRow[] marksRow = existingMarks.Select($"StudentId = {studentId}");

                    string markStr = marksRow.Length > 0 ? marksRow[0]["Mark"].ToString() : "";
                    string grade = GetGrade(markStr);

                    dgvMarks.Rows.Add(studentId, studentName, utNumber, markStr, grade);
                }
            }
        }


        private string GetGrade(string markStr)
        {
            if (string.Equals(markStr, "AB", StringComparison.OrdinalIgnoreCase))
                return "AB";

            if (int.TryParse(markStr, out int mark))
            {
                if (mark >= 90) return "A";
                if (mark >= 80) return "B";
                if (mark >= 60) return "C";
                if (mark >= 40) return "D";
                return "E";
            }

            return "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbExams.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an exam first!");
                return;
            }

            int examId = Convert.ToInt32(cmbExams.SelectedValue);

            using (var conn = DBConfig.GetConnection())
            {
                foreach (DataGridViewRow row in dgvMarks.Rows)
                {
                    int studentId = Convert.ToInt32(row.Cells["StudentId"].Value);
                    string markText = row.Cells["Mark"].Value?.ToString().Trim();

                    if (string.Equals(markText, "AB", StringComparison.OrdinalIgnoreCase))
                    {
                        marksController.SaveOrUpdateMark(examId, studentId, "AB", "AB", conn);
                        row.Cells["Grade"].Value = "AB";
                    }
                    else if (int.TryParse(markText, out int mark) && mark >= 0)
                    {
                        string grade = GetGrade(mark.ToString());
                        marksController.SaveOrUpdateMark(examId, studentId, mark.ToString(), grade, conn);
                        row.Cells["Grade"].Value = grade;
                    }
                    else
                    {
                        MessageBox.Show($"Invalid mark for student {row.Cells["StudentName"].Value}. Setting to 0 and grade E.", "Invalid Mark", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        row.Cells["Mark"].Value = 0;
                        row.Cells["Grade"].Value = "E";
                        marksController.SaveOrUpdateMark(examId, studentId, "0", "E", conn);
                    }
                }
            }

            MessageBox.Show("Marks and Grades saved successfully!");
        }

        private void dgvMarks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional: handle DataGridView cell clicks if needed
        }
    }
}
