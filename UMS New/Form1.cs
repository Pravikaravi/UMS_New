using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using UMS_New.Data;
using UMS_New.Views;
using UnicomTIC_Management_System.Design;

namespace UMS_New
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(formMain_Paint);
            this.Load += new EventHandler(Form1_Load);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadCoursesIntoComboBox();
        }

        private void LoadCoursesIntoComboBox()
        {
            using (var conn = DBConfig.GetConnection())
            {
                string query = "SELECT Id, CourseName FROM Course";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                comboBox1.DisplayMember = "CourseName";
                comboBox1.ValueMember = "Id";
                comboBox1.DataSource = dt;
                comboBox1.SelectedIndex = -1;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Optional: Show selected course details
            if (comboBox1.SelectedItem is DataRowView row)
            {
                string courseName = row["CourseName"].ToString();
                int courseId = Convert.ToInt32(row["Id"]);
                Console.WriteLine($"Selected Course: {courseName} (ID: {courseId})");
            }
        }

        private void formMain_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect_header = new Rectangle(1, 1, 881, 120);
            int radius_header = 10;

            DrawRectangle.DrawRoundedRectangle(
                e.Graphics,
                rect_header,
                radius_header,
                Color.Black,
                Color.Black
            );

            Rectangle rect = new Rectangle(150, 250, 600, 385);
            int radius = 25;

            DrawRectangle.DrawRoundedRectangle(
                e.Graphics,
                rect,
                radius,
                Color.White,
                Color.White,
                3f
            );
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtUT_Number.Text) ||
                string.IsNullOrWhiteSpace(txtPhone_Number.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmpassword.Text) ||
                comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill in all the fields and select a course!");
                return;
            }

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(txtEmail.Text, emailPattern))
            {
                MessageBox.Show("Invalid email address format!");
                return;
            }

            string phonePattern = @"^\d{10}$";
            if (!Regex.IsMatch(txtPhone_Number.Text, phonePattern))
            {
                MessageBox.Show("Phone number must be exactly 10 digits!");
                return;
            }

            string utPattern = @"^UT\d{6}$";
            if (!Regex.IsMatch(txtUT_Number.Text, utPattern))
            {
                MessageBox.Show("UT Number must be 'UT' followed by 6 digits (e.g., UT010008)!");
                return;
            }

            string passwordPattern = @"^[a-zA-Z0-9]{6,12}$";
            if (!Regex.IsMatch(txtPassword.Text, passwordPattern))
            {
                MessageBox.Show("Password must be 6–12 characters with letters and numbers only. No symbols allowed!");
                return;
            }

            if (txtPassword.Text != txtConfirmpassword.Text)
            {
                MessageBox.Show("Passwords do not match!");
                return;
            }

            try
            {
                int selectedCourseId = Convert.ToInt32(comboBox1.SelectedValue);

                using (SQLiteConnection conn = DBConfig.GetConnection())
                {
                  

                    // ✅ Check if UT Number already exists in SignupRequests
                    string checkUTQuery = @"
                SELECT COUNT(*) FROM SignupRequests WHERE UT_Number = @UT
                UNION ALL
                SELECT COUNT(*) FROM Student WHERE UT_Number = @UT";

                    using (SQLiteCommand checkCmd = new SQLiteCommand(checkUTQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@UT", txtUT_Number.Text.Trim());

                        using (SQLiteDataReader reader = checkCmd.ExecuteReader())
                        {
                            int totalCount = 0;
                            while (reader.Read())
                                totalCount += reader.GetInt32(0);

                            if (totalCount > 0)
                            {
                                MessageBox.Show("UT Number already exists. Please use a unique UT Number.", "Duplicate UT Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }

                    // ✅ Insert into SignupRequests
                    string insertQuery = @"
                        INSERT INTO SignupRequests
                        (StudentName, UT_Number, Phone_Number, Email, Password, CourseID, RequestDate)
                        VALUES
                        (@Name, @UT, @Phone, @Email, @Password, @CourseID, @Date);";

                    using (SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                        cmd.Parameters.AddWithValue("@UT", txtUT_Number.Text.Trim());
                        cmd.Parameters.AddWithValue("@Phone", txtPhone_Number.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim()); // Hash later
                        cmd.Parameters.AddWithValue("@CourseID", selectedCourseId);
                        cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Signup request sent to admin for approval!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Database Error: " + ex.Message);
            }
        }


        private void ClearForm()
        {
            txtName.Clear();
            txtUT_Number.Clear();
            txtPhone_Number.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            txtConfirmpassword.Clear();
            comboBox1.SelectedIndex = -1;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide(); // Hide Form1 first

            LoginForm loginForm = new LoginForm();
            var result = loginForm.ShowDialog(); // This will block until login form closes

            //if (result == DialogResult.OK)
            //{
            //    // Login was successful, close Form1 completely
            //    this.Close();
            //}
            //else
            //{
            //    // Login was cancelled or failed, show Form1 again
            //    this.Show();
            //}
        }


        //private void btnLogin_Click(object sender, EventArgs e)
        //{
        //    LoginForm login = new LoginForm();

        //    if (login.ShowDialog() == DialogResult.OK)
        //    {
        //        if (login.IsAdmin)
        //        {
        //            this.Hide();
        //            AdminDashboard adminForm = new AdminDashboard();
        //            adminForm.FormClosed += (s, args) => this.Show();
        //            adminForm.Show();
        //        }
        //        else
        //        {
        //            MessageBox.Show("User login successful!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            // You can open user dashboard here
        //        }
        //    }
        //}
    }
}
