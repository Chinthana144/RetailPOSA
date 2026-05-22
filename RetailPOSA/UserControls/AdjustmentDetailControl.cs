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
    }
}
