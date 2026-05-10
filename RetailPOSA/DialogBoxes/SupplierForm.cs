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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RetailPOSA.DialogBoxes
{
    public partial class SupplierForm : Form
    {
        private int selectedID = 0;
        public SupplierForm(int id)
        {
            InitializeComponent();

            selectedID = id;
        }
        private void SupplierForm_Load(object sender, EventArgs e)
        {
            btnSupplier.Text = selectedID == 0 ? "Add Supplier" : "Update Supplier";

            if (selectedID > 0)
            {
                loadSupplier();
            }
        }//load form

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            SupplierService service = new SupplierService();
            bool status = true;
            if (selectedID == 0)
            {
                //insert supplier
                service.InsertSupplier(txtCompanyName.Text, txtSupplierName.Text, txtContactNo.Text, status);
                this.Close();
            }
            else 
            {
                //update supplier
                service.UpdateSupplier(selectedID, txtCompanyName.Text, txtSupplierName.Text, txtContactNo.Text, status);
                this.Close();
            }
        }

        private void loadSupplier()
        { 
            DataTable dt = new SupplierService().GetSupplierByID(selectedID);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtCompanyName.Text = row["company_name"].ToString();
                txtSupplierName.Text = row["supplier_name"].ToString();
                txtContactNo.Text = row["contact_no"].ToString();
            }
        }
       
    }//class
}
