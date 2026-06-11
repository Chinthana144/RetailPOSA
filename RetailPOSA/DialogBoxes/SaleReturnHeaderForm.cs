using RetailPOSA.Forms;
using RetailPOSA.Models;
using RetailPOSA.Services;
using RetailPOSA.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RetailPOSA.DialogBoxes
{
    public partial class SaleReturnHeaderForm : Form
    {
        private int returnHeaderID = 0;
        private string invoiceNo = string.Empty;
        public SaleReturnHeaderForm(string invoiceNumber, int returnHeaderID)
        {
            InitializeComponent();
            this.invoiceNo = invoiceNumber;
            this.returnHeaderID = returnHeaderID;
        }//constructor

        private void SaleReturnHeaderForm_Load(object sender, EventArgs e)
        {
            cmbReturnType.SelectedIndex = 0;
        }

        private void btnAddSalesReturn_Click(object sender, EventArgs e)
        {
            //check invoice no
            InvoiceService invoiceService = new InvoiceService();

            DataTable invoiceData = invoiceService.GetInvoiceByInvoiceNo(txtInvoiceNo.Text.Trim());
            if (invoiceData.Rows.Count > 0)
            {
                int userID = Session.UserID;
                int invoiceID = Convert.ToInt32(invoiceData.Rows[0]["id"]);
                string returnType = cmbReturnType.SelectedItem.ToString();
                string reason = txtReason.Text.Trim();
                string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                SaleReturnHeaderService headerService = new SaleReturnHeaderService();

                //check update
                if (returnHeaderID > 0)
                {
                    headerService.UpdateSaleReturnInvoice(returnHeaderID, invoiceID, now, returnType, reason, userID, 0);
                }//update
                else
                {
                    headerService.InsertSaleReturnHeader(invoiceID, now, returnType, reason, 0, 0, userID, 0);

                    //load return detail control
                    DataTable lastHeaderData = headerService.GetLastSaleReturnByUserID(userID);

                    int headerID = Convert.ToInt32(lastHeaderData.Rows[0]["id"]);
                    SaleReturnDetailControl detailControl = new SaleReturnDetailControl(headerID);
                    //load sale return detail
                    Main mainForm = (Main)Application.OpenForms["Main"];
                    mainForm.loadControl(detailControl);
                }//insert

                this.Close();
                
            }//has invoice
            else {
                MessageBox.Show("Invalid invoice number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }//btnAddSalesReturn_Click

        private void loadReturnData()
        {
            if (returnHeaderID > 0)
            {
                SaleReturnHeaderService headerService = new SaleReturnHeaderService();

                DataTable headerData = headerService.GetSaleReturnHeaderByID(returnHeaderID);

                string invoiceNo = headerData.Rows[0]["invoice_no"].ToString();
                string returnType = headerData.Rows[0]["return_type"].ToString();
                string reason = headerData.Rows[0]["reason"].ToString();
                
                txtInvoiceNo.Text = invoiceNo;
                cmbReturnType.Text = returnType;
                txtReason.Text = reason;

                btnAddSalesReturn.Text = "Update Sales Return";
            }//has return header
        }//load return data
    }//class
}
