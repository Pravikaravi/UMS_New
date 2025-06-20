namespace UMS_New.Views.StudentDashboardFiles
{
    partial class myTimetable
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
            this.dgvStudentTimetable = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentTimetable)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStudentTimetable
            // 
            this.dgvStudentTimetable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudentTimetable.Location = new System.Drawing.Point(3, 3);
            this.dgvStudentTimetable.Name = "dgvStudentTimetable";
            this.dgvStudentTimetable.Size = new System.Drawing.Size(711, 533);
            this.dgvStudentTimetable.TabIndex = 0;
            this.dgvStudentTimetable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStudentTimetable_CellContentClick);
            // 
            // myTimetable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvStudentTimetable);
            this.Name = "myTimetable";
            this.Size = new System.Drawing.Size(717, 539);
            this.Load += new System.EventHandler(this.myTimetable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentTimetable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStudentTimetable;
    }
}
