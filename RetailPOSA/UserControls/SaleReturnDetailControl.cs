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
    public partial class SaleReturnDetailControl : UserControl
    {
        private int selectedInvoiceID = 0;
        private int selectedReturnID = 0;
        private int headerID = 0;
        public SaleReturnDetailControl(int headerId)
        {
            InitializeComponent();
            this.headerID = headerId;
        }

        private void SaleReturnDetailControl_Load(object sender, EventArgs e)
        {
            ThemeManager.ApplyTheme(this);
            loadInvoiceDetail();

            loadReturnDetail();

            btnRemoveReturnItem.Enabled = false;
            btnSubmitReturn.Enabled = false;
        }

        private void dgvInvoiceDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            { 
                DataGridViewRow row = dgvInvoiceDetail.Rows[e.RowIndex];
                selectedInvoiceID = Convert.ToInt32(row.Cells["id"].Value);

                ReturnQtyForm returnQtyForm = new ReturnQtyForm(headerID, selectedInvoiceID);
                returnQtyForm.ShowDialog();

                loadReturnDetail();
            }
        }//cell click
        
        private void loadInvoiceDetail()
        {
            InvoiceService invoiceService = new InvoiceService();

            DataTable invoiceData = invoiceService.GetInvoiceDetailByHeaderID(this.headerID);

            dgvInvoiceDetail.DataSource = invoiceData;

            dgvInvoiceDetail.Columns["invoice_id"].Visible = false;
            dgvInvoiceDetail.Columns["inventory_id"].Visible = false;
            dgvInvoiceDetail.Columns["product_id"].Visible = false;
            dgvInvoiceDetail.Columns["category_id"].Visible = false;
            dgvInvoiceDetail.Columns["second_name"].Visible = false;
            dgvInvoiceDetail.Columns["status"].Visible = false;

            dgvInvoiceDetail.Columns["id"].HeaderText = "ID";
            dgvInvoiceDetail.Columns["barcode"].HeaderText = "Barcode";
            dgvInvoiceDetail.Columns["name"].HeaderText = "Product";
            dgvInvoiceDetail.Columns["unit_price"].HeaderText = "Unit Price";
            dgvInvoiceDetail.Columns["qty"].HeaderText = "Qty";
            dgvInvoiceDetail.Columns["selling_price"].HeaderText = "Price";
            dgvInvoiceDetail.Columns["discount"].HeaderText = "discount";
            dgvInvoiceDetail.Columns["final_price"].HeaderText = "Sold Price";
        }//load invoice

        private void dgvReturnDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            { 
                DataGridViewRow row = dgvReturnDetail.Rows[e.RowIndex];
                selectedReturnID = Convert.ToInt32(row.Cells["id"].Value);
                btnRemoveReturnItem.Enabled = true;
                btnSubmitReturn.Enabled = true;
            }
        }//cell click
        private void btnRemoveReturnItem_Click(object sender, EventArgs e)
        {
            if (selectedReturnID > 0)
            { 
                SaleReturnDetailService returnDetailService = new SaleReturnDetailService();
                returnDetailService.RemoveReturnDetail(selectedReturnID);

                loadReturnDetail();
            }
        }//remove

        private void btnSubmitReturn_Click(object sender, EventArgs e)
        {
            InventoryService inventoryService = new InventoryService();
            SaleReturnHeaderService returnHeaderService = new SaleReturnHeaderService();
            SaleReturnDetailService returnDetailService = new SaleReturnDetailService();
            DataTable returnData = returnDetailService.GetReturnDetailByHeaderID(headerID);

            DataTable headerData = returnHeaderService.GetSaleReturnHeaderByID(headerID);
            string returnType = headerData.Rows[0]["return_type"].ToString();

            DataTable totalData = returnDetailService.GetTotalByHeaderID(headerID);
            int itemCount = Convert.ToInt32(totalData.Rows[0]["row_count"]);
            decimal total = Convert.ToDecimal(totalData.Rows[0]["total"]);

            if (returnType == "Return to Stock")
            {
                //update inventory
                foreach (DataRow row in returnData.Rows)
                {
                    int inventoryID = Convert.ToInt32(row["inventory_id"]);
                    //multiply by -1 to add to inventory.
                    decimal qty = Convert.ToDecimal(row["qty"]) * -1;

                    inventoryService.UpdateInventoryQty(inventoryID, qty);

                }//foreach
            }//return to stock

            int userID = Session.UserID;
            string submittedDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            returnHeaderService.UpdateSaleReturnHeaderTotals(headerID, submittedDate, itemCount, total, userID, 1);

            //load POS control
            POSControl posControl = new POSControl(headerID);

            Main mainForm = (Main)Application.OpenForms["Main"];
            mainForm.loadControl(posControl);
        }

        private void loadReturnDetail()
        {
            SaleReturnDetailService detailService = new SaleReturnDetailService();
            DataTable returnData = detailService.GetReturnDetailByHeaderID(this.headerID);

            dgvReturnDetail.DataSource = returnData;

            dgvReturnDetail.Columns["sale_return_header_id"].Visible = false;
            dgvReturnDetail.Columns["inventory_id"].Visible = false;
            dgvReturnDetail.Columns["invoice_detail_id"].Visible = false;
            dgvReturnDetail.Columns["product_id"].Visible = false;
            dgvReturnDetail.Columns["status"].Visible = false;

            dgvReturnDetail.Columns["id"].HeaderText = "ID";
            dgvReturnDetail.Columns["barcode"].HeaderText = "Barcode";
            dgvReturnDetail.Columns["name"].HeaderText = "Name";
            dgvReturnDetail.Columns["unit_price"].HeaderText = "Unit Price";
            dgvReturnDetail.Columns["qty"].HeaderText = "Qty";
            dgvReturnDetail.Columns["selling_price"].HeaderText = "Sell Price";
            dgvReturnDetail.Columns["discount"].HeaderText = "Disc.";
            dgvReturnDetail.Columns["final_price"].HeaderText = "Total";

            //get totals
            DataTable totalData = detailService.GetTotalByHeaderID(this.headerID);

            lblRowCount.Text = "Rows: " + totalData.Rows.Count.ToString();
            lblReturnTotal.Text = "Total: " + totalData.Rows[0]["total"].ToString();

            btnRemoveReturnItem.Enabled = false;
            btnSubmitReturn.Enabled = false;
        }//load return detail


    }//class
}
