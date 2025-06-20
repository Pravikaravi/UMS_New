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
using UMS_New.Views.DashboardFiles;
using UMS_New.Views.LecturerDashboardFiles;

namespace UMS_New.Views
{
    public partial class StaffDashboard : Form
    {
        public StaffDashboard()
        {
            InitializeComponent();
        }

        private void btnMarks_Click(object sender, EventArgs e)
        {
            rightStaff.Controls.Clear(); // Clear existing controls

            AddMarks addmarksControl = new AddMarks(); // Create the user control instance
            addmarksControl.Dock = DockStyle.Fill; // Set to fill the panel

            rightStaff.Controls.Add(addmarksControl); // Add to the panel

        }

        private void btnTimetable_Click(object sender, EventArgs e)
        {
            rightStaff.Controls.Clear(); // Clear existing controls

            viewTimetable timetableControl = new viewTimetable(); // Create the user control instance
            timetableControl.Dock = DockStyle.Fill; // Set to fill the panel

            rightStaff.Controls.Add(timetableControl); // Add to the panel
        }

        private void btnAddExams_Click(object sender, EventArgs e)
        {
            rightStaff.Controls.Clear(); // Clear existing controls

            AddExam addexamControl = new AddExam(); // Create the user control instance
            addexamControl.Dock = DockStyle.Fill; // Set to fill the panel

            rightStaff.Controls.Add(addexamControl); // Add to the panel

        }

        private void btnExamAction_Click(object sender, EventArgs e)
        {
            rightStaff.Controls.Clear(); // Clear existing controls

            ExamActions examactionsControl = new ExamActions(); // Create the user control instance
            examactionsControl.Dock = DockStyle.Fill; // Set to fill the panel

            rightStaff.Controls.Add(examactionsControl); // Add to the panel
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

        private void rightStaff_Paint(object sender, PaintEventArgs e)
        {

        }

        private void StaffDashboard_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = UserSession.Username ?? "";
        }
    }
}
