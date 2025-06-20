namespace UMS_New.Views.DashboardFiles
{
    partial class AddRoom
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
            this.chkAvailable = new System.Windows.Forms.CheckBox();
            this.btnAddRoom = new System.Windows.Forms.Button();
            this.txtRoomName = new System.Windows.Forms.TextBox();
            this.lblRoomAvailable = new System.Windows.Forms.Label();
            this.lblCapacity = new System.Windows.Forms.Label();
            this.lblRoomName = new System.Windows.Forms.Label();
            this.lblUsers = new System.Windows.Forms.Label();
            this.numCapacity = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numCapacity)).BeginInit();
            this.SuspendLayout();
            // 
            // chkAvailable
            // 
            this.chkAvailable.AutoSize = true;
            this.chkAvailable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAvailable.Location = new System.Drawing.Point(252, 268);
            this.chkAvailable.Name = "chkAvailable";
            this.chkAvailable.Size = new System.Drawing.Size(106, 20);
            this.chkAvailable.TabIndex = 73;
            this.chkAvailable.Text = "Available (✔️)";
            this.chkAvailable.UseVisualStyleBackColor = true;
            this.chkAvailable.CheckedChanged += new System.EventHandler(this.chkStaff_CheckedChanged);
            // 
            // btnAddRoom
            // 
            this.btnAddRoom.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddRoom.BackColor = System.Drawing.Color.Black;
            this.btnAddRoom.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRoom.ForeColor = System.Drawing.Color.White;
            this.btnAddRoom.Location = new System.Drawing.Point(247, 351);
            this.btnAddRoom.Name = "btnAddRoom";
            this.btnAddRoom.Size = new System.Drawing.Size(175, 39);
            this.btnAddRoom.TabIndex = 72;
            this.btnAddRoom.Text = "Submit";
            this.btnAddRoom.UseVisualStyleBackColor = false;
            this.btnAddRoom.Click += new System.EventHandler(this.btnAddRoom_Click);
            // 
            // txtRoomName
            // 
            this.txtRoomName.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoomName.Location = new System.Drawing.Point(245, 155);
            this.txtRoomName.Name = "txtRoomName";
            this.txtRoomName.Size = new System.Drawing.Size(319, 25);
            this.txtRoomName.TabIndex = 68;
            // 
            // lblRoomAvailable
            // 
            this.lblRoomAvailable.AutoSize = true;
            this.lblRoomAvailable.BackColor = System.Drawing.Color.White;
            this.lblRoomAvailable.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomAvailable.Location = new System.Drawing.Point(106, 267);
            this.lblRoomAvailable.Name = "lblRoomAvailable";
            this.lblRoomAvailable.Size = new System.Drawing.Size(84, 19);
            this.lblRoomAvailable.TabIndex = 66;
            this.lblRoomAvailable.Text = "Is Available :";
            // 
            // lblCapacity
            // 
            this.lblCapacity.AutoSize = true;
            this.lblCapacity.BackColor = System.Drawing.Color.White;
            this.lblCapacity.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapacity.Location = new System.Drawing.Point(101, 216);
            this.lblCapacity.Name = "lblCapacity";
            this.lblCapacity.Size = new System.Drawing.Size(69, 19);
            this.lblCapacity.TabIndex = 65;
            this.lblCapacity.Text = "Capacity :";
            // 
            // lblRoomName
            // 
            this.lblRoomName.AutoSize = true;
            this.lblRoomName.BackColor = System.Drawing.Color.White;
            this.lblRoomName.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomName.Location = new System.Drawing.Point(101, 156);
            this.lblRoomName.Name = "lblRoomName";
            this.lblRoomName.Size = new System.Drawing.Size(93, 19);
            this.lblRoomName.TabIndex = 63;
            this.lblRoomName.Text = "Room Name :";
            // 
            // lblUsers
            // 
            this.lblUsers.AutoSize = true;
            this.lblUsers.BackColor = System.Drawing.Color.White;
            this.lblUsers.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsers.Location = new System.Drawing.Point(258, 81);
            this.lblUsers.Name = "lblUsers";
            this.lblUsers.Size = new System.Drawing.Size(123, 26);
            this.lblUsers.TabIndex = 62;
            this.lblUsers.Text = "Add Rooms";
            // 
            // numCapacity
            // 
            this.numCapacity.Location = new System.Drawing.Point(247, 215);
            this.numCapacity.Name = "numCapacity";
            this.numCapacity.Size = new System.Drawing.Size(120, 20);
            this.numCapacity.TabIndex = 74;
            // 
            // AddRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numCapacity);
            this.Controls.Add(this.chkAvailable);
            this.Controls.Add(this.btnAddRoom);
            this.Controls.Add(this.txtRoomName);
            this.Controls.Add(this.lblRoomAvailable);
            this.Controls.Add(this.lblCapacity);
            this.Controls.Add(this.lblRoomName);
            this.Controls.Add(this.lblUsers);
            this.Name = "AddRoom";
            this.Size = new System.Drawing.Size(664, 570);
            this.Load += new System.EventHandler(this.AddRoom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numCapacity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox chkAvailable;
        private System.Windows.Forms.Button btnAddRoom;
        private System.Windows.Forms.TextBox txtRoomName;
        private System.Windows.Forms.Label lblRoomAvailable;
        private System.Windows.Forms.Label lblCapacity;
        private System.Windows.Forms.Label lblRoomName;
        private System.Windows.Forms.Label lblUsers;
        private System.Windows.Forms.NumericUpDown numCapacity;
    }
}
