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

namespace UMS_New.Views.DashboardFiles
{

    public partial class AddExam : UserControl
    {
        private roomController roomController = new roomController();
        private subjectController subjectController = new subjectController();

        public AddExam()
        {
            InitializeComponent();
            // Set Date picker to show only date
            dtpExamDate.Format = DateTimePickerFormat.Custom;
            dtpExamDate.CustomFormat = "yyyy-MM-dd";

            // Set Time picker to show time only with up/down control (no calendar)
            dtpStartTime.Format = DateTimePickerFormat.Custom;
            dtpStartTime.CustomFormat = "HH:mm";
            dtpStartTime.ShowUpDown = true;
        }

        private void AddExam_Load(object sender, EventArgs e)
        {
            LoadRooms();
            LoadSubjects();
        }


        private void LoadRooms()
        {
            using (var conn = DBConfig.GetConnection())
            {
                DataTable dt = roomController.GetAvailableRooms(conn);
                cmbRoom.DisplayMember = "RoomName";
                cmbRoom.ValueMember = "Id";
                cmbRoom.DataSource = dt;
                cmbRoom.SelectedIndex = -1;
            }
        }

        private void LoadSubjects()
        {
            using (var conn = DBConfig.GetConnection())
            {
                DataTable dt = subjectController.GetAllSubjects(conn);
                cmbSubject.DisplayMember = "SubjectName";
                cmbSubject.ValueMember = "Id";
                cmbSubject.DataSource = dt;
                cmbSubject.SelectedIndex = -1;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtExamName.Text) ||
                cmbRoom.SelectedIndex == -1 ||
                cmbSubject.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill in all fields before submitting.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string examName = txtExamName.Text.Trim();
            string examDate = dtpExamDate.Value.ToString("yyyy-MM-dd");         // Format as DATE string
            string startTime = dtpStartTime.Value.ToString("HH:mm:ss");         // Format as TIME string
            int durationMinutes = (int)nudDuration.Value;
            int roomId = Convert.ToInt32(cmbRoom.SelectedValue);
            int subjectId = Convert.ToInt32(cmbSubject.SelectedValue);

            try
            {
                using (var conn = DBConfig.GetConnection())
                {
                    string insertQuery = @"
                INSERT INTO Exam 
                (ExamName, ExamDate, StartTime, DurationMinutes, RoomId, SubjectId)
                VALUES
                (@ExamName, @ExamDate, @StartTime, @DurationMinutes, @RoomId, @SubjectId);";

                    using (var cmd = new SQLiteCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@ExamName", examName);
                        cmd.Parameters.AddWithValue("@ExamDate", examDate);
                        cmd.Parameters.AddWithValue("@StartTime", startTime);
                        cmd.Parameters.AddWithValue("@DurationMinutes", durationMinutes);
                        cmd.Parameters.AddWithValue("@RoomId", roomId);
                        cmd.Parameters.AddWithValue("@SubjectId", subjectId);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Exam added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding exam: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            txtExamName.Clear();
            cmbRoom.SelectedIndex = -1;
            cmbSubject.SelectedIndex = -1;
            nudDuration.Value = 1; // or any default you want
            dtpExamDate.Value = DateTime.Now;
            dtpStartTime.Value = DateTime.Now;
        }

    }
}
