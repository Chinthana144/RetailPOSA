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

namespace RetailPOSA.DialogBoxes
{
    public partial class ProductForm : Form
    {
        private int ProductID = 0;
        public ProductForm(int id)
        {
            InitializeComponent();

            ProductID = id;
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            loadCategories();

            loadEditProduct();

            btnProduct.Text = ProductID == 0 ? "Add Product" : "Update Product";
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            ProductService service = new ProductService();

            int categoryId = Convert.ToInt32(cmbCategory.SelectedValue);

            //check minimum stock
            if (!int.TryParse(txtMinimumStock.Text, out int minimumStock))
            {
                MessageBox.Show("Minimum stock must be a valid integer.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //check null or empty fields
            if (string.IsNullOrWhiteSpace(txtBarcode.Text) || string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Barcode and Name fields cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //default status to active
            bool status = true;

            if (ProductID > 0)
            {
                service.UpdateProduct(ProductID, categoryId, txtBarcode.Text, txtName.Text, txtSecondName.Text, chkWeighted.Checked, chkExpiry.Checked, Convert.ToInt32(txtMinimumStock.Text), status);
            }
            else
            {
                service.InsertProduct(categoryId, txtBarcode.Text, txtName.Text, txtSecondName.Text, chkWeighted.Checked, chkExpiry.Checked, Convert.ToInt32(txtMinimumStock.Text), status);
            }//save

            this.Close();
        }//btn add product

        private void loadCategories()
        {
            CategoryService categoryService = new CategoryService();

            DataTable dt = categoryService.GetAllCategories();

            cmbCategory.DataSource = dt;
            cmbCategory.DisplayMember = "name";
            cmbCategory.ValueMember = "id";
        }//load categories

        private void loadEditProduct()
        {
            ProductService service = new ProductService();
            DataTable dt = service.GetProductByID(ProductID);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                cmbCategory.SelectedValue = Convert.ToInt32(row["category_id"].ToString());
                txtBarcode.Text = row["barcode"].ToString();
                txtName.Text = row["product"].ToString();
                txtSecondName.Text = row["second_name"].ToString();
                chkWeighted.Checked = Convert.ToBoolean(row["is_weighted"]);
                chkExpiry.Checked = Convert.ToBoolean(row["has_expiry"]);
                txtMinimumStock.Text = row["minimum_stock"].ToString();
            }
        }//load edit product

    }//class
}
