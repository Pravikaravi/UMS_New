using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using UMS_New.Controller;
using UMS_New.Data;
using UMS_New.Model;

namespace UMS_New.Views.DashboardFiles
{
    public partial class AddUser : UserControl
    {
        private Label lblSubject;
        private CheckedListBox checkedListSubjects;
        private Dictionary<string, int> subjectMap = new Dictionary<string, int>();

        public AddUser()
        {
            InitializeComponent();

            // Add Subject Label
            lblSubject = new Label
            {
                Text = "Select Subjects:",
                Location = new Point(100, 380),
                Font = new Font("Microsoft YaHei", 10, FontStyle.Regular),
                AutoSize = true,
                Visible = false
            };
            this.Controls.Add(lblSubject);

            // Add CheckedListBox
            checkedListSubjects = new CheckedListBox
            {
                Location = new Point(250, 380),
                Size = new Size(200, 100),
                Visible = false,
                CheckOnClick = true
            };
            this.Controls.Add(checkedListSubjects);
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            // Initial state: password hidden
            txtPassword.UseSystemPasswordChar = true;
            picPassword.Image = Properties.Resources.Eye;

        }


        private void chkStaff_CheckedChanged(object sender, EventArgs e)
        {
            if (chkStaff.Checked)
            {
                chkAdmin.Checked = false;
                chkLecturer.Checked = false;
                lblSubject.Visible = false;
                checkedListSubjects.Visible = false;
            }
        }

        private void chkAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAdmin.Checked)
            {
                chkStaff.Checked = false;
                chkLecturer.Checked = false;
                lblSubject.Visible = false;
                checkedListSubjects.Visible = false;
            }
        }

        private void chkLecturer_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLecturer.Checked)
            {
                chkStaff.Checked = false;
                chkAdmin.Checked = false;
                lblSubject.Visible = true;
                checkedListSubjects.Visible = true;
                LoadSubjects();
            }
            else
            {
                lblSubject.Visible = false;
                checkedListSubjects.Visible = false;
            }
        }

        private void LoadSubjects()
        {
            checkedListSubjects.Items.Clear();
            subjectMap.Clear();

            using (var conn = DBConfig.GetConnection())
            {
                string query = "SELECT Id, SubjectName FROM Subject";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["Id"]);
                        string name = reader["SubjectName"].ToString();

                        checkedListSubjects.Items.Add(name);
                        subjectMap[name] = id;
                    }
                }
            }
        }

        private void ClearInputs()
        {
            txtName.Text = "";
            txtEmail.Text = "";
            txtPhone_Number.Text = "";
            txtPassword.Text = "";
            chkStaff.Checked = false;
            chkAdmin.Checked = false;
            chkLecturer.Checked = false;
            lblSubject.Visible = false;
            checkedListSubjects.Visible = false;
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string phone = txtPhone_Number.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            // 1. Field Validations
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

            // 2. Pattern Validations
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email, emailPattern))
            {
                MessageBox.Show("Invalid email address format!");
                txtEmail.Focus();
                return;
            }

            string phonePattern = @"^\d{10}$";
            if (!Regex.IsMatch(phone, phonePattern))
            {
                MessageBox.Show("Phone number must be exactly 10 digits!");
                txtPhone_Number.Focus();
                return;
            }

            string passwordPattern = @"^[a-zA-Z0-9]{6,12}$";
            if (!Regex.IsMatch(password, passwordPattern))
            {
                MessageBox.Show("Password must be 6–12 characters long with only letters and numbers.");
                txtPassword.Focus();
                return;
            }

            // 3. Role Selection
            string role = null;
            if (chkLecturer.Checked) role = "Lecturer";
            else if (chkAdmin.Checked) role = "Admin";
            else if (chkStaff.Checked) role = "Staff";

            if (role == null)
            {
                MessageBox.Show("Please select a role (Lecturer, Admin, or Staff).");
                return;
            }

            // 4. Lecturer must select at least one subject
            if (role == "Lecturer" && checkedListSubjects.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please select at least one subject for the Lecturer.");
                return;
            }

            // 5. Database Actions
            using (var conn = DBConfig.GetConnection())
            {
                var user = new User
                {
                    Username = email,
                    Password = password,
                    Role = role
                };
                new userController().CreateUser(user, conn);

                long userId = (long)new SQLiteCommand("SELECT last_insert_rowid();", conn).ExecuteScalar();

                if (role == "Lecturer")
                {
                    List<int> selectedSubjectIds = new List<int>();
                    foreach (var item in checkedListSubjects.CheckedItems)
                    {
                        string subjectName = item.ToString();
                        if (subjectMap.ContainsKey(subjectName))
                            selectedSubjectIds.Add(subjectMap[subjectName]);
                    }

                    var lecturer = new Lecturer
                    {
                        LecturerName = name,
                        Phone_Number = phone,
                        Email = email,
                        UserID = (int)userId,
                        SubjectIDs = selectedSubjectIds
                    };

                    new lecturerController().CreateLecturer(lecturer, conn);
                }
                else if (role == "Admin")
                {
                    string insertAdmin = "INSERT INTO Admin (AdminName, Phone_Number, Email, UserID) VALUES (@name, @phone, @email, @userId)";
                    using (var cmd = new SQLiteCommand(insertAdmin, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@phone", phone);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.ExecuteNonQuery();
                    }
                }
                else if (role == "Staff")
                {
                    string insertStaff = "INSERT INTO Staff (StaffName, Phone_Number, Email, UserID) VALUES (@name, @phone, @email, @userId)";
                    using (var cmd = new SQLiteCommand(insertStaff, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@phone", phone);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.ExecuteNonQuery();
                    }
                }

                conn.Close();
            }

            MessageBox.Show($"{role} created successfully!");
            ClearInputs();
        }

        private void picPassword_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
            picPassword.Image = txtPassword.UseSystemPasswordChar
                ? Properties.Resources.Eye
                : Properties.Resources.Eye;
        }
    }
}
