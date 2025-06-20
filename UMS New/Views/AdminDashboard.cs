using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMS_New.Data;
using UMS_New.Session;
using UMS_New.Views.DashboardFiles;

namespace UMS_New.Views
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
            this.pictureBoxBell.Click += pictureBoxBell_Click;
            this.Resize += AdminDashboard_Resize;
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            StyleNotificationLabel();
            UpdateNotificationUI();  // call here to initialize bell & label

            lblWelcome.Text = UMS_New.Session.UserSession.Username;

            // Tree setup
            TreeNode studentNode = treeAdmin.Nodes.Add("Student Management");
            studentNode.Nodes.Add("➕ Add Student");
            studentNode.Nodes.Add("📄 View/Edit/Delete Students");
            studentNode.Nodes.Add("📄 Manage requests");

            TreeNode userNode = treeAdmin.Nodes.Add("User Management");
            userNode.Nodes.Add("➕ Add User");
            userNode.Nodes.Add("📄 View/Edit/Delete Users");

            TreeNode courseNode = treeAdmin.Nodes.Add("Course Management");
            courseNode.Nodes.Add("➕ Add Course");
            courseNode.Nodes.Add("📄 View/Edit/Delete Courses");

            TreeNode subjectNode = treeAdmin.Nodes.Add("Subject Management");
            subjectNode.Nodes.Add("➕ Add Subject");
            subjectNode.Nodes.Add("📄 View/Edit/Delete Subjects");

            TreeNode examNode = treeAdmin.Nodes.Add("Exam Management");
            examNode.Nodes.Add("➕ Add Exam");
            examNode.Nodes.Add("📄 View Exams");

            TreeNode marksNode = treeAdmin.Nodes.Add("Marks Management");
            marksNode.Nodes.Add("📄 Manage Student Marks");

            TreeNode timetableNode = treeAdmin.Nodes.Add("Timetable Management");
            timetableNode.Nodes.Add("➕ Add Timetable Entry");
            timetableNode.Nodes.Add("📄 View/Edit/Delete Timetable");

            TreeNode roomNode = treeAdmin.Nodes.Add("Room Management");
            roomNode.Nodes.Add("➕ Add Room (Lab or Hall)");
            roomNode.Nodes.Add("📄 View/Edit/Delete Rooms");
        }

        // New method you can call anytime to refresh the notification UI
        public void UpdateNotificationUI()
        {
            int requestCount = GetPendingRequestCount();

            if (requestCount > 0)
            {
                lblNote.Text = requestCount.ToString();
                lblNote.Visible = true;
                pictureBoxBell.Visible = true;
            }
            else
            {
                lblNote.Visible = false;
                pictureBoxBell.Visible = false;
            }
        }

        private int GetPendingRequestCount()
        {
            int count = 0;
            using (var conn = DBConfig.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM SignupRequests";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    count = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            return count;
        }

        private void treeAdmin_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent == null)
            {
                treeAdmin.SelectedNode = null;
                return;
            }

            string selected = e.Node.Text;
            rightAdmin.Controls.Clear();

            if (selected == "➕ Add Student")
                rightAdmin.Controls.Add(new AddStudent() { Dock = DockStyle.Fill });
            else if (selected == "📄 View/Edit/Delete Students")
                rightAdmin.Controls.Add(new StudentActions() { Dock = DockStyle.Fill });
            else if (selected == "📄 Manage requests")
                rightAdmin.Controls.Add(new ManageRequestActions() { Dock = DockStyle.Fill });
            else if (selected == "➕ Add User")
                rightAdmin.Controls.Add(new AddUser() { Dock = DockStyle.Fill });
            else if (selected == "📄 View/Edit/Delete Users")
                rightAdmin.Controls.Add(new UserActions() { Dock = DockStyle.Fill });
            else if (selected == "➕ Add Course")
                rightAdmin.Controls.Add(new AddCourse() { Dock = DockStyle.Fill });
            else if (selected == "📄 View/Edit/Delete Courses")
                rightAdmin.Controls.Add(new CourseActions() { Dock = DockStyle.Fill });
            else if (selected == "➕ Add Subject")
                rightAdmin.Controls.Add(new AddSubject() { Dock = DockStyle.Fill });
            else if (selected == "📄 View/Edit/Delete Subjects")
                rightAdmin.Controls.Add(new SubjectActions() { Dock = DockStyle.Fill });
            else if (selected == "➕ Add Exam")
                rightAdmin.Controls.Add(new AddExam() { Dock = DockStyle.Fill });
            else if (selected == "📄 View Exams")
                rightAdmin.Controls.Add(new ExamActions() { Dock = DockStyle.Fill });
            else if (selected == "📄 Manage Student Marks")
                rightAdmin.Controls.Add(new AddMarks() { Dock = DockStyle.Fill });
            else if (selected == "➕ Add Timetable Entry")
                rightAdmin.Controls.Add(new AddTimetable() { Dock = DockStyle.Fill });
            else if (selected == "📄 View/Edit/Delete Timetable")
                rightAdmin.Controls.Add(new TimetableActions() { Dock = DockStyle.Fill });
            else if (selected == "➕ Add Room (Lab or Hall)")
                rightAdmin.Controls.Add(new AddRoom() { Dock = DockStyle.Fill });
            else if (selected == "📄 View/Edit/Delete Rooms")
                rightAdmin.Controls.Add(new RoomActions() { Dock = DockStyle.Fill });
        }

        private void pictureBoxBell_Click(object sender, EventArgs e)
        {
            rightAdmin.Controls.Clear();
            ManageRequestActions managerequestactions = new ManageRequestActions();
            managerequestactions.Dock = DockStyle.Fill;
            rightAdmin.Controls.Add(managerequestactions);
        }

        private void AdminDashboard_Resize(object sender, EventArgs e)
        {
            // Reposition lblNote when window resizes
            lblNote.Location = new Point(
                pictureBoxBell.Right - lblNote.Width / 2,
                pictureBoxBell.Top - lblNote.Height / 2
            );
        }

        private void StyleNotificationLabel()
        {
            lblNote.BackColor = Color.Red;
            lblNote.ForeColor = Color.White;
            lblNote.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblNote.TextAlign = ContentAlignment.MiddleCenter;
            lblNote.Size = new Size(20, 20); // make it circle
            lblNote.Visible = false;

            // Make it circular
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, lblNote.Width, lblNote.Height);
            lblNote.Region = new Region(path);

            // Position top-right of bell
            lblNote.Location = new Point(
                pictureBoxBell.Right - lblNote.Width / 2,
                pictureBoxBell.Top - lblNote.Height / 2
            );

            lblNote.BringToFront();
        }

        // Other existing empty event handlers you had:
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

        private void panel2_Paint(object sender, PaintEventArgs e) { }

        private void headerAdmin_Paint(object sender, PaintEventArgs e) { }

        private void label2_Click(object sender, EventArgs e) { }

        private void pictureBox1_Click(object sender, EventArgs e) { }

        private void pictureBox1_Click_1(object sender, EventArgs e) { }

        private void pictureBox2_Click(object sender, EventArgs e) { }

        private void lblNotification_Click(object sender, EventArgs e) { }
    }
}
