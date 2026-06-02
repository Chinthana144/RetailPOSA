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
    public partial class PriceChangeDetailControl : UserControl
    {
        private int headerID = 0;
        public PriceChangeDetailControl(int headerID)
        {
            InitializeComponent();
            this.headerID = headerID;
        }

        private void PriceChangeDetailControl_Load(object sender, EventArgs e)
        {
            loadHeaderData();
        }

        private void loadHeaderData()
        {
            PriceChangeHeaderService headerService = new PriceChangeHeaderService();
            DataTable headerData = headerService.GetPriceChangeByID(headerID);
            if (headerData.Rows.Count > 0)
            {
                DataRow row = headerData.Rows[0];
                lblTitle.Text = "Price Change No: " + row["price_change_no"].ToString();
                lblDate.Text = "Date: " + row["submitted_datetime"].ToString();
                lblNote.Text = "Note: " + row["note"].ToString();
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtSearch.Text.Length > 0)
            {
                if (e.KeyCode == Keys.Enter)
                { 
                    InventoryService inventoryService = new InventoryService();

                    DataTable searchResult = inventoryService.SearchActiveInventory(txtSearch.Text);

                    if (searchResult.Rows.Count > 0)
                    {
                        //DataRow row = searchResult.Rows[0];
                        //txtProductID.Text = row["id"].ToString();
                        //txtProductName.Text = row["product_name"].ToString();
                        //txtCurrentPrice.Text = row["selling_price"].ToString();
                        MessageBox.Show("show dialog box");
                    }
                    else
                    {
                        MessageBox.Show("No product found with the given search term.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }//enter key pressed
            }//has text
        }
    }//class
}
