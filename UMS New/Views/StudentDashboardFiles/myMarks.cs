using System;
using System.Data;
using System.Windows.Forms;
using UMS_New.Controller;
using UMS_New.Data;
using UMS_New.Session;

namespace UMS_New.Views.StudentDashboardFiles
{
    public partial class myMarks : UserControl
    {
        private marksController marksController;
        private examController examController;
        private studentController studentController;

        public myMarks()
        {
            InitializeComponent();
            marksController = new marksController();
            examController = new examController();
            studentController = new studentController();

            this.Load += myMarks_Load;
        }

        private void myMarks_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadStudentMarks();
        }

        private void SetupDataGridView()
        {
            dgvMyMarks.Columns.Clear();

            dgvMyMarks.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "ExamName",
                HeaderText = "Exam Name",
                ReadOnly = true,
                Width = 150
            });

            dgvMyMarks.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "ExamDate",
                HeaderText = "Exam Date",
                ReadOnly = true,
                Width = 100
            });

            dgvMyMarks.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Mark",
                HeaderText = "Mark",
                ReadOnly = true,
                Width = 70
            });

            dgvMyMarks.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Grade",
                HeaderText = "Grade",
                ReadOnly = true,
                Width = 70
            });

            dgvMyMarks.AllowUserToAddRows = false;
            dgvMyMarks.AllowUserToDeleteRows = false;
        }

        private void dgvMyMarks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // You can leave this empty if you don't need to handle clicks here
        }


        private void LoadStudentMarks()
        {
            dgvMyMarks.Rows.Clear();

            using (var conn = DBConfig.GetConnection())
            {
                string username = UserSession.Username;

                // Get Student ID from username
                var studentData = studentController.GetStudentByUsername(username, conn);
                if (studentData.Rows.Count == 0)
                {
                    MessageBox.Show("Student data not found for current user.");
                    return;
                }

                int studentId = Convert.ToInt32(studentData.Rows[0]["Id"]);

                // Get marks for this student
                DataTable marksData = marksController.GetMarksByStudentId(studentId, conn);

                foreach (DataRow markRow in marksData.Rows)
                {
                    string examName = markRow["ExamName"].ToString();
                    string examDate = Convert.ToDateTime(markRow["ExamDate"]).ToString("yyyy-MM-dd");
                    string mark = markRow["Mark"].ToString();
                    string grade = markRow["Grade"].ToString();

                    dgvMyMarks.Rows.Add(examName, examDate, mark, grade);
                }
            }
        }
    }
}
