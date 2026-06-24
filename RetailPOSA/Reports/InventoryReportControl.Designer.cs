namespace RetailPOSA.Reports
{
    partial class InventoryReportControl
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
            this.btnLowStockPDF = new System.Windows.Forms.Button();
            this.btnCurrentStockPDF = new System.Windows.Forms.Button();
            this.calEndDate = new System.Windows.Forms.MonthCalendar();
            this.calStartDate = new System.Windows.Forms.MonthCalendar();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEndDate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStartDate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExpiryPDF = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLowStockPDF
            // 
            this.btnLowStockPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLowStockPDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(115)))));
            this.btnLowStockPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLowStockPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLowStockPDF.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLowStockPDF.Location = new System.Drawing.Point(750, 173);
            this.btnLowStockPDF.Name = "btnLowStockPDF";
            this.btnLowStockPDF.Size = new System.Drawing.Size(357, 50);
            this.btnLowStockPDF.TabIndex = 38;
            this.btnLowStockPDF.Text = "Low Stock Report PDF";
            this.btnLowStockPDF.UseVisualStyleBackColor = false;
            // 
            // btnCurrentStockPDF
            // 
            this.btnCurrentStockPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCurrentStockPDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(115)))));
            this.btnCurrentStockPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCurrentStockPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCurrentStockPDF.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCurrentStockPDF.Location = new System.Drawing.Point(750, 92);
            this.btnCurrentStockPDF.Name = "btnCurrentStockPDF";
            this.btnCurrentStockPDF.Size = new System.Drawing.Size(357, 50);
            this.btnCurrentStockPDF.TabIndex = 37;
            this.btnCurrentStockPDF.Text = "Current Stock Report PDF";
            this.btnCurrentStockPDF.UseVisualStyleBackColor = false;
            this.btnCurrentStockPDF.Click += new System.EventHandler(this.btnCurrentStockPDF_Click);
            // 
            // calEndDate
            // 
            this.calEndDate.Location = new System.Drawing.Point(431, 98);
            this.calEndDate.Name = "calEndDate";
            this.calEndDate.TabIndex = 32;
            this.calEndDate.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.calEndDate_DateSelected);
            this.calEndDate.MouseLeave += new System.EventHandler(this.calEndDate_MouseLeave);
            // 
            // calStartDate
            // 
            this.calStartDate.Location = new System.Drawing.Point(69, 98);
            this.calStartDate.Name = "calStartDate";
            this.calStartDate.TabIndex = 31;
            this.calStartDate.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.calStartDate_DateSelected);
            this.calStartDate.MouseLeave += new System.EventHandler(this.calStartDate_MouseLeave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(433, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 21);
            this.label3.TabIndex = 36;
            this.label3.Text = "End Date";
            // 
            // txtEndDate
            // 
            this.txtEndDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.txtEndDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEndDate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndDate.ForeColor = System.Drawing.Color.White;
            this.txtEndDate.Location = new System.Drawing.Point(431, 92);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Size = new System.Drawing.Size(262, 32);
            this.txtEndDate.TabIndex = 35;
            this.txtEndDate.Click += new System.EventHandler(this.txtEndDate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(71, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 21);
            this.label2.TabIndex = 34;
            this.label2.Text = "Start Date";
            // 
            // txtStartDate
            // 
            this.txtStartDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.txtStartDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStartDate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStartDate.ForeColor = System.Drawing.Color.White;
            this.txtStartDate.Location = new System.Drawing.Point(69, 92);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.Size = new System.Drawing.Size(262, 32);
            this.txtStartDate.TabIndex = 33;
            this.txtStartDate.Click += new System.EventHandler(this.txtStartDate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(18, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 25);
            this.label1.TabIndex = 29;
            this.label1.Text = "Inventory Reports";
            // 
            // btnExpiryPDF
            // 
            this.btnExpiryPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExpiryPDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(115)))));
            this.btnExpiryPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpiryPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpiryPDF.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnExpiryPDF.Location = new System.Drawing.Point(750, 254);
            this.btnExpiryPDF.Name = "btnExpiryPDF";
            this.btnExpiryPDF.Size = new System.Drawing.Size(357, 50);
            this.btnExpiryPDF.TabIndex = 39;
            this.btnExpiryPDF.Text = "Expiry Report PDF";
            this.btnExpiryPDF.UseVisualStyleBackColor = false;
            // 
            // InventoryReportControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.Controls.Add(this.btnExpiryPDF);
            this.Controls.Add(this.btnLowStockPDF);
            this.Controls.Add(this.btnCurrentStockPDF);
            this.Controls.Add(this.calEndDate);
            this.Controls.Add(this.calStartDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEndDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtStartDate);
            this.Controls.Add(this.label1);
            this.Name = "InventoryReportControl";
            this.Size = new System.Drawing.Size(1136, 674);
            this.Load += new System.EventHandler(this.InventoryReportControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLowStockPDF;
        private System.Windows.Forms.Button btnCurrentStockPDF;
        private System.Windows.Forms.MonthCalendar calEndDate;
        private System.Windows.Forms.MonthCalendar calStartDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEndDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStartDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExpiryPDF;
    }
}
