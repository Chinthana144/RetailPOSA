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
    public partial class GrnHeaderControl : UserControl
    {
        private int selectedID = 0;
        private int currentPage = 1;
        private int pageSize = 50;

        public GrnHeaderControl()
        {
            InitializeComponent();
        }
        private void GrnHeaderControl_Load(object sender, EventArgs e)
        {
            loadGrnHeaders();

            btnEditGrn.Enabled = false;
            btnAddItems.Enabled = false;
            cmbStatus.SelectedIndex = 0;
        }

        private void btnAddGrn_Click(object sender, EventArgs e)
        {
            GrnHeaderForm form = new GrnHeaderForm(0);

            form.ShowDialog();

            //load grn header data to the datagridview
            loadGrnHeaders();
        }

        private void loadGrnHeaders()
        {
            //load grn header data to the datagridview
            GrnHeaderService service = new GrnHeaderService();

            DataTable dt = service.GetAllGrnHeaders(pageSize, (currentPage - 1) * pageSize);
    
            dgvGrnHeaders.DataSource = dt;
    
            dgvGrnHeaders.Columns["id"].HeaderText = "ID";
            dgvGrnHeaders.Columns["date_submitted"].HeaderText = "Date Submitted";
            dgvGrnHeaders.Columns["invoice_no"].HeaderText = "Invoice No";
            dgvGrnHeaders.Columns["item_count"].HeaderText = "Item Count";
            dgvGrnHeaders.Columns["purchase_price"].HeaderText = "Purchase Price";
            dgvGrnHeaders.Columns["company_name"].HeaderText = "Company Name";
            dgvGrnHeaders.Columns["username"].HeaderText = "Username";
    
            lblPageNo.Text = $"Page {currentPage}";

            dgvGrnHeaders.Columns["id"].Width = 50;

            dgvGrnHeaders.Columns["status"].Visible = false;

        }//load grn headers

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            GrnHeaderService service = new GrnHeaderService();
            //status change
            string selectedStatus = cmbStatus.SelectedItem.ToString();
            //MessageBox.Show($"Selected status: {selectedStatus}");

            int status = 0;
            switch (selectedStatus)
            {
                case "Pending":
                    status = 1;
                    break;
                case "Submitted":
                    status = 2;
                    break;
                case "Canceled":
                    status = 3;
                    break;
            }//switch

            DataTable dt = service.GetGrnHeaderByStatus(status, pageSize, (currentPage - 1) * pageSize);
            dgvGrnHeaders.DataSource = dt;

            dgvGrnHeaders.Columns["id"].HeaderText = "ID";
            dgvGrnHeaders.Columns["date_submitted"].HeaderText = "Date Submitted";
            dgvGrnHeaders.Columns["invoice_no"].HeaderText = "Invoice No";
            dgvGrnHeaders.Columns["item_count"].HeaderText = "Item Count";
            dgvGrnHeaders.Columns["purchase_price"].HeaderText = "Purchase Price";
            dgvGrnHeaders.Columns["company_name"].HeaderText = "Company Name";
            dgvGrnHeaders.Columns["username"].HeaderText = "Username";

            lblPageNo.Text = $"Page {currentPage}";

            dgvGrnHeaders.Columns["id"].Width = 50;

            dgvGrnHeaders.Columns["status"].Visible = false;
        }

        private void dgvGrnHeaders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvGrnHeaders.Rows[e.RowIndex];

                selectedID = Convert.ToInt32(row.Cells["id"].Value);

                int status = Convert.ToInt32(row.Cells["status"].Value);

                if (selectedID > 0 && status == 1) 
                { 
                    btnEditGrn.Enabled = true;
                    btnAddItems.Enabled = true;
                }
            }
        }

        private void btnEditGrn_Click(object sender, EventArgs e)
        {
            GrnHeaderForm form = new GrnHeaderForm(selectedID);

            form.ShowDialog();

            //load grn header data to the datagridview
            loadGrnHeaders();
        }
    }//class
}
