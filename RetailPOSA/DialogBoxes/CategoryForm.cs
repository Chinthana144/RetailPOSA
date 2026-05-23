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
    public partial class CategoryForm : Form
    {
        private int categoryID = 0;
        public CategoryForm(int id)
        {
            InitializeComponent();

            categoryID = id;
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            CategoryService service = new CategoryService();

            DataTable dt = new DataTable();

            if (categoryID != 0)
            {
                dt = service.GetCategoryByID(categoryID);
                txtCategory.Text = dt.Rows[0]["name"].ToString();
            }

            btnCategory.Text = categoryID == 0 ? "Add Category" : "Update Category";
        }//load category

        private void btnCategory_Click(object sender, EventArgs e)
        {
            //add category
            CategoryService service = new CategoryService();

            bool CategoryStatus = true;

            if (string.IsNullOrEmpty(txtCategory.Text))
            {
                MessageBox.Show("Please enter a category name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (categoryID == 0)
            {
                service.InsertCategory(txtCategory.Text, CategoryStatus);
            }
            else
            {
                service.UpdateCategory(categoryID, txtCategory.Text);
            }

            this.Close();

        }//create and update category

    }//class
}
