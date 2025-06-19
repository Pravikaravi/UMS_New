namespace UMS_New.Views.DashboardFiles
{
    partial class ManageRequestActions
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
            this.dgvManageRequests = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManageRequests)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvManageRequests
            // 
            this.dgvManageRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManageRequests.Location = new System.Drawing.Point(3, 3);
            this.dgvManageRequests.Name = "dgvManageRequests";
            this.dgvManageRequests.Size = new System.Drawing.Size(729, 571);
            this.dgvManageRequests.TabIndex = 0;
            this.dgvManageRequests.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvManageRequests_CellContentClick);
            // 
            // ManageRequestsActions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvManageRequests);
            this.Name = "ManageRequestsActions";
            this.Size = new System.Drawing.Size(735, 577);
            ((System.ComponentModel.ISupportInitialize)(this.dgvManageRequests)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvManageRequests;
    }
}
