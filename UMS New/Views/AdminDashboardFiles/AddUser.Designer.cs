namespace UMS_New.Views.DashboardFiles
{
    partial class AddUser
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chkAdmin = new System.Windows.Forms.CheckBox();
            this.chkLecturer = new System.Windows.Forms.CheckBox();
            this.chkStaff = new System.Windows.Forms.CheckBox();
            this.btnSignup = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhone_Number = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblPhonenumber = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblUsers = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chkAdmin
            // 
            this.chkAdmin.AutoSize = true;
            this.chkAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAdmin.Location = new System.Drawing.Point(323, 222);
            this.chkAdmin.Name = "chkAdmin";
            this.chkAdmin.Size = new System.Drawing.Size(64, 20);
            this.chkAdmin.TabIndex = 61;
            this.chkAdmin.Text = "Admin";
            this.chkAdmin.UseVisualStyleBackColor = true;
            this.chkAdmin.CheckedChanged += new System.EventHandler(this.chkAdmin_CheckedChanged);
            // 
            // chkLecturer
            // 
            this.chkLecturer.AutoSize = true;
            this.chkLecturer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLecturer.Location = new System.Drawing.Point(404, 221);
            this.chkLecturer.Name = "chkLecturer";
            this.chkLecturer.Size = new System.Drawing.Size(74, 20);
            this.chkLecturer.TabIndex = 60;
            this.chkLecturer.Text = "Lecturer";
            this.chkLecturer.UseVisualStyleBackColor = true;
            this.chkLecturer.CheckedChanged += new System.EventHandler(this.chkLecturer_CheckedChanged);
            // 
            // chkStaff
            // 
            this.chkStaff.AutoSize = true;
            this.chkStaff.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkStaff.Location = new System.Drawing.Point(252, 222);
            this.chkStaff.Name = "chkStaff";
            this.chkStaff.Size = new System.Drawing.Size(52, 20);
            this.chkStaff.TabIndex = 59;
            this.chkStaff.Text = "Staff";
            this.chkStaff.UseVisualStyleBackColor = true;
            this.chkStaff.CheckedChanged += new System.EventHandler(this.chkStaff_CheckedChanged);
            // 
            // btnSignup
            // 
            this.btnSignup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSignup.BackColor = System.Drawing.Color.Black;
            this.btnSignup.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignup.ForeColor = System.Drawing.Color.White;
            this.btnSignup.Location = new System.Drawing.Point(252, 494);
            this.btnSignup.Name = "btnSignup";
            this.btnSignup.Size = new System.Drawing.Size(175, 39);
            this.btnSignup.TabIndex = 58;
            this.btnSignup.Text = "Submit";
            this.btnSignup.UseVisualStyleBackColor = false;
            this.btnSignup.Click += new System.EventHandler(this.btnSignup_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(250, 336);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(319, 25);
            this.txtPassword.TabIndex = 57;
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(250, 298);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(319, 25);
            this.txtEmail.TabIndex = 56;
            // 
            // txtPhone_Number
            // 
            this.txtPhone_Number.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone_Number.Location = new System.Drawing.Point(250, 258);
            this.txtPhone_Number.Name = "txtPhone_Number";
            this.txtPhone_Number.Size = new System.Drawing.Size(319, 25);
            this.txtPhone_Number.TabIndex = 55;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(250, 177);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(319, 25);
            this.txtName.TabIndex = 54;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.White;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(106, 339);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(74, 19);
            this.lblPassword.TabIndex = 53;
            this.lblPassword.Text = "Password :";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.BackColor = System.Drawing.Color.White;
            this.lblRole.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRole.Location = new System.Drawing.Point(106, 221);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(42, 19);
            this.lblRole.TabIndex = 52;
            this.lblRole.Text = "Role :";
            // 
            // lblPhonenumber
            // 
            this.lblPhonenumber.AutoSize = true;
            this.lblPhonenumber.BackColor = System.Drawing.Color.White;
            this.lblPhonenumber.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhonenumber.Location = new System.Drawing.Point(106, 261);
            this.lblPhonenumber.Name = "lblPhonenumber";
            this.lblPhonenumber.Size = new System.Drawing.Size(107, 19);
            this.lblPhonenumber.TabIndex = 51;
            this.lblPhonenumber.Text = "Phone number :";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.BackColor = System.Drawing.Color.White;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(106, 301);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(52, 19);
            this.lblEmail.TabIndex = 50;
            this.lblEmail.Text = "E mail :";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.White;
            this.lblName.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(106, 178);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(53, 19);
            this.lblName.TabIndex = 49;
            this.lblName.Text = "Name :";
            // 
            // lblUsers
            // 
            this.lblUsers.AutoSize = true;
            this.lblUsers.BackColor = System.Drawing.Color.White;
            this.lblUsers.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsers.Location = new System.Drawing.Point(196, 125);
            this.lblUsers.Name = "lblUsers";
            this.lblUsers.Size = new System.Drawing.Size(250, 26);
            this.lblUsers.TabIndex = 48;
            this.lblUsers.Text = "Create Account for Users";
            // 
            // AddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkAdmin);
            this.Controls.Add(this.chkLecturer);
            this.Controls.Add(this.chkStaff);
            this.Controls.Add(this.btnSignup);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPhone_Number);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.lblPhonenumber);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblUsers);
            this.Name = "AddUser";
            this.Size = new System.Drawing.Size(674, 676);
            this.Load += new System.EventHandler(this.AddUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkAdmin;
        private System.Windows.Forms.CheckBox chkLecturer;
        private System.Windows.Forms.CheckBox chkStaff;
        private System.Windows.Forms.Button btnSignup;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPhone_Number;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblPhonenumber;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblUsers;
    }
}
