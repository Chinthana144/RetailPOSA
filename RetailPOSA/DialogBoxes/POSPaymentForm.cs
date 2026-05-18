using RetailPOSA.Models;
using RetailPOSA.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RetailPOSA.DialogBoxes
{
    public partial class POSPaymentForm : Form
    {
        private int cartHeaderID = 0;
        private decimal subTotal = 0;
        public POSPaymentForm(int cartHeaderID)
        {
            InitializeComponent();

            this.cartHeaderID = cartHeaderID;

            GetCartTotals();
        }

        private void POSPaymentForm_Load(object sender, EventArgs e)
        {
            loadPaymethods();
        }

        private void GetCartTotals()
        {
            CartDetailService cartDetailService = new CartDetailService();

            DataTable dt = cartDetailService.GetCartTotals(cartHeaderID);

            subTotal = Convert.ToDecimal(dt.Rows[0]["final_total"]);

            lblItemCount.Text = "Items: " + dt.Rows[0]["row_count"].ToString();
            lblSellingPrice.Text = "Total: " + dt.Rows[0]["total_price"].ToString();
            lblDiscount.Text = "Discount: " + dt.Rows[0]["total_discount"].ToString();
            lblSubTotal.Text = "Sub Total: " + subTotal.ToString();

            txtPayment.Text = subTotal.ToString();
            txtPayment.Focus();
            txtPayment.Select();
        }

        private void loadPaymethods()
        { 
            InvoiceService invoiceService = new InvoiceService();

            DataTable dt = invoiceService.GetPaymethods();

            foreach (DataRow row in dt.Rows)
            {
                Button btn = new Button();

                btn.Text = row["paymethod"].ToString();
                btn.Width = 80;
                btn.Height = 50;

                btn.Tag = row["id"];

                btn.Click += PaymentButton_Click;

                pnlPaymethods.Controls.Add(btn);
            }
        }

        private void submitPayment(int cartHeaderID, int paymethodID)
        {
            /*
             * create invoice
             * get cart details by cart header ID
             * iterate through cart
             * add invoice details
             * upcate invoice header
             * clear cart details
             * clear cart header
             */

            int userID = Session.UserID;

            InvoiceService invoiceService = new InvoiceService();
            CartHeaderService cartHeaderService = new CartHeaderService();
            CartDetailService cartDetailService = new CartDetailService();

            string issuedDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            decimal paidAmount = Convert.ToDecimal(txtPayment.Text);

            invoiceService.InsertInvoiceHeader(issuedDate, 0,0,0,0,0,0,0,userID,1);

            int newInvoiceID = invoiceService.GetActiveInvoicebyUserID(userID);

            //get cart detail by header id
            DataTable cart = cartDetailService.GetCartByHeaderID(cartHeaderID);

            int rowCount = 0;
            decimal total = 0;
            decimal totalDiscount = 0;
            decimal subTotal = 0;

            foreach (DataRow row in cart.Rows)
            {
                //iterate here
                int inventoryID = Convert.ToInt32(row["inventory_id"]);
                int productID = Convert.ToInt32(row["product_id"]);
                decimal unitPrice = Convert.ToDecimal(row["unit_price"]);
                decimal qty = Convert.ToDecimal(row["qty"]);
                decimal totalPrice = Convert.ToDecimal(row["total_price"]);
                decimal discount = Convert.ToDecimal(row["discount"]);
                decimal finalPrice = Convert.ToDecimal(row["final_price"]);

                //create invoice detail
                invoiceService.InsertInvoiceDetail(newInvoiceID, inventoryID, productID, unitPrice, qty, totalPrice, discount, finalPrice, 1);

                rowCount++;
                total += Convert.ToDecimal(totalPrice);
                totalDiscount += Convert.ToDecimal(discount);
                subTotal += Convert.ToDecimal(finalPrice);

            }

            decimal balance = paidAmount - subTotal;
            //update invoice header
            invoiceService.UpdateInvoiceHeader(newInvoiceID, rowCount, total, totalDiscount, subTotal, paymethodID, paidAmount, balance, 2);

            //clear cart detail
            cartDetailService.ClearCart(cartHeaderID);

            //delete cart header
            cartHeaderService.DeleteCartHeader(cartHeaderID);

            this.Close();

        }//submit payment

        private void PaymentButton_Click(object sender, EventArgs e)
        { 
            Button btn = (Button)sender;

            int paymethodID = Convert.ToInt32(btn.Tag);

            string paymentMethod = btn.Text;

            //MessageBox.Show("Selected: " + paymentMethod);

            submitPayment(cartHeaderID, paymethodID);

        }//payment button click

        //========================= Number Pad ==========================//
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
            else
            {
                MessageBox.Show("Enter velid number.", "Error Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//show number

        private void btnNum1_Click(object sender, EventArgs e)
        {
            showNumber(txtPayment, "1");
        }

        private void btnNum2_Click(object sender, EventArgs e)
        {
            showNumber(txtPayment, "2");
        }

        private void btnNum3_Click(object sender, EventArgs e)
        {
            showNumber(txtPayment, "3");
        }

        private void btnNum4_Click(object sender, EventArgs e)
        {
            showNumber(txtPayment, "4");
        }

        private void btnNum5_Click(object sender, EventArgs e)
        {
            showNumber(txtPayment, "5");
        }

        private void btnNum6_Click(object sender, EventArgs e)
        {
            showNumber(txtPayment, "6");
        }

        private void btnNum7_Click(object sender, EventArgs e)
        {
            showNumber(txtPayment, "7");
        }

        private void btnNum8_Click(object sender, EventArgs e)
        {
            showNumber(txtPayment, "8");
        }

        private void btnNum9_Click(object sender, EventArgs e)
        {
            showNumber(txtPayment, "9");
        }

        private void btnNum0_Click(object sender, EventArgs e)
        {
            showNumber(txtPayment, "0");
        }

        private void btnNumDot_Click(object sender, EventArgs e)
        {
            showNumber(txtPayment, ".");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPayment.Clear();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            string text = txtPayment.Text;
            int strLenght = text.Length;

            if (strLenght > 0)
            {
                string newText = text.Substring(0, strLenght - 1);
                txtPayment.Text = newText;
            }
        }

        private void txtPayment_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtPayment.Text, out decimal result))
            {
                decimal balance = result - subTotal;
                if (balance > 0)
                {
                    lblBalance.Text = "Balance: " + Math.Round(balance, 2).ToString();
                }
                else 
                {
                    lblBalance.Text = "Balance: 0";
                }
            }//valid number
            else
            {
                if (txtPayment.TextLength > 0)
                {
                    MessageBox.Show("Please enter valid amount.", "Error Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPayment.Clear();
                }//has text
            }//invelid entry not a number
        }
    }
}
