using RetailPOSA.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RetailPOSA.DialogBoxes
{
    public partial class ShopForm : Form
    {
        private string shopLogoPath = "";
        private string receiptLogoPath = "";
        private int shopID = 0;
        public ShopForm(int shipID)
        {
            InitializeComponent();
            this.shopID = shipID;
        }

        private void ShopForm_Load(object sender, EventArgs e)
        {
            ThemeManager.ApplyTheme(this);
            loadShopData();
        }

        private void btnShop_Click(object sender, EventArgs e)
        {
            ShopService shopService = new ShopService();
            //check inputs
            if (txtShopName.Text == "")
            {
                MessageBox.Show("Please add shop Name.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtShopName.Focus();
                return;
            }
            if (txtAddress.Text == "")
            {
                MessageBox.Show("Please add shop Address.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
                return;
            }
            if (txtContact.Text == "")
            {
                MessageBox.Show("Please add shop Contact No.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContact.Focus();
                return;
            }
            if (txtInvoicePrefix.Text == "")
            {
                MessageBox.Show("Please add Invoice prefix text.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtInvoicePrefix.Focus();
                return;
            }
            if (txtCurrency.Text == "")
            {
                MessageBox.Show("Please add shop Currency.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCurrency.Focus();
                return;
            }

            string shopName = txtShopName.Text.Replace(" ", "_");
            string logoExt = Path.GetExtension(this.shopLogoPath);
            string receiptExt = Path.GetExtension(this.receiptLogoPath);
            string shopFileName = shopName + logoExt;
            string receiptFileName = "receipt_" + shopName + receiptExt;

            //image path
            string shopLogoPath = Path.Combine(Application.StartupPath, "Logos", shopFileName);
            string receiptLogoPath = Path.Combine(Application.StartupPath, "Logos", receiptFileName);

            picShopLogo.Image.Dispose();
            picShopLogo.Image = null;

            picReceiptLogo.Image.Dispose();
            picReceiptLogo.Image = null;

            if (this.shopLogoPath != shopLogoPath)
            {
                File.Copy(this.shopLogoPath, shopLogoPath);
            }
            if (this.receiptLogoPath != receiptLogoPath)
            {
                File.Copy(this.receiptLogoPath, receiptLogoPath);
            }
            
            if (shopID > 0)
            {
                int shopStatus = chkStatus.Checked ? 1 : 0;
                shopService.UpdateShop(shopID, txtShopName.Text, txtAddress.Text, txtContact.Text, shopLogoPath, receiptLogoPath, txtInvoicePrefix.Text, txtCurrency.Text, shopStatus);
            }//update
            else
            { 
                int shopStatus = chkStatus.Checked ? 1 : 0;
                shopService.InsertShop(txtShopName.Text, txtAddress.Text, txtContact.Text, shopLogoPath, receiptLogoPath, txtInvoicePrefix.Text, txtCurrency.Text, shopStatus);
            }//insert

            this.Close();
        }

        private void btnUploadShopLogo_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    //picShopLogo.Image = Image.FromFile(dialog.FileName);
                    picShopLogo.Image = Image.FromFile(dialog.FileName);
                    this.shopLogoPath = dialog.FileName;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error Occured!", "Error");
            }
        }

        private void btnUploadReceiptLogo_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    picReceiptLogo.Image = Image.FromFile(dialog.FileName);
                    this.receiptLogoPath = dialog.FileName;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error Occured!", "Error");
            }
        }

        private void loadShopData()
        {
            if (shopID > 0)
            { 
                ShopService shopService = new ShopService();

                DataTable shopData = shopService.GetShopByID(shopID);

                txtShopName.Text = shopData.Rows[0]["name"].ToString();
                txtAddress.Text = shopData.Rows[0]["address"].ToString();
                txtContact.Text = shopData.Rows[0]["phone"].ToString();
                txtInvoicePrefix.Text = shopData.Rows[0]["invoice_prefix"].ToString();
                txtCurrency.Text = shopData.Rows[0]["currency"].ToString();

                int status = Convert.ToInt32(shopData.Rows[0]["status"]);
                chkStatus.Checked = status == 1 ? true : false;

                string shopPath = shopData.Rows[0]["shop_logo"].ToString();
                string receiptPath = shopData.Rows[0]["receipt_logo"].ToString();
                if (shopPath != "")
                {
                    picShopLogo.Image = Image.FromFile(shopData.Rows[0]["shop_logo"].ToString());
                }
                if (receiptPath != "")
                {
                    picReceiptLogo.Image = Image.FromFile(shopData.Rows[0]["receipt_logo"].ToString());
                }
                this.shopLogoPath = shopData.Rows[0]["shop_logo"].ToString();
                this.receiptLogoPath = shopData.Rows[0]["receipt_logo"].ToString();
            }
        }//load shop data
    }//class
}
