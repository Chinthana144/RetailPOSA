using RetailPOSA.DialogBoxes;
using RetailPOSA.Forms;
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
    public partial class GrnDetailControl : UserControl
    {
        private int grnID = 0;
        private int selectedID = 0;

        public GrnDetailControl(int id)
        {
            InitializeComponent();

            grnID = id;
        }
        private void GrnDetailControl_Load(object sender, EventArgs e)
        {
            loadGrnHeader();

            loadGrnDetails();

            btnDeleteProduct.Enabled = false;
        }

        private void loadGrnHeader()
        { 
            GrnHeaderService grnHeaderService = new GrnHeaderService();

            DataTable dt = grnHeaderService.GetGrnHeaderByID(grnID);

            if (dt.Rows.Count > 0)
            { 
                lblInvoiceNo.Text = dt.Rows[0]["invoice_no"].ToString();
            }
        }//load grn header

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { 
                //search item here
                ProductService productService = new ProductService();

                DataTable dt = productService.SearchProducts(txtSearch.Text);

                if (dt.Rows.Count == 1)
                {
                    GrnDetailForm grnDetailForm = new GrnDetailForm(Convert.ToInt32(dt.Rows[0]["id"]), grnID);
                    grnDetailForm.ShowDialog();
                    loadGrnDetails();
                }
                else 
                {
                    //MessageBox.Show("multiple results");
                    GrnProductSearchForm productSearchForm = new GrnProductSearchForm(txtSearch.Text, grnID);
                    productSearchForm.ShowDialog();
                    loadGrnDetails();
                }
            }//enter key pressed
        }//search key down event

        private void btnAddNewProduct_Click(object sender, EventArgs e)
        {
            ProductForm productForm = new ProductForm(0);

            productForm.ShowDialog();
        }

        private void dgvGrnProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvGrnProducts.Rows[e.RowIndex];

                selectedID = Convert.ToInt32(row.Cells["id"].Value);

                if (selectedID > 0) { btnDeleteProduct.Enabled = true; }
            }
        }

        private void loadGrnDetails()
        { 
            GrnDetailService grnDetailService = new GrnDetailService();

            DataTable dt = grnDetailService.GetGrnDetailsByGrnHeaderID(grnID);

            dgvGrnProducts.DataSource = dt;

            dgvGrnProducts.Columns["id"].Width = 50;
            dgvGrnProducts.Columns["product_id"].Visible = false;
            dgvGrnProducts.Columns["grn_header_id"].Visible = false;

            //get purchase total
            decimal purchaseTotal = dt.AsEnumerable().Sum(row => row.Field<decimal>("purchase_total"));
            lblPurchaseTotal.Text = "Purchase Total: " + purchaseTotal.ToString("0.00");

            btnDeleteProduct.Enabled = false;
        }

        private void btnSubmitGrn_Click(object sender, EventArgs e)
        {
            //fetch grn details
            GrnDetailService grnDetailService = new GrnDetailService();
            DataTable dt = grnDetailService.GetGrnDetailsByGrnHeaderID(grnID);

            InventoryService inventoryService = new InventoryService();

            GrnHeaderService grnHeaderService = new GrnHeaderService();

            foreach (DataRow row in dt.Rows)
            { 
                int grnHeaderID = Convert.ToInt32(row["grn_header_id"]);
                int productID = Convert.ToInt32(row["product_id"]);
                decimal qty = Convert.ToDecimal(row["qty"]) + Convert.ToDecimal(row["free_qty"]);
                decimal purchasePrice = Convert.ToDecimal(row["purchase_price"]);
                decimal sellingPrice = Convert.ToDecimal(row["selling_price"]);
                decimal discount = Convert.ToDecimal(row["discount"]);
                decimal finalPrice = Convert.ToDecimal(row["final_price"]);
                decimal purchaseTotal = Convert.ToDecimal(row["purchase_total"]);
                DateTime expiryDate = DateTime.Parse(row["expiry_date"].ToString());
                bool status = true;

                inventoryService.InsertInventory(grnHeaderID, productID, Convert.ToInt32(qty), Convert.ToInt32(qty), purchasePrice, sellingPrice, discount, finalPrice, purchaseTotal, expiryDate, status);

            }//foreach

            //Update GRN header status to completed
            grnHeaderService.UpdateGrnHeaderStatus(grnID, 2);

            //MessageBox.Show("GRN submitted successfully!");
            DialogResult result = MessageBox.Show("GRN submitted successfully! Do you want to print the GRN?", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                //goto print form
            }
            else 
            { 
                GrnHeaderControl grnHeaderControl = new GrnHeaderControl();

                Main mainForm = (Main)Application.OpenForms["Main"];
                mainForm.loadControl(grnHeaderControl);
            }
        }
    }//class
}
