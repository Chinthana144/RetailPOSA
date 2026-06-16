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
    public partial class CategoryControl : UserControl
    {
        private int selectedID = 0;

        public CategoryControl()
        {
            InitializeComponent();
        }

        private void CategoryControl_Load(object sender, EventArgs e)
        {
            ThemeManager.ApplyTheme(this);

            loadAllCategories();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            CategoryForm categoryForm = new CategoryForm(0);

            categoryForm.ShowDialog();

            loadAllCategories();
        }//add category button click event

        private void loadAllCategories()
        { 
            CategoryService service = new CategoryService();

            DataTable dt = service.GetAllCategories();

            dgvCategories.DataSource = dt;

            dgvCategories.Columns[0].HeaderText = "ID";
            dgvCategories.Columns[1].HeaderText = "Name";

            dgvCategories.Columns[0].Width = 50;
        }

        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCategories.Rows[e.RowIndex];

                selectedID = Convert.ToInt32(row.Cells["id"].Value);

                if (selectedID > 0) { btnEditCategory.Enabled = true; }

            }
        }

        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            if(selectedID > 0)
            {
                CategoryForm categoryForm = new CategoryForm(selectedID);

                categoryForm.ShowDialog();

                loadAllCategories();
            }
        }
    }
}
