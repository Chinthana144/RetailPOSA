using RetailPOSA.DialogBoxes;
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

        public GrnDetailControl(int id)
        {
            InitializeComponent();

            grnID = id;
        }
        private void GrnDetailControl_Load(object sender, EventArgs e)
        {
            loadGrnHeader();
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
                }
                else 
                {
                    //MessageBox.Show("multiple results");
                    GrnProductSearchForm productSearchForm = new GrnProductSearchForm(txtSearch.Text, grnID);
                    productSearchForm.ShowDialog();
                }
            }//enter key pressed
        }//search key down event

        private void btnAddNewProduct_Click(object sender, EventArgs e)
        {
            ProductForm productForm = new ProductForm(0);

            productForm.ShowDialog();
        }
    }//class
}
