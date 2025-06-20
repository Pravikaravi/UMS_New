namespace UMS_New.Views.DashboardFiles
{
    partial class AddExam
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
            this.cmbSubject = new System.Windows.Forms.ComboBox();
            this.lblSubject = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtExamName = new System.Windows.Forms.TextBox();
            this.lblRoom = new System.Windows.Forms.Label();
            this.lblExamDate = new System.Windows.Forms.Label();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblExamName = new System.Windows.Forms.Label();
            this.lblExam = new System.Windows.Forms.Label();
            this.dtpExamDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.nudDuration = new System.Windows.Forms.NumericUpDown();
            this.cmbRoom = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuration)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbSubject
            // 
            this.cmbSubject.FormattingEnabled = true;
            this.cmbSubject.Location = new System.Drawing.Point(262, 373);
            this.cmbSubject.Name = "cmbSubject";
            this.cmbSubject.Size = new System.Drawing.Size(319, 21);
            this.cmbSubject.TabIndex = 60;
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.BackColor = System.Drawing.Color.White;
            this.lblSubject.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubject.Location = new System.Drawing.Point(118, 372);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(62, 19);
            this.lblSubject.TabIndex = 59;
            this.lblSubject.Text = "Subject :";
            // 
            // btnSave
            // 
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.BackColor = System.Drawing.Color.Black;
            this.btnSave.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(280, 423);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(175, 39);
            this.btnSave.TabIndex = 58;
            this.btnSave.Text = "Submit";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtExamName
            // 
            this.txtExamName.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExamName.Location = new System.Drawing.Point(262, 161);
            this.txtExamName.Name = "txtExamName";
            this.txtExamName.Size = new System.Drawing.Size(319, 25);
            this.txtExamName.TabIndex = 53;
            // 
            // lblRoom
            // 
            this.lblRoom.AutoSize = true;
            this.lblRoom.BackColor = System.Drawing.Color.White;
            this.lblRoom.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoom.Location = new System.Drawing.Point(118, 323);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Size = new System.Drawing.Size(52, 19);
            this.lblRoom.TabIndex = 52;
            this.lblRoom.Text = "Room :";
            // 
            // lblExamDate
            // 
            this.lblExamDate.AutoSize = true;
            this.lblExamDate.BackColor = System.Drawing.Color.White;
            this.lblExamDate.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExamDate.Location = new System.Drawing.Point(118, 205);
            this.lblExamDate.Name = "lblExamDate";
            this.lblExamDate.Size = new System.Drawing.Size(82, 19);
            this.lblExamDate.TabIndex = 51;
            this.lblExamDate.Text = "Exam Date :";
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.BackColor = System.Drawing.Color.White;
            this.lblStartTime.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartTime.Location = new System.Drawing.Point(118, 245);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(79, 19);
            this.lblStartTime.TabIndex = 50;
            this.lblStartTime.Text = "Start Time :";
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.BackColor = System.Drawing.Color.White;
            this.lblDuration.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDuration.Location = new System.Drawing.Point(118, 285);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(131, 19);
            this.lblDuration.TabIndex = 49;
            this.lblDuration.Text = "Duration (minutes) :";
            // 
            // lblExamName
            // 
            this.lblExamName.AutoSize = true;
            this.lblExamName.BackColor = System.Drawing.Color.White;
            this.lblExamName.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExamName.Location = new System.Drawing.Point(118, 162);
            this.lblExamName.Name = "lblExamName";
            this.lblExamName.Size = new System.Drawing.Size(90, 19);
            this.lblExamName.TabIndex = 48;
            this.lblExamName.Text = "Exam Name :";
            // 
            // lblExam
            // 
            this.lblExam.AutoSize = true;
            this.lblExam.BackColor = System.Drawing.Color.White;
            this.lblExam.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExam.Location = new System.Drawing.Point(208, 109);
            this.lblExam.Name = "lblExam";
            this.lblExam.Size = new System.Drawing.Size(110, 26);
            this.lblExam.TabIndex = 47;
            this.lblExam.Text = "Add Exam";
            // 
            // dtpExamDate
            // 
            this.dtpExamDate.CalendarMonthBackground = System.Drawing.SystemColors.WindowFrame;
            this.dtpExamDate.Location = new System.Drawing.Point(262, 205);
            this.dtpExamDate.Name = "dtpExamDate";
            this.dtpExamDate.Size = new System.Drawing.Size(319, 20);
            this.dtpExamDate.TabIndex = 61;
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.Location = new System.Drawing.Point(262, 245);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new System.Drawing.Size(319, 20);
            this.dtpStartTime.TabIndex = 62;
            // 
            // nudDuration
            // 
            this.nudDuration.Location = new System.Drawing.Point(262, 285);
            this.nudDuration.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudDuration.Name = "nudDuration";
            this.nudDuration.Size = new System.Drawing.Size(319, 20);
            this.nudDuration.TabIndex = 63;
            this.nudDuration.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cmbRoom
            // 
            this.cmbRoom.FormattingEnabled = true;
            this.cmbRoom.Location = new System.Drawing.Point(262, 324);
            this.cmbRoom.Name = "cmbRoom";
            this.cmbRoom.Size = new System.Drawing.Size(319, 21);
            this.cmbRoom.TabIndex = 64;
            // 
            // AddExam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbRoom);
            this.Controls.Add(this.nudDuration);
            this.Controls.Add(this.dtpStartTime);
            this.Controls.Add(this.dtpExamDate);
            this.Controls.Add(this.cmbSubject);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtExamName);
            this.Controls.Add(this.lblRoom);
            this.Controls.Add(this.lblExamDate);
            this.Controls.Add(this.lblStartTime);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.lblExamName);
            this.Controls.Add(this.lblExam);
            this.Name = "AddExam";
            this.Size = new System.Drawing.Size(699, 571);
            this.Load += new System.EventHandler(this.AddExam_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudDuration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbSubject;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtExamName;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.Label lblExamDate;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label lblExamName;
        private System.Windows.Forms.Label lblExam;
        private System.Windows.Forms.DateTimePicker dtpExamDate;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.NumericUpDown nudDuration;
        private System.Windows.Forms.ComboBox cmbRoom;
    }
}
