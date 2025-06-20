using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMS_New.Session;
using UMS_New.Views.LecturerDashboardFiles;

namespace UMS_New.Views
{
    public partial class LecturerDashboard : Form
    {
        public LecturerDashboard()
        {
            InitializeComponent();
        }

        private void leftAdmin_Paint(object sender, PaintEventArgs e)
        {

        }

        private void treeAdmin_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void LecturerDashboard_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = UserSession.Username ?? "";
        }

        private void btnTimetable_Click(object sender, EventArgs e)
        {
            rightLecturer.Controls.Clear(); // Clear existing controls
            viewTimetable timetableControl = new viewTimetable(); // Create the control
            timetableControl.Dock = DockStyle.Fill; // Fill the panel
            rightLecturer.Controls.Add(timetableControl); // Add to the panel
        }

        private void btnMarks_Click(object sender, EventArgs e)
        {
            rightLecturer.Controls.Clear(); // Clear existing controls
            viewMarks marksControl = new viewMarks(); // Create the control
            marksControl.Dock = DockStyle.Fill; // Fill the panel
            rightLecturer.Controls.Add(marksControl); // Add to the panel
        }

        private void rightLecturer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Optional: Clear session info if you use a session manager
            UserSession.Username = null;
            UserSession.Role = null;

            // Show the login form
            LoginForm login = new LoginForm();
            login.Show();

            // Close or hide the current dashboard (assuming this is inside the dashboard form)
            this.Close();
        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {

        }
    }
}
