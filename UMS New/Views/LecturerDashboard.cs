using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UMS_New.Views
{
    public partial class LecturerDashboard : Form
    {
        public LecturerDashboard()
        {
            InitializeComponent();
        }

        private void leftAdmin_Paint(object sender, PaintEventArgs e)
        {

        }

        private void treeAdmin_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void LecturerDashboard_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = UMS_New.Session.UserSession.Username;
        }
    }
}
