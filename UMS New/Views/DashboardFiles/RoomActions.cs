using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Windows.Forms;
using UMS_New.Controller;
using UMS_New.Data;
using UMS_New.Model;

namespace UMS_New.Views.DashboardFiles
{
    public partial class RoomActions : UserControl
    {
        private roomController controller = new roomController();
        private int selectedRoomId = -1;

        public RoomActions()
        {
            InitializeComponent();
            LoadRooms();
            dgvRooms.SelectionChanged += DgvRooms_SelectionChanged;
            dgvRooms.CellClick += DgvRooms_CellClick;
        }

        private void RoomActions_Load(object sender, EventArgs e)
        {
            LoadRooms();
        }

        private void dgvRooms_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional: Leave blank or redirect to CellClick
            // DgvRooms_CellClick(sender, e); ← if you want
        }


        private void LoadRooms()
        {
            using (var conn = DBConfig.GetConnection())
            {
                DataTable dt = controller.GetAllRooms(conn);
                dgvRooms.DataSource = dt;
                dgvRooms.ClearSelection();
                selectedRoomId = -1;

                // Hide ID if needed
                if (dgvRooms.Columns.Contains("Id"))
                    dgvRooms.Columns["Id"].Width = 50;

                // Set column widths
                if (dgvRooms.Columns.Contains("RoomName"))
                    dgvRooms.Columns["RoomName"].Width = 180;

                if (dgvRooms.Columns.Contains("Capacity"))
                    dgvRooms.Columns["Capacity"].Width = 100;

                if (dgvRooms.Columns.Contains("IsAvailable"))
                    dgvRooms.Columns["IsAvailable"].Width = 100;

                // Add Edit button
                if (!dgvRooms.Columns.Contains("Edit"))
                {
                    DataGridViewButtonColumn editBtn = new DataGridViewButtonColumn
                    {
                        HeaderText = "Edit",
                        Name = "Edit",
                        Text = "✏️",
                        UseColumnTextForButtonValue = true,
                        Width = 80
                    };
                    dgvRooms.Columns.Add(editBtn);
                }

                // Add Delete button
                if (!dgvRooms.Columns.Contains("Delete"))
                {
                    DataGridViewButtonColumn deleteBtn = new DataGridViewButtonColumn
                    {
                        HeaderText = "Delete",
                        Name = "Delete",
                        Text = "🗑️",
                        UseColumnTextForButtonValue = true,
                        Width = 80
                    };
                    dgvRooms.Columns.Add(deleteBtn);
                }
            }
        }


        private void DgvRooms_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRooms.SelectedRows.Count > 0)
            {
                selectedRoomId = Convert.ToInt32(dgvRooms.SelectedRows[0].Cells["Id"].Value);
            }
            else
            {
                selectedRoomId = -1;
            }
        }

        private void DgvRooms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int id = Convert.ToInt32(dgvRooms.Rows[e.RowIndex].Cells["Id"].Value);

                if (dgvRooms.Columns[e.ColumnIndex].Name == "Edit")
                {
                    string roomName = Interaction.InputBox("Edit Room Name:", "Edit Room", dgvRooms.Rows[e.RowIndex].Cells["RoomName"].Value.ToString());
                    if (string.IsNullOrWhiteSpace(roomName)) return;

                    string capacityStr = Interaction.InputBox("Edit Capacity:", "Edit Room", dgvRooms.Rows[e.RowIndex].Cells["Capacity"].Value.ToString());
                    if (!int.TryParse(capacityStr, out int capacity)) return;

                    string isAvailableStr = Interaction.InputBox("Is Available? (Yes/No):", "Edit Room", dgvRooms.Rows[e.RowIndex].Cells["IsAvailable"].Value.ToString());
                    bool isAvailable = isAvailableStr.Equals("Yes", StringComparison.OrdinalIgnoreCase);

                    Room updatedRoom = new Room
                    {
                        Id = id,
                        RoomName = roomName,
                        Capacity = capacity,
                        IsAvailable = isAvailable
                    };

                    using (var conn = DBConfig.GetConnection())
                    {
                        controller.UpdateRoom(updatedRoom, conn);
                        MessageBox.Show("Room updated successfully!");
                        LoadRooms();
                    }
                }
                else if (dgvRooms.Columns[e.ColumnIndex].Name == "Delete")
                {
                    DialogResult confirm = MessageBox.Show("Are you sure to delete this room?", "Confirm Delete", MessageBoxButtons.YesNo);
                    if (confirm == DialogResult.Yes)
                    {
                        using (var conn = DBConfig.GetConnection())
                        {
                            controller.DeleteRoom(id, conn);
                            MessageBox.Show("Room deleted successfully!");
                            LoadRooms();
                        }
                    }
                }
            }
        }
    }
}
