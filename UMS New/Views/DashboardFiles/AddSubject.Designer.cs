namespace UMS_New.Views.DashboardFiles
{
    partial class AddSubject
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
            this.cmbCourses = new System.Windows.Forms.ComboBox();
            this.btnAddSubject = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtSubjectName = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUTNumber = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblSignup = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbCourses
            // 
            this.cmbCourses.FormattingEnabled = true;
            this.cmbCourses.Location = new System.Drawing.Point(245, 318);
            this.cmbCourses.Name = "cmbCourses";
            this.cmbCourses.Size = new System.Drawing.Size(319, 21);
            this.cmbCourses.TabIndex = 53;
            this.cmbCourses.SelectedIndexChanged += new System.EventHandler(this.cmbCourses_SelectedIndexChanged);
            // 
            // btnAddSubject
            // 
            this.btnAddSubject.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddSubject.BackColor = System.Drawing.Color.Black;
            this.btnAddSubject.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSubject.ForeColor = System.Drawing.Color.White;
            this.btnAddSubject.Location = new System.Drawing.Point(263, 404);
            this.btnAddSubject.Name = "btnAddSubject";
            this.btnAddSubject.Size = new System.Drawing.Size(175, 39);
            this.btnAddSubject.TabIndex = 52;
            this.btnAddSubject.Text = "Submit";
            this.btnAddSubject.UseVisualStyleBackColor = false;
            this.btnAddSubject.Click += new System.EventHandler(this.btnAddSubject_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(245, 267);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(319, 25);
            this.txtDescription.TabIndex = 51;
            // 
            // txtSubjectName
            // 
            this.txtSubjectName.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubjectName.Location = new System.Drawing.Point(245, 226);
            this.txtSubjectName.Name = "txtSubjectName";
            this.txtSubjectName.Size = new System.Drawing.Size(319, 25);
            this.txtSubjectName.TabIndex = 50;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.White;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(101, 317);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(100, 19);
            this.lblPassword.TabIndex = 49;
            this.lblPassword.Text = "Select Course :";
            // 
            // lblUTNumber
            // 
            this.lblUTNumber.AutoSize = true;
            this.lblUTNumber.BackColor = System.Drawing.Color.White;
            this.lblUTNumber.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUTNumber.Location = new System.Drawing.Point(101, 270);
            this.lblUTNumber.Name = "lblUTNumber";
            this.lblUTNumber.Size = new System.Drawing.Size(86, 19);
            this.lblUTNumber.TabIndex = 48;
            this.lblUTNumber.Text = "Description :";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.White;
            this.lblName.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(101, 227);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(103, 19);
            this.lblName.TabIndex = 47;
            this.lblName.Text = "Subject Name :";
            // 
            // lblSignup
            // 
            this.lblSignup.AutoSize = true;
            this.lblSignup.BackColor = System.Drawing.Color.White;
            this.lblSignup.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSignup.Location = new System.Drawing.Point(300, 170);
            this.lblSignup.Name = "lblSignup";
            this.lblSignup.Size = new System.Drawing.Size(138, 26);
            this.lblSignup.TabIndex = 46;
            this.lblSignup.Text = "Add Subjects";
            // 
            // AddSubject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbCourses);
            this.Controls.Add(this.btnAddSubject);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtSubjectName);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUTNumber);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblSignup);
            this.Name = "AddSubject";
            this.Size = new System.Drawing.Size(665, 613);
            this.Load += new System.EventHandler(this.AddSubject_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCourses;
        private System.Windows.Forms.Button btnAddSubject;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtSubjectName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUTNumber;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblSignup;
    }
}
