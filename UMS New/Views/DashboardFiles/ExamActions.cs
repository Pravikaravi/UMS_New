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
    public partial class ExamActions : UserControl
    {
        private examController examController;
        private int selectedExamId = -1;

        public ExamActions()
        {
            InitializeComponent();
            examController = new examController();
            LoadExams();

            dgvExams.SelectionChanged += DgvExams_SelectionChanged;
            dgvExams.CellClick += DgvExams_CellClick;
        }

        private void ExamActions_Load(object sender, EventArgs e)
        {
            LoadExams();
        }

        private void LoadExams()
        {
            using (var conn = DBConfig.GetConnection())
            {
                DataTable dt = examController.GetAllExams(conn);
                dgvExams.DataSource = dt;
                dgvExams.ClearSelection();
                selectedExamId = -1;

                // Hide ID columns
                if (dgvExams.Columns.Contains("Id"))
                    dgvExams.Columns["Id"].Visible = false;

                if (dgvExams.Columns.Contains("RoomId"))
                    dgvExams.Columns["RoomId"].Visible = false;

                if (dgvExams.Columns.Contains("SubjectId"))
                    dgvExams.Columns["SubjectId"].Visible = false;

                // Adjust widths of visible columns
                if (dgvExams.Columns.Contains("ExamName"))
                    dgvExams.Columns["ExamName"].Width = 100;

                if (dgvExams.Columns.Contains("ExamDate"))
                    dgvExams.Columns["ExamDate"].Width = 80;

                if (dgvExams.Columns.Contains("StartTime"))
                    dgvExams.Columns["StartTime"].Width = 60;

                if (dgvExams.Columns.Contains("DurationMinutes"))
                    dgvExams.Columns["DurationMinutes"].Width = 50;

                // Add Edit and Delete buttons if not exist
                if (!dgvExams.Columns.Contains("Edit"))
                {
                    var editBtn = new DataGridViewButtonColumn();
                    editBtn.HeaderText = "Edit";
                    editBtn.Name = "Edit";
                    editBtn.Text = "✏️";
                    editBtn.UseColumnTextForButtonValue = true;
                    editBtn.Width = 50;
                    dgvExams.Columns.Add(editBtn);
                }

                if (!dgvExams.Columns.Contains("Delete"))
                {
                    var deleteBtn = new DataGridViewButtonColumn();
                    deleteBtn.HeaderText = "Delete";
                    deleteBtn.Name = "Delete";
                    deleteBtn.Text = "🗑️";
                    deleteBtn.UseColumnTextForButtonValue = true;
                    deleteBtn.Width = 50;
                    dgvExams.Columns.Add(deleteBtn);
                }
            }
        }


        private void DgvExams_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvExams.SelectedRows.Count > 0)
            {
                selectedExamId = Convert.ToInt32(dgvExams.SelectedRows[0].Cells["Id"].Value);
            }
            else
            {
                selectedExamId = -1;
            }
        }

        private void dgvExams_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional future use
        }

        private void DgvExams_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(dgvExams.Rows[e.RowIndex].Cells["Id"].Value);

            if (dgvExams.Columns[e.ColumnIndex].Name == "Edit")
            {
                string examName = Interaction.InputBox("Edit Exam Name:", "Edit Exam", dgvExams.Rows[e.RowIndex].Cells["ExamName"].Value.ToString());
                if (string.IsNullOrWhiteSpace(examName)) return;

                string examDateStr = Interaction.InputBox("Edit Exam Date (YYYY-MM-DD):", "Edit Exam", dgvExams.Rows[e.RowIndex].Cells["ExamDate"].Value.ToString());
                if (!DateTime.TryParse(examDateStr, out DateTime examDate))
                {
                    MessageBox.Show("Invalid Exam Date format! Use YYYY-MM-DD.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string startTimeStr = Interaction.InputBox("Edit Start Time (HH:mm:ss):", "Edit Exam", dgvExams.Rows[e.RowIndex].Cells["StartTime"].Value.ToString());
                if (!TimeSpan.TryParse(startTimeStr, out TimeSpan startTime))
                {
                    MessageBox.Show("Invalid Start Time format! Use HH:mm:ss.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string durationStr = Interaction.InputBox("Edit Duration (minutes):", "Edit Exam", dgvExams.Rows[e.RowIndex].Cells["DurationMinutes"].Value.ToString());
                if (!int.TryParse(durationStr, out int duration))
                {
                    MessageBox.Show("Invalid Duration! Please enter a number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int roomId = Convert.ToInt32(dgvExams.Rows[e.RowIndex].Cells["RoomId"].Value);
                int subjectId = Convert.ToInt32(dgvExams.Rows[e.RowIndex].Cells["SubjectId"].Value);

                var updatedExam = new Exam
                {
                    Id = id,
                    ExamName = examName,
                    ExamDate = examDate,
                    StartTime = startTime,
                    DurationMinutes = duration,
                    RoomId = roomId,
                    SubjectId = subjectId
                };

                using (var conn = DBConfig.GetConnection())
                {
                    examController.UpdateExam(updatedExam, conn);
                    MessageBox.Show("Exam updated successfully");
                    LoadExams();
                }
            }
            else if (dgvExams.Columns[e.ColumnIndex].Name == "Delete")
            {
                var confirm = MessageBox.Show("Are you sure to delete this exam?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    using (var conn = DBConfig.GetConnection())
                    {
                        examController.DeleteExam(id, conn);
                        MessageBox.Show("Exam deleted successfully");
                        LoadExams();
                    }
                }
            }
        }
    }
}
