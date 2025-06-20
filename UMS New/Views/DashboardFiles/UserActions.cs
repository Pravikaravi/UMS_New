using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using UMS_New.Controller;
using UMS_New.Data;
using UMS_New.Model;

namespace UMS_New.Views.DashboardFiles
{
    public partial class UserActions : UserControl
    {
        private userController controller;
        private int selectedUserId = -1;

        public UserActions()
        {
            InitializeComponent();
            controller = new userController();
            LoadUsers();
            dgvUsers.SelectionChanged += DgvUsers_SelectionChanged;
            dgvUsers.CellClick += DgvUsers_CellClick;
        }

        private void UserActions_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void LoadUsers()
        {
            using (var conn = DBConfig.GetConnection())
            {
                var dt = controller.GetAllUsers(conn);
                dgvUsers.DataSource = dt;
                dgvUsers.ClearSelection();
                selectedUserId = -1;

                // Set column widths (adjust widths as needed)
                if (dgvUsers.Columns.Contains("Id"))
                    dgvUsers.Columns["Id"].Width = 40;

                if (dgvUsers.Columns.Contains("Username"))
                    dgvUsers.Columns["Username"].Width = 150;

                if (dgvUsers.Columns.Contains("Password"))
                    dgvUsers.Columns["Password"].Width = 150;

                if (dgvUsers.Columns.Contains("Email"))
                    dgvUsers.Columns["Email"].Width = 150;

                if (dgvUsers.Columns.Contains("Role"))
                    dgvUsers.Columns["Role"].Width = 100;

                // Add Edit button if not already added
                if (!dgvUsers.Columns.Contains("Edit"))
                {
                    DataGridViewButtonColumn editBtn = new DataGridViewButtonColumn();
                    editBtn.HeaderText = "Edit";
                    editBtn.Name = "Edit";
                    editBtn.Text = "✏️";
                    editBtn.UseColumnTextForButtonValue = true;
                    editBtn.Width = 75;
                    dgvUsers.Columns.Add(editBtn);
                }

                // Add Delete button if not already added
                if (!dgvUsers.Columns.Contains("Delete"))
                {
                    DataGridViewButtonColumn deleteBtn = new DataGridViewButtonColumn();
                    deleteBtn.HeaderText = "Delete";
                    deleteBtn.Name = "Delete";
                    deleteBtn.Text = "🗑️";
                    deleteBtn.UseColumnTextForButtonValue = true;
                    deleteBtn.Width = 75;
                    dgvUsers.Columns.Add(deleteBtn);
                }
            }
        }


        private void DgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                selectedUserId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["Id"].Value);
            }
            else
            {
                selectedUserId = -1;
            }
        }

        private void DgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int id = Convert.ToInt32(dgvUsers.Rows[e.RowIndex].Cells["Id"].Value);

                if (dgvUsers.Columns[e.ColumnIndex].Name == "Edit")
                {
                    string username = Interaction.InputBox("Edit Username:", "Edit User", dgvUsers.Rows[e.RowIndex].Cells["Username"].Value.ToString());
                    if (string.IsNullOrWhiteSpace(username)) return;

                    string password = Interaction.InputBox("Edit Password:", "Edit User", dgvUsers.Rows[e.RowIndex].Cells["Password"].Value.ToString());
                    if (string.IsNullOrWhiteSpace(password)) return;

                    string role = Interaction.InputBox("Edit Role:", "Edit User", dgvUsers.Rows[e.RowIndex].Cells["Role"].Value.ToString());
                    if (string.IsNullOrWhiteSpace(role)) return;

                    var updatedUser = new User
                    {
                        Id = id,
                        Username = username,
                        Password = password,
                        Role = role
                    };

                    using (var conn = DBConfig.GetConnection())
                    {
                        controller.UpdateUser(updatedUser, conn);
                        MessageBox.Show("User updated successfully");
                        LoadUsers();
                    }
                }
                else if (dgvUsers.Columns[e.ColumnIndex].Name == "Delete")
                {
                    var confirm = MessageBox.Show("Are you sure to delete this user?", "Confirm Delete", MessageBoxButtons.YesNo);
                    if (confirm == DialogResult.Yes)
                    {
                        using (var conn = DBConfig.GetConnection())
                        {
                            controller.DeleteUser(id, conn);
                            MessageBox.Show("User deleted successfully");
                            LoadUsers();
                        }
                    }
                }
            }
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}