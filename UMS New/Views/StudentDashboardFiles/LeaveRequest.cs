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
    public partial class LeaveRequest : UserControl
    {
        public LeaveRequest()
        {
            InitializeComponent();
        }

        private void AutoFillStudentDetails()
        {
            //if (UserSession.UserID == 0)
            //{
            //    MessageBox.Show("UserID is not set correctly in session.");
            //    return;
            //}

            //MessageBox.Show("Executing Query for UserID: " + UserSession.UserID);

            //using (var conn = DBConfig.GetConnection())
            //{
            //    string query = "SELECT UserName FROM Users WHERE UserID = @userID";
            //    using (var cmd = new SQLiteCommand(query, conn))
            //    {
            //        cmd.Parameters.AddWithValue("@userID", UserSession.UserID);
            //        using (var reader = cmd.ExecuteReader())
            //        {
            //            if (reader.Read())
            //            {
            //                txtName.Text = reader["UserName"].ToString();
            //                //txtUT_Number.Text = reader["UT_Number"].ToString();
            //                txtName.ReadOnly = true;
            //                //txtUT_Number.ReadOnly = true;
            //            }
            //            else
            //            {
            //                MessageBox.Show("Student data not found!");
            //            }
            //        }
            //    }
            //}

            txtUT_Number.Text = UserSession.Username;

        }



        private void LeaveRequest_Load(object sender, EventArgs e)
        {
            AutoFillStudentDetails();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUT_Number_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLeave_Click(object sender, EventArgs e)
        {

        }
    }
}
