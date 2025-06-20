using System;
using System.Data;
using System.Windows.Forms;
using UMS_New.Controller;
using UMS_New.Data;

namespace UMS_New.Views.DashboardFiles
{
    public partial class AddMarks : UserControl
    {
        private marksController marksController;
        private examController examController;
        private studentController studentController;

        public AddMarks()
        {
            InitializeComponent();

            this.Load += AddMarks_Load;

            marksController = new marksController();
            examController = new examController();
            studentController = new studentController();

            LoadExams();

            cmbExams.SelectedIndexChanged += cmbExams_SelectedIndexChanged;
            btnSave.Click += btnSave_Click;

            SetupDataGridView();
        }

        private void AddMarks_Load(object sender, EventArgs e)
        {
            // Optional: Load logic on form load
        }

        private void LoadExams()
        {
            using (var conn = DBConfig.GetConnection())
            {
                var dt = examController.GetAllExams(conn);
                cmbExams.DisplayMember = "ExamName";
                cmbExams.ValueMember = "Id";
                cmbExams.DataSource = dt;
                cmbExams.SelectedIndex = -1;
            }
        }

        private void SetupDataGridView()
        {
            dgvMarks.Columns.Clear();

            var colStudentId = new DataGridViewTextBoxColumn
            {
                Name = "StudentId",
                HeaderText = "Student Id",
                Visible = false,
                Width = 50 // optional
            };
            dgvMarks.Columns.Add(colStudentId);

            var colStudentName = new DataGridViewTextBoxColumn
            {
                Name = "StudentName",
                HeaderText = "Student Name",
                ReadOnly = true,
                Width = 150
            };
            dgvMarks.Columns.Add(colStudentName);

            var colUTNumber = new DataGridViewTextBoxColumn
            {
                Name = "UT_Number",
                HeaderText = "UT Number",
                ReadOnly = true,
                Width = 120
            };
            dgvMarks.Columns.Add(colUTNumber);

            var colMark = new DataGridViewTextBoxColumn
            {
                Name = "Mark",
                HeaderText = "Mark",
                Width = 80
            };
            dgvMarks.Columns.Add(colMark);

            var colGrade = new DataGridViewTextBoxColumn
            {
                Name = "Grade",
                HeaderText = "Grade",
                ReadOnly = true,
                Width = 80
            };
            dgvMarks.Columns.Add(colGrade);

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
                if (exam == null)
                    return;

                int subjectId = Convert.ToInt32(exam["SubjectId"]);

                var students = studentController.GetStudentsByCourseId(subjectId, conn);
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

        // Optional: if you want to handle any clicks on the DataGridView (empty now)
        private void dgvMarks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            // Your existing save logic here
        }

    }
}
