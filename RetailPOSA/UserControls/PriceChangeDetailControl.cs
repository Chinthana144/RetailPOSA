using RetailPOSA.DialogBoxes;
using RetailPOSA.Forms;
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

namespace RetailPOSA.UserControls
{
    public partial class PriceChangeDetailControl : UserControl
    {
        private int selectedID = 0;
        private int headerID = 0;
        public PriceChangeDetailControl(int headerID)
        {
            InitializeComponent();
            this.headerID = headerID;
        }

        private void PriceChangeDetailControl_Load(object sender, EventArgs e)
        {
            loadHeaderData();

            loadPriceChangeDetails();

            btnRemove.Enabled = false;
        }

        private void loadHeaderData()
        {
            PriceChangeHeaderService headerService = new PriceChangeHeaderService();
            DataTable headerData = headerService.GetPriceChangeByID(headerID);
            if (headerData.Rows.Count > 0)
            {
                DataRow row = headerData.Rows[0];
                lblTitle.Text = "Price Change No: " + row["price_change_no"].ToString();
                lblDate.Text = "Date: " + row["submitted_datetime"].ToString();
                lblNote.Text = "Note: " + row["note"].ToString();
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtSearch.Text.Length > 0)
            {
                if (e.KeyCode == Keys.Enter)
                { 
                    InventoryService inventoryService = new InventoryService();

                    DataTable searchResult = inventoryService.SearchActiveInventory(txtSearch.Text);

                    if (searchResult.Rows.Count == 1)
                    {
                        int inventoryID = Convert.ToInt32(searchResult.Rows[0]["id"]);

                        PriceChangeDetailForm priceDetail = new PriceChangeDetailForm(headerID, inventoryID);
                        priceDetail.ShowDialog();
                    }
                    else if(searchResult.Rows.Count > 1)
                    {
                        PriceChangeProductSearchForm searchForm = new PriceChangeProductSearchForm(txtSearch.Text, headerID);
                        searchForm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("No product found with the given search term.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    //load data
                    loadPriceChangeDetails();
                }//enter key pressed
            }//has text
        }
        private void dgvChangeDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvChangeDetail.Rows[e.RowIndex];
                selectedID = Convert.ToInt32(row.Cells["id"].Value);

                btnRemove.Enabled = true;
            }
        }//cell Click
        private void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to remove the selected product from the price change?", "Confirm Removal", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (selectedID > 0)
                {
                    PriceChangeDetailService detailService = new PriceChangeDetailService();
                    detailService.RemovePriceChangeDetail(selectedID);
                }
                else
                {
                    MessageBox.Show("Please select a product to remove.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }//dialog result yes
            loadPriceChangeDetails();
        }//remove product from price change
      
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            InventoryService inventoryService = new InventoryService();
            DialogResult result = MessageBox.Show("Are you sure you want to submit the price change? Once submitted, it cannot be edited.", "Confirm Submission", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(result == DialogResult.Yes)
            {
                /*
                 * iterate through details
                 * update inventory
                 * insert to inventory
                 * update price change header
                 */
                PriceChangeDetailService detailService = new PriceChangeDetailService();
                DataTable detailsData = detailService.GetPriceChangeDetailByHeaderID(headerID);
                int userID = Session.UserID;

                foreach (DataRow row in detailsData.Rows)
                {
                    int inventoryID = Convert.ToInt32(row["inventory_id"]);
                    decimal qty = Convert.ToDecimal(row["qty"]);

                    //fetch inventory data for new record
                    DataTable inventoryData = inventoryService.GetInventoryByID(inventoryID);
                    int grnHeaderID = Convert.ToInt32(inventoryData.Rows[0]["grn_header_id"]);
                    DateTime expiryDate = Convert.ToDateTime(inventoryData.Rows[0]["expiry_date"]);

                    //update inventory qty
                    inventoryService.UpdateInventoryQty(inventoryID, qty);

                    //insert new inventory record with new price
                    int productID = Convert.ToInt32(row["product_id"]);
                    decimal sellingPrice = Convert.ToDecimal(row["selling_price"]);
                    decimal discount = Convert.ToDecimal(row["discount"]);
                    decimal newPrice = Convert.ToDecimal(row["new_price"]);

                    inventoryService.InsertInventory(grnHeaderID, productID, qty, qty, 0, sellingPrice, discount, newPrice, 0, expiryDate, 1);

                }//foreach

                int rowCount = detailsData.Rows.Count;
                decimal totalPrice = Convert.ToDecimal(detailsData.Compute("SUM(total_price)", string.Empty));

                //update price change header
                PriceChangeHeaderService headerService = new PriceChangeHeaderService();
                headerService.UpdatePriceChangeTotals(headerID, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), rowCount, totalPrice, userID, 1);

                //load header control
                PriceChangeHeaderControl headerControl = new PriceChangeHeaderControl();
                Main mainForm = (Main)Application.OpenForms["Main"];
                mainForm.loadControl(headerControl);

            }//dialog result yes
        }//submit

        private void loadPriceChangeDetails()
        {
            PriceChangeDetailService detailService = new PriceChangeDetailService();
            DataTable detailsData = detailService.GetPriceChangeDetailByHeaderID(headerID);

            dgvChangeDetail.DataSource = detailsData;

            dgvChangeDetail.Columns["price_change_header_id"].Visible = false;
            dgvChangeDetail.Columns["inventory_id"].Visible = false;
            dgvChangeDetail.Columns["product_id"].Visible = false;
            dgvChangeDetail.Columns["status"].Visible = false;

            dgvChangeDetail.Columns["id"].HeaderText = "ID";
            dgvChangeDetail.Columns["name"].HeaderText = "Product";
            dgvChangeDetail.Columns["barcode"].HeaderText = "Barcode";
            dgvChangeDetail.Columns["qty"].HeaderText = "Qty";
            dgvChangeDetail.Columns["selling_price"].HeaderText = "Selling Price";
            dgvChangeDetail.Columns["discount"].HeaderText = "Discount";
            dgvChangeDetail.Columns["old_price"].HeaderText = "Old Price";
            dgvChangeDetail.Columns["new_price"].HeaderText = "New Price";
            dgvChangeDetail.Columns["total_price"].HeaderText = "Total Price";

            //get totals
            DataTable totals = detailService.GetPriceChangeTotalsByHeaderID(headerID);

            lblRowCount.Text = "Rows: " + totals.Rows[0]["row_count"].ToString();
            lblTotal.Text = "Total: " + totals.Rows[0]["total_price"].ToString();

            this.selectedID = 0;
            btnRemove.Enabled = false;
        }

        
    }//class
}
