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
    public partial class AdjustmentControl : UserControl
    {
        private int selectedID = 0;
        private int currentPage = 1;
        private int pageSize = 50;
        public AdjustmentControl()
        {
            InitializeComponent();
        }

        private void AdjustmentControl_Load(object sender, EventArgs e)
        {
            ThemeManager.ApplyTheme(this);
            btnAddItems.Enabled = false;
            btnEditAdjustment.Enabled = false;

            cmbStatus.SelectedIndex = 0;

            //load adjustment header
            loadAdjustments();

            lblPageNo.Text = "Page: " + currentPage.ToString();
        }

        private void btnAddAdjustment_Click(object sender, EventArgs e)
        {
            AdjustmentHeaderForm adjustmentHeaderForm = new AdjustmentHeaderForm(0);
            adjustmentHeaderForm.ShowDialog();
        }

        private void dgvAdjustHeader_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvAdjustHeader.Rows[e.RowIndex];

                selectedID = Convert.ToInt32(row.Cells["id"].Value);

                if (selectedID > 0) 
                { 
                    btnAddItems.Enabled = true;
                    btnEditAdjustment.Enabled = true;
                }
            }
        }

        private void btnEditAdjustment_Click(object sender, EventArgs e)
        {
            if (selectedID > 0)
            {
                AdjustmentHeaderForm adjustmentHeaderForm = new AdjustmentHeaderForm(selectedID);
                adjustmentHeaderForm.ShowDialog();
            }
            loadAdjustments();
        }

        private void btnAddItems_Click(object sender, EventArgs e)
        {
            if (selectedID > 0 && cmbStatus.SelectedIndex == 0)
            {
                AdjustmentDetailControl adjustmentDetailControl = new AdjustmentDetailControl(selectedID);

                Main mainForm = (Main)Application.OpenForms["Main"];
                mainForm.loadControl(adjustmentDetailControl);
            }//load detail form
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchAdjustments();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            searchTimer.Stop();
            searchTimer.Start();
        }

        private void searchTimer_Tick(object sender, EventArgs e)
        {
            searchTimer.Stop();

            if (txtSearch.Text.Length > 0)
            {
                searchAdjustments();
            }//has text
            else
            {
                loadAdjustments();
            }
        }//search timer

        private void loadAdjustments()
        {
            AdjustmentHeaderService adjustHeaderService = new AdjustmentHeaderService();

            DataTable headerData = adjustHeaderService.GetAdjustmentByStatus(cmbStatus.SelectedIndex);

            dgvAdjustHeader.DataSource = headerData;

            dgvAdjustHeader.Columns["id"].Visible = false;
            dgvAdjustHeader.Columns["user_id"].Visible = false;
            dgvAdjustHeader.Columns["status"].Visible = false;

            dgvAdjustHeader.Columns["type"].HeaderText = "Type";
            dgvAdjustHeader.Columns["submitted_datetime"].HeaderText = "Date";
            dgvAdjustHeader.Columns["item_count"].HeaderText = "Items";
            dgvAdjustHeader.Columns["purchase_price"].HeaderText = "Pur. Price";
            dgvAdjustHeader.Columns["note"].HeaderText = "Note";
            dgvAdjustHeader.Columns["username"].HeaderText = "User";

        }//load adjustment

        private void searchAdjustments()
        {
            AdjustmentHeaderService adjustHeaderService = new AdjustmentHeaderService();

            DataTable headerData = adjustHeaderService.SearchAdjustmentHeader(txtSearch.Text, cmbStatus.SelectedIndex, pageSize, (currentPage - 1) * pageSize);

            dgvAdjustHeader.DataSource = headerData;

            dgvAdjustHeader.Columns["id"].Visible = false;
            dgvAdjustHeader.Columns["user_id"].Visible = false;
            dgvAdjustHeader.Columns["status"].Visible = false;

            dgvAdjustHeader.Columns["type"].HeaderText = "Type";
            dgvAdjustHeader.Columns["submitted_datetime"].HeaderText = "Date";
            dgvAdjustHeader.Columns["item_count"].HeaderText = "Items";
            dgvAdjustHeader.Columns["purchase_price"].HeaderText = "Pur. Price";
            dgvAdjustHeader.Columns["note"].HeaderText = "Note";
            dgvAdjustHeader.Columns["username"].HeaderText = "User";

            lblPageNo.Text = "Page: " + currentPage.ToString();
            this.selectedID = 0;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            currentPage++;
            searchAdjustments();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 0)
            {
                currentPage--;
                searchAdjustments();
            }
        }
    }//class
}
