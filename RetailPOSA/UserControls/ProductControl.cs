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
    public partial class ProductControl : UserControl
    {
        private int selectedID = 0;
        private int currentPage = 1;
        private int pageSize = 50;

        public ProductControl()
        {
            InitializeComponent();
        }

        private void ProductControl_Load(object sender, EventArgs e)
        {
            loadProducts();
            lblPageNo.Text = $"Page {currentPage}";
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            ProductForm productForm = new ProductForm(0);

            productForm.ShowDialog();

            //load products
            loadProducts();
        }

        private void loadProducts()
        { 
            ProductService service = new ProductService();

            int offset = (currentPage - 1) * pageSize;
            DataTable dt = service.GetAllProducts(pageSize, offset);

            dgvProducts.DataSource = dt;
            dgvProducts.Columns["Id"].HeaderText = "ID";
            dgvProducts.Columns["category"].HeaderText = "Category";
            dgvProducts.Columns["barcode"].HeaderText = "Barcode";
            dgvProducts.Columns["product"].HeaderText = "Product";
            dgvProducts.Columns["second_name"].HeaderText = "Second Name";
            dgvProducts.Columns["is_weighted"].HeaderText = "Scalable";
            dgvProducts.Columns["has_expiry"].HeaderText = "Expiry";
            dgvProducts.Columns["minimum_stock"].HeaderText = "Minimum Qty";

            lblPageNo.Text = $"Page {currentPage}";

            dgvProducts.Columns[0].Width = 50;
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProducts.Rows[e.RowIndex];

                selectedID = Convert.ToInt32(row.Cells["id"].Value);

                if (selectedID > 0) { btnEditProduct.Enabled = true; }

            }
        }//cell click event

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            if (selectedID > 0)
            { 
                ProductForm productForm = new ProductForm(selectedID);

                productForm.ShowDialog();

                //load products
                loadProducts();
            }
        }//edit products

        private void btnNext_Click(object sender, EventArgs e)
        {
            currentPage++;

            loadProducts();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;

                loadProducts();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            timer1.Stop();

            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            if (txtSearch.Text.Trim() != "")
            {
                searchProducts();
            }
            else
            {
                loadProducts();
            }

        }//timer tick

        private void searchProducts()
        {
            ProductService service = new ProductService();
            DataTable dt = service.SearchProducts(txtSearch.Text);
            dgvProducts.DataSource = dt;
            dgvProducts.Columns["Id"].HeaderText = "ID";
            dgvProducts.Columns["category"].HeaderText = "Category";
            dgvProducts.Columns["barcode"].HeaderText = "Barcode";
            dgvProducts.Columns["product"].HeaderText = "Product";
            dgvProducts.Columns["second_name"].HeaderText = "Second Name";
            dgvProducts.Columns["is_weighted"].HeaderText = "Scalable";
            dgvProducts.Columns["has_expiry"].HeaderText = "Expiry";
            dgvProducts.Columns["minimum_stock"].HeaderText = "Minimum Qty";
        }//search products

    }//class
}
