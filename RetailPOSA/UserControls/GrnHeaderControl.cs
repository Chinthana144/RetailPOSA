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
        }

        private void btnAddGrn_Click(object sender, EventArgs e)
        {
            GrnHeaderForm form = new GrnHeaderForm();

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
            dgvGrnHeaders.Columns["item_count"].HeaderText = "Item Count";
            dgvGrnHeaders.Columns["purchase_price"].HeaderText = "Purchase Price";
            dgvGrnHeaders.Columns["status"].HeaderText = "Status";
            dgvGrnHeaders.Columns["company_name"].HeaderText = "Company Name";
            dgvGrnHeaders.Columns["username"].HeaderText = "Username";
    
            lblPageNo.Text = $"Page {currentPage}";     

            foreach (DataGridViewRow row in dgvGrnHeaders.Rows)
            {
                if (row.Cells["status"].Value != null)
                {
                    int status = Convert.ToInt32(row.Cells["status"].Value);
                    row.Cells["status"].Value = getStatusText(status);
                }
            }

        }//load grn headers

        private string getStatusText(int status)
        {
            switch (status)
            {
                case 1:
                    return "Pending";
                case 2:
                    return "Approved";
                case 3:
                    return "Rejected";
                default:
                    return "Unknown";
            }
        }
    }//class
}
