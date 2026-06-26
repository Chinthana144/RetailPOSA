using RetailPOSA.DialogBoxes;
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
    public partial class SupplierControl : UserControl
    {
        private int currentPage = 1;
        private int pageSize = 50;
        private int selectedID = 0;

        public SupplierControl()
        {
            InitializeComponent();
        }

        private void SupplierControl_Load(object sender, EventArgs e)
        {
            ThemeManager.ApplyTheme(this);
            loadSuppliers();

            btnEditSupplier.Enabled = false;
        }//form load

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            SupplierForm supplierForm = new SupplierForm(0);

            supplierForm.ShowDialog();

            //load suppliers
            loadSuppliers();
        }

        private void loadSuppliers()
        {
            SupplierService service = new SupplierService();

            DataTable suppliers = service.GetAllSuppliers(pageSize, (currentPage - 1) * pageSize);
    
            dgvSuppliers.DataSource = suppliers;

            dgvSuppliers.Columns["id"].HeaderText = "ID";
            dgvSuppliers.Columns["company_name"].HeaderText = "Company Name";
            dgvSuppliers.Columns["supplier_name"].HeaderText = "Supplier Name";
            dgvSuppliers.Columns["contact_no"].HeaderText = "Contact";

            lblPageNo.Text = $"Page {currentPage}";

            dgvSuppliers.Columns[0].Width = 50;
        }//get all suppliers

        private void dgvSuppliers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSuppliers.Rows[e.RowIndex];

                selectedID = Convert.ToInt32(row.Cells["id"].Value);

                if (selectedID > 0) { btnEditSupplier.Enabled = true; }
            }
        }//cell click

        private void btnEditSupplier_Click(object sender, EventArgs e)
        {
            SupplierForm supplierForm = new SupplierForm(selectedID);

            supplierForm.ShowDialog();

            //load suppliers
            loadSuppliers();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;

                loadSuppliers();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            currentPage++;

            loadSuppliers();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SupplierService service = new SupplierService();

            DataTable dt = new DataTable();

            dt = service.SearchSupplier(txtSearch.Text);

            dgvSuppliers.DataSource = dt;
        }
    }//class
}
