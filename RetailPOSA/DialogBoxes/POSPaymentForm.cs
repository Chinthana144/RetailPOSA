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

        

        private void PaymentButton_Click(object sender, EventArgs e)
        { 
            Button btn = (Button)sender;

            int paymethodID = Convert.ToInt32(btn.Tag);

            string paymentMethod = btn.Text;

            MessageBox.Show("Selected: " + paymentMethod);
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
                //calculate balance
            }
            else
            {
                MessageBox.Show("Please enter valid amount.", "Error Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPayment.Clear();
            }
        }
    }
}
