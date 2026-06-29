using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using RetailPOSA.Reports.PDFs;
using RetailPOSA.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RetailPOSA.Reports
{
    public partial class SalesReportControl : UserControl
    {
        private string startDate = DateTime.Now.ToString("yyyy-MM-dd");
        private string endDate = DateTime.Now.ToString("yyyy-MM-dd");
        public SalesReportControl()
        {
            InitializeComponent();
        }
        private void SalesReportControl_Load(object sender, EventArgs e)
        {
            ThemeManager.ApplyTheme(this);
            //hide
            calStartDate.Visible = false;
            calEndDate.Visible = false;
            txtStartDate.Text = startDate;
            txtEndDate.Text = endDate;
        }
        private void btnTest_Click(object sender, EventArgs e)
        {
            string filePath = @"C:\Users\ASUS\OneDrive\Documents\Reports\DailySales.pdf";

            DailySalesReport salesreport = new DailySalesReport();
            salesreport.Generate(filePath, txtStartDate.Text, txtEndDate.Text);

            Process.Start(
            new ProcessStartInfo(filePath)
            {
                UseShellExecute = true
            });
        }//test report

        private void txtStartDate_MouseUp(object sender, MouseEventArgs e)
        {
            calStartDate.Visible = true;
        }

        private void calStartDate_DateSelected(object sender, DateRangeEventArgs e)
        {
            string selectedDate = calStartDate.SelectionStart.ToString("yyyy-MM-dd");

            this.startDate = selectedDate;
            txtStartDate.Text = selectedDate;
            calStartDate.Visible = false;
        }

        private void calStartDate_MouseLeave(object sender, EventArgs e)
        {
            calStartDate.Visible=false;
        }

        private void txtEndDate_Click(object sender, EventArgs e)
        {
            calEndDate.Visible = true;
        }

        private void calEndDate_DateSelected(object sender, DateRangeEventArgs e)
        {
            string selectedDate = calEndDate.SelectionStart.ToString("yyyy-MM-dd");

            this.endDate = selectedDate;
            txtEndDate.Text = selectedDate;
            calEndDate.Visible = false;
        }

        private void calEndDate_MouseLeave(object sender, EventArgs e)
        {
            calEndDate.Visible=false;
        }

        //=========================== Report Buttons =========================//
        private void btnDailySalesPDF_Click(object sender, EventArgs e)
        {
            string filePath = @"C:\Users\ASUS\OneDrive\Documents\Reports\DailySales.pdf";

            DailySalesReport salesreport = new DailySalesReport();
            salesreport.Generate(filePath, txtStartDate.Text, txtEndDate.Text);

            Process.Start(
            new ProcessStartInfo(filePath)
            {
                UseShellExecute = true
            });
        }

        private void btnDailySummaryPDF_Click(object sender, EventArgs e)
        {
            //get file path
            GeneralSettingsService settingsService = new GeneralSettingsService();
            string reportBasePath = settingsService.GetSettingsValueByKey("report_path");
            string reportPath = reportBasePath + "\\Daily_Summary_" + txtStartDate.Text + "_" + txtEndDate.Text + ".pdf";

            DailySummaryReport summaryReport = new DailySummaryReport();
            summaryReport.Generate(reportPath, txtStartDate.Text, txtEndDate.Text);

            Process.Start(
            new ProcessStartInfo(reportPath)
            {
                UseShellExecute = true
            });
        }//summary report

        private void btnUserSalePDF_Click(object sender, EventArgs e)
        {
            //get file path
            GeneralSettingsService settingsService = new GeneralSettingsService();
            string reportBasePath = settingsService.GetSettingsValueByKey("report_path");
            string reportPath = reportBasePath + "\\User_Sales_" + txtStartDate.Text + "_" + txtEndDate.Text + ".pdf";

            UserSalesReport userSalesReport = new UserSalesReport();
            userSalesReport.Generate(reportPath, txtStartDate.Text, txtEndDate.Text);

            Process.Start(
            new ProcessStartInfo(reportPath)
            {
                UseShellExecute = true
            });
        }//user sales report
    }//clas
}
