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
    public partial class AdjustmentProductSearchForm : Form
    {
        private string searchTerm = "";
        private int adjustmentHeaderID = 0; 
        public AdjustmentProductSearchForm(string searchTerm, int adjustmentHeaderID)
        {
            InitializeComponent();

            this.searchTerm = searchTerm;
            this.adjustmentHeaderID = adjustmentHeaderID;
        }

        private void AdjustmentProductSearchForm_Load(object sender, EventArgs e)
        {
            ThemeManager.ApplyTheme(this);
            loadproducts();
        }

        private void loadproducts()
        {
            InventoryService inventoryService = new InventoryService();

            DataTable SearchData = inventoryService.SearchActiveInventory(searchTerm);

            dgvProducts.DataSource = SearchData;

            dgvProducts.Columns["id"].Visible = false;
            dgvProducts.Columns["grn_header_id"].Visible = false;
            dgvProducts.Columns["product_id"].Visible = false;
            dgvProducts.Columns["second_name"].Visible = false;
            dgvProducts.Columns["is_weighted"].Visible = false;
            dgvProducts.Columns["has_expiry"].Visible = false;
            dgvProducts.Columns["initial_qty"].Visible = false;

            dgvProducts.Columns["barcode"].HeaderText = "Barcode";
            dgvProducts.Columns["name"].HeaderText = "Product";
            dgvProducts.Columns["current_qty"].HeaderText = "Qty";
            dgvProducts.Columns["purchase_price"].HeaderText = "Pur. Price";
            dgvProducts.Columns["selling_price"].HeaderText = "Sell Price";
            dgvProducts.Columns["discount"].HeaderText = "Discount";
            dgvProducts.Columns["final_price"].HeaderText = "Final Price";
            dgvProducts.Columns["expiry_date"].HeaderText = "Expire";
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProducts.Rows[e.RowIndex];

                int inventoryID = Convert.ToInt32(row.Cells["id"].Value);

                AdjustmentDetailForm adjustmentDetailForm = new AdjustmentDetailForm(this.adjustmentHeaderID, inventoryID);
                adjustmentDetailForm.ShowDialog();

                this.Close();
            } 
        }
    }
}
