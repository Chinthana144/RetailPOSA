using RetailPOSA.DialogBoxes;
using RetailPOSA.Models;
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
        public int selectedProductID = 0;
        private int cartHeaderID = 0;

        //get user id from session
        private int userID = Session.UserID;

        public POSControl()
        {
            InitializeComponent();
        }

        private void POSControl_Load(object sender, EventArgs e)
        {
            //get cart id
            cartHeaderID = CheckCartHeader();
            //load cart
            loadCart();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { 
                InventoryService inventoryService = new InventoryService();
                CartDetailService cartDetailService = new CartDetailService();

                DataTable dt = inventoryService.SearchActiveInventory(txtSearch.Text);

                if (dt.Rows.Count == 1)
                {
                    // Add the product to the cart
                    selectedProductID = Convert.ToInt32(dt.Rows[0]["product_id"]);
                    int cartHeaderID = CheckCartHeader();
                    int inventoryID = Convert.ToInt32(dt.Rows[0]["id"]);
                    decimal unitPrice = Convert.ToDecimal(dt.Rows[0]["final_price"]);
                    decimal qty = 1;
                    decimal price = qty * unitPrice;

                    cartDetailService.AddToCart(cartHeaderID, inventoryID, selectedProductID, unitPrice, qty, price);

                    txtSearch.Text = "";
                    txtSearch.Focus();

                    //load cart
                    loadCart();
                }
                else if (dt.Rows.Count > 1)
                {
                    //getting multiple data
                    POSProductSearchForm searchForm = new POSProductSearchForm(txtSearch.Text);

                    searchForm.ShowDialog();
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
            DataTable dt = cartHeaderService.GetCartHeader(userID);
            if (dt.Rows.Count > 0)
            {
                cartHeaderID = Convert.ToInt32(dt.Rows[0]["id"]);
                return cartHeaderID;
            }
            else
            {
                //create new cart header
                cartHeaderID = cartHeaderService.InsertCartHeader(userID, DateTime.Now, 1);
                DataTable dtNew = cartHeaderService.GetCartHeader(userID);
                cartHeaderID = Convert.ToInt32(dtNew.Rows[0]["id"]);           
                return cartHeaderID;
            }
        }//check cart header

        private void loadCart()
        { 
            CartDetailService cartDetailService = new CartDetailService();

            DataTable dt = cartDetailService.GetCartByHeaderID(cartHeaderID);

            dgvCart.DataSource = dt;

            dgvCart.Columns["id"].Visible = false;
            dgvCart.Columns["cart_header_id"].Visible = false;
            dgvCart.Columns["product_id"].Visible = false;
            dgvCart.Columns["second_name"].Visible = false;
            dgvCart.Columns["is_weighted"].Visible = false;
            dgvCart.Columns["has_expiry"].Visible = false;
            dgvCart.Columns["minimum_stock"].Visible = false;
            dgvCart.Columns["status"].Visible = false;

            //get totals
            DataTable dtTotal = cartDetailService.GetCartTotals(cartHeaderID);

            lblItemCount.Text = "Items: " + dtTotal.Rows[0]["row_count"].ToString();
            lblCartTotal.Text = "Total: " + dtTotal.Rows[0]["cart_total"].ToString();

            btnPay.Text = "Pay " + dtTotal.Rows[0]["cart_total"].ToString();
        }//load cart

        //=================================================================================//
        //================================= POS Buttons ===================================//
        //=================================================================================//
        private void btnClearCart_Click(object sender, EventArgs e)
        {
            CartDetailService cartDetailService = new CartDetailService();

            cartDetailService.ClearCart(cartHeaderID);

            loadCart();
        }
    }//class
}
