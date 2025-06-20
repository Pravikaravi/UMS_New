using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMS_New.Views.DashboardFiles;

namespace UMS_New.Views
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();

        }   

        private void AdminDashboard_Load(object sender, EventArgs e)
        {

            lblWelcome.Text = UMS_New.Session.UserSession.Username;
            // Student Management
            TreeNode studentNode = treeAdmin.Nodes.Add("Student Management");
            studentNode.Nodes.Add("➕ Add Student");
            studentNode.Nodes.Add("📄 View/Edit/Delete Students");
            studentNode.Nodes.Add("📄 Manage requests");

            // User Management
            TreeNode userNode = treeAdmin.Nodes.Add("User Management");
            userNode.Nodes.Add("➕ Add User");
            userNode.Nodes.Add("📄 View/Edit/Delete Users");

            // Course Management
            TreeNode courseNode = treeAdmin.Nodes.Add("Course Management");
            courseNode.Nodes.Add("➕ Add Course");
            courseNode.Nodes.Add("📄 View/Edit/Delete Courses");

            // Subject Management
            TreeNode subjectNode = treeAdmin.Nodes.Add("Subject Management");
            subjectNode.Nodes.Add("➕ Add Subject");
            subjectNode.Nodes.Add("📄 View/Edit/Delete Subjects");

            // Exam Management
            TreeNode examNode = treeAdmin.Nodes.Add("Exam Management");
            examNode.Nodes.Add("➕ Add Exam");
            examNode.Nodes.Add("📄 View Exams");

            // Marks Management
            TreeNode marksNode = treeAdmin.Nodes.Add("Marks Management");
            marksNode.Nodes.Add("➕ Add Marks");
            marksNode.Nodes.Add("📄 View/Edit Marks");

            // Timetable Management
            TreeNode timetableNode = treeAdmin.Nodes.Add("Timetable Management");
            timetableNode.Nodes.Add("➕ Add Timetable Entry");
            timetableNode.Nodes.Add("📄 View/Edit/Delete Timetable");

            // Room Management
            TreeNode roomNode = treeAdmin.Nodes.Add("Room Management");
            roomNode.Nodes.Add("➕ Add Room (Lab or Hall)");
            roomNode.Nodes.Add("📄 View/Edit/Delete Rooms");


        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }


        private void treeAdmin_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Prevent action if a main node (parent node) is selected
            if (e.Node.Parent == null)
            {
                treeAdmin.SelectedNode = null; // Deselect main node
                return;
            }

            string selected = e.Node.Text;
            rightAdmin.Controls.Clear();

            if (selected == "➕ Add Student")
            {
                AddStudent addstudent = new AddStudent();
                addstudent.Dock = DockStyle.Fill;
                rightAdmin.Controls.Add(addstudent);
            }
            else if (selected == "📄 View/Edit/Delete Students")
            {
                StudentActions studentactions = new StudentActions();
                studentactions.Dock = DockStyle.Fill;
                rightAdmin.Controls.Add(studentactions);
            }
            else if (selected == "📄 Manage requests")
            {
                ManageRequestActions managerequestactions = new ManageRequestActions();
                managerequestactions.Dock = DockStyle.Fill;
                rightAdmin.Controls.Add(managerequestactions);
            }
            else if (selected == "➕ Add User")
            {
                AddUser adduser = new AddUser();
                adduser.Dock = DockStyle.Fill;
                rightAdmin.Controls.Add(adduser);
            }
            else if (selected == "📄 View/Edit/Delete Users")
            {
                UserActions useractions = new UserActions();
                useractions.Dock = DockStyle.Fill;
                rightAdmin.Controls.Add(useractions);
            }
            else if (selected == "➕ Add Course")
            {
                AddCourse addcourse = new AddCourse();
                addcourse.Dock = DockStyle.Fill;
                rightAdmin.Controls.Add(addcourse);
            }
            else if (selected == "📄 View/Edit/Delete Courses")
            {
                CourseActions courseactions = new CourseActions();
                courseactions.Dock = DockStyle.Fill;
                rightAdmin.Controls.Add(courseactions);
            }
            else if (selected == "➕ Add Subject")
            {
                AddSubject addsubject = new AddSubject();
                addsubject.Dock = DockStyle.Fill;
                rightAdmin.Controls.Add(addsubject);
            }
            else if (selected == "📄 View/Edit/Delete Subjects")
            {
                SubjectActions subjectactions = new SubjectActions();
                subjectactions.Dock = DockStyle.Fill;
                rightAdmin.Controls.Add(subjectactions);
            }
            else if (selected == "➕ Add Exam")
            {
                AddExam addexam = new AddExam();
                addexam.Dock = DockStyle.Fill;
                rightAdmin.Controls.Add(addexam);
            }
            else if (selected == "📄 View Exams")
            {
                ExamActions examactions = new ExamActions();
                examactions.Dock = DockStyle.Fill;
                rightAdmin.Controls.Add(examactions);
            }
            else if (selected == "➕ Add Marks")
            {
                AddMarks addmarks = new AddMarks();
                addmarks.Dock = DockStyle.Fill;
                rightAdmin.Controls.Add(addmarks);
            }
            else if (selected == "📄 View/Edit Marks")
            {
                MarksActions marksactions = new MarksActions();
                marksactions.Dock = DockStyle.Fill;
                rightAdmin.Controls.Add(marksactions);
            }
            else if (selected == "➕ Add Timetable Entry")
            {
                AddTimetable addtimetable = new AddTimetable();
                addtimetable.Dock = DockStyle.Fill;
                rightAdmin.Controls.Add(addtimetable);
            }
            else if (selected == "📄 View/Edit/Delete Timetable")
            {
                TimetableActions timetableactions = new TimetableActions();
                timetableactions.Dock = DockStyle.Fill;
                rightAdmin.Controls.Add(timetableactions);
            }
            else if (selected == "➕ Add Room (Lab or Hall)")
            {
                AddRoom addroom = new AddRoom();
                addroom.Dock = DockStyle.Fill;
                rightAdmin.Controls.Add(addroom);
            }
            else if (selected == "📄 View/Edit/Delete Rooms")
            {
                RoomActions roomactions = new RoomActions();
                roomactions.Dock = DockStyle.Fill;
                rightAdmin.Controls.Add(roomactions);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void headerAdmin_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
