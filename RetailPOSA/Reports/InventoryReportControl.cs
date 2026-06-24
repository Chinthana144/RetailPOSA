using RetailPOSA.Reports.PDFs;
using RetailPOSA.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RetailPOSA.Reports
{
    public partial class InventoryReportControl : UserControl
    {
        private string startDate = DateTime.Now.ToString("yyyy-MM-dd");
        private string endDate = DateTime.Now.ToString("yyyy-MM-dd");
        public InventoryReportControl()
        {
            InitializeComponent();
        }

        private void InventoryReportControl_Load(object sender, EventArgs e)
        {
            ThemeManager.ApplyTheme(this);
            //hide
            calStartDate.Visible = false;
            calEndDate.Visible = false;
            txtStartDate.Text = startDate;
            txtEndDate.Text = endDate;
        }

        private void txtStartDate_Click(object sender, EventArgs e)
        {
            calStartDate.Visible = true;
        }
        private void txtEndDate_Click(object sender, EventArgs e)
        {
            calEndDate.Visible = true;
        }
        private void calStartDate_MouseLeave(object sender, EventArgs e)
        {
            calStartDate.Visible = false;
        }
        private void calEndDate_MouseLeave(object sender, EventArgs e)
        {
            calEndDate.Visible = false;
        }

        private void calStartDate_DateSelected(object sender, DateRangeEventArgs e)
        {
            string selectedDate = calStartDate.SelectionStart.ToString("yyyy-MM-dd");

            this.startDate = selectedDate;
            txtStartDate.Text = selectedDate;
            calStartDate.Visible = false;
        }

        private void calEndDate_DateSelected(object sender, DateRangeEventArgs e)
        {
            string selectedDate = calEndDate.SelectionStart.ToString("yyyy-MM-dd");

            this.endDate = selectedDate;
            txtEndDate.Text = selectedDate;
            calEndDate.Visible=false;
        }
        //============================= Reports buttons ===========================//
        private void btnCurrentStockPDF_Click(object sender, EventArgs e)
        {
            string today = DateTime.Now.ToString("yyyy-MM-dd");
            //get file path
            GeneralSettingsService settingsService = new GeneralSettingsService();
            string reportBasePath = settingsService.GetSettingsValueByKey("report_path");
            string reportPath = reportBasePath + "\\Current_Stock"+today+".pdf";

            CurrentStockReport currentStockReport = new CurrentStockReport();
            currentStockReport.Generate(reportPath);

            Process.Start(
            new ProcessStartInfo(reportPath)
            {
                UseShellExecute = true
            });
        }//current stock report
    }//class
}
