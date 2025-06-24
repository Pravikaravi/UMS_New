namespace UMS_New.Views.DashboardFiles
{
    partial class ManageLeaveRequest
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
            this.dgvLeaveRequests = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeaveRequests)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLeaveRequests
            // 
            this.dgvLeaveRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLeaveRequests.Location = new System.Drawing.Point(3, 3);
            this.dgvLeaveRequests.Name = "dgvLeaveRequests";
            this.dgvLeaveRequests.Size = new System.Drawing.Size(786, 534);
            this.dgvLeaveRequests.TabIndex = 0;
            this.dgvLeaveRequests.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLeaveRequests_CellContentClick);
            // 
            // ManageLeaveRequest
            // 
            this.Controls.Add(this.dgvLeaveRequests);
            this.Name = "ManageLeaveRequest";
            this.Size = new System.Drawing.Size(792, 540);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeaveRequests)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtvLeaveRequests;
        private System.Windows.Forms.DataGridView dgvLeaveRequests;
    }
}
