namespace UMS_New.Views.LecturerDashboardFiles
{
    partial class viewTimetable
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
            this.dgvTimetable = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimetable)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTimetable
            // 
            this.dgvTimetable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimetable.Location = new System.Drawing.Point(3, 3);
            this.dgvTimetable.Name = "dgvTimetable";
            this.dgvTimetable.Size = new System.Drawing.Size(749, 575);
            this.dgvTimetable.TabIndex = 0;
            this.dgvTimetable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTimetable_CellContentClick);
            // 
            // viewTimetable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvTimetable);
            this.Name = "viewTimetable";
            this.Size = new System.Drawing.Size(755, 581);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimetable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTimetable;
    }
}
