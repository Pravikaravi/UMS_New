using System;
using System.Data.SQLite;
using System.Windows.Forms;
using UMS_New.Data;
using UMS_New.Views;

namespace UMS_New.Views
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.Load += LoginForm_Load;
            linkLogin.LinkClicked += linkLogin_LinkClicked;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // You can add any initial load logic here
        }




        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            using (var conn = DBConfig.GetConnection())
            {
                string query = "SELECT Role FROM Users WHERE Username = @username AND Password = @password";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    var role = cmd.ExecuteScalar() as string;

                    if (role == null)
                    {
                        MessageBox.Show("Invalid username or password.");
                        return;
                    }

                    Form dashboard = null;

                    if (role == "Admin")
                        dashboard = new AdminDashboard();
                    else if (role == "Student")
                        dashboard = new StudentDashboard();
                    else if (role == "Staff")
                        dashboard = new StaffDashboard();
                    else if (role == "Lecturer")
                        dashboard = new LecturerDashboard();
                    else
                    {
                        MessageBox.Show("Unknown role. Contact administrator.");
                        return;
                    }

                    // ✅ Hide login, show dashboard, and close login after dashboard closes
                    this.Hide();
                    dashboard.FormClosed += (s, args) => this.Close(); // Login closes *after* dashboard
                    dashboard.Show();
                }
            }
        }


        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 signupForm = new Form1();
            signupForm.ShowDialog();
        }
    }
}
