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
            this.adminTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnUpdateShop = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCurrency = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtInvoicePrefix = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtShopName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUploadReceiptLogo = new System.Windows.Forms.Button();
            this.picReceiptLogo = new System.Windows.Forms.PictureBox();
            this.btnUploadShopLogo = new System.Windows.Forms.Button();
            this.picShopLogo = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.adminTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picReceiptLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picShopLogo)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblGreetings
            // 
            this.lblGreetings.AutoSize = true;
            this.lblGreetings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGreetings.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblGreetings.Location = new System.Drawing.Point(11, 11);
            this.lblGreetings.Name = "lblGreetings";
            this.lblGreetings.Size = new System.Drawing.Size(123, 25);
            this.lblGreetings.TabIndex = 3;
            this.lblGreetings.Text = "Admin Panel";
            // 
            // adminTabControl
            // 
            this.adminTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.adminTabControl.Controls.Add(this.tabPage1);
            this.adminTabControl.Controls.Add(this.tabPage2);
            this.adminTabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminTabControl.Location = new System.Drawing.Point(12, 46);
            this.adminTabControl.Name = "adminTabControl";
            this.adminTabControl.SelectedIndex = 0;
            this.adminTabControl.Size = new System.Drawing.Size(1103, 690);
            this.adminTabControl.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.tabPage1.Controls.Add(this.btnUpdateShop);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.txtCurrency);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtInvoicePrefix);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtContact);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txtAddress);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtShopName);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btnUploadReceiptLogo);
            this.tabPage1.Controls.Add(this.picReceiptLogo);
            this.tabPage1.Controls.Add(this.btnUploadShopLogo);
            this.tabPage1.Controls.Add(this.picShopLogo);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1095, 652);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Shop";
            // 
            // btnUpdateShop
            // 
            this.btnUpdateShop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateShop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnUpdateShop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateShop.Location = new System.Drawing.Point(32, 593);
            this.btnUpdateShop.Name = "btnUpdateShop";
            this.btnUpdateShop.Size = new System.Drawing.Size(242, 40);
            this.btnUpdateShop.TabIndex = 22;
            this.btnUpdateShop.Text = "Update Shop";
            this.btnUpdateShop.UseVisualStyleBackColor = false;
            this.btnUpdateShop.Click += new System.EventHandler(this.btnUpdateShop_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(25, 354);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 21);
            this.label7.TabIndex = 21;
            this.label7.Text = "Currency";
            // 
            // txtCurrency
            // 
            this.txtCurrency.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.txtCurrency.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCurrency.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrency.ForeColor = System.Drawing.Color.White;
            this.txtCurrency.Location = new System.Drawing.Point(25, 378);
            this.txtCurrency.Name = "txtCurrency";
            this.txtCurrency.Size = new System.Drawing.Size(483, 36);
            this.txtCurrency.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(25, 272);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 21);
            this.label6.TabIndex = 19;
            this.label6.Text = "Invoice Prefix";
            // 
            // txtInvoicePrefix
            // 
            this.txtInvoicePrefix.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.txtInvoicePrefix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInvoicePrefix.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvoicePrefix.ForeColor = System.Drawing.Color.White;
            this.txtInvoicePrefix.Location = new System.Drawing.Point(25, 296);
            this.txtInvoicePrefix.Name = "txtInvoicePrefix";
            this.txtInvoicePrefix.Size = new System.Drawing.Size(483, 36);
            this.txtInvoicePrefix.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(25, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 21);
            this.label5.TabIndex = 17;
            this.label5.Text = "Contact";
            // 
            // txtContact
            // 
            this.txtContact.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.txtContact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContact.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContact.ForeColor = System.Drawing.Color.White;
            this.txtContact.Location = new System.Drawing.Point(25, 214);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(483, 36);
            this.txtContact.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(25, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 21);
            this.label4.TabIndex = 15;
            this.label4.Text = "Address";
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.ForeColor = System.Drawing.Color.White;
            this.txtAddress.Location = new System.Drawing.Point(25, 132);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(483, 36);
            this.txtAddress.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(25, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 21);
            this.label3.TabIndex = 13;
            this.label3.Text = "Shop Name";
            // 
            // txtShopName
            // 
            this.txtShopName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.txtShopName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShopName.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShopName.ForeColor = System.Drawing.Color.White;
            this.txtShopName.Location = new System.Drawing.Point(25, 50);
            this.txtShopName.Name = "txtShopName";
            this.txtShopName.Size = new System.Drawing.Size(483, 36);
            this.txtShopName.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Location = new System.Drawing.Point(842, 326);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Receipt Logo";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(842, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Shop Logo";
            // 
            // btnUploadReceiptLogo
            // 
            this.btnUploadReceiptLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUploadReceiptLogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadReceiptLogo.Location = new System.Drawing.Point(839, 593);
            this.btnUploadReceiptLogo.Name = "btnUploadReceiptLogo";
            this.btnUploadReceiptLogo.Size = new System.Drawing.Size(242, 40);
            this.btnUploadReceiptLogo.TabIndex = 8;
            this.btnUploadReceiptLogo.Text = "Upload Receipt Logo";
            this.btnUploadReceiptLogo.UseVisualStyleBackColor = true;
            this.btnUploadReceiptLogo.Click += new System.EventHandler(this.btnUploadReceiptLogo_Click);
            // 
            // picReceiptLogo
            // 
            this.picReceiptLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picReceiptLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
            this.picReceiptLogo.Location = new System.Drawing.Point(839, 354);
            this.picReceiptLogo.Name = "picReceiptLogo";
            this.picReceiptLogo.Size = new System.Drawing.Size(242, 233);
            this.picReceiptLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picReceiptLogo.TabIndex = 7;
            this.picReceiptLogo.TabStop = false;
            // 
            // btnUploadShopLogo
            // 
            this.btnUploadShopLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUploadShopLogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadShopLogo.Location = new System.Drawing.Point(839, 271);
            this.btnUploadShopLogo.Name = "btnUploadShopLogo";
            this.btnUploadShopLogo.Size = new System.Drawing.Size(242, 40);
            this.btnUploadShopLogo.TabIndex = 6;
            this.btnUploadShopLogo.Text = "Upload Shop Logo";
            this.btnUploadShopLogo.UseVisualStyleBackColor = true;
            this.btnUploadShopLogo.Click += new System.EventHandler(this.btnUploadShopLogo_Click);
            // 
            // picShopLogo
            // 
            this.picShopLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picShopLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
            this.picShopLogo.Location = new System.Drawing.Point(839, 32);
            this.picShopLogo.Name = "picShopLogo";
            this.picShopLogo.Size = new System.Drawing.Size(242, 233);
            this.picShopLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picShopLogo.TabIndex = 0;
            this.picShopLogo.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1095, 652);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Printer";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label8.Location = new System.Drawing.Point(15, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(144, 25);
            this.label8.TabIndex = 10;
            this.label8.Text = "Printer Settings";
            // 
            // AdminControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.Controls.Add(this.adminTabControl);
            this.Controls.Add(this.lblGreetings);
            this.Name = "AdminControl";
            this.Size = new System.Drawing.Size(1128, 751);
            this.Load += new System.EventHandler(this.AdminControl_Load);
            this.adminTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picReceiptLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picShopLogo)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGreetings;
        private System.Windows.Forms.TabControl adminTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox picShopLogo;
        private System.Windows.Forms.Button btnUploadShopLogo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUploadReceiptLogo;
        private System.Windows.Forms.PictureBox picReceiptLogo;
        private System.Windows.Forms.Button btnUpdateShop;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCurrency;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtInvoicePrefix;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtShopName;
        private System.Windows.Forms.Label label8;
    }
}
