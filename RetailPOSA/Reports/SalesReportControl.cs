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
        public SalesReportControl()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            string filePath = @"C:\Users\ASUS\OneDrive\Documents\Reports\DailySales.pdf";

            DailySalesReport salesreport = new DailySalesReport();
            salesreport.Generate(filePath);

            Process.Start(
            new ProcessStartInfo(filePath)
            {
                UseShellExecute = true
            });
        }//test report
    }//clas
}
