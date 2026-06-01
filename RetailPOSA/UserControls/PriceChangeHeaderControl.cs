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
    public partial class PriceChangeHeaderControl : UserControl
    {
        private int selectedID = 0;
        private int currentPage = 1;
        private int pageSize = 50;

        public PriceChangeHeaderControl()
        {
            InitializeComponent();
        }

        private void PriceChangeHeaderControl_Load(object sender, EventArgs e)
        {
            cmbStatus.SelectedIndex = 0;

            btnAddItems.Enabled = false;
            btnEditPriceChange.Enabled = false;

            loadPriceChanges();
        }

        private void btnAddPriceChange_Click(object sender, EventArgs e)
        {
            PriceChangeHeaderForm headerForm = new PriceChangeHeaderForm(0);
            headerForm.ShowDialog();
        }

        private void dgvChangeHeader_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvChangeHeader.Rows[e.RowIndex];

                selectedID = Convert.ToInt32(row.Cells["id"].Value);

                if (selectedID > 0)
                {
                    btnAddItems.Enabled = true;
                    btnEditPriceChange.Enabled = true;
                }
            }//has index
        }//dgv cell clicked

        private void btnEditPriceChange_Click(object sender, EventArgs e)
        {
            if (selectedID > 0)
            {
                PriceChangeHeaderForm headerForm = new PriceChangeHeaderForm(selectedID);
                headerForm.ShowDialog();
            }
        }//show edit form

        private void loadPriceChanges()
        {
            PriceChangeHeaderService headerService = new PriceChangeHeaderService();

            DataTable headerData = headerService.SearchPriceChangeHeader("", cmbStatus.SelectedIndex, currentPage, (currentPage - 1)*pageSize);

            dgvChangeHeader.DataSource = headerData;

            dgvChangeHeader.Columns["user_id"].Visible = false;
            dgvChangeHeader.Columns["status"].Visible = false;

            dgvChangeHeader.Columns["id"].HeaderText = "ID";
            dgvChangeHeader.Columns["price_change_no"].HeaderText = "Price Change No";
            dgvChangeHeader.Columns["submitted_datetime"].HeaderText = "Date";
            dgvChangeHeader.Columns["item_count"].HeaderText = "Count";
            dgvChangeHeader.Columns["total_price"].HeaderText = "Total";
            dgvChangeHeader.Columns["username"].HeaderText = "User";
        }

        
    }//class
}
