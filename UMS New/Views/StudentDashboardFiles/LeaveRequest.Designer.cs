namespace UMS_New.Views.StudentDashboardFiles
{
    partial class LeaveRequest
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
            this.btnLeave = new System.Windows.Forms.Button();
            this.txtUT_Number = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUTNumber = new System.Windows.Forms.Label();
            this.lblLeaveFirst = new System.Windows.Forms.Label();
            this.lblLast = new System.Windows.Forms.Label();
            this.lblSignup = new System.Windows.Forms.Label();
            this.dtpFirst = new System.Windows.Forms.DateTimePicker();
            this.dtpLastday = new System.Windows.Forms.DateTimePicker();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnLeave
            // 
            this.btnLeave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLeave.BackColor = System.Drawing.Color.Black;
            this.btnLeave.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeave.ForeColor = System.Drawing.Color.White;
            this.btnLeave.Location = new System.Drawing.Point(243, 380);
            this.btnLeave.Name = "btnLeave";
            this.btnLeave.Size = new System.Drawing.Size(175, 39);
            this.btnLeave.TabIndex = 59;
            this.btnLeave.Text = "Submit";
            this.btnLeave.UseVisualStyleBackColor = false;
            this.btnLeave.Click += new System.EventHandler(this.btnLeave_Click);
            // 
            // txtUT_Number
            // 
            this.txtUT_Number.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUT_Number.Location = new System.Drawing.Point(243, 196);
            this.txtUT_Number.Name = "txtUT_Number";
            this.txtUT_Number.ReadOnly = true;
            this.txtUT_Number.Size = new System.Drawing.Size(319, 25);
            this.txtUT_Number.TabIndex = 55;
            this.txtUT_Number.TextChanged += new System.EventHandler(this.txtUT_Number_TextChanged);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.White;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.Black;
            this.lblPassword.Location = new System.Drawing.Point(73, 317);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(60, 19);
            this.lblPassword.TabIndex = 53;
            this.lblPassword.Text = "Reason :";
            // 
            // lblUTNumber
            // 
            this.lblUTNumber.AutoSize = true;
            this.lblUTNumber.BackColor = System.Drawing.Color.White;
            this.lblUTNumber.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUTNumber.ForeColor = System.Drawing.Color.Black;
            this.lblUTNumber.Location = new System.Drawing.Point(73, 199);
            this.lblUTNumber.Name = "lblUTNumber";
            this.lblUTNumber.Size = new System.Drawing.Size(88, 19);
            this.lblUTNumber.TabIndex = 52;
            this.lblUTNumber.Text = "UT Number :";
            // 
            // lblLeaveFirst
            // 
            this.lblLeaveFirst.AutoSize = true;
            this.lblLeaveFirst.BackColor = System.Drawing.Color.White;
            this.lblLeaveFirst.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeaveFirst.ForeColor = System.Drawing.Color.Black;
            this.lblLeaveFirst.Location = new System.Drawing.Point(73, 239);
            this.lblLeaveFirst.Name = "lblLeaveFirst";
            this.lblLeaveFirst.Size = new System.Drawing.Size(141, 19);
            this.lblLeaveFirst.TabIndex = 51;
            this.lblLeaveFirst.Text = "First day of Absence :";
            // 
            // lblLast
            // 
            this.lblLast.AutoSize = true;
            this.lblLast.BackColor = System.Drawing.Color.White;
            this.lblLast.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLast.ForeColor = System.Drawing.Color.Black;
            this.lblLast.Location = new System.Drawing.Point(73, 279);
            this.lblLast.Name = "lblLast";
            this.lblLast.Size = new System.Drawing.Size(140, 19);
            this.lblLast.TabIndex = 50;
            this.lblLast.Text = "Last day of Absence :";
            // 
            // lblSignup
            // 
            this.lblSignup.AutoSize = true;
            this.lblSignup.BackColor = System.Drawing.Color.White;
            this.lblSignup.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSignup.ForeColor = System.Drawing.Color.Black;
            this.lblSignup.Location = new System.Drawing.Point(270, 96);
            this.lblSignup.Name = "lblSignup";
            this.lblSignup.Size = new System.Drawing.Size(122, 26);
            this.lblSignup.TabIndex = 48;
            this.lblSignup.Text = "Leave Form";
            // 
            // dtpFirst
            // 
            this.dtpFirst.Location = new System.Drawing.Point(243, 237);
            this.dtpFirst.Name = "dtpFirst";
            this.dtpFirst.Size = new System.Drawing.Size(319, 20);
            this.dtpFirst.TabIndex = 60;
            // 
            // dtpLastday
            // 
            this.dtpLastday.Location = new System.Drawing.Point(243, 279);
            this.dtpLastday.Name = "dtpLastday";
            this.dtpLastday.Size = new System.Drawing.Size(319, 20);
            this.dtpLastday.TabIndex = 61;
            // 
            // txtReason
            // 
            this.txtReason.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReason.Location = new System.Drawing.Point(243, 314);
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(319, 25);
            this.txtReason.TabIndex = 62;
            // 
            // LeaveRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.dtpLastday);
            this.Controls.Add(this.dtpFirst);
            this.Controls.Add(this.btnLeave);
            this.Controls.Add(this.txtUT_Number);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUTNumber);
            this.Controls.Add(this.lblLeaveFirst);
            this.Controls.Add(this.lblLast);
            this.Controls.Add(this.lblSignup);
            this.Name = "LeaveRequest";
            this.Size = new System.Drawing.Size(672, 682);
            this.Load += new System.EventHandler(this.LeaveRequest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnLeave;
        private System.Windows.Forms.TextBox txtUT_Number;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUTNumber;
        private System.Windows.Forms.Label lblLeaveFirst;
        private System.Windows.Forms.Label lblLast;
        private System.Windows.Forms.Label lblSignup;
        private System.Windows.Forms.DateTimePicker dtpFirst;
        private System.Windows.Forms.DateTimePicker dtpLastday;
        private System.Windows.Forms.TextBox txtReason;
    }
}
