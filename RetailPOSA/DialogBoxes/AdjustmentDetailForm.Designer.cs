namespace RetailPOSA.DialogBoxes
{
    partial class AdjustmentDetailForm
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
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.lblAverageCost = new System.Windows.Forms.Label();
            this.lblAdjustQty = new System.Windows.Forms.Label();
            this.lblTotalValue = new System.Windows.Forms.Label();
            this.txtPhysicalQty = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.lblSystemQty = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddProduct.Location = new System.Drawing.Point(235, 331);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(181, 40);
            this.btnAddProduct.TabIndex = 48;
            this.btnAddProduct.Text = "Add Product";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // lblAverageCost
            // 
            this.lblAverageCost.AutoSize = true;
            this.lblAverageCost.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAverageCost.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblAverageCost.Location = new System.Drawing.Point(27, 247);
            this.lblAverageCost.Name = "lblAverageCost";
            this.lblAverageCost.Size = new System.Drawing.Size(119, 24);
            this.lblAverageCost.TabIndex = 56;
            this.lblAverageCost.Text = "Average Cost";
            // 
            // lblAdjustQty
            // 
            this.lblAdjustQty.AutoSize = true;
            this.lblAdjustQty.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdjustQty.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblAdjustQty.Location = new System.Drawing.Point(27, 212);
            this.lblAdjustQty.Name = "lblAdjustQty";
            this.lblAdjustQty.Size = new System.Drawing.Size(98, 24);
            this.lblAdjustQty.TabIndex = 55;
            this.lblAdjustQty.Text = "Adjust Qty";
            // 
            // lblTotalValue
            // 
            this.lblTotalValue.AutoSize = true;
            this.lblTotalValue.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalValue.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTotalValue.Location = new System.Drawing.Point(27, 282);
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.Size = new System.Drawing.Size(102, 24);
            this.lblTotalValue.TabIndex = 54;
            this.lblTotalValue.Text = "Total Value";
            // 
            // txtPhysicalQty
            // 
            this.txtPhysicalQty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.txtPhysicalQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhysicalQty.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhysicalQty.ForeColor = System.Drawing.Color.White;
            this.txtPhysicalQty.Location = new System.Drawing.Point(24, 157);
            this.txtPhysicalQty.Name = "txtPhysicalQty";
            this.txtPhysicalQty.Size = new System.Drawing.Size(392, 36);
            this.txtPhysicalQty.TabIndex = 43;
            this.txtPhysicalQty.TextChanged += new System.EventHandler(this.txtPhysicalQty_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(24, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 24);
            this.label5.TabIndex = 53;
            this.label5.Text = "Physical Qty";
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblProductName.Location = new System.Drawing.Point(27, 56);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(129, 24);
            this.lblProductName.TabIndex = 52;
            this.lblProductName.Text = "Product Name";
            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBarcode.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblBarcode.Location = new System.Drawing.Point(27, 22);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(78, 24);
            this.lblBarcode.TabIndex = 51;
            this.lblBarcode.Text = "Barcode";
            // 
            // lblSystemQty
            // 
            this.lblSystemQty.AutoSize = true;
            this.lblSystemQty.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSystemQty.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblSystemQty.Location = new System.Drawing.Point(24, 93);
            this.lblSystemQty.Name = "lblSystemQty";
            this.lblSystemQty.Size = new System.Drawing.Size(103, 24);
            this.lblSystemQty.TabIndex = 49;
            this.lblSystemQty.Text = "System Qty";
            // 
            // AdjustmentDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(443, 401);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.lblAverageCost);
            this.Controls.Add(this.lblAdjustQty);
            this.Controls.Add(this.lblTotalValue);
            this.Controls.Add(this.txtPhysicalQty);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.lblBarcode);
            this.Controls.Add(this.lblSystemQty);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdjustmentDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Adjustment Item";
            this.Load += new System.EventHandler(this.AdjustmentDetailForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Label lblAverageCost;
        private System.Windows.Forms.Label lblAdjustQty;
        private System.Windows.Forms.Label lblTotalValue;
        private System.Windows.Forms.TextBox txtPhysicalQty;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.Label lblSystemQty;
    }
}