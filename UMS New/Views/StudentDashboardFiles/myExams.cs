using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using UMS_New.Controller;
using UMS_New.Data;
using UMS_New.Session;

namespace UMS_New.Views.StudentDashboardFiles
{
    public partial class myExams : UserControl
    {
        private examController examController;

        public myExams()
        {
            InitializeComponent();
            examController = new examController();
            this.Load += myExams_Load;
            dgvMyExams.CellContentClick += dgvMyExams_CellContentClick;
        }

        private void myExams_Load(object sender, EventArgs e)
        {
            LoadStudentExams();
        }

        private void LoadStudentExams()
        {
            using (var conn = DBConfig.GetConnection())
            {
                string username = UserSession.Username;

                DataTable dt = examController.GetExamsByStudentUsername(username, conn);

                dgvMyExams.DataSource = dt;

                if (dgvMyExams.Columns.Contains("Id"))
                    dgvMyExams.Columns["Id"].Visible = false;

                if (dgvMyExams.Columns.Contains("RoomId"))
                    dgvMyExams.Columns["RoomId"].Visible = false;

                if (dgvMyExams.Columns.Contains("SubjectId"))
                    dgvMyExams.Columns["SubjectId"].Visible = false;

                if (dgvMyExams.Columns.Contains("ExamName"))
                    dgvMyExams.Columns["ExamName"].HeaderText = "Exam";

                if (dgvMyExams.Columns.Contains("ExamDate"))
                    dgvMyExams.Columns["ExamDate"].HeaderText = "Date";

                if (dgvMyExams.Columns.Contains("StartTime"))
                    dgvMyExams.Columns["StartTime"].HeaderText = "Start Time";

                if (dgvMyExams.Columns.Contains("DurationMinutes"))
                    dgvMyExams.Columns["DurationMinutes"].HeaderText = "Duration (min)";

                dgvMyExams.ClearSelection();
            }
        }


        private void dgvMyExams_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell clicks if needed
        }
    }
}
