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
    public partial class SettingControl : UserControl
    {
        public SettingControl()
        {
            InitializeComponent();
        }

        private void SettingControl_Load(object sender, EventArgs e)
        {
            ThemeManager.ApplyTheme(this);
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            UsersControl uc = new UsersControl();
            loadControl(uc);
        }

        private void loadControl(UserControl uc)
        {
            pnlMain.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(uc);
        }//load control

        private void btnUserAccess_Click(object sender, EventArgs e)
        {
            UserAccessControl uc = new UserAccessControl();
            loadControl(uc);
        }
    }//class
}
