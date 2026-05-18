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
    public partial class GrnProductSearchForm : Form
    {
        private int selectedProductID = 0;
        private int grnID = 0;
        private string searchText = string.Empty;
        public GrnProductSearchForm(string searchTerm, int grnID)
        {
            InitializeComponent();
            searchText = searchTerm;
            txtSearch.Text = searchText;
            this.grnID = grnID;
        }

        private void GrnProductSearchForm_Load(object sender, EventArgs e)
        {
            btnAddProduct.Enabled = false;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ProductService productService = new ProductService();

            DataTable searchResults = productService.SearchProducts(txtSearch.Text);

            dgvProducts.DataSource = searchResults;

            dgvProducts.Columns["is_weighted"].Visible = false;
            dgvProducts.Columns["has_expiry"].Visible = false;
            dgvProducts.Columns["minimum_stock"].Visible = false;

            dgvProducts.Columns["id"].HeaderText = "ID";
            dgvProducts.Columns["category"].HeaderText = "Category";
            dgvProducts.Columns["barcode"].HeaderText = "Barcode";
            dgvProducts.Columns["product"].HeaderText = "Product";

            dgvProducts.Columns["id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dgvProducts.Columns["id"].Width = 50;
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            { 
                DataGridViewRow row = dgvProducts.Rows[e.RowIndex];

                selectedProductID = Convert.ToInt32(row.Cells["id"].Value);

                if (selectedProductID > 0) { btnAddProduct.Enabled = true; }
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            this.Close();

            GrnDetailForm grnDetailForm = new GrnDetailForm(selectedProductID, this.grnID);

            grnDetailForm.ShowDialog();
        }//open the grn detail form with the selected product ID
    }//class
}
