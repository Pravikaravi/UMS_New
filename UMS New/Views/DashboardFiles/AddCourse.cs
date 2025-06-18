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

namespace UMS_New.Views.DashboardFiles
{
    public partial class AddCourse : UserControl
    {
        public AddCourse()
        {
            InitializeComponent();
        }

        private void AddCourse_Load(object sender, EventArgs e)
        {

        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            string name = txtCourseName.Text.Trim();
            string duration = txtDuration.Text.Trim();
            string description = txtDescription.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(duration) || string.IsNullOrEmpty(description))
            {
                MessageBox.Show("Please fill all fields!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SQLiteConnection conn = DBConfig.GetConnection())
                {
                    string insertQuery = "INSERT INTO Course (CourseName, Duration, Description) VALUES (@name, @duration, @description)";
                    using (SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@duration", duration);
                        cmd.Parameters.AddWithValue("@description", description);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Course added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                // Optionally clear fields
                txtCourseName.Clear();
                txtDuration.Clear();
                txtDescription.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
