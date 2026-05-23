namespace RetailPOSA.DialogBoxes
{
    partial class GrnHeaderForm
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
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.pnlSupplierResult = new System.Windows.Forms.Panel();
            this.dgvSupplierResult = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.btnAddGRN = new System.Windows.Forms.Button();
            this.pnlSupplierResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupplierResult)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.White;
            this.txtSearch.Location = new System.Drawing.Point(36, 122);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(473, 32);
            this.txtSearch.TabIndex = 20;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // pnlSupplierResult
            // 
            this.pnlSupplierResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.pnlSupplierResult.Controls.Add(this.dgvSupplierResult);
            this.pnlSupplierResult.Location = new System.Drawing.Point(36, 155);
            this.pnlSupplierResult.Name = "pnlSupplierResult";
            this.pnlSupplierResult.Size = new System.Drawing.Size(473, 227);
            this.pnlSupplierResult.TabIndex = 21;
            // 
            // dgvSupplierResult
            // 
            this.dgvSupplierResult.AllowUserToAddRows = false;
            this.dgvSupplierResult.AllowUserToDeleteRows = false;
            this.dgvSupplierResult.AllowUserToResizeRows = false;
            this.dgvSupplierResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSupplierResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSupplierResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSupplierResult.Location = new System.Drawing.Point(2, 3);
            this.dgvSupplierResult.MultiSelect = false;
            this.dgvSupplierResult.Name = "dgvSupplierResult";
            this.dgvSupplierResult.ReadOnly = true;
            this.dgvSupplierResult.RowHeadersVisible = false;
            this.dgvSupplierResult.RowHeadersWidth = 51;
            this.dgvSupplierResult.RowTemplate.Height = 24;
            this.dgvSupplierResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSupplierResult.Size = new System.Drawing.Size(469, 219);
            this.dgvSupplierResult.TabIndex = 14;
            this.dgvSupplierResult.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSupplierResult_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(39, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 24);
            this.label2.TabIndex = 22;
            this.label2.Text = "Select Supplier";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(39, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 24);
            this.label1.TabIndex = 24;
            this.label1.Text = "Invoice No";
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.txtInvoiceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInvoiceNo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvoiceNo.ForeColor = System.Drawing.Color.White;
            this.txtInvoiceNo.Location = new System.Drawing.Point(36, 52);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(473, 32);
            this.txtInvoiceNo.TabIndex = 23;
            // 
            // btnAddGRN
            // 
            this.btnAddGRN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddGRN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddGRN.Location = new System.Drawing.Point(328, 253);
            this.btnAddGRN.Name = "btnAddGRN";
            this.btnAddGRN.Size = new System.Drawing.Size(181, 40);
            this.btnAddGRN.TabIndex = 25;
            this.btnAddGRN.Text = "Add New GRN";
            this.btnAddGRN.UseVisualStyleBackColor = true;
            this.btnAddGRN.Click += new System.EventHandler(this.btnAddGRN_Click);
            // 
            // GrnHeaderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(536, 395);
            this.Controls.Add(this.pnlSupplierResult);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtInvoiceNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnAddGRN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GrnHeaderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GRN Header";
            this.Load += new System.EventHandler(this.GrnHeaderForm_Load);
            this.Click += new System.EventHandler(this.GrnHeaderForm_Click);
            this.pnlSupplierResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupplierResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel pnlSupplierResult;
        private System.Windows.Forms.DataGridView dgvSupplierResult;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.Button btnAddGRN;
    }
}