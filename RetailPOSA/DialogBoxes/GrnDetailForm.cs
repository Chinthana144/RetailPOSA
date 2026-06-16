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
    public partial class GrnDetailForm : Form
    {
        private int productID = 0;
        private int grnID = 0;
        private bool isExpiry = false;
        public GrnDetailForm(int id, int grnID)
        {
            InitializeComponent();
            productID = id;
            this.grnID = grnID;
        }

        private void GrnDetailForm_Load(object sender, EventArgs e)
        {
            ThemeManager.ApplyTheme(this);
            loadProductDetails();

            //expiry
            dtpExpiry.Enabled = isExpiry;

            txtFreeQty.Text = "0";
        }

        private void loadProductDetails()
        {
            ProductService productService = new ProductService();

            DataTable dt = productService.GetProductByID(productID);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                lblProductName.Text = row["product"].ToString();
                lblBarcode.Text = row["barcode"].ToString();
                isExpiry = Convert.ToBoolean(row["has_expiry"]);
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            //validate inputs
            if (!IsValidDecimal(txtQty.Text))
            { 
                MessageBox.Show("Please enter a valid quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsValidDecimal(txtFreeQty.Text))
            {
                MessageBox.Show("Please enter a valid quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsValidDecimal(txtPurchasePrice.Text))
            {
                MessageBox.Show("Please enter a valid Purchase Price.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsValidDecimal(txtSellingPrice.Text))
            {
                MessageBox.Show("Please enter a valid selling price.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsValidDecimal(txtDiscount.Text))
            {
                MessageBox.Show("Please enter a valid discount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsValidDecimal(txtFinalPrice.Text))
            {
                MessageBox.Show("Please enter a valid final price.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime today = DateTime.Now;
            DateTime expiryDate = dtpExpiry.Value;

            if(isExpiry && expiryDate <= today)
            {
                MessageBox.Show("Please enter a valid expiry date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            GrnDetailService grnDetailService = new GrnDetailService();

            decimal qty = Convert.ToDecimal(txtQty.Text);
            decimal freeQty = Convert.ToDecimal(txtFreeQty.Text);
            decimal purchasePrice = Convert.ToDecimal(txtPurchasePrice.Text);
            decimal sellingPrice = Convert.ToDecimal(txtSellingPrice.Text);
            decimal discount = Convert.ToDecimal(txtDiscount.Text);
            decimal finalPrice = Convert.ToDecimal(txtFinalPrice.Text);

            decimal purchaseTotal = (qty) * purchasePrice;

            int result = grnDetailService.InsertGrnDetail(grnID, productID, qty, freeQty, purchasePrice, sellingPrice, discount, finalPrice, isExpiry ? dtpExpiry.Value.ToString("yyyy-MM-dd") : null, purchaseTotal, 1);

            if (result == 0)
            { 
                MessageBox.Show("Failed to add product to the GRN details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Close();
        }//add product to the grn detail list

        public bool IsValidDecimal(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;

            return decimal.TryParse(value, out _);
        }
    }//class
}//namespace
