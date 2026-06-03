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
    public partial class SaleReturnHeaderControl : UserControl
    {
        private int selectedID = 0;
        private int currentPage = 1;
        private int pageSize = 50;
        public SaleReturnHeaderControl()
        {
            InitializeComponent();
        }
        private void SaleReturnHeaderControl_Load(object sender, EventArgs e)
        {
            cmbStatus.SelectedIndex = 0;
            btnReturnItems.Enabled = false;

            //loadSalesReturnData();
            searchSalesReturnHeader(txtSearch.Text.Trim(), cmbStatus.SelectedIndex, pageSize, (currentPage - 1) * pageSize);
        }
        private void btnAddSaleReturn_Click(object sender, EventArgs e)
        {
            SaleReturnHeaderForm form = new SaleReturnHeaderForm(string.Empty);
            form.ShowDialog();
        }
        private void dgvSaleReturnHeader_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSaleReturnHeader.Rows[e.RowIndex];
                selectedID = Convert.ToInt32(row.Cells["id"].Value);
                btnReturnItems.Enabled = true;
            }
        }
        private void btnReturnItems_Click(object sender, EventArgs e)
        {
            if (selectedID > 0)
            {
                SaleReturnDetailControl detailControl = new SaleReturnDetailControl(selectedID);

                //load sale return detail
                Main mainForm = (Main)Application.OpenForms["Main"];
                mainForm.loadControl(detailControl);

            }//load return detail control
        }//return items

        private void searchSalesReturnHeader(string searchTerm, int status, int limit, int offset)
        {
            SaleReturnHeaderService headerService = new SaleReturnHeaderService();

            DataTable searchData = headerService.SearchSaleReturnHeader(searchTerm, status, limit, offset);
            dgvSaleReturnHeader.DataSource = searchData;

            dgvSaleReturnHeader.Columns["invoice_id"].Visible = false;
            dgvSaleReturnHeader.Columns["user_id"].Visible = false;
            dgvSaleReturnHeader.Columns["status"].Visible = false;

            dgvSaleReturnHeader.Columns["id"].HeaderText = "ID";
            dgvSaleReturnHeader.Columns["sale_return_no"].HeaderText = "Return No";
            dgvSaleReturnHeader.Columns["invoice_no"].HeaderText = "Invoice No";
            dgvSaleReturnHeader.Columns["submitted_datetime"].HeaderText = "Submitted Date";
            dgvSaleReturnHeader.Columns["return_type"].HeaderText = "Return Type";
            dgvSaleReturnHeader.Columns["reason"].HeaderText = "Reason";
            dgvSaleReturnHeader.Columns["item_count"].HeaderText = "Item Count";
            dgvSaleReturnHeader.Columns["sale_total"].HeaderText = "Sale Total";
            dgvSaleReturnHeader.Columns["username"].HeaderText = "User";

            selectedID = 0;
        }

        
    }//class
}
