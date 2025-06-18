using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMS_New.Model;
using UMS_New.Repository;
using UnicomTIC_Management_System.Design;


namespace UMS_New.Views
{
    public partial class Login : Form
    {
        public bool IsAdmin { get; private set; }
        public Login()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(formMain_Paint);
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void formMain_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(150, 150, 600, 370); // position and size  x,y,width,height
            int radius = 25; // corner radius



            // 🖌️ Call your reusable drawing function
            DrawRectangle.DrawRoundedRectangle(
                e.Graphics,
                rect,
                radius,
                Color.White,  // border color
                Color.White,    // fill color
                3f                      // border thickness
            );
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (userRepository.ValidateAdminLogin(username, password))
            {
                IsAdmin = true;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else if (userRepository.ValidateUserLogin(username, password))
            {
                IsAdmin = false;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Create instance of formMain
            Form1 form1 = new Form1();
            form1.Show();    // Show the main form
            this.Hide();        // Hide the current login form
        }
    }
}
