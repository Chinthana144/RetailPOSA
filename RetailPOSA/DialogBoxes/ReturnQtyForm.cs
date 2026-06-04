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
    public partial class ReturnQtyForm : Form
    {
        private int returnHeaderID = 0;
        private int invoiceID = 0;
        private decimal maxQty = 0;
        private decimal returnUnitPrice = 0;
        public ReturnQtyForm(int returnHeaderID, int invoiceID)
        {
            InitializeComponent();
            this.returnHeaderID = returnHeaderID;
            this.invoiceID = invoiceID;
        }

        private void ReturnQtyForm_Load(object sender, EventArgs e)
        {
            loadInvoiceData();
        }
        private void txtReturnQty_KeyUp(object sender, KeyEventArgs e)
        {
            if (decimal.TryParse(txtReturnQty.Text, out decimal returnQty))
            {
                if(returnQty > maxQty)
                {
                    MessageBox.Show("Return quantity cannot exceed the maximum quantity.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtReturnQty.Text = maxQty.ToString();
                    txtReturnQty.Focus();
                    return;
                }
                decimal totalReturnPrice = returnUnitPrice * returnQty;

                lblFinalPrice.Text = "Final Price: " + totalReturnPrice.ToString();
            }
            else 
            { 
                MessageBox.Show("Please enter a valid quantity.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtReturnQty.Clear();
                txtReturnQty.Focus();
                return;
            }
        }
        private void btnAddReturn_Click(object sender, EventArgs e)
        {
            SaleReturnDetailService returnDetailService = new SaleReturnDetailService();
            InvoiceDetailService detailService = new InvoiceDetailService();
            DataTable detailData = detailService.GetInvoiceDetailByID(invoiceID);

            int inventoryID = Convert.ToInt32(detailData.Rows[0]["inventory_id"]);
            int productID = Convert.ToInt32(detailData.Rows[0]["product_id"]);
            string barcode = detailData.Rows[0]["barcode"].ToString();
            string productName = detailData.Rows[0]["name"].ToString();
            decimal unitPrice = Convert.ToDecimal(detailData.Rows[0]["unit_price"]);
            maxQty = Convert.ToDecimal(detailData.Rows[0]["qty"]);
            decimal sellingPrice = Convert.ToDecimal(detailData.Rows[0]["selling_price"]);
            decimal discount = Convert.ToDecimal(detailData.Rows[0]["discount"]);
            decimal finalPrice = Convert.ToDecimal(detailData.Rows[0]["final_price"]);

            decimal totalReturnPrice = returnUnitPrice * Convert.ToDecimal(txtReturnQty.Text);

            //check duplicates
            bool has_row = returnDetailService.CheckDublicateID(returnHeaderID, invoiceID);
            if (has_row)
            {
                MessageBox.Show("This item has been already added.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            returnDetailService.InsertSaleReturnDetail(returnHeaderID, inventoryID, invoiceID, productID, returnUnitPrice, Convert.ToDecimal(txtReturnQty.Text), totalReturnPrice, 0, totalReturnPrice, 1);

            this.Close();
        }
        private void loadInvoiceData()
        {
            InvoiceDetailService detailService = new InvoiceDetailService();
            DataTable detailData = detailService.GetInvoiceDetailByID(invoiceID);

            int inventoryID = Convert.ToInt32(detailData.Rows[0]["inventory_id"]);
            int productID = Convert.ToInt32(detailData.Rows[0]["product_id"]);
            string barcode = detailData.Rows[0]["barcode"].ToString();
            string productName = detailData.Rows[0]["name"].ToString();
            decimal unitPrice = Convert.ToDecimal(detailData.Rows[0]["unit_price"]);
            maxQty = Convert.ToDecimal(detailData.Rows[0]["qty"]);
            decimal sellingPrice = Convert.ToDecimal(detailData.Rows[0]["selling_price"]);
            decimal discount = Convert.ToDecimal(detailData.Rows[0]["discount"]);
            decimal finalPrice = Convert.ToDecimal(detailData.Rows[0]["final_price"]);

            //get unit price
            returnUnitPrice = finalPrice / maxQty;

            lblBarcode.Text = "Barcode: " + barcode;
            lblProduct.Text = "Product: " + productName;
            lblUnitPrice.Text = "Unit Price: " + returnUnitPrice.ToString();
            lblQty.Text = "Quantity: " + maxQty.ToString();
            lblFinalPrice.Text = "Final Price: " + finalPrice.ToString();

            txtReturnQty.Text = maxQty.ToString();
        }//load invoice data
    }//class
}
