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
            loadTheme();
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

        
        private void loadTheme()
        { 
            GeneralSettingsService settingsService = new GeneralSettingsService();

            string primaryColorName = settingsService.GetColor("primary_color") ?? "#2d2d2d";
            string secondaryColorName = settingsService.GetColor("secondary_color") ?? "#4d4d4d";
            string backColorName = settingsService.GetColor("back_color") ?? "#3d3d3d";
            string foreColorName = settingsService.GetColor("fore_color") ?? "#fefefe";
            string accentColorName = settingsService.GetColor("accent_color") ?? "#b4ef22";
            string successColorName = settingsService.GetColor("success_color") ?? "#23cf17";
            string dangerColorName = settingsService.GetColor("danger_color") ?? "#f52f50";

            Color primaryColor = ColorTranslator.FromHtml(primaryColorName);
            Color secondaryColor = ColorTranslator.FromHtml(secondaryColorName);
            Color backColor = ColorTranslator.FromHtml(backColorName);
            Color foreColor = ColorTranslator.FromHtml(foreColorName);
            Color accentColor = ColorTranslator.FromHtml(accentColorName);
            Color successColor = ColorTranslator.FromHtml(successColorName);
            Color dangerColor = ColorTranslator.FromHtml(dangerColorName);

            this.BackColor = primaryColor;

            foreach (Control ctrl in this.Controls)
            {
                //labels
                if (ctrl is Label)
                {
                    ctrl.BackColor = primaryColor;
                    ctrl.ForeColor = foreColor;
                }
                else if (ctrl is Panel)
                {
                    ctrl.BackColor = backColor;
                    ctrl.ForeColor = foreColor;
                }
                else if (ctrl is Chart)
                {
                    ctrl.BackColor = backColor;
                }
            }//foreach control

            //chart colors
            chrtDailySale.BorderlineColor = secondaryColor;
            ChartArea chartArea = chrtDailySale.ChartAreas[0];
            chartArea.BackColor = primaryColor;

            chartArea.AxisX.LabelStyle.ForeColor = foreColor;
            chartArea.AxisY.LabelStyle.ForeColor = foreColor;

            chartArea.AxisX.LineColor = foreColor;
            chartArea.AxisY.LineColor = foreColor;

            chartArea.AxisX.MajorGrid.LineColor = secondaryColor;
            chartArea.AxisY.MajorGrid.LineColor = secondaryColor;

            chartArea.AxisX.MajorGrid.Enabled = false;

            Legend legend = chrtDailySale.Legends[0];
            legend.Enabled = false;

            Series series = chrtDailySale.Series[0];
            series["PointWidth"] = "0.6";

            //table
            DataGridView dgv = dgvTopProducts;

            dgv.BackgroundColor = backColor;
            dgv.GridColor = secondaryColor;

            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            // Header Style
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersHeight = 40;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = backColor;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = foreColor;

            //cell style
            dgv.DefaultCellStyle.BackColor = backColor;
            dgv.DefaultCellStyle.ForeColor = foreColor;

            dgv.DefaultCellStyle.SelectionBackColor = accentColor;
            dgv.DefaultCellStyle.SelectionForeColor = foreColor;

        }//color theme

        //======================= Timers =====================//
        private void dateTimer_Tick(object sender, EventArgs e)
        {
            dateTimer.Stop();

            string todate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            lblTime.Text = todate;
            dateTimer.Start();
        }

        private void dataFetchTimer_Tick(object sender, EventArgs e)
        {
            dataFetchTimer.Stop();
            loadKPI();
            loadChat();
            loadTopItems();
            dataFetchTimer.Start();
        }
    }//class
}
