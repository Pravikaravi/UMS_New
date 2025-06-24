namespace UMS_New.Views.StudentDashboardFiles
{
    partial class ViewStudyMaterials
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
            this.dgvStudyMaterials = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudyMaterials)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStudyMaterials
            // 
            this.dgvStudyMaterials.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudyMaterials.Location = new System.Drawing.Point(127, 193);
            this.dgvStudyMaterials.Name = "dgvStudyMaterials";
            this.dgvStudyMaterials.Size = new System.Drawing.Size(479, 266);
            this.dgvStudyMaterials.TabIndex = 49;
            this.dgvStudyMaterials.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStudyMaterials_CellContentClick);
            // 
            // ViewStudyMaterials
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvStudyMaterials);
            this.Name = "ViewStudyMaterials";
            this.Size = new System.Drawing.Size(807, 574);
            this.Load += new System.EventHandler(this.ViewStudyMaterials_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudyMaterials)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvStudyMaterials;
    }
}
