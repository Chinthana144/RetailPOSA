namespace RetailPOSA.Forms
{
    partial class Main
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
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.btnNavInvoice = new System.Windows.Forms.Button();
            this.btnNavGRN = new System.Windows.Forms.Button();
            this.btnNavInventory = new System.Windows.Forms.Button();
            this.btnNavPOS = new System.Windows.Forms.Button();
            this.btnNavProducts = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.btnNavReports = new System.Windows.Forms.Button();
            this.btnNavSettings = new System.Windows.Forms.Button();
            this.btnNavProfile = new System.Windows.Forms.Button();
            this.pnlSidebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnlSidebar.Controls.Add(this.btnNavProfile);
            this.pnlSidebar.Controls.Add(this.btnNavSettings);
            this.pnlSidebar.Controls.Add(this.btnNavReports);
            this.pnlSidebar.Controls.Add(this.btnNavInvoice);
            this.pnlSidebar.Controls.Add(this.btnNavGRN);
            this.pnlSidebar.Controls.Add(this.btnNavInventory);
            this.pnlSidebar.Controls.Add(this.btnNavPOS);
            this.pnlSidebar.Controls.Add(this.btnNavProducts);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(270, 796);
            this.pnlSidebar.TabIndex = 0;
            // 
            // btnNavInvoice
            // 
            this.btnNavInvoice.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnNavInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavInvoice.Location = new System.Drawing.Point(0, 243);
            this.btnNavInvoice.Name = "btnNavInvoice";
            this.btnNavInvoice.Size = new System.Drawing.Size(269, 41);
            this.btnNavInvoice.TabIndex = 4;
            this.btnNavInvoice.Text = "Invoices";
            this.btnNavInvoice.UseVisualStyleBackColor = false;
            // 
            // btnNavGRN
            // 
            this.btnNavGRN.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnNavGRN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavGRN.Location = new System.Drawing.Point(0, 149);
            this.btnNavGRN.Name = "btnNavGRN";
            this.btnNavGRN.Size = new System.Drawing.Size(269, 41);
            this.btnNavGRN.TabIndex = 3;
            this.btnNavGRN.Text = "GRN";
            this.btnNavGRN.UseVisualStyleBackColor = false;
            // 
            // btnNavInventory
            // 
            this.btnNavInventory.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnNavInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavInventory.Location = new System.Drawing.Point(0, 196);
            this.btnNavInventory.Name = "btnNavInventory";
            this.btnNavInventory.Size = new System.Drawing.Size(269, 41);
            this.btnNavInventory.TabIndex = 2;
            this.btnNavInventory.Text = "Inventory";
            this.btnNavInventory.UseVisualStyleBackColor = false;
            // 
            // btnNavPOS
            // 
            this.btnNavPOS.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnNavPOS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavPOS.Location = new System.Drawing.Point(0, 102);
            this.btnNavPOS.Name = "btnNavPOS";
            this.btnNavPOS.Size = new System.Drawing.Size(269, 41);
            this.btnNavPOS.TabIndex = 1;
            this.btnNavPOS.Text = "POS";
            this.btnNavPOS.UseVisualStyleBackColor = false;
            // 
            // btnNavProducts
            // 
            this.btnNavProducts.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnNavProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavProducts.Location = new System.Drawing.Point(0, 55);
            this.btnNavProducts.Name = "btnNavProducts";
            this.btnNavProducts.Size = new System.Drawing.Size(269, 41);
            this.btnNavProducts.TabIndex = 0;
            this.btnNavProducts.Text = "Products";
            this.btnNavProducts.UseVisualStyleBackColor = false;
            this.btnNavProducts.Click += new System.EventHandler(this.btnNavProducts_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(270, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(954, 796);
            this.pnlContent.TabIndex = 1;
            // 
            // btnNavReports
            // 
            this.btnNavReports.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnNavReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavReports.Location = new System.Drawing.Point(0, 290);
            this.btnNavReports.Name = "btnNavReports";
            this.btnNavReports.Size = new System.Drawing.Size(269, 41);
            this.btnNavReports.TabIndex = 5;
            this.btnNavReports.Text = "Reports";
            this.btnNavReports.UseVisualStyleBackColor = false;
            // 
            // btnNavSettings
            // 
            this.btnNavSettings.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnNavSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavSettings.Location = new System.Drawing.Point(0, 337);
            this.btnNavSettings.Name = "btnNavSettings";
            this.btnNavSettings.Size = new System.Drawing.Size(269, 41);
            this.btnNavSettings.TabIndex = 6;
            this.btnNavSettings.Text = "Settings";
            this.btnNavSettings.UseVisualStyleBackColor = false;
            // 
            // btnNavProfile
            // 
            this.btnNavProfile.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnNavProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavProfile.Location = new System.Drawing.Point(0, 384);
            this.btnNavProfile.Name = "btnNavProfile";
            this.btnNavProfile.Size = new System.Drawing.Size(269, 41);
            this.btnNavProfile.TabIndex = 7;
            this.btnNavProfile.Text = "Profile";
            this.btnNavProfile.UseVisualStyleBackColor = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 796);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlSidebar);
            this.Name = "Main";
            this.Text = " Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.pnlSidebar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Button btnNavProducts;
        private System.Windows.Forms.Button btnNavPOS;
        private System.Windows.Forms.Button btnNavInvoice;
        private System.Windows.Forms.Button btnNavGRN;
        private System.Windows.Forms.Button btnNavInventory;
        private System.Windows.Forms.Button btnNavProfile;
        private System.Windows.Forms.Button btnNavSettings;
        private System.Windows.Forms.Button btnNavReports;
    }
}