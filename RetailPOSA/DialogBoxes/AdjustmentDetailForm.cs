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
    public partial class AdjustmentDetailForm : Form
    {
        private int adjustmentHeaderID = 0;
        private int inventoryID = 0;
        public AdjustmentDetailForm(int adjustmentHeaderID, int inventoryID)
        {
            InitializeComponent();

            this.adjustmentHeaderID = adjustmentHeaderID;
            this.inventoryID = inventoryID;
        }

        private void AdjustmentDetailForm_Load(object sender, EventArgs e)
        {

        }
    }//class
}
