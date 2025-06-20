namespace UMS_New.Views.DashboardFiles
{
    partial class AddStudent
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
            this.btnSignup = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhone_Number = new System.Windows.Forms.TextBox();
            this.txtUT_Number = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUTNumber = new System.Windows.Forms.Label();
            this.lblPhonenumber = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblSignup = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCourses = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnSignup
            // 
            this.btnSignup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSignup.BackColor = System.Drawing.Color.Black;
            this.btnSignup.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignup.ForeColor = System.Drawing.Color.White;
            this.btnSignup.Location = new System.Drawing.Point(239, 432);
            this.btnSignup.Name = "btnSignup";
            this.btnSignup.Size = new System.Drawing.Size(175, 39);
            this.btnSignup.TabIndex = 44;
            this.btnSignup.Text = "Submit";
            this.btnSignup.UseVisualStyleBackColor = false;
            this.btnSignup.Click += new System.EventHandler(this.btnSignup_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(221, 329);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(319, 25);
            this.txtPassword.TabIndex = 43;
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(221, 291);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(319, 25);
            this.txtEmail.TabIndex = 42;
            // 
            // txtPhone_Number
            // 
            this.txtPhone_Number.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone_Number.Location = new System.Drawing.Point(221, 251);
            this.txtPhone_Number.Name = "txtPhone_Number";
            this.txtPhone_Number.Size = new System.Drawing.Size(319, 25);
            this.txtPhone_Number.TabIndex = 41;
            // 
            // txtUT_Number
            // 
            this.txtUT_Number.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUT_Number.Location = new System.Drawing.Point(221, 211);
            this.txtUT_Number.Name = "txtUT_Number";
            this.txtUT_Number.Size = new System.Drawing.Size(319, 25);
            this.txtUT_Number.TabIndex = 40;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(221, 170);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(319, 25);
            this.txtName.TabIndex = 39;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.White;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(77, 332);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(74, 19);
            this.lblPassword.TabIndex = 38;
            this.lblPassword.Text = "Password :";
            // 
            // lblUTNumber
            // 
            this.lblUTNumber.AutoSize = true;
            this.lblUTNumber.BackColor = System.Drawing.Color.White;
            this.lblUTNumber.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUTNumber.Location = new System.Drawing.Point(77, 214);
            this.lblUTNumber.Name = "lblUTNumber";
            this.lblUTNumber.Size = new System.Drawing.Size(88, 19);
            this.lblUTNumber.TabIndex = 37;
            this.lblUTNumber.Text = "UT Number :";
            // 
            // lblPhonenumber
            // 
            this.lblPhonenumber.AutoSize = true;
            this.lblPhonenumber.BackColor = System.Drawing.Color.White;
            this.lblPhonenumber.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhonenumber.Location = new System.Drawing.Point(77, 254);
            this.lblPhonenumber.Name = "lblPhonenumber";
            this.lblPhonenumber.Size = new System.Drawing.Size(107, 19);
            this.lblPhonenumber.TabIndex = 36;
            this.lblPhonenumber.Text = "Phone number :";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.BackColor = System.Drawing.Color.White;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(77, 294);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(52, 19);
            this.lblEmail.TabIndex = 35;
            this.lblEmail.Text = "E mail :";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.White;
            this.lblName.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(77, 171);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(53, 19);
            this.lblName.TabIndex = 34;
            this.lblName.Text = "Name :";
            // 
            // lblSignup
            // 
            this.lblSignup.AutoSize = true;
            this.lblSignup.BackColor = System.Drawing.Color.White;
            this.lblSignup.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSignup.Location = new System.Drawing.Point(167, 118);
            this.lblSignup.Name = "lblSignup";
            this.lblSignup.Size = new System.Drawing.Size(331, 26);
            this.lblSignup.TabIndex = 33;
            this.lblSignup.Text = "Create Account for New Students";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(77, 381);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 19);
            this.label1.TabIndex = 45;
            this.label1.Text = "Select Course :";
            // 
            // cmbCourses
            // 
            this.cmbCourses.FormattingEnabled = true;
            this.cmbCourses.Location = new System.Drawing.Point(221, 382);
            this.cmbCourses.Name = "cmbCourses";
            this.cmbCourses.Size = new System.Drawing.Size(319, 21);
            this.cmbCourses.TabIndex = 46;
            this.cmbCourses.SelectedIndexChanged += new System.EventHandler(this.cmbCourses_SelectedIndexChanged);
            // 
            // AddStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbCourses);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSignup);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPhone_Number);
            this.Controls.Add(this.txtUT_Number);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUTNumber);
            this.Controls.Add(this.lblPhonenumber);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblSignup);
            this.Name = "AddStudent";
            this.Size = new System.Drawing.Size(728, 618);
            this.Load += new System.EventHandler(this.AddStudent_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSignup;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPhone_Number;
        private System.Windows.Forms.TextBox txtUT_Number;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUTNumber;
        private System.Windows.Forms.Label lblPhonenumber;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblSignup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCourses;
    }
}
