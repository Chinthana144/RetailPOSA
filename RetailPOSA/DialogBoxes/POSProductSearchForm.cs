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
    public partial class POSProductSearchForm : Form
    {
        private int selectedProductID = 0;
        private int cartHeaderID = 0;
        private string searchTerm;
        public POSProductSearchForm(string searchText, int cartHeaderID)
        {
            InitializeComponent();
            searchTerm = searchText;
            this.cartHeaderID = cartHeaderID;
        }

        private void POSProductSearchForm_Load(object sender, EventArgs e)
        {
            txtSearch.Text = searchTerm;
            InventoryService inventoryService = new InventoryService();
            DataTable searchResults = inventoryService.SearchActiveInventory(searchTerm);

            if (searchResults.Rows.Count > 0)
            {
                dgvProducts.DataSource = searchResults;
                dgvProducts.Columns["id"].Visible = false;
                dgvProducts.Columns["grn_header_id"].Visible = false;
                dgvProducts.Columns["product_id"].Visible = false;
                dgvProducts.Columns["second_name"].Visible = false;
                dgvProducts.Columns["is_weighted"].Visible = false;
                dgvProducts.Columns["has_expiry"].Visible = false;
                dgvProducts.Columns["initial_qty"].Visible = false;
                dgvProducts.Columns["purchase_price"].Visible = false;

                dgvProducts.Columns["barcode"].HeaderText = "Barcode";
                dgvProducts.Columns["name"].HeaderText = "Product";
                dgvProducts.Columns["current_qty"].HeaderText = "Qty";
                dgvProducts.Columns["selling_price"].HeaderText = "Sale";
                dgvProducts.Columns["discount"].HeaderText = "Discount";
                dgvProducts.Columns["final_price"].HeaderText = "Price";
                dgvProducts.Columns["expiry_date"].HeaderText = "Expiry";

                dgvProducts.Columns["current_qty"].Width = 80;
                dgvProducts.Columns["selling_price"].Width = 80;
                dgvProducts.Columns["discount"].Width = 80;
                dgvProducts.Columns["final_price"].Width = 80;
                dgvProducts.Columns["expiry_date"].Width = 100;

            }
            else
            {
                MessageBox.Show("No products found matching the search term.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            searchTimer.Stop();
            searchTimer.Start();
        }

        private void searchTimer_Tick(object sender, EventArgs e)
        {
            searchTimer.Stop();
            InventoryService inventoryService = new InventoryService();
            if (txtSearch.Text != "")
            { 
                DataTable dt = inventoryService.SearchActiveInventory(txtSearch.Text);

                dgvProducts.DataSource = dt;
            }
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                CartDetailService cartDetailService = new CartDetailService();
                DataGridViewRow row = dgvProducts.Rows[e.RowIndex];

                selectedProductID = Convert.ToInt32(row.Cells["product_id"].Value);
                int inventoryID = Convert.ToInt32(row.Cells["id"].Value);
                decimal unitPrice = Convert.ToInt32(row.Cells["final_price"].Value);
                decimal qty = 1;
                decimal price = qty * unitPrice;

                cartDetailService.AddToCart(cartHeaderID, inventoryID, selectedProductID, unitPrice, qty, price);

                this.Close();

            }
        }
    }
}
