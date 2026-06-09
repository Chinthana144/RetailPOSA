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
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using RetailPOSA.Reports.PDFs;

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
    }//clas
}
