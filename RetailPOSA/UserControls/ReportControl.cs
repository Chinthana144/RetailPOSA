using RetailPOSA.Reports;
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
    public partial class ReportControl : UserControl
    {
        public ReportControl()
        {
            InitializeComponent();
        }
        private void ReportControl_Load(object sender, EventArgs e)
        {
            SalesReportControl uc = new SalesReportControl();
            loadControl(uc);
        }
        private void navRptSales_Click(object sender, EventArgs e)
        {
            SalesReportControl uc = new SalesReportControl();
            loadControl(uc);
        }

        public void loadControl(UserControl uc)
        {
            pnlMain.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(uc);
        }//load control

        
    }//class
}
