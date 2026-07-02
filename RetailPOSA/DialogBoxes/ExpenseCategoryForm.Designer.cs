namespace RetailPOSA.DialogBoxes
{
    partial class ExpenseCategoryForm
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
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExpenseCategory = new System.Windows.Forms.Button();
            this.dgvExpenseCategories = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpenseCategories)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCategoryName
            // 
            this.txtCategoryName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCategoryName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.txtCategoryName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCategoryName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategoryName.ForeColor = System.Drawing.Color.White;
            this.txtCategoryName.Location = new System.Drawing.Point(12, 33);
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.Size = new System.Drawing.Size(318, 32);
            this.txtCategoryName.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 21);
            this.label2.TabIndex = 22;
            this.label2.Text = "Category";
            // 
            // btnExpenseCategory
            // 
            this.btnExpenseCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExpenseCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpenseCategory.Location = new System.Drawing.Point(347, 26);
            this.btnExpenseCategory.Name = "btnExpenseCategory";
            this.btnExpenseCategory.Size = new System.Drawing.Size(164, 40);
            this.btnExpenseCategory.TabIndex = 23;
            this.btnExpenseCategory.Text = "Create";
            this.btnExpenseCategory.UseVisualStyleBackColor = true;
            this.btnExpenseCategory.Click += new System.EventHandler(this.btnExpenseCategory_Click);
            // 
            // dgvExpenseCategories
            // 
            this.dgvExpenseCategories.AllowUserToAddRows = false;
            this.dgvExpenseCategories.AllowUserToDeleteRows = false;
            this.dgvExpenseCategories.AllowUserToResizeRows = false;
            this.dgvExpenseCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvExpenseCategories.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvExpenseCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExpenseCategories.Location = new System.Drawing.Point(12, 72);
            this.dgvExpenseCategories.MultiSelect = false;
            this.dgvExpenseCategories.Name = "dgvExpenseCategories";
            this.dgvExpenseCategories.ReadOnly = true;
            this.dgvExpenseCategories.RowHeadersVisible = false;
            this.dgvExpenseCategories.RowHeadersWidth = 51;
            this.dgvExpenseCategories.RowTemplate.Height = 24;
            this.dgvExpenseCategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExpenseCategories.Size = new System.Drawing.Size(499, 561);
            this.dgvExpenseCategories.TabIndex = 24;
            this.dgvExpenseCategories.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExpenseCategories_CellClick);
            // 
            // ExpenseCategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(523, 645);
            this.Controls.Add(this.dgvExpenseCategories);
            this.Controls.Add(this.btnExpenseCategory);
            this.Controls.Add(this.txtCategoryName);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExpenseCategoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Expense Category";
            this.Load += new System.EventHandler(this.ExpenseCategoryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpenseCategories)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExpenseCategory;
        private System.Windows.Forms.DataGridView dgvExpenseCategories;
    }
}