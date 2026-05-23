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
    public partial class InventoryControl : UserControl
    {
        private int currentPage = 1;
        private int pageSize = 50;

        public InventoryControl()
        {
            InitializeComponent();
        }
        private void InventoryControl_Load(object sender, EventArgs e)
        {
            loadInventory();
        }

        private void loadInventory()
        { 
            InventoryService service = new InventoryService();

            DataTable inventoryData = service.GetInventory(pageSize, (currentPage - 1) * pageSize);

            dgvInventory.DataSource = inventoryData;

            dgvInventory.Columns["id"].Visible = false;
            dgvInventory.Columns["grn_header_id"].Visible = false;
            dgvInventory.Columns["product_id"].Visible = false;
            dgvInventory.Columns["second_name"].Visible = false;

            dgvInventory.Columns["barcode"].HeaderText = "Barcode";
            dgvInventory.Columns["name"].HeaderText = "Product Name";
            dgvInventory.Columns["second_name"].HeaderText = "Second Name";
            dgvInventory.Columns["initial_qty"].HeaderText = "Ini.Qty";
            dgvInventory.Columns["current_qty"].HeaderText = "Cur. Qty";
            dgvInventory.Columns["purchase_price"].HeaderText = "Pur.Price";
            dgvInventory.Columns["selling_price"].HeaderText = "Sell. Price";
            dgvInventory.Columns["discount"].HeaderText = "Discount";
            dgvInventory.Columns["final_price"].HeaderText = "Final Price";

            lblPageNo.Text = "Page No: " + currentPage.ToString();
        }//load inventory

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;

                loadInventory();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            currentPage++;

            loadInventory();
        }

        private void SearchInventory()
        { 
            InventoryService service = new InventoryService();

            DataTable inventoryData = service.SearchInventory(txtSearch.Text, pageSize, (currentPage - 1) * pageSize);
            dgvInventory.DataSource = inventoryData;

            dgvInventory.Columns["id"].Visible = false;
            dgvInventory.Columns["grn_header_id"].Visible = false;
            dgvInventory.Columns["product_id"].Visible = false;
            dgvInventory.Columns["second_name"].Visible = false;

            dgvInventory.Columns["barcode"].HeaderText = "Barcode";
            dgvInventory.Columns["name"].HeaderText = "Product Name";
            dgvInventory.Columns["second_name"].HeaderText = "Second Name";
            dgvInventory.Columns["initial_qty"].HeaderText = "Initial Qty";
            dgvInventory.Columns["current_qty"].HeaderText = "Current Qty";
            dgvInventory.Columns["purchase_price"].HeaderText = "Pur.Price";
            dgvInventory.Columns["selling_price"].HeaderText = "Sell. Price";
            dgvInventory.Columns["discount"].HeaderText = "Discount";
            dgvInventory.Columns["final_price"].HeaderText = "Final Price";
        }//search inventory

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            currentPage = 1;
            pageSize = 50;

            timerSearch.Stop();
            timerSearch.Start();
        }

        private void timerSearch_Tick(object sender, EventArgs e)
        {
            timerSearch.Stop();
            if (txtSearch.Text.Trim() != "")
            {
                SearchInventory();
            }
            else { 
                loadInventory();
            }
        }
    }//class
}
