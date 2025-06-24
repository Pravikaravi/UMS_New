                                                                                                                                                                                          using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using UMS_New.Design;
using UMS_New.Session;
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
        private void StudentDashboard_Load(object sender, EventArgs e)
        {
            lbl1.Text = UserSession.Username ?? "";

            //new ButtonHoverAnimator(btnProfile, Color.Black);
            //new ButtonHoverAnimator(btnCancel, Color.LightBlue); // reuse for another button


        }
        private void leftLecturer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rightStudent_Paint(object sender, PaintEventArgs e)
        {

        }

       

        private void btnProfile_Click(object sender, EventArgs e)
        {
            rightStudent.Controls.Clear(); 
            myProfile myprofileControl = new myProfile(); 
            myprofileControl.Dock = DockStyle.Fill; 
            rightStudent.Controls.Add(myprofileControl); 
        }

        private void btnTimetable_Click(object sender, EventArgs e)
        {
            rightStudent.Controls.Clear(); 
            myTimetable mytimetableControl = new myTimetable(); 
            mytimetableControl.Dock = DockStyle.Fill; 
            rightStudent.Controls.Add(mytimetableControl); 

        }

        private void btnExams_Click(object sender, EventArgs e)
        {
            rightStudent.Controls.Clear(); 
            myExams myexamsControl = new myExams(); 
            myexamsControl.Dock = DockStyle.Fill; 
            rightStudent.Controls.Add(myexamsControl); 

        }

        private void btnMarks_Click(object sender, EventArgs e)
        {
            rightStudent.Controls.Clear(); 
            myMarks mymarksControl = new myMarks(); 
            mymarksControl.Dock = DockStyle.Fill; 
            rightStudent.Controls.Add(mymarksControl); 

        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            rightStudent.Controls.Clear(); 
            myAttendance myattendanceControl = new myAttendance();
            myattendanceControl.Dock = DockStyle.Fill; 
            rightStudent.Controls.Add(myattendanceControl); 

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Optional: Clear session info if you use a session manager
            UserSession.Username = null;
            UserSession.Role = null;

            
            LoginForm login = new LoginForm();
            login.Show();

            
            this.Close();
        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnProfile_Click_1(object sender, EventArgs e)
        {
            rightStudent.Controls.Clear(); // Clear existing controls
            myProfile myprofileControl = new myProfile(); // Create the control
            myprofileControl.Dock = DockStyle.Fill; // Fill the panel
            rightStudent.Controls.Add(myprofileControl); // Add to the panel
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            rightStudent.Controls.Clear(); 
            ChangePassword changepassword = new ChangePassword(); 
            changepassword.Dock = DockStyle.Fill; 
            rightStudent.Controls.Add(changepassword); 
        }

        
        private void btnLeaveRequest_Click(object sender, EventArgs e)
        {
            rightStudent.Controls.Clear();
            LeaveRequest leaverequest = new LeaveRequest();
            leaverequest.Dock = DockStyle.Fill; 
            rightStudent.Controls.Add(leaverequest); 
        }

        //private void btnStudyMaterials_Click(object sender, EventArgs e)
        //{
        //    rightStudent.Controls.Clear();
        //    ViewStudyMaterials viewstudymaterials = new ViewStudyMaterials();
        //    viewstudymaterials.Dock = DockStyle.Fill;
        //    rightStudent.Controls.Add(viewstudymaterials);
        //}
    }
}
