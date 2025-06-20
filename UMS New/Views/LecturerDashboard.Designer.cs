namespace UMS_New.Views
{
    partial class LecturerDashboard
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.leftLecturer = new System.Windows.Forms.Panel();
            this.btnMarks = new System.Windows.Forms.Button();
            this.btnTimetable = new System.Windows.Forms.Button();
            this.rightAdmin = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picLogout = new System.Windows.Forms.PictureBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.headerAdmin = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.rightLecturer = new System.Windows.Forms.Panel();
            this.leftLecturer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogout)).BeginInit();
            this.headerAdmin.SuspendLayout();
            this.SuspendLayout();
            // 
            // leftLecturer
            // 
            this.leftLecturer.BackColor = System.Drawing.Color.DimGray;
            this.leftLecturer.Controls.Add(this.btnMarks);
            this.leftLecturer.Controls.Add(this.btnTimetable);
            this.leftLecturer.Controls.Add(this.rightAdmin);
            this.leftLecturer.Controls.Add(this.label2);
            this.leftLecturer.Controls.Add(this.lblWelcome);
            this.leftLecturer.Controls.Add(this.pictureBox1);
            this.leftLecturer.Controls.Add(this.picLogout);
            this.leftLecturer.Controls.Add(this.btnLogout);
            this.leftLecturer.Location = new System.Drawing.Point(1, 1);
            this.leftLecturer.Name = "leftLecturer";
            this.leftLecturer.Size = new System.Drawing.Size(246, 660);
            this.leftLecturer.TabIndex = 1;
            this.leftLecturer.Paint += new System.Windows.Forms.PaintEventHandler(this.leftAdmin_Paint);
            // 
            // btnMarks
            // 
            this.btnMarks.Location = new System.Drawing.Point(43, 194);
            this.btnMarks.Name = "btnMarks";
            this.btnMarks.Size = new System.Drawing.Size(148, 23);
            this.btnMarks.TabIndex = 5;
            this.btnMarks.Text = "📊 View Marks";
            this.btnMarks.UseVisualStyleBackColor = true;
            this.btnMarks.Click += new System.EventHandler(this.btnMarks_Click);
            // 
            // btnTimetable
            // 
            this.btnTimetable.Location = new System.Drawing.Point(43, 136);
            this.btnTimetable.Name = "btnTimetable";
            this.btnTimetable.Size = new System.Drawing.Size(141, 23);
            this.btnTimetable.TabIndex = 4;
            this.btnTimetable.Text = "🗓️ View Timetable";
            this.btnTimetable.UseVisualStyleBackColor = true;
            this.btnTimetable.Click += new System.EventHandler(this.btnTimetable_Click);
            // 
            // rightAdmin
            // 
            this.rightAdmin.BackColor = System.Drawing.Color.Transparent;
            this.rightAdmin.Location = new System.Drawing.Point(247, 56);
            this.rightAdmin.Name = "rightAdmin";
            this.rightAdmin.Size = new System.Drawing.Size(637, 595);
            this.rightAdmin.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(-3, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(250, 2);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(79, 22);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(91, 22);
            this.lblWelcome.TabIndex = 2;
            this.lblWelcome.Text = "Welcome!";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UMS_New.Properties.Resources._1000123252;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // picLogout
            // 
            this.picLogout.Image = global::UMS_New.Properties.Resources.icons8_logout_48;
            this.picLogout.Location = new System.Drawing.Point(128, 622);
            this.picLogout.Name = "picLogout";
            this.picLogout.Size = new System.Drawing.Size(20, 20);
            this.picLogout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogout.TabIndex = 0;
            this.picLogout.TabStop = false;
            // 
            // btnLogout
            // 
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(33, 616);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(128, 33);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            // 
            // headerAdmin
            // 
            this.headerAdmin.BackColor = System.Drawing.Color.Black;
            this.headerAdmin.Controls.Add(this.label1);
            this.headerAdmin.Location = new System.Drawing.Point(247, 0);
            this.headerAdmin.Name = "headerAdmin";
            this.headerAdmin.Size = new System.Drawing.Size(638, 59);
            this.headerAdmin.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(117, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(409, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to the Lecturer Dashboard !";
            // 
            // rightLecturer
            // 
            this.rightLecturer.Location = new System.Drawing.Point(248, 60);
            this.rightLecturer.Name = "rightLecturer";
            this.rightLecturer.Size = new System.Drawing.Size(621, 601);
            this.rightLecturer.TabIndex = 4;
            this.rightLecturer.Paint += new System.Windows.Forms.PaintEventHandler(this.rightLecturer_Paint);
            // 
            // LecturerDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 661);
            this.Controls.Add(this.rightLecturer);
            this.Controls.Add(this.headerAdmin);
            this.Controls.Add(this.leftLecturer);
            this.Name = "LecturerDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LecturerDashboard";
            this.Load += new System.EventHandler(this.LecturerDashboard_Load);
            this.leftLecturer.ResumeLayout(false);
            this.leftLecturer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogout)).EndInit();
            this.headerAdmin.ResumeLayout(false);
            this.headerAdmin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel leftLecturer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox picLogout;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel rightAdmin;
        private System.Windows.Forms.Panel headerAdmin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMarks;
        private System.Windows.Forms.Button btnTimetable;
        private System.Windows.Forms.Panel rightLecturer;
    }
}