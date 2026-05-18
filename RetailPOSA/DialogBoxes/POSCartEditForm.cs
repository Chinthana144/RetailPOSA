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
    public partial class POSCartEditForm : Form
    {
        int cartHeaderID = 0;
        int cartDetailID = 0;
        int inventoryID = 0;
        int productID = 0;
        decimal unitPrice = 0;
        decimal qty = 0;
        decimal totalPrice = 0;
        decimal discount = 0;
        decimal finalPrice = 0;

        public POSCartEditForm(int cartHeaderID, int cartDetailID, int inventoryID, int productID, decimal unitPrice, decimal qty, decimal totalPrice, decimal discount, decimal finalPrice)
        {
            InitializeComponent();

            this.cartHeaderID = cartHeaderID;
            this.cartDetailID = cartDetailID;
            this.inventoryID = inventoryID;
            this.productID = productID;
            this.unitPrice = unitPrice;
            this.qty = qty;
            this.totalPrice = totalPrice;
            this.discount = discount;
            this.finalPrice = finalPrice;
        }
        private void POSCartEditForm_Load(object sender, EventArgs e)
        {
            txtQty.Text = this.qty.ToString();
            txtQty.Focus();
            txtQty.Select();

            btnAddQty.Text = cartDetailID > 0 ? "Update Qty" : "Add Product";
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtQty.Text ?? "0", out decimal result))
            {
                this.totalPrice = Math.Round(result * this.unitPrice, 2);
                
                lblUnitPrice.Text = this.unitPrice.ToString();
                lblTotalPrice.Text = this.totalPrice.ToString();
            }
        }

        private void btnAddQty_Click(object sender, EventArgs e)
        {
            CartDetailService cartDetailService = new CartDetailService();
            decimal qty = Convert.ToDecimal(txtQty.Text ?? "0");
            this.discount = this.discount * qty;
            this.finalPrice = totalPrice - this.discount;
            if (cartDetailID > 0)
            {
                //update
                cartDetailService.UpdateCartDetailQty(this.cartDetailID, qty, this.totalPrice, this.discount, this.finalPrice);
            }
            else
            {
                //add
                cartDetailService.AddToCart(cartHeaderID, inventoryID, productID, unitPrice, qty, totalPrice, this.discount, this.finalPrice);
            }

            this.Close();
        }//add or update

        //============================ Number Pad ============================//
        private void showNumber(TextBox txtBox, string num)
        {
            if (txtBox.SelectionLength > 0)
            {
                txtBox.Clear();
            }
            string currentText = txtBox.Text;
            string newText = currentText + num;

            if (decimal.TryParse(newText, out decimal result))
            {
                txtBox.Text = newText;
            }
            else {
                MessageBox.Show("Enter velid number.", "Error Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//show number

        private void btnNum1_Click(object sender, EventArgs e)
        {
            showNumber(txtQty, "1");
        }

        private void btnNum2_Click(object sender, EventArgs e)
        {
            showNumber(txtQty, "2");
        }

        private void btnNum3_Click(object sender, EventArgs e)
        {
            showNumber(txtQty, "3");
        }

        private void btnNum4_Click(object sender, EventArgs e)
        {
            showNumber(txtQty, "4");
        }

        private void btnNum5_Click(object sender, EventArgs e)
        {
            showNumber(txtQty, "5");
        }

        private void btnNum6_Click(object sender, EventArgs e)
        {
            showNumber(txtQty, "6");
        }

        private void btnNum7_Click(object sender, EventArgs e)
        {
            showNumber(txtQty, "7");
        }

        private void btnNum8_Click(object sender, EventArgs e)
        {
            showNumber(txtQty, "8");
        }

        private void btnNum9_Click(object sender, EventArgs e)
        {
            showNumber(txtQty, "9");
        }

        private void btnNum0_Click(object sender, EventArgs e)
        {
            showNumber(txtQty, "0");
        }

        private void btnNumDot_Click(object sender, EventArgs e)
        {
            showNumber(txtQty, ".");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtQty.Clear();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            string text = txtQty.Text;
            int strLenght = text.Length;

            if (strLenght > 0)
            {
                string newText = text.Substring(0, strLenght - 1);
                txtQty.Text = newText;
            }
        }

    }//class
}
