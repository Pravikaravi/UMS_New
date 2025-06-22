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
using UMS_New.Data;
using UMS_New.Session;

namespace UMS_New.Views.StudentDashboardFiles
{
    public partial class ChangePassword : UserControl
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void txtSubjectName_TextChanged(object sender, EventArgs e)
        {

        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            // Initial state: password hidden
            txtOldPassword.UseSystemPasswordChar = true;
            txtNewPassword.UseSystemPasswordChar = true;
            txtConfirmNewPassword.UseSystemPasswordChar = true;
            picOldPassword.Image = Properties.Resources.Eye;
            picNewPassword.Image = Properties.Resources.Eye;
            picConfirmNewPassword.Image = Properties.Resources.Eye;
        }

        private void picOldPassword_Click(object sender, EventArgs e)
        {
            txtOldPassword.UseSystemPasswordChar = !txtOldPassword.UseSystemPasswordChar;
            picOldPassword.Image = txtOldPassword.UseSystemPasswordChar
                ? Properties.Resources.Eye
                : Properties.Resources.Eye;
        }

        private void picNewPassword_Click(object sender, EventArgs e)
        {
            txtNewPassword.UseSystemPasswordChar = !txtNewPassword.UseSystemPasswordChar;
            picNewPassword.Image = txtNewPassword.UseSystemPasswordChar
                ? Properties.Resources.Eye
                : Properties.Resources.Eye;
        }

        private void picConfirmNewPassword_Click(object sender, EventArgs e)
        {
            txtConfirmNewPassword.UseSystemPasswordChar = !txtConfirmNewPassword.UseSystemPasswordChar;
            picConfirmNewPassword.Image = txtConfirmNewPassword.UseSystemPasswordChar
                ? Properties.Resources.Eye
                : Properties.Resources.Eye;
        }

        private void btnPasswordChange_Click(object sender, EventArgs e)
        {
            string oldPass = txtOldPassword.Text.Trim();
            string newPass = txtNewPassword.Text.Trim();
            string confirmPass = txtConfirmNewPassword.Text.Trim();
            string currentUsername = UserSession.Username;

            if (string.IsNullOrEmpty(oldPass) || string.IsNullOrEmpty(newPass) || string.IsNullOrEmpty(confirmPass))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            if (newPass != confirmPass)
            {
                MessageBox.Show("New Password and Confirm Password do not match!");
                txtConfirmNewPassword.Focus();
                return;
            }

            using (var conn = DBConfig.GetConnection())
            {
                string checkQuery = "SELECT Password FROM Users WHERE Username = @username";
                using (var cmd = new SQLiteCommand(checkQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@username", currentUsername);
                    var result = cmd.ExecuteScalar();

                    if (result == null)
                    {
                        MessageBox.Show("User not found!");
                        return;
                    }

                    string storedPassword = result.ToString();
                    if (storedPassword != oldPass)
                    {
                        MessageBox.Show("Old password is incorrect!");
                        txtOldPassword.Focus();
                        return;
                    }
                }

                // Update password
                string updateQuery = "UPDATE Users SET Password = @newPass WHERE Username = @username";
                using (var cmd = new SQLiteCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@newPass", newPass);
                    cmd.Parameters.AddWithValue("@username", currentUsername);
                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MessageBox.Show("Password changed successfully! 🔐");
                        txtOldPassword.Clear();
                        txtNewPassword.Clear();
                        txtConfirmNewPassword.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Password update failed.");
                    }
                }

                conn.Close();
            }
        }
    }
}
