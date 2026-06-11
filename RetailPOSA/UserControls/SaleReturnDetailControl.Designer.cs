namespace RetailPOSA.UserControls
{
    partial class SaleReturnDetailControl
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
            this.label2 = new System.Windows.Forms.Label();
            this.dgvInvoiceDetail = new System.Windows.Forms.DataGridView();
            this.dgvReturnDetail = new System.Windows.Forms.DataGridView();
            this.btnSubmitReturn = new System.Windows.Forms.Button();
            this.lblRowCount = new System.Windows.Forms.Label();
            this.lblReturnTotal = new System.Windows.Forms.Label();
            this.btnRemoveReturnItem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReturnDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(16, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 28);
            this.label2.TabIndex = 38;
            this.label2.Text = "Sales Return";
            // 
            // dgvInvoiceDetail
            // 
            this.dgvInvoiceDetail.AllowUserToAddRows = false;
            this.dgvInvoiceDetail.AllowUserToDeleteRows = false;
            this.dgvInvoiceDetail.AllowUserToResizeRows = false;
            this.dgvInvoiceDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInvoiceDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInvoiceDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoiceDetail.Location = new System.Drawing.Point(17, 42);
            this.dgvInvoiceDetail.MultiSelect = false;
            this.dgvInvoiceDetail.Name = "dgvInvoiceDetail";
            this.dgvInvoiceDetail.ReadOnly = true;
            this.dgvInvoiceDetail.RowHeadersVisible = false;
            this.dgvInvoiceDetail.RowHeadersWidth = 51;
            this.dgvInvoiceDetail.RowTemplate.Height = 24;
            this.dgvInvoiceDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInvoiceDetail.Size = new System.Drawing.Size(1109, 281);
            this.dgvInvoiceDetail.TabIndex = 40;
            this.dgvInvoiceDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInvoiceDetail_CellClick);
            // 
            // dgvReturnDetail
            // 
            this.dgvReturnDetail.AllowUserToAddRows = false;
            this.dgvReturnDetail.AllowUserToDeleteRows = false;
            this.dgvReturnDetail.AllowUserToResizeRows = false;
            this.dgvReturnDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReturnDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReturnDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReturnDetail.Location = new System.Drawing.Point(17, 376);
            this.dgvReturnDetail.MultiSelect = false;
            this.dgvReturnDetail.Name = "dgvReturnDetail";
            this.dgvReturnDetail.ReadOnly = true;
            this.dgvReturnDetail.RowHeadersVisible = false;
            this.dgvReturnDetail.RowHeadersWidth = 51;
            this.dgvReturnDetail.RowTemplate.Height = 24;
            this.dgvReturnDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReturnDetail.Size = new System.Drawing.Size(1109, 291);
            this.dgvReturnDetail.TabIndex = 41;
            this.dgvReturnDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReturnDetail_CellClick);
            // 
            // btnSubmitReturn
            // 
            this.btnSubmitReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmitReturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSubmitReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmitReturn.Location = new System.Drawing.Point(960, 681);
            this.btnSubmitReturn.Name = "btnSubmitReturn";
            this.btnSubmitReturn.Size = new System.Drawing.Size(166, 40);
            this.btnSubmitReturn.TabIndex = 43;
            this.btnSubmitReturn.Text = "Submit Return";
            this.btnSubmitReturn.UseVisualStyleBackColor = false;
            this.btnSubmitReturn.Click += new System.EventHandler(this.btnSubmitReturn_Click);
            // 
            // lblRowCount
            // 
            this.lblRowCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRowCount.AutoSize = true;
            this.lblRowCount.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRowCount.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblRowCount.Location = new System.Drawing.Point(17, 670);
            this.lblRowCount.Name = "lblRowCount";
            this.lblRowCount.Size = new System.Drawing.Size(102, 24);
            this.lblRowCount.TabIndex = 44;
            this.lblRowCount.Text = "Row Count";
            // 
            // lblReturnTotal
            // 
            this.lblReturnTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblReturnTotal.AutoSize = true;
            this.lblReturnTotal.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReturnTotal.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblReturnTotal.Location = new System.Drawing.Point(17, 699);
            this.lblReturnTotal.Name = "lblReturnTotal";
            this.lblReturnTotal.Size = new System.Drawing.Size(51, 24);
            this.lblReturnTotal.TabIndex = 45;
            this.lblReturnTotal.Text = "Total";
            // 
            // btnRemoveReturnItem
            // 
            this.btnRemoveReturnItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveReturnItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnRemoveReturnItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveReturnItem.Location = new System.Drawing.Point(838, 681);
            this.btnRemoveReturnItem.Name = "btnRemoveReturnItem";
            this.btnRemoveReturnItem.Size = new System.Drawing.Size(116, 40);
            this.btnRemoveReturnItem.TabIndex = 46;
            this.btnRemoveReturnItem.Text = "Remove";
            this.btnRemoveReturnItem.UseVisualStyleBackColor = false;
            this.btnRemoveReturnItem.Click += new System.EventHandler(this.btnRemoveReturnItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(15, 346);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 28);
            this.label1.TabIndex = 47;
            this.label1.Text = "Return Cart";
            // 
            // SaleReturnDetailControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRemoveReturnItem);
            this.Controls.Add(this.lblReturnTotal);
            this.Controls.Add(this.lblRowCount);
            this.Controls.Add(this.btnSubmitReturn);
            this.Controls.Add(this.dgvReturnDetail);
            this.Controls.Add(this.dgvInvoiceDetail);
            this.Controls.Add(this.label2);
            this.Name = "SaleReturnDetailControl";
            this.Size = new System.Drawing.Size(1140, 739);
            this.Load += new System.EventHandler(this.SaleReturnDetailControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReturnDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvInvoiceDetail;
        private System.Windows.Forms.DataGridView dgvReturnDetail;
        private System.Windows.Forms.Button btnSubmitReturn;
        private System.Windows.Forms.Label lblRowCount;
        private System.Windows.Forms.Label lblReturnTotal;
        private System.Windows.Forms.Button btnRemoveReturnItem;
        private System.Windows.Forms.Label label1;
    }
}
