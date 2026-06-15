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
    public partial class InvoiceControl : UserControl
    {
        private int currentPage = 1;
        private int pageSize = 50;
        public InvoiceControl()
        {
            InitializeComponent();
        }

        private void InvoiceControl_Load(object sender, EventArgs e)
        {
            loadInvoices();
            lblPageNo.Text = $"Page {currentPage}";
        }

        private void loadInvoices()
        {
            InvoiceService invoiceService = new InvoiceService();

            int offset = (currentPage - 1) * pageSize;
            DataTable headerData = invoiceService.GetInvoiceHeader(pageSize, offset);

            dgvInvoices.DataSource = headerData;

            dgvInvoices.Columns["id"].HeaderText = "ID";
            dgvInvoices.Columns["issued_datetime"].HeaderText = "Date";
            dgvInvoices.Columns["invoice_no"].HeaderText = "Invoice No";
            dgvInvoices.Columns["item_count"].HeaderText = "Count";
            dgvInvoices.Columns["total"].HeaderText = "Sale";
            dgvInvoices.Columns["discounts"].HeaderText = "Discount";
            dgvInvoices.Columns["sub_total"].HeaderText = "Total";
            dgvInvoices.Columns["paid_amount"].HeaderText = "Paid";
            dgvInvoices.Columns["balance"].HeaderText = "Balance";
            dgvInvoices.Columns["paymethod"].HeaderText = "Pay Method";
            dgvInvoices.Columns["username"].HeaderText = "User";

            dgvInvoices.Columns["id"].Width = 50;
        }



        private void btnNext_Click(object sender, EventArgs e)
        {
            currentPage++;
            loadInvoices();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 0)
            { 
                currentPage--;
                loadInvoices();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            searchTimer.Stop();
            searchTimer.Start();
        }

        private void searchTimer_Tick(object sender, EventArgs e)
        {
            searchTimer.Stop();

            if (txtSearch.Text.Trim() != "")
            {
                searchInvoices(txtSearch.Text);
            }
            else
            {
                loadInvoices();
            }

        }

        private void searchInvoices(string searchTerm)
        { 
            InvoiceService invoiceService = new InvoiceService();
            DataTable dt = invoiceService.SearchProducts(searchTerm);

            dgvInvoices.DataSource = dt;

            dgvInvoices.Columns["id"].HeaderText = "ID";
            dgvInvoices.Columns["issued_date"].HeaderText = "Date";
            dgvInvoices.Columns["invoice_no"].HeaderText = "Invoice No";
            dgvInvoices.Columns["item_count"].HeaderText = "Count";
            dgvInvoices.Columns["total"].HeaderText = "Sale";
            dgvInvoices.Columns["discounts"].HeaderText = "Discount";
            dgvInvoices.Columns["sub_total"].HeaderText = "Total";
            dgvInvoices.Columns["paid_amount"].HeaderText = "Paid";
            dgvInvoices.Columns["balance"].HeaderText = "Balance";
            dgvInvoices.Columns["paymethod"].HeaderText = "Pay Method";
            dgvInvoices.Columns["username"].HeaderText = "User";

            dgvInvoices.Columns["id"].Width = 50;
        }
    }//class
}
