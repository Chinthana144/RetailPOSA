namespace RetailPOSA.UserControls
{
    partial class PaymethodControl
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
            this.btnPaymethods = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPaymethod = new System.Windows.Forms.TextBox();
            this.lblGreetings = new System.Windows.Forms.Label();
            this.chkStatus = new System.Windows.Forms.CheckBox();
            this.dgvPaymethods = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymethods)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPaymethods
            // 
            this.btnPaymethods.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(115)))));
            this.btnPaymethods.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaymethods.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaymethods.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPaymethods.Location = new System.Drawing.Point(42, 191);
            this.btnPaymethods.Name = "btnPaymethods";
            this.btnPaymethods.Size = new System.Drawing.Size(274, 38);
            this.btnPaymethods.TabIndex = 16;
            this.btnPaymethods.Text = "Paymethod";
            this.btnPaymethods.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(42, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 21);
            this.label2.TabIndex = 18;
            this.label2.Text = "Paymethod";
            // 
            // txtPaymethod
            // 
            this.txtPaymethod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.txtPaymethod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPaymethod.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaymethod.ForeColor = System.Drawing.Color.White;
            this.txtPaymethod.Location = new System.Drawing.Point(42, 88);
            this.txtPaymethod.Name = "txtPaymethod";
            this.txtPaymethod.Size = new System.Drawing.Size(274, 32);
            this.txtPaymethod.TabIndex = 17;
            // 
            // lblGreetings
            // 
            this.lblGreetings.AutoSize = true;
            this.lblGreetings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGreetings.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblGreetings.Location = new System.Drawing.Point(13, 12);
            this.lblGreetings.Name = "lblGreetings";
            this.lblGreetings.Size = new System.Drawing.Size(170, 25);
            this.lblGreetings.TabIndex = 19;
            this.lblGreetings.Text = "Payment Methods";
            // 
            // chkStatus
            // 
            this.chkStatus.AutoSize = true;
            this.chkStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.chkStatus.Location = new System.Drawing.Point(250, 146);
            this.chkStatus.Name = "chkStatus";
            this.chkStatus.Size = new System.Drawing.Size(66, 20);
            this.chkStatus.TabIndex = 20;
            this.chkStatus.Text = "Active";
            this.chkStatus.UseVisualStyleBackColor = true;
            // 
            // dgvPaymethods
            // 
            this.dgvPaymethods.AllowUserToAddRows = false;
            this.dgvPaymethods.AllowUserToDeleteRows = false;
            this.dgvPaymethods.AllowUserToResizeRows = false;
            this.dgvPaymethods.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPaymethods.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPaymethods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPaymethods.Location = new System.Drawing.Point(340, 57);
            this.dgvPaymethods.MultiSelect = false;
            this.dgvPaymethods.Name = "dgvPaymethods";
            this.dgvPaymethods.ReadOnly = true;
            this.dgvPaymethods.RowHeadersVisible = false;
            this.dgvPaymethods.RowHeadersWidth = 51;
            this.dgvPaymethods.RowTemplate.Height = 24;
            this.dgvPaymethods.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPaymethods.Size = new System.Drawing.Size(784, 643);
            this.dgvPaymethods.TabIndex = 21;
            this.dgvPaymethods.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPaymethods_CellClick);
            // 
            // PaymethodControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.Controls.Add(this.dgvPaymethods);
            this.Controls.Add(this.chkStatus);
            this.Controls.Add(this.lblGreetings);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPaymethod);
            this.Controls.Add(this.btnPaymethods);
            this.Name = "PaymethodControl";
            this.Size = new System.Drawing.Size(1141, 719);
            this.Load += new System.EventHandler(this.PaymethodControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymethods)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPaymethods;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPaymethod;
        private System.Windows.Forms.Label lblGreetings;
        private System.Windows.Forms.CheckBox chkStatus;
        private System.Windows.Forms.DataGridView dgvPaymethods;
    }
}
