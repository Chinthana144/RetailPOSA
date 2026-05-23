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
                        //open add form
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
    }
}
