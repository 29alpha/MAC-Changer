namespace MacChanger
{
    partial class Form1
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
            this.cbNICs = new System.Windows.Forms.ComboBox();
            this.lblNICs = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblIP = new System.Windows.Forms.Label();
            this.lblMAC = new System.Windows.Forms.Label();
            this.txtMAC = new System.Windows.Forms.TextBox();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnRevert = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbNICs
            // 
            this.cbNICs.AllowDrop = true;
            this.cbNICs.FormattingEnabled = true;
            this.cbNICs.Location = new System.Drawing.Point(12, 34);
            this.cbNICs.Name = "cbNICs";
            this.cbNICs.Size = new System.Drawing.Size(241, 21);
            this.cbNICs.TabIndex = 0;
            // 
            // lblNICs
            // 
            this.lblNICs.AutoSize = true;
            this.lblNICs.Location = new System.Drawing.Point(12, 18);
            this.lblNICs.Name = "lblNICs";
            this.lblNICs.Size = new System.Drawing.Size(100, 13);
            this.lblNICs.TabIndex = 1;
            this.lblNICs.Text = "Network Interfaces:";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(13, 64);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(122, 13);
            this.lblType.TabIndex = 3;
            this.lblType.Text = "Network Interface Type:";
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(74, 87);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(61, 13);
            this.lblIP.TabIndex = 4;
            this.lblIP.Text = "IP Address:";
            // 
            // lblMAC
            // 
            this.lblMAC.AutoSize = true;
            this.lblMAC.Location = new System.Drawing.Point(61, 113);
            this.lblMAC.Name = "lblMAC";
            this.lblMAC.Size = new System.Drawing.Size(74, 13);
            this.lblMAC.TabIndex = 5;
            this.lblMAC.Text = "MAC Address:";
            // 
            // txtMAC
            // 
            this.txtMAC.Location = new System.Drawing.Point(141, 110);
            this.txtMAC.Name = "txtMAC";
            this.txtMAC.Size = new System.Drawing.Size(111, 20);
            this.txtMAC.TabIndex = 6;
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(124, 142);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(128, 34);
            this.btnChange.TabIndex = 7;
            this.btnChange.Text = "Change MAC";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnRevert
            // 
            this.btnRevert.Enabled = false;
            this.btnRevert.Location = new System.Drawing.Point(16, 142);
            this.btnRevert.Name = "btnRevert";
            this.btnRevert.Size = new System.Drawing.Size(102, 34);
            this.btnRevert.TabIndex = 8;
            this.btnRevert.Text = "Revert";
            this.btnRevert.UseVisualStyleBackColor = true;
            this.btnRevert.Click += new System.EventHandler(this.btnRevert_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 188);
            this.Controls.Add(this.btnRevert);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.txtMAC);
            this.Controls.Add(this.lblMAC);
            this.Controls.Add(this.lblIP);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblNICs);
            this.Controls.Add(this.cbNICs);
            this.Name = "Form1";
            this.Text = "MAC Changer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbNICs;
        private System.Windows.Forms.Label lblNICs;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.Label lblMAC;
        private System.Windows.Forms.TextBox txtMAC;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnRevert;
    }
}

