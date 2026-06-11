using RetailPOSA.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RetailPOSA.UserControls
{
    public partial class AdminControl : UserControl
    {
        private string shopLogoPath = "";
        private string receiptLogoPath = "";

        public AdminControl()
        {
            InitializeComponent();
        }

        private void AdminControl_Load(object sender, EventArgs e)
        {
            //create logo folder if not exist
            string logoFolder = Path.Combine(Application.StartupPath, "Logos");
            if (!Directory.Exists(logoFolder))
            {
                Directory.CreateDirectory(logoFolder);
            }

            //load general settings
            GeneralSettingsControl uc = new GeneralSettingsControl();
            loadControl(uc);
        }//load

        private void btnLoadShop_Click(object sender, EventArgs e)
        {
            ShopControl uc = new ShopControl();
            loadControl(uc);
        }

        private void btnLoadPaymethods_Click(object sender, EventArgs e)
        {
            PaymethodControl uc = new PaymethodControl();
            loadControl(uc);
        }

        private void btnGeneralSettings_Click(object sender, EventArgs e)
        {
            GeneralSettingsControl uc = new GeneralSettingsControl();
            loadControl(uc);
        }

        private void loadControl(UserControl uc)
        {
            pnlMain.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(uc);
        }

    }//class
}
