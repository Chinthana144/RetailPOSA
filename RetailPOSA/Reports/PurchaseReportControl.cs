using Org.BouncyCastle.Asn1.Cmp;
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
    public partial class PurchaseReportControl : UserControl
    {
        private int selectedID = 0;
        private int currentPage = 1;
        private int pageSize = 50;

        public PurchaseReportControl()
        {
            InitializeComponent();
        }

        private void PurchaseReportControl_Load(object sender, EventArgs e)
        {
            ThemeManager.ApplyTheme(this);
            loadGrnHeaders();
        }//load

        private void dgvGrnHeaders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvGrnHeaders.Rows[e.RowIndex];

                selectedID = Convert.ToInt32(row.Cells["id"].Value);

                int status = Convert.ToInt32(row.Cells["status"].Value);

                if (selectedID > 0 && status == 2)
                {
                    //open report
                    GeneralSettingsService settingsService = new GeneralSettingsService();
                    string reportBasePath = settingsService.GetSettingsValueByKey("report_path");
                    var submittedDate = DateTime.Parse(row.Cells["date_submitted"].Value.ToString());

                    string reportPath = reportBasePath + "\\GRN_report_" + selectedID + "_" + submittedDate.ToString("yyyy_MM_dd") + ".pdf";

                    GRNReport grnReport = new GRNReport();
                    grnReport.Generate(reportPath, selectedID);
                    Process.Start(
                    new ProcessStartInfo(reportPath)
                    {
                        UseShellExecute = true
                    });
                }//open report
            }//has index
        }//cell click

        private void searchTimer_Tick(object sender, EventArgs e)
        {
            searchTimer.Stop();
            loadGrnHeaders();
        }//search

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            searchTimer.Stop();
            searchTimer.Start();
        }

        private void loadGrnHeaders()
        {
            GrnHeaderService grnHeaderService = new GrnHeaderService();

            DataTable dt = grnHeaderService.SearchGrnHeader(txtSearch.Text, "Submitted", pageSize, (currentPage - 1) * pageSize);
            dgvGrnHeaders.DataSource = dt;

            dgvGrnHeaders.Columns["id"].HeaderText = "ID";
            dgvGrnHeaders.Columns["date_submitted"].HeaderText = "Date Submitted";
            dgvGrnHeaders.Columns["invoice_no"].HeaderText = "Invoice No";
            dgvGrnHeaders.Columns["item_count"].HeaderText = "Item Count";
            dgvGrnHeaders.Columns["purchase_price"].HeaderText = "Purchase Price";
            dgvGrnHeaders.Columns["company_name"].HeaderText = "Company Name";
            dgvGrnHeaders.Columns["username"].HeaderText = "Username";

            lblPageNo.Text = $"Page {currentPage}";

            dgvGrnHeaders.Columns["id"].Width = 50;

            dgvGrnHeaders.Columns["supplier_id"].Visible = false;
            dgvGrnHeaders.Columns["supplier_name"].Visible = false;
            dgvGrnHeaders.Columns["date_created"].Visible = false;
            dgvGrnHeaders.Columns["status"].Visible = false;
        }//load submitted GRNs

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                loadGrnHeaders();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            currentPage++;
            loadGrnHeaders();
        }

        
    }//class
}
