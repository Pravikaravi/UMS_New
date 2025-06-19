using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMS_New.Controller;
using UMS_New.Data;
using UMS_New.Model;

namespace UMS_New.Views.DashboardFiles
{
    public partial class SubjectActions : UserControl
    {
        private subjectController controller;
        private int selectedSubjectId = -1;
        public SubjectActions()
        {
            InitializeComponent();
            controller = new subjectController();
            LoadSubjects(); // Call directly here
            dgvSubjects.SelectionChanged += DgvSubjects_SelectionChanged;
            dgvSubjects.CellClick += DgvSubjects_CellClick;
        }

        private void dgvSubjects_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SubjectActions_Load(object sender, EventArgs e)
        {
            LoadSubjects();
        }

        private void DgvSubjects_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSubjects.SelectedRows.Count > 0)
            {
                selectedSubjectId = Convert.ToInt32(dgvSubjects.SelectedRows[0].Cells["Id"].Value);
            }
            else
            {
                selectedSubjectId = -1;
            }
        }

        private void LoadSubjects()
        {
            using (var conn = DBConfig.GetConnection())
            {
                var dt = controller.GetAllSubjects(conn);
                dgvSubjects.DataSource = dt;
                dgvSubjects.ClearSelection();
                selectedSubjectId = -1;

                if (!dgvSubjects.Columns.Contains("Edit"))
                {
                    DataGridViewButtonColumn editBtn = new DataGridViewButtonColumn();
                    editBtn.HeaderText = "Edit";
                    editBtn.Name = "Edit";
                    editBtn.Text = "✏️";
                    editBtn.UseColumnTextForButtonValue = true;
                    dgvSubjects.Columns.Add(editBtn);
                }

                if (!dgvSubjects.Columns.Contains("Delete"))
                {
                    DataGridViewButtonColumn deleteBtn = new DataGridViewButtonColumn();
                    deleteBtn.HeaderText = "Delete";
                    deleteBtn.Name = "Delete";
                    deleteBtn.Text = "🗑️";
                    deleteBtn.UseColumnTextForButtonValue = true;
                    dgvSubjects.Columns.Add(deleteBtn);
                }
            }
        }


        private void DgvSubjects_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int id = Convert.ToInt32(dgvSubjects.Rows[e.RowIndex].Cells["Id"].Value);

                if (dgvSubjects.Columns[e.ColumnIndex].Name == "Edit")
                {
                    string subjectname = Interaction.InputBox("Edit Subject Name:", "Edit Subject", dgvSubjects.Rows[e.RowIndex].Cells["SubjectName"].Value.ToString());
                    if (string.IsNullOrWhiteSpace(subjectname)) return;

                    string description = Interaction.InputBox("Edit Description:", "Edit Subject", dgvSubjects.Rows[e.RowIndex].Cells["Description"].Value.ToString());
                    if (string.IsNullOrWhiteSpace(description)) return;

                    var updatedSubject = new Subject
                    {
                        Id = id,
                        SubjectName = subjectname,
                        Description = description,
                        CourseID = id
                    };

                    using (var conn = DBConfig.GetConnection())
                    {
                        controller.UpdateSubject(updatedSubject, conn);
                        MessageBox.Show("Subject updated successfully");
                        LoadSubjects();
                    }
                }
                else if (dgvSubjects.Columns[e.ColumnIndex].Name == "Delete")
                {
                    var confirm = MessageBox.Show("Are you sure to delete this subject?", "Confirm Delete", MessageBoxButtons.YesNo);
                    if (confirm == DialogResult.Yes)
                    {
                        using (var conn = DBConfig.GetConnection())
                        {
                            controller.DeleteSubject(id, conn);
                            MessageBox.Show("Subject deleted successfully");
                            LoadSubjects();
                        }
                    }
                }
            }
        }
    }
}
