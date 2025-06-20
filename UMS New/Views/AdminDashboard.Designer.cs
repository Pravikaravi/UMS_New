namespace UMS_New.Views
{
    partial class AdminDashboard
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
            this.leftAdmin = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.treeAdmin = new System.Windows.Forms.TreeView();
            this.rightAdmin = new System.Windows.Forms.Panel();
            this.headerAdmin = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picLogout = new System.Windows.Forms.PictureBox();
            this.leftAdmin.SuspendLayout();
            this.headerAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogout)).BeginInit();
            this.SuspendLayout();
            // 
            // leftAdmin
            // 
            this.leftAdmin.BackColor = System.Drawing.Color.DimGray;
            this.leftAdmin.Controls.Add(this.label2);
            this.leftAdmin.Controls.Add(this.lblWelcome);
            this.leftAdmin.Controls.Add(this.pictureBox1);
            this.leftAdmin.Controls.Add(this.picLogout);
            this.leftAdmin.Controls.Add(this.btnLogout);
            this.leftAdmin.Controls.Add(this.treeAdmin);
            this.leftAdmin.Location = new System.Drawing.Point(0, 0);
            this.leftAdmin.Name = "leftAdmin";
            this.leftAdmin.Size = new System.Drawing.Size(246, 660);
            this.leftAdmin.TabIndex = 0;
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
            // treeAdmin
            // 
            this.treeAdmin.BackColor = System.Drawing.Color.DimGray;
            this.treeAdmin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeAdmin.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeAdmin.ForeColor = System.Drawing.Color.White;
            this.treeAdmin.Location = new System.Drawing.Point(0, 62);
            this.treeAdmin.Name = "treeAdmin";
            this.treeAdmin.Size = new System.Drawing.Size(240, 554);
            this.treeAdmin.TabIndex = 0;
            this.treeAdmin.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeAdmin_AfterSelect);
            // 
            // rightAdmin
            // 
            this.rightAdmin.BackColor = System.Drawing.Color.Transparent;
            this.rightAdmin.Location = new System.Drawing.Point(246, 65);
            this.rightAdmin.Name = "rightAdmin";
            this.rightAdmin.Size = new System.Drawing.Size(637, 595);
            this.rightAdmin.TabIndex = 1;
            this.rightAdmin.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // headerAdmin
            // 
            this.headerAdmin.BackColor = System.Drawing.Color.Black;
            this.headerAdmin.Controls.Add(this.label1);
            this.headerAdmin.Location = new System.Drawing.Point(246, 2);
            this.headerAdmin.Name = "headerAdmin";
            this.headerAdmin.Size = new System.Drawing.Size(638, 59);
            this.headerAdmin.TabIndex = 2;
            this.headerAdmin.Paint += new System.Windows.Forms.PaintEventHandler(this.headerAdmin_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(117, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(393, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to the Admin Dashboard !";
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
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(-3, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(250, 2);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UMS_New.Properties.Resources._1000123251;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
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
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 661);
            this.Controls.Add(this.headerAdmin);
            this.Controls.Add(this.rightAdmin);
            this.Controls.Add(this.leftAdmin);
            this.Name = "AdminDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminDashboard";
            this.Load += new System.EventHandler(this.AdminDashboard_Load);
            this.leftAdmin.ResumeLayout(false);
            this.leftAdmin.PerformLayout();
            this.headerAdmin.ResumeLayout(false);
            this.headerAdmin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogout)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel leftAdmin;
        private System.Windows.Forms.Panel rightAdmin;
        private System.Windows.Forms.Panel headerAdmin;
        private System.Windows.Forms.TreeView treeAdmin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.PictureBox picLogout;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label label2;
    }
}