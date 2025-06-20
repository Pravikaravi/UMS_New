namespace UMS_New.Views.StudentDashboardFiles
{
    partial class myExams
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
            this.dgvMyExams = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyExams)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMyExams
            // 
            this.dgvMyExams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMyExams.Location = new System.Drawing.Point(3, 3);
            this.dgvMyExams.Name = "dgvMyExams";
            this.dgvMyExams.Size = new System.Drawing.Size(808, 559);
            this.dgvMyExams.TabIndex = 0;
            this.dgvMyExams.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMyExams_CellContentClick);
            // 
            // myExams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvMyExams);
            this.Name = "myExams";
            this.Size = new System.Drawing.Size(814, 565);
            this.Load += new System.EventHandler(this.myExams_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyExams)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMyExams;
    }
}
