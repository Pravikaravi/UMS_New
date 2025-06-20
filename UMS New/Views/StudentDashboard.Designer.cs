namespace UMS_New.Views
{
    partial class StudentDashboard
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
            this.rightStudent = new System.Windows.Forms.Panel();
            this.leftStudent = new System.Windows.Forms.Panel();
            this.btnMarks = new System.Windows.Forms.Button();
            this.btnExams = new System.Windows.Forms.Button();
            this.btnTimetable = new System.Windows.Forms.Button();
            this.btnProfile = new System.Windows.Forms.Button();
            this.rightAdmin = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picLogout = new System.Windows.Forms.PictureBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.headerStudent = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.leftStudent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogout)).BeginInit();
            this.headerStudent.SuspendLayout();
            this.SuspendLayout();
            // 
            // rightStudent
            // 
            this.rightStudent.Location = new System.Drawing.Point(247, 60);
            this.rightStudent.Name = "rightStudent";
            this.rightStudent.Size = new System.Drawing.Size(634, 601);
            this.rightStudent.TabIndex = 7;
            this.rightStudent.Paint += new System.Windows.Forms.PaintEventHandler(this.rightStudent_Paint);
            // 
            // leftStudent
            // 
            this.leftStudent.BackColor = System.Drawing.Color.DimGray;
            this.leftStudent.Controls.Add(this.btnMarks);
            this.leftStudent.Controls.Add(this.btnExams);
            this.leftStudent.Controls.Add(this.btnTimetable);
            this.leftStudent.Controls.Add(this.btnProfile);
            this.leftStudent.Controls.Add(this.rightAdmin);
            this.leftStudent.Controls.Add(this.label2);
            this.leftStudent.Controls.Add(this.lbl1);
            this.leftStudent.Controls.Add(this.pictureBox1);
            this.leftStudent.Controls.Add(this.picLogout);
            this.leftStudent.Controls.Add(this.btnLogout);
            this.leftStudent.Location = new System.Drawing.Point(0, 1);
            this.leftStudent.Name = "leftStudent";
            this.leftStudent.Size = new System.Drawing.Size(246, 660);
            this.leftStudent.TabIndex = 5;
            this.leftStudent.Paint += new System.Windows.Forms.PaintEventHandler(this.leftLecturer_Paint);
            // 
            // btnMarks
            // 
            this.btnMarks.Location = new System.Drawing.Point(33, 247);
            this.btnMarks.Name = "btnMarks";
            this.btnMarks.Size = new System.Drawing.Size(164, 23);
            this.btnMarks.TabIndex = 6;
            this.btnMarks.Text = "📊My Marks";
            this.btnMarks.UseVisualStyleBackColor = true;
            this.btnMarks.Click += new System.EventHandler(this.btnMarks_Click);
            // 
            // btnExams
            // 
            this.btnExams.Location = new System.Drawing.Point(33, 200);
            this.btnExams.Name = "btnExams";
            this.btnExams.Size = new System.Drawing.Size(164, 23);
            this.btnExams.TabIndex = 5;
            this.btnExams.Text = "📝My Exams";
            this.btnExams.UseVisualStyleBackColor = true;
            this.btnExams.Click += new System.EventHandler(this.btnExams_Click);
            // 
            // btnTimetable
            // 
            this.btnTimetable.Location = new System.Drawing.Point(33, 153);
            this.btnTimetable.Name = "btnTimetable";
            this.btnTimetable.Size = new System.Drawing.Size(164, 23);
            this.btnTimetable.TabIndex = 4;
            this.btnTimetable.Text = "📅My Timetable";
            this.btnTimetable.UseVisualStyleBackColor = true;
            this.btnTimetable.Click += new System.EventHandler(this.btnTimetable_Click);
            // 
            // btnProfile
            // 
            this.btnProfile.Location = new System.Drawing.Point(33, 108);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(164, 23);
            this.btnProfile.TabIndex = 0;
            this.btnProfile.Text = "🎓My Profile";
            this.btnProfile.UseVisualStyleBackColor = true;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
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
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.ForeColor = System.Drawing.Color.White;
            this.lbl1.Location = new System.Drawing.Point(79, 22);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(91, 22);
            this.lbl1.TabIndex = 2;
            this.lbl1.Text = "Welcome!";
            this.lbl1.Click += new System.EventHandler(this.lblWelcome_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UMS_New.Properties.Resources._1000123253;
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
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // headerStudent
            // 
            this.headerStudent.BackColor = System.Drawing.Color.Black;
            this.headerStudent.Controls.Add(this.label1);
            this.headerStudent.Location = new System.Drawing.Point(246, 0);
            this.headerStudent.Name = "headerStudent";
            this.headerStudent.Size = new System.Drawing.Size(638, 59);
            this.headerStudent.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(117, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(407, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to the Student Dashboard !";
            // 
            // StudentDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 661);
            this.Controls.Add(this.rightStudent);
            this.Controls.Add(this.leftStudent);
            this.Controls.Add(this.headerStudent);
            this.Name = "StudentDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserDashboard";
            this.leftStudent.ResumeLayout(false);
            this.leftStudent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogout)).EndInit();
            this.headerStudent.ResumeLayout(false);
            this.headerStudent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel rightStudent;
        private System.Windows.Forms.Panel leftStudent;
        private System.Windows.Forms.Panel rightAdmin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox picLogout;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel headerStudent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnMarks;
        private System.Windows.Forms.Button btnExams;
        private System.Windows.Forms.Button btnTimetable;
    }
}