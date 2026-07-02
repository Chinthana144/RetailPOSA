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
    public partial class ExpenseControl : UserControl
    {
        private int selectedID = 0;
        private int currentPage = 1;
        private int pageSize = 50;

        public ExpenseControl()
        {
            InitializeComponent();
        }
        private void ExpenseControl_Load(object sender, EventArgs e)
        {
            ThemeManager.ApplyTheme(this);
            loadExpenses();
        }

        private void btnExpenseCategory_Click(object sender, EventArgs e)
        {
            ExpenseCategoryForm categoryForm = new ExpenseCategoryForm();
            categoryForm.ShowDialog();
        }

        private void btnAddExpenses_Click(object sender, EventArgs e)
        {
            ExpenseForm expenseForm = new ExpenseForm(0);
            expenseForm.ShowDialog();

            loadExpenses();
        }

        private void dgvExpenses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvExpenses.Rows[e.RowIndex];

                selectedID = Convert.ToInt32(row.Cells["id"].Value);
                btnEditExpense.Enabled = true;
            }
        }
        private void btnEditExpense_Click(object sender, EventArgs e)
        {
            ExpenseForm expenseForm = new ExpenseForm(selectedID);
            expenseForm.ShowDialog();

            loadExpenses();
        }

        private void searchTimer_Tick(object sender, EventArgs e)
        {
            searchTimer.Stop();
            searchTimer.Start();
        }
        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            searchTimer.Stop();
            ExpenseService expenseService = new ExpenseService();
            if (txtSearch.Text.Trim() != "")
            {
                searchExpenses();
            }
            else
            {
                loadExpenses();
            }
        }
        private void loadExpenses()
        {
            ExpenseService expenseService = new ExpenseService();

            DataTable expenseData = expenseService.searchExpenses("", pageSize, (currentPage - 1) * pageSize);

            dgvExpenses.DataSource = expenseData;

            dgvExpenses.Columns["category_id"].Visible = false;
            dgvExpenses.Columns["user_id"].Visible = false;
            dgvExpenses.Columns["status"].Visible = false;

            dgvExpenses.Columns["id"].HeaderText = "ID";
            dgvExpenses.Columns["datetime"].HeaderText = "Date Time";
            dgvExpenses.Columns["category_name"].HeaderText = "Category";            
            dgvExpenses.Columns["description"].HeaderText = "Description";
            dgvExpenses.Columns["amount"].HeaderText = "Amount";
            dgvExpenses.Columns["username"].HeaderText = "User";

            dgvExpenses.Columns["id"].Width = 50;

            selectedID = 0;
            lblPageNo.Text = "Page: " + currentPage.ToString();
            btnEditExpense.Enabled = false;
        }//load expeanses

        private void searchExpenses()
        {
            ExpenseService expenseService = new ExpenseService();

            DataTable expenseData = expenseService.searchExpenses(txtSearch.Text, pageSize, (currentPage - 1) * pageSize);

            dgvExpenses.DataSource = expenseData;

            dgvExpenses.Columns["category_id"].Visible = false;
            dgvExpenses.Columns["user_id"].Visible = false;
            dgvExpenses.Columns["status"].Visible = false;

            dgvExpenses.Columns["id"].HeaderText = "ID";
            dgvExpenses.Columns["datetime"].HeaderText = "Date Time";
            dgvExpenses.Columns["category_name"].HeaderText = "Category";
            dgvExpenses.Columns["description"].HeaderText = "Description";
            dgvExpenses.Columns["amount"].HeaderText = "Amount";
            dgvExpenses.Columns["username"].HeaderText = "User";

            dgvExpenses.Columns["id"].Width = 50;

            selectedID = 0;
            lblPageNo.Text = "Page: " + currentPage.ToString();
            btnEditExpense.Enabled = false;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                loadExpenses();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            currentPage++;
            loadExpenses();
        }

        
    }//class
}
