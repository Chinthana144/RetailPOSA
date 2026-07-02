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
    public partial class ExpenseCategoryForm : Form
    {
        private int selectedID = 0;
        public ExpenseCategoryForm()
        {
            InitializeComponent();
        }

        private void ExpenseCategoryForm_Load(object sender, EventArgs e)
        {
            ThemeManager.ApplyTheme(this);
            loadExpenseCategories();
        }

        private void btnExpenseCategory_Click(object sender, EventArgs e)
        {
            ExpenseService expenseService = new ExpenseService();
            if (selectedID > 0)
            {
                int updateStat = expenseService.UpdateExpenseCategory(selectedID, txtCategoryName.Text);
                if (updateStat > 0)
                {
                    MessageBox.Show(
                        "Expense Category updated successfully!",
                        "Expense Category",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(
                        "Expense Category already exists.",
                        "Expense Category",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }//duplicate entry
            }//update
            else 
            {
                int insertStat = expenseService.InsertExpenseCategory(txtCategoryName.Text, 1);
                if (insertStat > 0)
                {
                    MessageBox.Show(
                        "Expense Category created successfully!",
                        "Expense Category",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else {
                    MessageBox.Show(
                        "Expense Category already exists.",
                        "Expense Category",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }//duplicate entry
            }//insert
            loadExpenseCategories();
        }//create or update category

        private void dgvExpenseCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvExpenseCategories.Rows[e.RowIndex];

                selectedID = Convert.ToInt32(row.Cells["id"].Value);

                string categoryName = row.Cells["category_name"].Value.ToString();

                btnExpenseCategory.Text = "Update";
                txtCategoryName.Text = categoryName;
            }
        }//cell click

        private void loadExpenseCategories()
        { 
            ExpenseService expenseService = new ExpenseService();

            DataTable expenseCategories = expenseService.GetExpenseCategories();

            dgvExpenseCategories.DataSource = expenseCategories;

            dgvExpenseCategories.Columns["status"].Visible = false;

            dgvExpenseCategories.Columns["id"].HeaderText = "ID";
            dgvExpenseCategories.Columns["category_name"].HeaderText = "Category";

            dgvExpenseCategories.Columns["id"].Width = 50;

            selectedID = 0;
            btnExpenseCategory.Text = selectedID > 0 ? "Update" : "Create";
            txtCategoryName.Text = "";
        }//load expense categories

        
    }//class
}
