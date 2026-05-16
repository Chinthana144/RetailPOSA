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
        private int cartDetailID = 0;

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

            //buttons
            btnEditCart.Enabled = false;
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
                    bool is_scale = Convert.ToBoolean(dt.Rows[0]["is_weighted"]);
                    bool is_expiry = Convert.ToBoolean(dt.Rows[0]["has_expiry"]);

                    //check expire
                    if (is_expiry)
                    {
                        DateTime expireDate = Convert.ToDateTime(dt.Rows[0]["expiry_date"]);
                        DateTime currentDate = DateTime.Now;
                        if (expireDate > currentDate)
                        {
                            //check scale
                            if (is_scale)
                            {
                                POSCartEditForm posCartEditForm = new POSCartEditForm(cartHeaderID, 0, inventoryID, selectedProductID, unitPrice, qty, price);
                                posCartEditForm.ShowDialog();
                            }//scale items add QTY
                            else
                            {
                                cartDetailService.AddToCart(cartHeaderID, inventoryID, selectedProductID, unitPrice, qty, price);
                            }//not scale item (unit item)
                        }//not expired
                        else 
                        {
                            MessageBox.Show("This product is expired!", "Expired Item", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }//expired
                    }

                    txtSearch.Text = "";
                    txtSearch.Focus();

                    //load cart
                    loadCart();
                }
                else if (dt.Rows.Count > 1)
                {
                    //getting multiple data
                    POSProductSearchForm searchForm = new POSProductSearchForm(txtSearch.Text, cartHeaderID);

                    searchForm.ShowDialog();

                    loadCart();
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

            dgvCart.Columns["barcode"].HeaderText = "Barcode";
            dgvCart.Columns["name"].HeaderText = "Product";
            dgvCart.Columns["unit_price"].HeaderText = "Unit Price";
            dgvCart.Columns["qty"].HeaderText = "Qty";
            dgvCart.Columns["total_price"].HeaderText = "Total";

            dgvCart.Columns["unit_price"].Width = 80;
            dgvCart.Columns["qty"].Width = 80;
            dgvCart.Columns["total_price"].Width = 80;

            //get totals
            DataTable dtTotal = cartDetailService.GetCartTotals(cartHeaderID);

            lblItemCount.Text = "Items: " + dtTotal.Rows[0]["row_count"].ToString();
            lblCartTotal.Text = "Total: " + dtTotal.Rows[0]["cart_total"].ToString();

            btnPay.Text = "Pay " + dtTotal.Rows[0]["cart_total"].ToString();

            //focus on search
            txtSearch.Focus();
        }//load cart

        private void dgvCart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCart.Rows[e.RowIndex];

                cartDetailID = Convert.ToInt32(row.Cells["id"].Value);

                if (cartDetailID >= 0)  
                {
                    btnEditCart.Enabled = true;
                }//enable buttons

            }
        }

        //=================================================================================//
        //================================= POS Buttons ===================================//
        //=================================================================================//
        private void btnClearCart_Click(object sender, EventArgs e)
        {
            CartDetailService cartDetailService = new CartDetailService();

            cartDetailService.ClearCart(cartHeaderID);

            loadCart();
        }

        private void btnEditCart_Click(object sender, EventArgs e)
        {
            //edit qty in cart
            CartDetailService cartDetailService = new CartDetailService();

            DataTable dt = cartDetailService.GetCartByID(cartDetailID);

            int inventoryID = Convert.ToInt32(dt.Rows[0]["inventory_id"]);
            int productID = Convert.ToInt32(dt.Rows[0]["product_id"]);
            decimal unitPrice = Convert.ToDecimal(dt.Rows[0]["unit_price"]);
            decimal qty = Convert.ToDecimal(dt.Rows[0]["qty"]);
            decimal totalPrice = Convert.ToDecimal(dt.Rows[0]["total_price"]);

            POSCartEditForm posCartEditForm = new POSCartEditForm(cartHeaderID, cartDetailID, inventoryID, productID, unitPrice, qty, totalPrice);

            posCartEditForm.ShowDialog();

            loadCart();
        }

        private void btnOpenInventory_Click(object sender, EventArgs e)
        {
            POSProductSearchForm posProductSearch = new POSProductSearchForm("", cartHeaderID);
            posProductSearch.ShowDialog();
        }

        private void btnDeleteCartItem_Click(object sender, EventArgs e)
        {
            CartDetailService cartDetailService = new CartDetailService();
            if (cartDetailID > 0)
            {
                cartDetailService.DeleteCartItem(cartDetailID);
            }
            
            loadCart();
        }
    }//class
}
