namespace RetailPOSA.UserControls
{
    partial class AdminControl
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
            this.lblGreetings = new System.Windows.Forms.Label();
            this.btnLoadShop = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnGeneralSettings = new System.Windows.Forms.Button();
            this.btnLoadBackup = new System.Windows.Forms.Button();
            this.btnLoadPaymethods = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblGreetings
            // 
            this.lblGreetings.AutoSize = true;
            this.lblGreetings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGreetings.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblGreetings.Location = new System.Drawing.Point(10, 9);
            this.lblGreetings.Name = "lblGreetings";
            this.lblGreetings.Size = new System.Drawing.Size(123, 25);
            this.lblGreetings.TabIndex = 3;
            this.lblGreetings.Text = "Admin Panel";
            // 
            // btnLoadShop
            // 
            this.btnLoadShop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadShop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(115)))));
            this.btnLoadShop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadShop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadShop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLoadShop.Location = new System.Drawing.Point(1022, 11);
            this.btnLoadShop.Name = "btnLoadShop";
            this.btnLoadShop.Size = new System.Drawing.Size(95, 38);
            this.btnLoadShop.TabIndex = 13;
            this.btnLoadShop.Text = "Shop";
            this.btnLoadShop.UseVisualStyleBackColor = false;
            this.btnLoadShop.Click += new System.EventHandler(this.btnLoadShop_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMain.AutoScroll = true;
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pnlMain.Location = new System.Drawing.Point(0, 63);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1128, 685);
            this.pnlMain.TabIndex = 14;
            // 
            // btnGeneralSettings
            // 
            this.btnGeneralSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGeneralSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(115)))));
            this.btnGeneralSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeneralSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGeneralSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnGeneralSettings.Location = new System.Drawing.Point(519, 11);
            this.btnGeneralSettings.Name = "btnGeneralSettings";
            this.btnGeneralSettings.Size = new System.Drawing.Size(200, 38);
            this.btnGeneralSettings.TabIndex = 15;
            this.btnGeneralSettings.Text = "General Settings";
            this.btnGeneralSettings.UseVisualStyleBackColor = false;
            this.btnGeneralSettings.Click += new System.EventHandler(this.btnGeneralSettings_Click);
            // 
            // btnLoadBackup
            // 
            this.btnLoadBackup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadBackup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(115)))));
            this.btnLoadBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadBackup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLoadBackup.Location = new System.Drawing.Point(890, 11);
            this.btnLoadBackup.Name = "btnLoadBackup";
            this.btnLoadBackup.Size = new System.Drawing.Size(126, 38);
            this.btnLoadBackup.TabIndex = 16;
            this.btnLoadBackup.Text = "Backup";
            this.btnLoadBackup.UseVisualStyleBackColor = false;
            // 
            // btnLoadPaymethods
            // 
            this.btnLoadPaymethods.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadPaymethods.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(115)))));
            this.btnLoadPaymethods.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadPaymethods.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadPaymethods.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLoadPaymethods.Location = new System.Drawing.Point(725, 11);
            this.btnLoadPaymethods.Name = "btnLoadPaymethods";
            this.btnLoadPaymethods.Size = new System.Drawing.Size(159, 38);
            this.btnLoadPaymethods.TabIndex = 17;
            this.btnLoadPaymethods.Text = "Paymethods";
            this.btnLoadPaymethods.UseVisualStyleBackColor = false;
            this.btnLoadPaymethods.Click += new System.EventHandler(this.btnLoadPaymethods_Click);
            // 
            // AdminControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.Controls.Add(this.btnLoadPaymethods);
            this.Controls.Add(this.btnLoadBackup);
            this.Controls.Add(this.btnGeneralSettings);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.btnLoadShop);
            this.Controls.Add(this.lblGreetings);
            this.Name = "AdminControl";
            this.Size = new System.Drawing.Size(1128, 751);
            this.Load += new System.EventHandler(this.AdminControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGreetings;
        private System.Windows.Forms.Button btnLoadShop;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnGeneralSettings;
        private System.Windows.Forms.Button btnLoadBackup;
        private System.Windows.Forms.Button btnLoadPaymethods;
    }
}
