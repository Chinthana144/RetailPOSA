using RetailPOSA.DialogBoxes;
using RetailPOSA.Forms;
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

namespace RetailPOSA.UserControls
{
    public partial class AdjustmentDetailControl : UserControl
    {   
        private int adjustmentID = 0;
        private int adjustDetailID = 0;
        public AdjustmentDetailControl(int adjustmentID)
        {
            InitializeComponent();

            this.adjustmentID = adjustmentID;
        }

        private void AdjustmentDetailControl_Load(object sender, EventArgs e)
        {
            loadHeaderDetails();

            loadAdjustmentDetails();

            btnRemove.Enabled = false;
        }

        private void loadHeaderDetails()
        { 
            AdjustmentHeaderService headerService = new AdjustmentHeaderService();

            DataTable headerData = headerService.GetAdjustmentHeaderByID(adjustmentID);

            string submitDate = headerData.Rows[0]["submitted_datetime"].ToString().Substring(0,10);
            string type = headerData.Rows[0]["type"].ToString();
            string note = headerData.Rows[0]["note"].ToString();

            lblDate.Text = "Date: " + submitDate;
            lblType.Text = "Type: " + type;
            lblNote.Text = "Note: " + note;
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            InventoryService inventoryService = new InventoryService();
            if (e.KeyCode == Keys.Enter)
            {
                DataTable result = inventoryService.SearchActiveInventory(txtSearch.Text);

                if (result.Rows.Count > 0)
                {
                    if (result.Rows.Count == 1)
                    {
                        int inventoryID = Convert.ToInt32(result.Rows[0]["id"]);
                        //open add form
                        AdjustmentDetailForm adjustmentDetailForm = new AdjustmentDetailForm(adjustmentID, inventoryID);
                        adjustmentDetailForm.ShowDialog();

                        loadAdjustmentDetails();
                    }
                    else
                    {
                        //open search form
                        AdjustmentProductSearchForm searchForm = new AdjustmentProductSearchForm(txtSearch.Text, adjustmentID);
                        searchForm.ShowDialog();

                        loadAdjustmentDetails();
                    }
                }//has result
                else
                {
                    MessageBox.Show("No results found.", "No Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSearch.Text = "";
                }
            }
        }

        private void loadAdjustmentDetails()
        { 
            AdjustmentDetailService detailService = new AdjustmentDetailService();

            DataTable dt = detailService.GetAdjustmentDetailByHeaderID(adjustmentID);

            dgvAdjustDetail.DataSource = dt;

            dgvAdjustDetail.Columns["id"].Visible = false;
            dgvAdjustDetail.Columns["adjustment_header_id"].Visible = false;
            dgvAdjustDetail.Columns["inventory_id"].Visible = false;
            dgvAdjustDetail.Columns["product_id"].Visible = false;

            dgvAdjustDetail.Columns["barcode"].HeaderText = "Barcode";
            dgvAdjustDetail.Columns["name"].HeaderText = "Product";
            dgvAdjustDetail.Columns["system_qty"].HeaderText = "System Qty";
            dgvAdjustDetail.Columns["physical_qty"].HeaderText = "Physical Qty";
            dgvAdjustDetail.Columns["adjust_qty"].HeaderText = "Adjust Qty";
            dgvAdjustDetail.Columns["average_cost"].HeaderText = "Average Cost";
            dgvAdjustDetail.Columns["total_value"].HeaderText = "Total";

            //get totals
            DataTable totals = detailService.GetAdjustmentDetailTotals(adjustmentID);

            string rowCount = totals.Rows[0]["row_count"].ToString();
            string total = totals.Rows[0]["total"].ToString();

            lblRowCount.Text = "Rows: " + rowCount;
            lblTotal.Text = "Total: " + total;

        }//fetch adjustments by header id

        private void dgvAdjustDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            { 
                DataGridViewRow row = dgvAdjustDetail.Rows[e.RowIndex];
                this.adjustDetailID = Convert.ToInt32(row.Cells["id"].Value);

                if (this.adjustDetailID > 0)
                {
                    //enable buttons
                    btnRemove.Enabled = true;
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (this.adjustDetailID > 0)
            {
                //delete item from detail tables
                AdjustmentDetailService detailService = new AdjustmentDetailService();

                detailService.RemoveAdjustmentDetail(this.adjustDetailID);

                loadAdjustmentDetails();
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            InventoryService inventoryService = new InventoryService();
            AdjustmentHeaderService adjustHeaderService = new AdjustmentHeaderService();
            AdjustmentDetailService adjustDetailService = new AdjustmentDetailService();
            DialogResult result = MessageBox.Show("Do you want to Submit this Adjustment?", "Adjustment Varification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            { 
                DataTable detailData = adjustDetailService.GetAdjustmentDetailByHeaderID(adjustmentID);

                int rowCount = 0;
                decimal total = 0;

                foreach (DataRow row in detailData.Rows)
                {
                    int inventoryID = Convert.ToInt32(row["inventory_id"]);
                    decimal adjustQty = Convert.ToDecimal(row["adjust_qty"]) * (-1); //make it positive

                    //change inventory qty
                    inventoryService.UpdateInventoryQty(inventoryID, adjustQty);

                    //get totals
                    rowCount++;
                    total += Convert.ToDecimal(row["total_value"]);

                }//foreach

                int userID = Session.UserID;
                //update adjustment header
                adjustHeaderService.UpdateAdjustmentHeaderTotals(this.adjustmentID, rowCount, total, userID, 1);

                //load adjustment header control
                AdjustmentControl adjustmentHeaderControl = new AdjustmentControl();
                Main mainForm = (Main)Application.OpenForms["Main"];
                mainForm.loadControl(adjustmentHeaderControl);

            }//said yes
        }
    }//class
}
