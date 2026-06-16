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
        private int tabID = 1;
        public ReportControl()
        {
            InitializeComponent();
        }
        private void ReportControl_Load(object sender, EventArgs e)
        {
            ThemeManager.ApplyTheme(this);
            SalesReportControl uc = new SalesReportControl();
            loadControl(uc);
        }
        private void navRptSales_Click(object sender, EventArgs e)
        {
            tabID = 1;
            SalesReportControl uc = new SalesReportControl();
            loadControl(uc);
        }

        public void loadControl(UserControl uc)
        {
            pnlMain.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(uc);

            switch (this.tabID)
            {
                case 1:
                    navRptSales.BackColor = Color.FromArgb(122, 122, 122, 1);
                    navRptInventory.BackColor = Color.FromArgb(76, 76, 76, 1);
                    navRptPurchase.BackColor = Color.FromArgb(76, 76, 76, 1);
                    navRptFinanacial.BackColor = Color.FromArgb(76, 76, 76, 1);
                break;

                default:
                break;
            }//switch
        }//load control

        
    }//class
}
