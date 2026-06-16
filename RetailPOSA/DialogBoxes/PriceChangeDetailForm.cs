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
    public partial class PriceChangeDetailForm : Form
    {
        private int headerID = 0;
        private int inventoryID = 0;
        private int productID = 0;
        public PriceChangeDetailForm(int headerID, int inventoryID)
        {
            InitializeComponent();
            this.headerID = headerID;
            this.inventoryID = inventoryID;
        }

        private void PriceChangeDetailForm_Load(object sender, EventArgs e)
        {
            ThemeManager.ApplyTheme(this);
            loadData();
        }//load form

        private void loadData()
        {
            InventoryService inventoryService = new InventoryService();
            DataTable inventoryData = inventoryService.GetInventoryByID(inventoryID);

            this.productID = int.Parse(inventoryData.Rows[0]["product_id"].ToString());

            lblBarcode.Text = "Barcode: " + inventoryData.Rows[0]["Barcode"].ToString();
            lblProduct.Text = "Product: " + inventoryData.Rows[0]["name"].ToString();

            txtQty.Text = inventoryData.Rows[0]["current_qty"].ToString();
            txtSellingPrice.Text = inventoryData.Rows[0]["selling_price"].ToString();
            txtDiscount.Text = inventoryData.Rows[0]["discount"].ToString();
            txtOldPrice.Text = inventoryData.Rows[0]["final_price"].ToString();
        }//load data

        private bool validateNumber(string input)
        { 
            if(decimal.TryParse(input, out decimal result))
            {
                // Input is a valid decimal
                return true;
            }
            else
            {
                // Input is not a valid decimal
                return false;
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (!validateNumber(txtQty.Text))
            { 
                MessageBox.Show("Please enter a valid number for quantity.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(!validateNumber(txtSellingPrice.Text))
            {
                MessageBox.Show("Please enter a valid number for selling price.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(!validateNumber(txtDiscount.Text))
            {
                MessageBox.Show("Please enter a valid number for discount.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(!validateNumber(txtOldPrice.Text))
            {
                MessageBox.Show("Please enter a valid number for old price.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(!validateNumber(txtNewPrice.Text) || txtNewPrice.Text == "")
            {
                MessageBox.Show("Please enter a valid number for new price.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PriceChangeDetailService detailService = new PriceChangeDetailService();

            //check duplicate inventory
            if (detailService.CheckDuplicateInventory(headerID, inventoryID))
            {
                MessageBox.Show("This product is already added to the list.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //get total price
            decimal totalPrice = decimal.Parse(txtNewPrice.Text) * decimal.Parse(txtQty.Text);

            detailService.InsertPriceChangeDetail(
                headerID, inventoryID, productID, 
                decimal.Parse(txtQty.Text), 
                decimal.Parse(txtOldPrice.Text), 
                decimal.Parse(txtSellingPrice.Text), 
                decimal.Parse(txtDiscount.Text), 
                decimal.Parse(txtNewPrice.Text), 
                Math.Round(totalPrice, 2),
                1);

            this.Close();
        }

        private void txtNewPrice_KeyUp(object sender, KeyEventArgs e)
        {
            if (decimal.TryParse(txtNewPrice.Text, out decimal newPrice))
            {
                // Update total price based on new price
                if (decimal.TryParse(txtQty.Text, out decimal qty))
                {
                    decimal totalPrice = newPrice * qty;
                    lblTotal.Text = "Total: " + Math.Round(totalPrice, 2).ToString();
                }
            }
            else
            { 
                txtNewPrice.Text = "";
            }//invelid entry
        }
    }//class
}
