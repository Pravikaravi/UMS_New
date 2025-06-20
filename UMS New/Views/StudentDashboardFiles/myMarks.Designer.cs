namespace UMS_New.Views.StudentDashboardFiles
{
    partial class myMarks
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
            this.dgvMyMarks = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyMarks)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMyMarks
            // 
            this.dgvMyMarks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMyMarks.Location = new System.Drawing.Point(3, 3);
            this.dgvMyMarks.Name = "dgvMyMarks";
            this.dgvMyMarks.Size = new System.Drawing.Size(708, 553);
            this.dgvMyMarks.TabIndex = 0;
            this.dgvMyMarks.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMyMarks_CellContentClick);
            // 
            // myMarks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvMyMarks);
            this.Name = "myMarks";
            this.Size = new System.Drawing.Size(714, 556);
            this.Load += new System.EventHandler(this.myMarks_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyMarks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMyMarks;
    }
}
