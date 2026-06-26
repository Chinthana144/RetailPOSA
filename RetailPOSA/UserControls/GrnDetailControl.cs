using RetailPOSA.DialogBoxes;
using RetailPOSA.Forms;
using RetailPOSA.Reports.PDFs;
using RetailPOSA.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            ThemeManager.ApplyTheme(this);

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
        }//cell click event

        private void btnSubmitGrn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to submit GRN?", "Submit GRN", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                //fetch grn details
                GrnDetailService grnDetailService = new GrnDetailService();
                DataTable dt = grnDetailService.GetGrnDetailsByGrnHeaderID(grnID);

                InventoryService inventoryService = new InventoryService();

                GrnHeaderService grnHeaderService = new GrnHeaderService();

                int itemCount = dt.Rows.Count;
                decimal TotalPurchasePrice = dt.AsEnumerable().Sum(row => row.Field<decimal>("purchase_price"));

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
                    int status = 1;

                    inventoryService.InsertInventory(grnHeaderID, productID, qty, qty, purchasePrice, sellingPrice, discount, finalPrice, purchaseTotal, expiryDate, status);

                }//foreach

                string submittedDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                //Update GRN header status to completed
                grnHeaderService.UpdateGrnHeaderStatus(grnID, submittedDate, itemCount, TotalPurchasePrice, 2);

                //open report
                GeneralSettingsService settingsService = new GeneralSettingsService();
                string reportBasePath = settingsService.GetSettingsValueByKey("report_path");
                var reportSubmittedDate = DateTime.Parse(submittedDate);

                string reportPath = reportBasePath + "\\GRN_report_" + grnID + "_" + reportSubmittedDate.ToString("yyyy_MM_dd") + ".pdf";

                GRNReport grnReport = new GRNReport();
                grnReport.Generate(reportPath, grnID);
                Process.Start(
                new ProcessStartInfo(reportPath)
                {
                    UseShellExecute = true
                });

                GrnHeaderControl grnHeaderControl = new GrnHeaderControl();

                Main mainForm = (Main)Application.OpenForms["Main"];
                mainForm.loadControl(grnHeaderControl);
            }//yes
            else 
            { 
                GrnHeaderControl grnHeaderControl = new GrnHeaderControl();

                Main mainForm = (Main)Application.OpenForms["Main"];
                mainForm.loadControl(grnHeaderControl);
            }//no
        }//submit grn

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            GrnDetailService grnDetailService = new GrnDetailService();

            DialogResult result = MessageBox.Show("Are you sure you want to delete this product from the GRN?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                grnDetailService.DeleteGrnDetail(selectedID);
                loadGrnDetails();
            }
        }//delete

        private void loadGrnDetails()
        {
            GrnDetailService grnDetailService = new GrnDetailService();

            DataTable dt = grnDetailService.GetGrnDetailsByGrnHeaderID(grnID);

            dgvGrnProducts.DataSource = dt;

            dgvGrnProducts.Columns["id"].Width = 50;
            dgvGrnProducts.Columns["product_id"].Visible = false;
            dgvGrnProducts.Columns["grn_header_id"].Visible = false;

            dgvGrnProducts.Columns["product_name"].HeaderText = "Product Name";
            dgvGrnProducts.Columns["qty"].HeaderText = "Qty";
            dgvGrnProducts.Columns["free_qty"].HeaderText = "Free Qty";
            dgvGrnProducts.Columns["purchase_price"].HeaderText = "Purchase Price";
            dgvGrnProducts.Columns["selling_price"].HeaderText = "Selling Price";
            dgvGrnProducts.Columns["discount"].HeaderText = "Discount";
            dgvGrnProducts.Columns["final_price"].HeaderText = "Final Price";
            dgvGrnProducts.Columns["expiry_date"].HeaderText = "Expiry Date";
            dgvGrnProducts.Columns["purchase_total"].HeaderText = "Purchase Total";

            //get purchase total
            decimal purchaseTotal = dt.AsEnumerable().Sum(row => row.Field<decimal>("purchase_total"));
            lblPurchaseTotal.Text = "Purchase Total: " + purchaseTotal.ToString("0.00");

            btnDeleteProduct.Enabled = false;
        }//laod grn details 

        
    }//class
}
