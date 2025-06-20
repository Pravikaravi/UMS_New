namespace UMS_New.Views
{
    partial class StaffDashboard
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
            this.rightStaff = new System.Windows.Forms.Panel();
            this.leftStaff = new System.Windows.Forms.Panel();
            this.btnExamAction = new System.Windows.Forms.Button();
            this.btnMarks = new System.Windows.Forms.Button();
            this.btnAddExams = new System.Windows.Forms.Button();
            this.btnTimetable = new System.Windows.Forms.Button();
            this.rightAdmin = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.picStaff = new System.Windows.Forms.PictureBox();
            this.picLogout = new System.Windows.Forms.PictureBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.headerStaff = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.leftStaff.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStaff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogout)).BeginInit();
            this.headerStaff.SuspendLayout();
            this.SuspendLayout();
            // 
            // rightStaff
            // 
            this.rightStaff.Location = new System.Drawing.Point(247, 62);
            this.rightStaff.Name = "rightStaff";
            this.rightStaff.Size = new System.Drawing.Size(637, 599);
            this.rightStaff.TabIndex = 10;
            this.rightStaff.Paint += new System.Windows.Forms.PaintEventHandler(this.rightStaff_Paint);
            // 
            // leftStaff
            // 
            this.leftStaff.BackColor = System.Drawing.Color.DimGray;
            this.leftStaff.Controls.Add(this.btnExamAction);
            this.leftStaff.Controls.Add(this.btnMarks);
            this.leftStaff.Controls.Add(this.btnAddExams);
            this.leftStaff.Controls.Add(this.btnTimetable);
            this.leftStaff.Controls.Add(this.rightAdmin);
            this.leftStaff.Controls.Add(this.label2);
            this.leftStaff.Controls.Add(this.lblWelcome);
            this.leftStaff.Controls.Add(this.picStaff);
            this.leftStaff.Controls.Add(this.picLogout);
            this.leftStaff.Controls.Add(this.btnLogout);
            this.leftStaff.Location = new System.Drawing.Point(0, 1);
            this.leftStaff.Name = "leftStaff";
            this.leftStaff.Size = new System.Drawing.Size(246, 660);
            this.leftStaff.TabIndex = 8;
            // 
            // btnExamAction
            // 
            this.btnExamAction.Location = new System.Drawing.Point(33, 213);
            this.btnExamAction.Name = "btnExamAction";
            this.btnExamAction.Size = new System.Drawing.Size(164, 23);
            this.btnExamAction.TabIndex = 7;
            this.btnExamAction.Text = "📝Delete/Edit Exams";
            this.btnExamAction.UseVisualStyleBackColor = true;
            this.btnExamAction.Click += new System.EventHandler(this.btnExamAction_Click);
            // 
            // btnMarks
            // 
            this.btnMarks.Location = new System.Drawing.Point(33, 267);
            this.btnMarks.Name = "btnMarks";
            this.btnMarks.Size = new System.Drawing.Size(164, 23);
            this.btnMarks.TabIndex = 6;
            this.btnMarks.Text = "📊Add/Edit Marks";
            this.btnMarks.UseVisualStyleBackColor = true;
            this.btnMarks.Click += new System.EventHandler(this.btnMarks_Click);
            // 
            // btnAddExams
            // 
            this.btnAddExams.Location = new System.Drawing.Point(33, 160);
            this.btnAddExams.Name = "btnAddExams";
            this.btnAddExams.Size = new System.Drawing.Size(164, 23);
            this.btnAddExams.TabIndex = 5;
            this.btnAddExams.Text = "📝Add Exams ";
            this.btnAddExams.UseVisualStyleBackColor = true;
            this.btnAddExams.Click += new System.EventHandler(this.btnAddExams_Click);
            // 
            // btnTimetable
            // 
            this.btnTimetable.Location = new System.Drawing.Point(33, 113);
            this.btnTimetable.Name = "btnTimetable";
            this.btnTimetable.Size = new System.Drawing.Size(164, 23);
            this.btnTimetable.TabIndex = 4;
            this.btnTimetable.Text = "📅View Timetable";
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
            // picStaff
            // 
            this.picStaff.Image = global::UMS_New.Properties.Resources.Staff;
            this.picStaff.Location = new System.Drawing.Point(3, 3);
            this.picStaff.Name = "picStaff";
            this.picStaff.Size = new System.Drawing.Size(100, 50);
            this.picStaff.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picStaff.TabIndex = 0;
            this.picStaff.TabStop = false;
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
            // headerStaff
            // 
            this.headerStaff.BackColor = System.Drawing.Color.Black;
            this.headerStaff.Controls.Add(this.label1);
            this.headerStaff.Location = new System.Drawing.Point(246, 0);
            this.headerStaff.Name = "headerStaff";
            this.headerStaff.Size = new System.Drawing.Size(638, 59);
            this.headerStaff.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(117, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(374, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to the Staff Dashboard !";
            // 
            // StaffDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 661);
            this.Controls.Add(this.rightStaff);
            this.Controls.Add(this.leftStaff);
            this.Controls.Add(this.headerStaff);
            this.Name = "StaffDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StaffDashboard";
            this.Load += new System.EventHandler(this.StaffDashboard_Load);
            this.leftStaff.ResumeLayout(false);
            this.leftStaff.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStaff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogout)).EndInit();
            this.headerStaff.ResumeLayout(false);
            this.headerStaff.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel rightStaff;
        private System.Windows.Forms.Panel leftStaff;
        private System.Windows.Forms.Button btnMarks;
        private System.Windows.Forms.Button btnAddExams;
        private System.Windows.Forms.Button btnTimetable;
        private System.Windows.Forms.Panel rightAdmin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.PictureBox picStaff;
        private System.Windows.Forms.PictureBox picLogout;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel headerStaff;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExamAction;
    }
}