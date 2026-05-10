using RetailPOSA.Models;
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

namespace RetailPOSA.DialogBoxes
{
    public partial class GrnHeaderForm : Form
    {
        private int supplierID = 0;
        public GrnHeaderForm()
        {
            InitializeComponent();
        }

        private void GrnHeaderForm_Load(object sender, EventArgs e)
        {
            pnlSupplierResult.Visible = false;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SupplierService supplierService = new SupplierService();

            DataTable dt = supplierService.SearchSupplier(txtSearch.Text);

            if (dt != null)
            {
                dgvSupplierResult.DataSource = dt;
                pnlSupplierResult.Visible = true;

                dgvSupplierResult.Columns["id"].HeaderText = "ID";
                dgvSupplierResult.Columns["company_name"].HeaderText = "Company Name";
                dgvSupplierResult.Columns["supplier_name"].HeaderText = "Supplier Name";
                dgvSupplierResult.Columns["contact_no"].HeaderText = "Contact No";
            }
        }

        private void GrnHeaderForm_Click(object sender, EventArgs e)
        {
            pnlSupplierResult.Visible = false;
        }

        private void dgvSupplierResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSupplierResult.Rows[e.RowIndex];
                supplierID = Convert.ToInt32(row.Cells["id"].Value);
                string supplier = row.Cells["company_name"].Value.ToString() + " - " + row.Cells["supplier_name"].Value.ToString() + " - " + row.Cells["contact_no"].Value.ToString();
                txtSearch.Text = supplier;

                pnlSupplierResult.Visible = false;
            }
        }

        private void btnAddGRN_Click(object sender, EventArgs e)
        {
            GrnHeaderService service = new GrnHeaderService();

            int userID = Session.UserID;
            string date_created = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            int grnID = service.InsertGrnHeader(supplierID, txtInvoiceNo.Text, date_created, date_created, 0, 0, 0, 1, userID);

            if (grnID > 0)
            {
                //MessageBox.Show("GRN Header added successfully. GRN ID: " + grnID);
                //this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to add GRN Header.");
            }
        }
    }//class
}
