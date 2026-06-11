using Org.BouncyCastle.Crypto.Parameters;
using RetailPOSA.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RetailPOSA.UserControls
{
    public partial class PaymethodControl : UserControl
    {
        private int selectedID = 0;
        public PaymethodControl()
        {
            InitializeComponent();
        }

        private void PaymethodControl_Load(object sender, EventArgs e)
        {
            loadPaymethods();

            btnPaymethods.Text = selectedID > 0 ? "Update Paymethod" : "Add Paymethod";
        }

        private void loadPaymethods()
        { 
            PaymethodService paymethodService = new PaymethodService();
            DataTable paymethodData = paymethodService.GetAllPaymethods();

            dgvPaymethods.DataSource = paymethodData;

            dgvPaymethods.Columns["id"].HeaderText = "ID";
            dgvPaymethods.Columns["paymethod"].HeaderText = "Paymethod";
            dgvPaymethods.Columns["status"].HeaderText = "Status";

            dgvPaymethods.Columns["id"].Width = 50;

            selectedID = 0;
            btnPaymethods.Text = selectedID > 0 ? "Update Paymethod" : "Add Paymethod";
            txtPaymethod.Text = "";
        }//laod paymethod

        private void dgvPaymethods_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPaymethods.Rows[e.RowIndex];
                this.selectedID = Convert.ToInt32(row.Cells["id"].Value);
                string paymethod = row.Cells["paymethod"].Value.ToString();
                int status = Convert.ToInt32(row.Cells["status"].Value);

                txtPaymethod.Text = paymethod;
                chkStatus.Checked = status == 1 ? true : false;

                btnPaymethods.Text = "Update Paymethod";
            }
        }

        private void btnPaymethods_Click(object sender, EventArgs e)
        {
            if (txtPaymethod.Text == "")
            {
                MessageBox.Show("Please enter payment method.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }//null check

            PaymethodService paymethodService = new PaymethodService();
            int status = chkStatus.Checked ? 1 : 0;
            if (selectedID > 0)
            {
                paymethodService.UpdatePaymethod(selectedID, txtPaymethod.Text, status);
            }//update
            else
            { 
                paymethodService.InsertPaymethod(txtPaymethod.Text, status);
            }//insert

            loadPaymethods();
        }
    }//class
}
