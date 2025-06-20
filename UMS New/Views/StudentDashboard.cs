using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMS_New.Views.LecturerDashboardFiles;
using UMS_New.Views.StudentDashboardFiles;

namespace UMS_New.Views
{
    public partial class StudentDashboard : Form
    {
        public StudentDashboard()
        {
            InitializeComponent();
        }

        private void leftLecturer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rightStudent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void StudentDashboard_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = UMS_New.Session.UserSession.Username;
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            rightStudent.Controls.Clear(); // Clear existing controls
            myProfile myprofileControl = new myProfile(); // Create the control
            myprofileControl.Dock = DockStyle.Fill; // Fill the panel
            rightStudent.Controls.Add(myprofileControl); // Add to the panel
        }

        private void btnTimetable_Click(object sender, EventArgs e)
        {
            rightStudent.Controls.Clear(); // Clear existing controls
            myTimetable mytimetableControl = new myTimetable(); // Create the control
            mytimetableControl.Dock = DockStyle.Fill; // Fill the panel
            rightStudent.Controls.Add(mytimetableControl); // Add to the panel

        }

        private void btnExams_Click(object sender, EventArgs e)
        {
            rightStudent.Controls.Clear(); // Clear existing controls
            myExams myexamsControl = new myExams(); // Create the control
            myexamsControl.Dock = DockStyle.Fill; // Fill the panel
            rightStudent.Controls.Add(myexamsControl); // Add to the panel

        }

        private void btnMarks_Click(object sender, EventArgs e)
        {
            rightStudent.Controls.Clear(); // Clear existing controls
            myMarks mymarksControl = new myMarks(); // Create the control
            mymarksControl.Dock = DockStyle.Fill; // Fill the panel
            rightStudent.Controls.Add(mymarksControl); // Add to the panel

        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            rightStudent.Controls.Clear(); // Clear existing controls
            myAttendance myattendanceControl = new myAttendance(); // Create the control
            myattendanceControl.Dock = DockStyle.Fill; // Fill the panel
            rightStudent.Controls.Add(myattendanceControl); // Add to the panel

        }
    }
}
