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
    public partial class DashboardControl : UserControl
    {
        public DashboardControl()
        {
            InitializeComponent();
        }

        private void DashboardControl_Load(object sender, EventArgs e)
        {
            loadShop();
            loadKPI();
            dateTimer.Start();       
        }

        public void loadShop()
        { 
            ShopService shopService = new ShopService();

            DataTable shopData = shopService.GetShop();

            string shopName = shopData.Rows[0]["name"].ToString();
            lblShopName.Text = shopName;
        }//load shop

        public void loadKPI()
        {
            string today = DateTime.Now.ToString("yyyy-MM-dd");
            InvoiceService invoiceService = new InvoiceService();
            //get daily totals
            DataTable todayData = invoiceService.GetDailyTotal(today);

            string todaySale = todayData.Rows[0]["total_sale"].ToString() ?? "0";
            string invoiceCount = todayData.Rows[0]["invoice_count"].ToString();

            lblTodaySale.Text = todaySale;
            lblTodayInvoice.Text = invoiceCount;

            //month days
            DateTime thisDay = DateTime.Now;
            var firstDay = new DateTime(thisDay.Year, thisDay.Month, 1);
            var lastDay = firstDay.AddMonths(1).AddDays(-1);

            MessageBox.Show(lastDay.ToString());

        }//load KPI

        private void dateTimer_Tick(object sender, EventArgs e)
        {
            dateTimer.Stop();
            
            string todate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            lblTime.Text = todate;
            dateTimer.Start();
        }
    }//class
}
