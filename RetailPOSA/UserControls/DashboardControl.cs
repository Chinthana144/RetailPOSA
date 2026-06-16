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
using System.Windows.Forms.DataVisualization.Charting;

namespace RetailPOSA.UserControls
{
    public partial class DashboardControl : UserControl
    {
        private string currency = "";
        public DashboardControl()
        {
            InitializeComponent();
        }

        private void DashboardControl_Load(object sender, EventArgs e)
        {
            loadShop();
            loadKPI();
            loadChat();
            loadTopItems();
            dateTimer.Start();       
        }

        public void loadShop()
        { 
            ShopService shopService = new ShopService();

            DataTable shopData = shopService.GetShop();

            string shopName = shopData.Rows[0]["name"].ToString();
            lblShopName.Text = shopName;

            this.currency = shopData.Rows[0]["currency"].ToString();
        }//load shop

        public void loadKPI()
        {
            string today = DateTime.Now.ToString("yyyy-MM-dd");
            InvoiceService invoiceService = new InvoiceService();
            //get daily totals
            DataTable todayData = invoiceService.GetDailyTotal(today);

            string todaySale = todayData.Rows[0]["total_sale"].ToString() ?? "0";
            string invoiceCount = todayData.Rows[0]["invoice_count"].ToString();

            lblTodaySale.Text = currency + ":" + todaySale;
            lblTodayInvoice.Text = "Invoices:" + invoiceCount;

            //month days
            DateTime thisDay = DateTime.Now;
            var firstDay = new DateTime(thisDay.Year, thisDay.Month, 1);
            var lastDay = firstDay.AddMonths(1).AddDays(-1);

            DataTable monthData = invoiceService.GetTotalByDateRange(firstDay.ToString("yyyy-MM-dd"), lastDay.ToString("yyyy-MM-dd"));

            string totalInvoices = monthData.Rows[0]["invoice_count"].ToString();
            string monthSale = monthData.Rows[0]["total_sale"].ToString();
            lblMonthSale.Text = currency +":"+ monthSale;

            //low stock inventory
            InventoryService inventoryService = new InventoryService();
            DataTable inventoryData = inventoryService.GetLowStockCount();

            string lowStock = inventoryData.Rows[0]["low_stock"].ToString();

            lblLowStock.Text = lowStock + " Item(s)";
        }//load KPI

        public void loadChat()
        {
            chrtDailySale.Series.Clear();

            Series sales = new Series();

            sales.ChartType = SeriesChartType.Column;

            //fetch data
            InvoiceService invoiceService = new InvoiceService();
            DataTable chartData = invoiceService.GetChartData();

            foreach (DataRow row in chartData.Rows)
            {
                var date = DateTime.Parse(row["invoice_date"].ToString());
                string xAxis = date.ToString("yyyy-MM-dd").Substring(5,5);

                decimal sale = Convert.ToDecimal(row["total_sale"]);

                sales.Points.AddXY(xAxis, sale);
            }//foreach

            chrtDailySale.Series.Add(sales);

        }//load chart

        private void loadTopItems()
        {
            string today = DateTime.Now.ToString("yyyy-MM-dd");
            string lastDay = DateTime.Parse(today).AddDays(-30).ToString("yyyy-MM-dd");

            InvoiceDetailService detailService = new InvoiceDetailService();

            DataTable topData = detailService.GetTopSellingProducts(lastDay);

            lblTopSaleTitle.Text = "Top selling items since " + lastDay;

            dgvTopProducts.DataSource = topData;

            dgvTopProducts.Columns["count"].HeaderText = "Count";
            dgvTopProducts.Columns["category"].HeaderText = "Category";
            dgvTopProducts.Columns["barcode"].HeaderText = "Barcode";
            dgvTopProducts.Columns["name"].HeaderText = "Product";
            dgvTopProducts.Columns["total_qty"].HeaderText = "Sold Qty";
            dgvTopProducts.Columns["minimum_stock"].HeaderText = "Min Stock";

            dgvTopProducts.Columns["count"].Width = 80;
        }//load top table

        private void dateTimer_Tick(object sender, EventArgs e)
        {
            dateTimer.Stop();
            
            string todate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            lblTime.Text = todate;
            dateTimer.Start();
        }


    }//class
}
