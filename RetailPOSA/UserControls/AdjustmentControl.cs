using RetailPOSA.DialogBoxes;
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
        public AdjustmentControl()
        {
            InitializeComponent();
        }

        private void AdjustmentControl_Load(object sender, EventArgs e)
        {
            cmbStatus.SelectedIndex = 0;
        }

        private void btnAddAdjustment_Click(object sender, EventArgs e)
        {
            AdjustmentHeaderForm adjustmentHeaderForm = new AdjustmentHeaderForm();
            adjustmentHeaderForm.ShowDialog();
        }

        private void loadAdjustments()
        { 
            
        }//load adjustment
        
    }//class
}
