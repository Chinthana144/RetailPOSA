using RetailPOSA.Models;
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

namespace RetailPOSA.Forms
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            lblUsername.Text = Session.UserName;
            lblRole.Text = Session.RoleName;

            if (Session.RoleName == "Admin")
            {
                btnNavAdmin.Visible = true;
            }
            else {
                btnNavAdmin.Visible = false;
            }
        }

        public void loadControl(UserControl uc)
        { 
            pnlContent.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(uc);
        }//load control

        private void btnNavCategories_Click(object sender, EventArgs e)
        {
            CategoryControl uc = new CategoryControl();
            loadControl(uc);
        }

        private void btnNavProducts_Click(object sender, EventArgs e)
        {
            ProductControl pc = new ProductControl();
            loadControl(pc);
        }//products

        private void btnNavSuppliers_Click(object sender, EventArgs e)
        {
            SupplierControl uc = new SupplierControl();
            loadControl(uc);
        }//suppliers

        private void btnNavGRN_Click(object sender, EventArgs e)
        {
            GrnHeaderControl uc = new GrnHeaderControl();
            loadControl(uc);
        }//grn

        private void btnNavInventory_Click(object sender, EventArgs e)
        {
            InventoryControl uc = new InventoryControl();
            loadControl(uc);
        }

        private void btnNavAdjustment_Click(object sender, EventArgs e)
        {
            AdjustmentControl uc = new AdjustmentControl();
            loadControl(uc);
        }

        private void btnNavPOS_Click(object sender, EventArgs e)
        {
            POSControl uc = new POSControl();
            loadControl(uc);
        }

        private void btnNavInvoice_Click(object sender, EventArgs e)
        {
            InvoiceControl uc = new InvoiceControl();
            loadControl(uc);
        }

        private void btnNavSettings_Click(object sender, EventArgs e)
        {
            SettingControl uc = new SettingControl();
            loadControl(uc);
        }      

        private void btnNavUsers_Click_1(object sender, EventArgs e)
        {
            UsersControl uc = new UsersControl();
            loadControl(uc);
        }

        private void btnNavAdmin_Click(object sender, EventArgs e)
        {
            AdminControl uc = new AdminControl();
            loadControl(uc);
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            //close the application when the main form is closed
            Application.Exit();
        }

    }//class
}
