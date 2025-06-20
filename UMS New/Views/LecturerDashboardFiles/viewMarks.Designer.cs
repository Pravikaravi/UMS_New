namespace UMS_New.Views.LecturerDashboardFiles
{
    partial class viewMarks
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
            this.dgvMarks = new System.Windows.Forms.DataGridView();
            this.cmbExams = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblSelectExam = new System.Windows.Forms.Label();
            this.lblMarks = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarks)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMarks
            // 
            this.dgvMarks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMarks.Location = new System.Drawing.Point(139, 188);
            this.dgvMarks.Name = "dgvMarks";
            this.dgvMarks.Size = new System.Drawing.Size(459, 235);
            this.dgvMarks.TabIndex = 67;
            // 
            // cmbExams
            // 
            this.cmbExams.FormattingEnabled = true;
            this.cmbExams.Location = new System.Drawing.Point(279, 139);
            this.cmbExams.Name = "cmbExams";
            this.cmbExams.Size = new System.Drawing.Size(319, 21);
            this.cmbExams.TabIndex = 66;
            // 
            // btnSave
            // 
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.BackColor = System.Drawing.Color.Black;
            this.btnSave.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(423, 452);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(175, 39);
            this.btnSave.TabIndex = 65;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // lblSelectExam
            // 
            this.lblSelectExam.AutoSize = true;
            this.lblSelectExam.BackColor = System.Drawing.Color.White;
            this.lblSelectExam.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectExam.Location = new System.Drawing.Point(135, 139);
            this.lblSelectExam.Name = "lblSelectExam";
            this.lblSelectExam.Size = new System.Drawing.Size(90, 19);
            this.lblSelectExam.TabIndex = 64;
            this.lblSelectExam.Text = "Select Exam :";
            // 
            // lblMarks
            // 
            this.lblMarks.AutoSize = true;
            this.lblMarks.BackColor = System.Drawing.Color.White;
            this.lblMarks.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarks.Location = new System.Drawing.Point(286, 83);
            this.lblMarks.Name = "lblMarks";
            this.lblMarks.Size = new System.Drawing.Size(117, 26);
            this.lblMarks.TabIndex = 63;
            this.lblMarks.Text = "Add Marks";
            // 
            // viewMarks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvMarks);
            this.Controls.Add(this.cmbExams);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblSelectExam);
            this.Controls.Add(this.lblMarks);
            this.Name = "viewMarks";
            this.Size = new System.Drawing.Size(733, 574);
            this.Load += new System.EventHandler(this.ViewMarks_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvMarks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMarks;
        private System.Windows.Forms.ComboBox cmbExams;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblSelectExam;
        private System.Windows.Forms.Label lblMarks;
    }
}
