namespace RetailPOSA.UserControls
{
    partial class DashboardControl
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlInvoice = new System.Windows.Forms.Panel();
            this.lblTodayInvoice = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlMonthlySale = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlStock = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlTodaySale = new System.Windows.Forms.Panel();
            this.lblTodaySale = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblShopName = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.dateTimer = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlInvoice.SuspendLayout();
            this.pnlMonthlySale.SuspendLayout();
            this.pnlStock.SuspendLayout();
            this.pnlTodaySale.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.pnlInvoice, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlMonthlySale, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlStock, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlTodaySale, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(16, 57);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1106, 147);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pnlInvoice
            // 
            this.pnlInvoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlInvoice.Controls.Add(this.lblTodayInvoice);
            this.pnlInvoice.Controls.Add(this.label2);
            this.pnlInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInvoice.Location = new System.Drawing.Point(286, 10);
            this.pnlInvoice.Margin = new System.Windows.Forms.Padding(10);
            this.pnlInvoice.Name = "pnlInvoice";
            this.pnlInvoice.Size = new System.Drawing.Size(256, 127);
            this.pnlInvoice.TabIndex = 2;
            // 
            // lblTodayInvoice
            // 
            this.lblTodayInvoice.AutoSize = true;
            this.lblTodayInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTodayInvoice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblTodayInvoice.Location = new System.Drawing.Point(33, 65);
            this.lblTodayInvoice.Name = "lblTodayInvoice";
            this.lblTodayInvoice.Size = new System.Drawing.Size(134, 32);
            this.lblTodayInvoice.TabIndex = 2;
            this.lblTodayInvoice.Text = "0 Invoces";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Location = new System.Drawing.Point(15, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Today\'s Invoices";
            // 
            // pnlMonthlySale
            // 
            this.pnlMonthlySale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlMonthlySale.Controls.Add(this.label7);
            this.pnlMonthlySale.Controls.Add(this.label3);
            this.pnlMonthlySale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMonthlySale.Location = new System.Drawing.Point(562, 10);
            this.pnlMonthlySale.Margin = new System.Windows.Forms.Padding(10);
            this.pnlMonthlySale.Name = "pnlMonthlySale";
            this.pnlMonthlySale.Size = new System.Drawing.Size(256, 127);
            this.pnlMonthlySale.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label7.Location = new System.Drawing.Point(30, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 32);
            this.label7.TabIndex = 3;
            this.label7.Text = "LKR:0.00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.Location = new System.Drawing.Point(14, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Monthly Sale";
            // 
            // pnlStock
            // 
            this.pnlStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlStock.Controls.Add(this.label8);
            this.pnlStock.Controls.Add(this.label4);
            this.pnlStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStock.Location = new System.Drawing.Point(838, 10);
            this.pnlStock.Margin = new System.Windows.Forms.Padding(10);
            this.pnlStock.Name = "pnlStock";
            this.pnlStock.Size = new System.Drawing.Size(258, 127);
            this.pnlStock.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label8.Location = new System.Drawing.Point(26, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 32);
            this.label8.TabIndex = 3;
            this.label8.Text = "0 Items";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label4.Location = new System.Drawing.Point(15, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "Low Stock";
            // 
            // pnlTodaySale
            // 
            this.pnlTodaySale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlTodaySale.Controls.Add(this.lblTodaySale);
            this.pnlTodaySale.Controls.Add(this.label1);
            this.pnlTodaySale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTodaySale.Location = new System.Drawing.Point(10, 10);
            this.pnlTodaySale.Margin = new System.Windows.Forms.Padding(10);
            this.pnlTodaySale.Name = "pnlTodaySale";
            this.pnlTodaySale.Size = new System.Drawing.Size(256, 127);
            this.pnlTodaySale.TabIndex = 1;
            // 
            // lblTodaySale
            // 
            this.lblTodaySale.AutoSize = true;
            this.lblTodaySale.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTodaySale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblTodaySale.Location = new System.Drawing.Point(26, 65);
            this.lblTodaySale.Name = "lblTodaySale";
            this.lblTodaySale.Size = new System.Drawing.Size(133, 32);
            this.lblTodaySale.TabIndex = 1;
            this.lblTodaySale.Text = "LRK:0.00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Today\'s Sales";
            // 
            // lblShopName
            // 
            this.lblShopName.AutoSize = true;
            this.lblShopName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShopName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblShopName.Location = new System.Drawing.Point(19, 13);
            this.lblShopName.Name = "lblShopName";
            this.lblShopName.Size = new System.Drawing.Size(156, 32);
            this.lblShopName.TabIndex = 2;
            this.lblShopName.Text = "ShopName";
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblTime.Location = new System.Drawing.Point(788, 13);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(331, 32);
            this.lblTime.TabIndex = 3;
            this.lblTime.Text = "YYYY-MM-DD HH:mm:ss";
            // 
            // dateTimer
            // 
            this.dateTimer.Interval = 500;
            this.dateTimer.Tick += new System.EventHandler(this.dateTimer_Tick);
            // 
            // DashboardControl
            // 
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblShopName);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DashboardControl";
            this.Size = new System.Drawing.Size(1138, 707);
            this.Load += new System.EventHandler(this.DashboardControl_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnlInvoice.ResumeLayout(false);
            this.pnlInvoice.PerformLayout();
            this.pnlMonthlySale.ResumeLayout(false);
            this.pnlMonthlySale.PerformLayout();
            this.pnlStock.ResumeLayout(false);
            this.pnlStock.PerformLayout();
            this.pnlTodaySale.ResumeLayout(false);
            this.pnlTodaySale.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnlTodaySale;
        private System.Windows.Forms.Panel pnlInvoice;
        private System.Windows.Forms.Panel pnlMonthlySale;
        private System.Windows.Forms.Panel pnlStock;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTodaySale;
        private System.Windows.Forms.Label lblShopName;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblTodayInvoice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Timer dateTimer;
    }
}
