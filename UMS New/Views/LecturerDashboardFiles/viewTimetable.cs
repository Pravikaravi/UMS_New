using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using UMS_New.Controller;
using UMS_New.Data;

namespace UMS_New.Views.LecturerDashboardFiles
{
    public partial class viewTimetable : UserControl
    {
        private timetableController controller;

        public viewTimetable()
        {
            InitializeComponent();
            controller = new timetableController();
            this.Load += viewTimetable_Load;
        }

        private void viewTimetable_Load(object sender, EventArgs e)
        {
            LoadTimetable();
        }

        private void SetColumnWidth(string columnName, int width)
        {
            if (dgvTimetable.Columns.Contains(columnName))
                dgvTimetable.Columns[columnName].Width = width;
        }


        private void LoadTimetable()
        {
            using (var conn = DBConfig.GetConnection())
            {
                var dt = controller.GetAllTimetableEntriesWithDetails(conn);
                dgvTimetable.DataSource = dt;

                // Hide internal ID columns
                HideColumn("TimetableID");
                HideColumn("SubjectID");
                HideColumn("RoomID");
                HideColumn("LecturerID");

                // Rename column headers
                RenameColumn("DayOfWeek", "Day");
                RenameColumn("TimeSlot", "Time");
                RenameColumn("SubjectName", "Subject");
                RenameColumn("LecturerName", "Lecturer");
                RenameColumn("RoomName", "Room");

                // Set display order
                SetColumnOrder("DayOfWeek", 0);
                SetColumnOrder("TimeSlot", 1);
                SetColumnOrder("SubjectName", 2);
                SetColumnOrder("LecturerName", 3);
                SetColumnOrder("RoomName", 4);

                // Set column widths
                SetColumnWidth("DayOfWeek", 100);
                SetColumnWidth("TimeSlot", 120);
                SetColumnWidth("SubjectName", 100);
                SetColumnWidth("LecturerName", 135);
                SetColumnWidth("RoomName", 120);

                // Make DataGridView read-only
                dgvTimetable.ReadOnly = true;
                dgvTimetable.AllowUserToAddRows = false;
                dgvTimetable.AllowUserToDeleteRows = false;
                dgvTimetable.ClearSelection();
            }
        }


        private void HideColumn(string columnName)
        {
            if (dgvTimetable.Columns.Contains(columnName))
                dgvTimetable.Columns[columnName].Visible = false;
        }

        private void RenameColumn(string columnName, string headerText)
        {
            if (dgvTimetable.Columns.Contains(columnName))
                dgvTimetable.Columns[columnName].HeaderText = headerText;
        }

        private void SetColumnOrder(string columnName, int index)
        {
            if (dgvTimetable.Columns.Contains(columnName))
                dgvTimetable.Columns[columnName].DisplayIndex = index;
        }

        private void dgvTimetable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Do nothing for now (read-only view)
        }
    }
}
