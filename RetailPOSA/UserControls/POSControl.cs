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
    public partial class POSControl : UserControl
    { 
        Database db = new Database();
        public POSControl()
        {
            InitializeComponent();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { 
                InventoryService inventoryService = new InventoryService();

                DataTable dt = inventoryService.SearchActiveInventory(txtSearch.Text);

                if (dt.Rows.Count == 1)
                {
                    // Add the product to the cart
                    int productID = Convert.ToInt32(dt.Rows[0]["product_id"]);
                    string productName = dt.Rows[0]["ProductName"].ToString();
                    decimal sellingPrice = Convert.ToDecimal(dt.Rows[0]["SellingPrice"]);
                    // For demonstration, we'll just show a message box
                    MessageBox.Show($"Added to cart: {productName} (ID: {productID}) - Price: {sellingPrice:C}");
                }
                else if (dt.Rows.Count > 1)
                {
                    // Show a selection dialog if multiple products match
                    string message = "Multiple products found:\n";
                    foreach (DataRow row in dt.Rows)
                    {
                        message += $"{row["ProductID"]}: {row["ProductName"]} - {row["SellingPrice"]:C}\n";
                    }
                    MessageBox.Show(message);
                }
                else
                {
                    MessageBox.Show("No products found.");
                }   
            }//enter key
        }//search

        private int CheckCartHeader()
        {
            CartHeaderService cartHeaderService = new CartHeaderService();
            DataTable dt = cartHeaderService.GetCartHeader();
            if (dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0]["id"]);
            }
            else
            {
                //create new cart header
            }
            return 0;
        }//check cart header

    }//class
}
