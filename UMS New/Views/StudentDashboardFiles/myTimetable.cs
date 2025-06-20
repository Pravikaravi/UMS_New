using System;
using System.Data;
using System.Windows.Forms;
using UMS_New.Controller;
using UMS_New.Data;

namespace UMS_New.Views.StudentDashboardFiles
{
    public partial class myTimetable : UserControl
    {
        private timetableController controller;

        public myTimetable()
        {
            InitializeComponent();
            controller = new timetableController();
            this.Load += myTimetable_Load;
        }

        private void myTimetable_Load(object sender, EventArgs e)
        {
            LoadTimetable();
        }

        private void dgvStudentTimetable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Leave empty — no action needed
        }


        private void LoadTimetable()
        {
            using (var conn = DBConfig.GetConnection())
            {
                var dt = controller.GetAllTimetableEntriesWithDetails(conn);
                dgvStudentTimetable.DataSource = dt;

                // Hide IDs (if present)
                if (dgvStudentTimetable.Columns.Contains("TimetableID"))
                    dgvStudentTimetable.Columns["TimetableID"].Visible = false;
                if (dgvStudentTimetable.Columns.Contains("SubjectID"))
                    dgvStudentTimetable.Columns["SubjectID"].Visible = false;
                if (dgvStudentTimetable.Columns.Contains("RoomID"))
                    dgvStudentTimetable.Columns["RoomID"].Visible = false;
                if (dgvStudentTimetable.Columns.Contains("LecturerID"))
                    dgvStudentTimetable.Columns["LecturerID"].Visible = false;

                // Set header text
                dgvStudentTimetable.Columns["DayOfWeek"].HeaderText = "Day";
                dgvStudentTimetable.Columns["TimeSlot"].HeaderText = "Time";
                dgvStudentTimetable.Columns["SubjectName"].HeaderText = "Subject";
                dgvStudentTimetable.Columns["LecturerName"].HeaderText = "Lecturer";
                dgvStudentTimetable.Columns["RoomName"].HeaderText = "Hall";

                // Set display order
                dgvStudentTimetable.Columns["DayOfWeek"].DisplayIndex = 0;
                dgvStudentTimetable.Columns["TimeSlot"].DisplayIndex = 1;
                dgvStudentTimetable.Columns["SubjectName"].DisplayIndex = 2;
                dgvStudentTimetable.Columns["LecturerName"].DisplayIndex = 3;
                dgvStudentTimetable.Columns["RoomName"].DisplayIndex = 4;

                // Set column widths (example values — adjust to your taste)
                dgvStudentTimetable.Columns["DayOfWeek"].Width = 80;
                dgvStudentTimetable.Columns["TimeSlot"].Width = 100;
                dgvStudentTimetable.Columns["SubjectName"].Width = 150;
                dgvStudentTimetable.Columns["LecturerName"].Width = 150;
                dgvStudentTimetable.Columns["RoomName"].Width = 107;

                dgvStudentTimetable.ClearSelection();
            }
        }

    }
}
