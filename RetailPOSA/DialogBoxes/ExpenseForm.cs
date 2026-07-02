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

namespace RetailPOSA.DialogBoxes
{
    public partial class ExpenseForm : Form
    {
        private int expenseID = 0;
        public ExpenseForm(int expenseID)
        {
            InitializeComponent();
            this.expenseID = expenseID;
        }

        private void ExpenseForm_Load(object sender, EventArgs e)
        {
            ThemeManager.ApplyTheme(this);
            loadCategories();
            loadExpense();
            btnExpense.Text = expenseID > 0 ? "Update Expense" : "Add Expense";
        }

        private void btnExpense_Click(object sender, EventArgs e)
        {
            ExpenseService expenseService = new ExpenseService();
            string categoryName = cmbCategory.Text;
            decimal amount = Convert.ToDecimal(txtAmount.Text);
            int userID = Session.UserID;
            string today = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            if (expenseID > 0)
            {
                expenseService.UpdateExpense(expenseID, today, categoryName, txtDescription.Text, amount, userID);
            }//update
            else
            {
                expenseService.InsertExpense(today, categoryName, txtDescription.Text, amount, userID, 1);
            }//insert

            this.Close();
        }//insert or update 

        private void loadCategories()
        { 
            ExpenseService expenseService = new ExpenseService();
            DataTable categoryData = expenseService.GetExpenseCategories();

            cmbCategory.DataSource = categoryData;
            cmbCategory.DisplayMember = "category_name";
            cmbCategory.ValueMember = "id";
        }

        private void loadExpense()
        {
            if (expenseID > 0)
            {
                ExpenseService expenseService = new ExpenseService();

                DataTable expenseData = expenseService.GetExpenseByID(expenseID);

                int categoryID = Convert.ToInt32(expenseData.Rows[0]["category_id"]);
                string description = expenseData.Rows[0]["description"].ToString();
                string amount = expenseData.Rows[0]["amount"].ToString();

                cmbCategory.SelectedValue = categoryID;
                txtDescription.Text = description;
                txtAmount.Text = amount;

            }//if as data
        }//load expense

        private void txtAmount_KeyUp(object sender, KeyEventArgs e)
        {
            if (!decimal.TryParse(txtAmount.Text, out decimal result))
            {
                MessageBox.Show(
                    "Please enter velid amount!",
                    "Invelid entry",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtAmount.Text = "0";
            }
        }
    }//class
}
