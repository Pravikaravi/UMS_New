using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMS_New.Controller;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using UMS_New.Data;

namespace UMS_New.Views.DashboardFiles
{
    public partial class AddStudent : UserControl
    {
        private courseController controller;
        public AddStudent()
        {
            InitializeComponent();
            controller = new courseController();
            LoadCoursesToComboBox();
        }

        private void LoadCoursesToComboBox()
        {
            using (var conn = DBConfig.GetConnection())
            {
                DataTable dt = controller.GetAllCourses(conn);
                cmbCourses.DisplayMember = "CourseName"; // Column name from the database
                cmbCourses.ValueMember = "Id";            // Optional: useful if you want the course ID
                cmbCourses.DataSource = dt;
                cmbCourses.SelectedIndex = -1; // optional - to leave empty at start
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
