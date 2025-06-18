using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
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
    public partial class AddUser : UserControl
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void AddUser_Load(object sender, EventArgs e)
        {

        }

        private void chkStaff_CheckedChanged(object sender, EventArgs e)
        {
            if (chkStaff.Checked)
            {
                chkAdmin.Checked = false;
                chkLecturer.Checked = false;
            }
        }

        private void chkAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAdmin.Checked)
            {
                chkStaff.Checked = false;
                chkLecturer.Checked = false;
            }
        }

        private void chkLecturer_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLecturer.Checked)
            {
                chkStaff.Checked = false;
                chkAdmin.Checked = false;
            }
        }

        // Clear all inputs to empty/default
        private void ClearInputs()
        {
            txtName.Text = "";
            txtEmail.Text = "";
            txtPhone_Number.Text = "";
            txtPassword.Text = "";
            chkStaff.Checked = false;
            chkAdmin.Checked = false;
            chkLecturer.Checked = false;
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string phone = txtPhone_Number.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string role = "";

            // Validate all required fields
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please enter your name.");
                txtName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Please enter your phone number.");
                txtPhone_Number.Focus();
                return;
            }
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please enter your email.");
                txtEmail.Focus();
                return;
            }
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter a password.");
                txtPassword.Focus();
                return;
            }

            // Validate role selection
            if (chkStaff.Checked)
                role = "Staff";
            else if (chkAdmin.Checked)
                role = "Admin";
            else if (chkLecturer.Checked)
                role = "Lecturer";
            else
            {
                MessageBox.Show("Please select one role.");
                return;
            }

            using (var conn = DBConfig.GetConnection())
            {
                // 1. Create user first
                var user = new User { Username = email, Password = password, Role = role };
                new userController().CreateUser(user, conn);

                // 2. Get last inserted UserID
                long userId = (long)new SQLiteCommand("SELECT last_insert_rowid();", conn).ExecuteScalar();

                // 3. Create role-specific record with UserID
                if (role == "Staff")
                {
                    new staffController().CreateStaff(new Staff { StaffName = name, Phone_Number = phone, Email = email, UserID = (int)userId }, conn);
                }
                else if (role == "Admin")
                {
                    new adminController().CreateAdmin(new Admin { AdminName = name, Phone_Number = phone, Email = email, UserID = (int)userId }, conn);
                }
                else if (role == "Lecturer")
                {
                    new lecturerController().CreateLecturer(new Lecturer { LecturerName = name, Phone_Number = phone, Email = email, UserID = (int)userId }, conn);
                }

                conn.Close();
            }


            MessageBox.Show("User created successfully!");
            ClearInputs(); // Reset form
        }
    }
   }

