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

namespace RetailPOSA.UserControls
{
    public partial class AdminControl : UserControl
    {
        private string shopLogoPath = "";
        private string receiptLogoPath = "";

        public AdminControl()
        {
            InitializeComponent();
        }

        private void AdminControl_Load(object sender, EventArgs e)
        {
            //create logo folder if not exist
            string logoFolder = Path.Combine(Application.StartupPath, "Logos");
            if (!Directory.Exists(logoFolder))
            {
                Directory.CreateDirectory(logoFolder);
            }

            //load shop
            loadShop();
        }//load

        private void btnUploadShopLogo_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    //picShopLogo.Image = Image.FromFile(dialog.FileName);
                    picShopLogo.Image = LoadImage(dialog.FileName);
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

        private void btnUpdateShop_Click(object sender, EventArgs e)
        {
            ShopService shopService = new ShopService();
            DataTable shopData = shopService.GetShop();

            if (shopData.Rows.Count == 0)
            {
                //insert shop
                string shopName = "My Shop";
                string address = "No123, somewhere.";
                string phone = "0712345678";
                string invoicePrefix = "INV";
                string currency = "LKR";
                shopService.InsertShop(shopName, address, phone, "", "", invoicePrefix, currency, 1);
            }
            else
            {
                //update shop
                int shopID = Convert.ToInt32(shopData.Rows[0]["id"]);
                
                string shopLogoPath = Path.Combine(Application.StartupPath, "Logos", "shop_logo.png");
                string receiptLogoPath = Path.Combine(Application.StartupPath, "Logos", "receipt_logo.png");

                shopService.UpdateShop(shopID, txtShopName.Text, txtAddress.Text, txtContact.Text, shopLogoPath, receiptLogoPath, txtInvoicePrefix.Text, txtCurrency.Text);

                if (this.shopLogoPath != shopLogoPath)
                {
                    picShopLogo.Image.Dispose();
                    picShopLogo.Image = null;
                    File.Copy(this.shopLogoPath, shopLogoPath);
                }
                if (this.receiptLogoPath != receiptLogoPath)
                {
                    picReceiptLogo.Image.Dispose();
                    picReceiptLogo.Image = null;
                    File.Copy(this.receiptLogoPath, receiptLogoPath, true);
                }

                MessageBox.Show("Shop updated successfully", "Shop Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                loadShop();
            }//update and copy
        }

        private void loadShop()
        {
            ShopService shopService = new ShopService();
            DataTable shopData = shopService.GetShop();
            if (shopData.Rows.Count == 0)
            {
                //insert shop
                string shopName = "My Shop";
                string address = "No123, somewhere.";
                string phone = "0712345678";
                string invoicePrefix = "INV";
                string currency = "LKR";
                shopService.InsertShop(shopName, address, phone, "", "", invoicePrefix, currency, 1);
            }//create shop
            else
            {
                txtShopName.Text = shopData.Rows[0]["name"].ToString();
                txtAddress.Text = shopData.Rows[0]["address"].ToString();
                txtContact.Text = shopData.Rows[0]["phone"].ToString();
                txtInvoicePrefix.Text = shopData.Rows[0]["invoice_prefix"].ToString();
                txtCurrency.Text = shopData.Rows[0]["currency"].ToString();

                //string shopPath = shopData.Rows[0]["shop_logo"].ToString();
                this.shopLogoPath = shopData.Rows[0]["shop_logo"].ToString();
                this.receiptLogoPath = shopData.Rows[0]["receipt_logo"].ToString();

                picShopLogo.Image = LoadImage(this.shopLogoPath);
                picReceiptLogo.Image = LoadImage(this.receiptLogoPath);
            }//update shop
        }//load shop

        public Image LoadImage(string path)
        {
            using (var bmpTemp = new Bitmap(path))
            {
                return new Bitmap(bmpTemp);
            }
        }
    }//class
}
