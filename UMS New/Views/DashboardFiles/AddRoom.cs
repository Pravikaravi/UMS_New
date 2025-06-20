using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using UMS_New.Controller;
using UMS_New.Data;
using UMS_New.Model;

namespace UMS_New.Views.DashboardFiles
{
    public partial class AddRoom : UserControl
    {
        private RoomController roomController = new RoomController();

        public AddRoom()
        {
            InitializeComponent();
        }

        private void AddRoom_Load(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            // Validation check
            if (string.IsNullOrWhiteSpace(txtRoomName.Text) || numCapacity.Value <= 0)
            {
                MessageBox.Show("Please enter Room Name and a valid Capacity.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Prepare Room object
            Room room = new Room
            {
                RoomName = txtRoomName.Text.Trim(),
                Capacity = (int)numCapacity.Value,
                IsAvailable = chkAvailable.Checked
            };

            // Save to DB
            using (var conn = DBConfig.GetConnection())
            {
                roomController.CreateRoom(room, conn);
            }

            // Feedback
            MessageBox.Show("Room added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearForm();
        }

        private void chkStaff_CheckedChanged(object sender, EventArgs e)
        {
            // Empty or your logic
        }


        private void ClearForm()
        {
            txtRoomName.Clear();
            numCapacity.Value = 1;
            chkAvailable.Checked = true;
        }
    }
}
