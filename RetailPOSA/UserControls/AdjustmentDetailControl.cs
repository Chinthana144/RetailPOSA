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
    public partial class AdjustmentDetailControl : UserControl
    {   
        private int adjustmentID = 0;
        public AdjustmentDetailControl(int adjustmentID)
        {
            InitializeComponent();

            this.adjustmentID = adjustmentID;
        }

        private void AdjustmentDetailControl_Load(object sender, EventArgs e)
        {
            loadHeaderDetails();

            loadAdjustmentDetails();
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

                if (result != null)
                {
                    if (result.Rows.Count == 1)
                    {
                        int inventoryID = Convert.ToInt32(result.Rows[0]["id"]);
                        //open add form
                        AdjustmentDetailForm adjustmentDetailForm = new AdjustmentDetailForm(adjustmentID, inventoryID);
                        adjustmentDetailForm.ShowDialog();
                    }
                    else
                    { 
                        //open search form
                    }
                }//has result
                else
                {
                    MessageBox.Show("No result found.", "No Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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



        }//fetch adjustments by header id

    }//class
}
