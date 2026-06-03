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
        private int headerID = 0;
        public SaleReturnDetailControl(int headerId)
        {
            InitializeComponent();
            this.headerID = headerId;
        }

        private void SaleReturnDetailControl_Load(object sender, EventArgs e)
        {
            btnAddReturn.Enabled = false;

            loadInvoiceDetail();

            loadReturnDetail();
        }

        private void dgvInvoiceDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            { 
                DataGridViewRow row = dgvInvoiceDetail.Rows[e.RowIndex];
                selectedInvoiceID = Convert.ToInt32(row.Cells["invoice_id"].Value);
                btnAddReturn.Enabled = true;
            }
        }//cell click
        private void btnAddReturn_Click(object sender, EventArgs e)
        {
            InvoiceDetailService detailService = new InvoiceDetailService();
            SaleReturnDetailService returnDetailService = new SaleReturnDetailService();
            if (selectedInvoiceID > 0)
            {
                DataTable detailData = detailService.GetInvoiceDetailByID(selectedInvoiceID);

                int inventoryID = Convert.ToInt32(detailData.Rows[0]["inventory_id"]);
                int productID = Convert.ToInt32(detailData.Rows[0]["product_id"]);
                decimal unitPrice = Convert.ToDecimal(detailData.Rows[0]["unit_price"]);
                decimal qty = Convert.ToDecimal(detailData.Rows[0]["qty"]);
                decimal sellingPrice = Convert.ToDecimal(detailData.Rows[0]["selling_price"]);
                decimal discount = Convert.ToDecimal(detailData.Rows[0]["discount"]);
                decimal finalPrice = Convert.ToDecimal(detailData.Rows[0]["final_price"]);

                //returnDetailService.InsertSaleReturnDetail(this.headerID, inventoryID, productID, unitPrice, (int)qty, sellingPrice, discount, finalPrice, 1);

                loadReturnDetail();
            }
        }//add to return details

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

        private void loadReturnDetail()
        {
            SaleReturnDetailService detailService = new SaleReturnDetailService();
            DataTable returnData = detailService.GetReturnDetailByHeaderID(this.headerID);

            dgvReturnDetail.DataSource = returnData;
        }//load return detail
    }//class
}
