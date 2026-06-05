namespace RetailPOSA.UserControls
{
    partial class UserAccessControl
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
            this.flpRoles = new System.Windows.Forms.FlowLayoutPanel();
            this.flpPages = new System.Windows.Forms.FlowLayoutPanel();
            this.chkView = new System.Windows.Forms.CheckBox();
            this.chkAdd = new System.Windows.Forms.CheckBox();
            this.chkEdit = new System.Windows.Forms.CheckBox();
            this.chkDelete = new System.Windows.Forms.CheckBox();
            this.chkPrint = new System.Windows.Forms.CheckBox();
            this.btnUserAccess = new System.Windows.Forms.Button();
            this.lblRoleName = new System.Windows.Forms.Label();
            this.lblPageName = new System.Windows.Forms.Label();
            this.dgvPermissions = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermissions)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "User Access";
            // 
            // flpRoles
            // 
            this.flpRoles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flpRoles.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpRoles.Location = new System.Drawing.Point(15, 64);
            this.flpRoles.Name = "flpRoles";
            this.flpRoles.Size = new System.Drawing.Size(265, 664);
            this.flpRoles.TabIndex = 5;
            // 
            // flpPages
            // 
            this.flpPages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flpPages.AutoScroll = true;
            this.flpPages.Location = new System.Drawing.Point(286, 64);
            this.flpPages.Name = "flpPages";
            this.flpPages.Size = new System.Drawing.Size(235, 664);
            this.flpPages.TabIndex = 6;
            // 
            // chkView
            // 
            this.chkView.AutoSize = true;
            this.chkView.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.chkView.Location = new System.Drawing.Point(550, 74);
            this.chkView.Name = "chkView";
            this.chkView.Size = new System.Drawing.Size(88, 33);
            this.chkView.TabIndex = 7;
            this.chkView.Text = "View";
            this.chkView.UseVisualStyleBackColor = true;
            // 
            // chkAdd
            // 
            this.chkAdd.AutoSize = true;
            this.chkAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.chkAdd.Location = new System.Drawing.Point(653, 74);
            this.chkAdd.Name = "chkAdd";
            this.chkAdd.Size = new System.Drawing.Size(107, 33);
            this.chkAdd.TabIndex = 8;
            this.chkAdd.Text = "Create";
            this.chkAdd.UseVisualStyleBackColor = true;
            // 
            // chkEdit
            // 
            this.chkEdit.AutoSize = true;
            this.chkEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.chkEdit.Location = new System.Drawing.Point(775, 74);
            this.chkEdit.Name = "chkEdit";
            this.chkEdit.Size = new System.Drawing.Size(113, 33);
            this.chkEdit.TabIndex = 9;
            this.chkEdit.Text = "Update";
            this.chkEdit.UseVisualStyleBackColor = true;
            // 
            // chkDelete
            // 
            this.chkDelete.AutoSize = true;
            this.chkDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.chkDelete.Location = new System.Drawing.Point(903, 74);
            this.chkDelete.Name = "chkDelete";
            this.chkDelete.Size = new System.Drawing.Size(106, 33);
            this.chkDelete.TabIndex = 10;
            this.chkDelete.Text = "Delete";
            this.chkDelete.UseVisualStyleBackColor = true;
            // 
            // chkPrint
            // 
            this.chkPrint.AutoSize = true;
            this.chkPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPrint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.chkPrint.Location = new System.Drawing.Point(1024, 74);
            this.chkPrint.Name = "chkPrint";
            this.chkPrint.Size = new System.Drawing.Size(84, 33);
            this.chkPrint.TabIndex = 11;
            this.chkPrint.Text = "Print";
            this.chkPrint.UseVisualStyleBackColor = true;
            // 
            // btnUserAccess
            // 
            this.btnUserAccess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUserAccess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(115)))));
            this.btnUserAccess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserAccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserAccess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnUserAccess.Location = new System.Drawing.Point(957, 119);
            this.btnUserAccess.Name = "btnUserAccess";
            this.btnUserAccess.Size = new System.Drawing.Size(173, 38);
            this.btnUserAccess.TabIndex = 12;
            this.btnUserAccess.Text = "Update Access";
            this.btnUserAccess.UseVisualStyleBackColor = false;
            this.btnUserAccess.Click += new System.EventHandler(this.btnUserAccess_Click);
            // 
            // lblRoleName
            // 
            this.lblRoleName.AutoSize = true;
            this.lblRoleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoleName.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblRoleName.Location = new System.Drawing.Point(557, 20);
            this.lblRoleName.Name = "lblRoleName";
            this.lblRoleName.Size = new System.Drawing.Size(108, 25);
            this.lblRoleName.TabIndex = 13;
            this.lblRoleName.Text = "Role Name";
            // 
            // lblPageName
            // 
            this.lblPageName.AutoSize = true;
            this.lblPageName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageName.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblPageName.Location = new System.Drawing.Point(761, 20);
            this.lblPageName.Name = "lblPageName";
            this.lblPageName.Size = new System.Drawing.Size(115, 25);
            this.lblPageName.TabIndex = 14;
            this.lblPageName.Text = "Page Name";
            // 
            // dgvPermissions
            // 
            this.dgvPermissions.AllowUserToAddRows = false;
            this.dgvPermissions.AllowUserToDeleteRows = false;
            this.dgvPermissions.AllowUserToResizeRows = false;
            this.dgvPermissions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPermissions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPermissions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPermissions.Location = new System.Drawing.Point(527, 163);
            this.dgvPermissions.MultiSelect = false;
            this.dgvPermissions.Name = "dgvPermissions";
            this.dgvPermissions.ReadOnly = true;
            this.dgvPermissions.RowHeadersVisible = false;
            this.dgvPermissions.RowHeadersWidth = 51;
            this.dgvPermissions.RowTemplate.Height = 24;
            this.dgvPermissions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPermissions.Size = new System.Drawing.Size(603, 565);
            this.dgvPermissions.TabIndex = 15;
            this.dgvPermissions.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPermissions_CellClick);
            // 
            // UserAccessControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.Controls.Add(this.dgvPermissions);
            this.Controls.Add(this.lblPageName);
            this.Controls.Add(this.lblRoleName);
            this.Controls.Add(this.btnUserAccess);
            this.Controls.Add(this.chkPrint);
            this.Controls.Add(this.chkDelete);
            this.Controls.Add(this.chkEdit);
            this.Controls.Add(this.chkAdd);
            this.Controls.Add(this.chkView);
            this.Controls.Add(this.flpPages);
            this.Controls.Add(this.flpRoles);
            this.Controls.Add(this.label1);
            this.Name = "UserAccessControl";
            this.Size = new System.Drawing.Size(1145, 745);
            this.Load += new System.EventHandler(this.UserAccessControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermissions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flpRoles;
        private System.Windows.Forms.FlowLayoutPanel flpPages;
        private System.Windows.Forms.CheckBox chkView;
        private System.Windows.Forms.CheckBox chkAdd;
        private System.Windows.Forms.CheckBox chkEdit;
        private System.Windows.Forms.CheckBox chkDelete;
        private System.Windows.Forms.CheckBox chkPrint;
        private System.Windows.Forms.Button btnUserAccess;
        private System.Windows.Forms.Label lblRoleName;
        private System.Windows.Forms.Label lblPageName;
        private System.Windows.Forms.DataGridView dgvPermissions;
    }
}
