namespace RetailPOSA.Reports
{
    partial class SalesReportControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.calStartDate = new System.Windows.Forms.MonthCalendar();
            this.calEndDate = new System.Windows.Forms.MonthCalendar();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStartDate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEndDate = new System.Windows.Forms.TextBox();
            this.btnDailySalesPDF = new System.Windows.Forms.Button();
            this.btnDailySummaryPDF = new System.Windows.Forms.Button();
            this.btnUserSalePDF = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 25);
            this.label1.TabIndex = 15;
            this.label1.Text = "Sales Reports";
            // 
            // btnTest
            // 
            this.btnTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(115)))));
            this.btnTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnTest.Location = new System.Drawing.Point(733, 569);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(357, 50);
            this.btnTest.TabIndex = 20;
            this.btnTest.Text = "Test PDF";
            this.btnTest.UseVisualStyleBackColor = false;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // calStartDate
            // 
            this.calStartDate.Location = new System.Drawing.Point(52, 76);
            this.calStartDate.Name = "calStartDate";
            this.calStartDate.TabIndex = 21;
            this.calStartDate.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.calStartDate_DateSelected);
            this.calStartDate.MouseLeave += new System.EventHandler(this.calStartDate_MouseLeave);
            // 
            // calEndDate
            // 
            this.calEndDate.Location = new System.Drawing.Point(414, 76);
            this.calEndDate.Name = "calEndDate";
            this.calEndDate.TabIndex = 22;
            this.calEndDate.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.calEndDate_DateSelected);
            this.calEndDate.MouseLeave += new System.EventHandler(this.calEndDate_MouseLeave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(54, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 21);
            this.label2.TabIndex = 24;
            this.label2.Text = "Start Date";
            // 
            // txtStartDate
            // 
            this.txtStartDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.txtStartDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStartDate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStartDate.ForeColor = System.Drawing.Color.White;
            this.txtStartDate.Location = new System.Drawing.Point(52, 70);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.Size = new System.Drawing.Size(262, 32);
            this.txtStartDate.TabIndex = 23;
            this.txtStartDate.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtStartDate_MouseUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(416, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 21);
            this.label3.TabIndex = 26;
            this.label3.Text = "End Date";
            // 
            // txtEndDate
            // 
            this.txtEndDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.txtEndDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEndDate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndDate.ForeColor = System.Drawing.Color.White;
            this.txtEndDate.Location = new System.Drawing.Point(414, 70);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Size = new System.Drawing.Size(262, 32);
            this.txtEndDate.TabIndex = 25;
            this.txtEndDate.Click += new System.EventHandler(this.txtEndDate_Click);
            // 
            // btnDailySalesPDF
            // 
            this.btnDailySalesPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDailySalesPDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(115)))));
            this.btnDailySalesPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDailySalesPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDailySalesPDF.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDailySalesPDF.Location = new System.Drawing.Point(733, 70);
            this.btnDailySalesPDF.Name = "btnDailySalesPDF";
            this.btnDailySalesPDF.Size = new System.Drawing.Size(357, 50);
            this.btnDailySalesPDF.TabIndex = 27;
            this.btnDailySalesPDF.Text = "Daily Sales Report PDF";
            this.btnDailySalesPDF.UseVisualStyleBackColor = false;
            this.btnDailySalesPDF.Click += new System.EventHandler(this.btnDailySalesPDF_Click);
            // 
            // btnDailySummaryPDF
            // 
            this.btnDailySummaryPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDailySummaryPDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(115)))));
            this.btnDailySummaryPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDailySummaryPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDailySummaryPDF.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDailySummaryPDF.Location = new System.Drawing.Point(733, 153);
            this.btnDailySummaryPDF.Name = "btnDailySummaryPDF";
            this.btnDailySummaryPDF.Size = new System.Drawing.Size(357, 50);
            this.btnDailySummaryPDF.TabIndex = 28;
            this.btnDailySummaryPDF.Text = "Daily Sales Summary PDF";
            this.btnDailySummaryPDF.UseVisualStyleBackColor = false;
            this.btnDailySummaryPDF.Click += new System.EventHandler(this.btnDailySummaryPDF_Click);
            // 
            // btnUserSalePDF
            // 
            this.btnUserSalePDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUserSalePDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(115)))));
            this.btnUserSalePDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserSalePDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserSalePDF.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnUserSalePDF.Location = new System.Drawing.Point(733, 239);
            this.btnUserSalePDF.Name = "btnUserSalePDF";
            this.btnUserSalePDF.Size = new System.Drawing.Size(357, 50);
            this.btnUserSalePDF.TabIndex = 29;
            this.btnUserSalePDF.Text = "User Sales Report PDF";
            this.btnUserSalePDF.UseVisualStyleBackColor = false;
            this.btnUserSalePDF.Click += new System.EventHandler(this.btnUserSalePDF_Click);
            // 
            // SalesReportControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.Controls.Add(this.btnUserSalePDF);
            this.Controls.Add(this.btnDailySummaryPDF);
            this.Controls.Add(this.btnDailySalesPDF);
            this.Controls.Add(this.calEndDate);
            this.Controls.Add(this.calStartDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEndDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtStartDate);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.label1);
            this.Name = "SalesReportControl";
            this.Size = new System.Drawing.Size(1140, 670);
            this.Load += new System.EventHandler(this.SalesReportControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.MonthCalendar calStartDate;
        private System.Windows.Forms.MonthCalendar calEndDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStartDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEndDate;
        private System.Windows.Forms.Button btnDailySalesPDF;
        private System.Windows.Forms.Button btnDailySummaryPDF;
        private System.Windows.Forms.Button btnUserSalePDF;
    }
}
