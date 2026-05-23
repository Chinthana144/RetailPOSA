using RetailPOSA.Forms;
using RetailPOSA.Models;
using RetailPOSA.Services;
using RetailPOSA.UserControls;
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
    public partial class AdjustmentHeaderForm : Form
    {
        private int adjustmentID = 0;
        public AdjustmentHeaderForm(int adjustmentID)
        {
            InitializeComponent();

            this.adjustmentID = adjustmentID;

            btnAdjustment.Text = adjustmentID > 0 ? "Create Adjustment" : "Update Adjustment";
        }

        private void AdjustmentHeaderForm_Load(object sender, EventArgs e)
        {
            cmbAdjustmentType.SelectedIndex = 0;

            loadHeaderData();
        }

        private void btnAdjustment_Click(object sender, EventArgs e)
        {
            AdjustmentHeaderService adjustmentService = new AdjustmentHeaderService();
            string submitDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            int userID = Session.UserID;

            //status = 0 pending
            int status = 0;

            if (adjustmentID > 0)
            {
                //update adjustment
                adjustmentService.UpdateAdjustmentHeader(adjustmentID, cmbAdjustmentType.Text, txtNote.Text);
            }
            else
            {
                adjustmentService.InsertAdjustmentHeader(cmbAdjustmentType.Text, submitDate, 0, 0, txtNote.Text, userID, status);

                //get adjustment
                DataTable adjustmentData = adjustmentService.GetLastAdjustmentByUser(userID);

                int newAdjustmentHeaderID = Convert.ToInt32(adjustmentData.Rows[0]["id"]);

                AdjustmentDetailControl adjustmentDetailControl = new AdjustmentDetailControl(newAdjustmentHeaderID);
                //load Adjustment Detail
                Main mainForm = (Main)Application.OpenForms["Main"];
                mainForm.loadControl(adjustmentDetailControl);
            }

            this.Close();
        }

        private void loadHeaderData()
        {
            
            if (this.adjustmentID > 0)
            {
                AdjustmentHeaderService adjustmentService = new AdjustmentHeaderService();

                DataTable headerData = adjustmentService.GetAdjustmentHeaderByID(adjustmentID);

                string type = headerData.Rows[0]["type"].ToString();
                string note = headerData.Rows[0]["note"].ToString();

                cmbAdjustmentType.Text = type;
                txtNote.Text = note;

            }
        }//load header data if exists

    }//class
}
