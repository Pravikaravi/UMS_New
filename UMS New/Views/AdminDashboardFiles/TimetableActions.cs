using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using UMS_New.Controller;
using UMS_New.Data;
using UMS_New.Model;

namespace UMS_New.Views.DashboardFiles
{
    public partial class TimetableActions : UserControl
    {
        private timetableController controller;

        public TimetableActions()
        {
            InitializeComponent();
            controller = new timetableController();
            this.Load += TimetableActions_Load;
            dgvTimetable.CellClick += dgvTimetable_CellClick;
        }

        private void TimetableActions_Load(object sender, EventArgs e)
        {
            LoadTimetable();
        }

        private void LoadTimetable()
        {
            using (var conn = DBConfig.GetConnection())
            {
                var dt = controller.GetAllTimetableEntriesWithDetails(conn);
                dgvTimetable.DataSource = dt;

                if (dgvTimetable.Columns.Contains("TimetableID"))
                    dgvTimetable.Columns["TimetableID"].Visible = false;
                if (dgvTimetable.Columns.Contains("SubjectID"))
                    dgvTimetable.Columns["SubjectID"].Visible = false;
                if (dgvTimetable.Columns.Contains("RoomID"))
                    dgvTimetable.Columns["RoomID"].Visible = false;
                if (dgvTimetable.Columns.Contains("LecturerID"))
                    dgvTimetable.Columns["LecturerID"].Visible = false;

                dgvTimetable.Columns["DayOfWeek"].HeaderText = "Day";
                dgvTimetable.Columns["TimeSlot"].HeaderText = "Time";
                dgvTimetable.Columns["SubjectName"].HeaderText = "Subject";
                dgvTimetable.Columns["LecturerName"].HeaderText = "Lecturer";
                dgvTimetable.Columns["RoomName"].HeaderText = "Hall";

                dgvTimetable.Columns["DayOfWeek"].DisplayIndex = 0;
                dgvTimetable.Columns["TimeSlot"].DisplayIndex = 1;
                dgvTimetable.Columns["SubjectName"].DisplayIndex = 2;
                dgvTimetable.Columns["LecturerName"].DisplayIndex = 3;
                dgvTimetable.Columns["RoomName"].DisplayIndex = 4;

                if (!dgvTimetable.Columns.Contains("Edit"))
                {
                    var edit = new DataGridViewButtonColumn();
                    edit.Name = "Edit";
                    edit.HeaderText = "Edit";
                    edit.Text = "✏️";
                    edit.UseColumnTextForButtonValue = true;
                    edit.Width = 45;
                    dgvTimetable.Columns.Add(edit);
                }

                if (!dgvTimetable.Columns.Contains("Delete"))
                {
                    var del = new DataGridViewButtonColumn();
                    del.Name = "Delete";
                    del.HeaderText = "Delete";
                    del.Text = "🗑️";
                    del.UseColumnTextForButtonValue = true;
                    del.Width = 45;
                    dgvTimetable.Columns.Add(del);
                }

                dgvTimetable.ClearSelection();
            }
        }

        private void dgvTimetable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(dgvTimetable.Rows[e.RowIndex].Cells["TimetableID"].Value);

            if (dgvTimetable.Columns[e.ColumnIndex].Name == "Edit")
            {
                string day = Interaction.InputBox("Day:", "Edit", dgvTimetable.Rows[e.RowIndex].Cells["DayOfWeek"].Value.ToString());
                string time = Interaction.InputBox("Time Slot:", "Edit", dgvTimetable.Rows[e.RowIndex].Cells["TimeSlot"].Value.ToString());

                // optional: get SubjectID, RoomID, LecturerID from hidden columns
                int subjectId = Convert.ToInt32(dgvTimetable.Rows[e.RowIndex].Cells["SubjectID"].Value);
                int roomId = Convert.ToInt32(dgvTimetable.Rows[e.RowIndex].Cells["RoomID"].Value);
                int lecturerId = Convert.ToInt32(dgvTimetable.Rows[e.RowIndex].Cells["LecturerID"].Value);

                var updated = new Timetable
                {
                    TimetableID = id,
                    DayOfWeek = day,
                    TimeSlot = time,
                    SubjectID = subjectId,
                    RoomID = roomId,
                    LecturerID = lecturerId
                };

                using (var conn = DBConfig.GetConnection())
                {
                    controller.UpdateTimetableEntry(updated, conn);
                    MessageBox.Show("Updated successfully");
                    LoadTimetable();
                }
            }
            else if (dgvTimetable.Columns[e.ColumnIndex].Name == "Delete")
            {
                var confirm = MessageBox.Show("Are you sure?", "Delete", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    using (var conn = DBConfig.GetConnection())
                    {
                        controller.DeleteTimetableEntry(id, conn);
                        MessageBox.Show("Deleted successfully");
                        LoadTimetable();
                    }
                }
            }
        }

        private void dgvTimetable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
