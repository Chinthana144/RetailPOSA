using RetailPOSA.Models;
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
    public partial class ProfileControl : UserControl
    {
        private int userID = Session.UserID;
        public ProfileControl()
        {
            InitializeComponent();
        }

        private void ProfileControl_Load(object sender, EventArgs e)
        {
            ThemeManager.ApplyTheme(this);
            string userName = Session.UserName;
            int roleID = Session.RoleID;

            fetchUser();

            chkPassword.Checked = false;
            lblProfile.Text = "Welcome, " + userName;
            txtPassword.UseSystemPasswordChar = true;
        }

        private void fetchUser()
        { 
            UserService userService = new UserService();
            DataTable userData = userService.GetUserById(userID);

            lblRole.Text = "Role: " + userData.Rows[0]["role_name"].ToString();
            txtUsername.Text = userData.Rows[0]["username"].ToString();
            txtPassword.Text = userData.Rows[0]["password"].ToString();
        }
        private void chkPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkPassword.Checked;
        }

        private void btnChangeUsername_Click(object sender, EventArgs e)
        {
            UserService userService = new UserService();
            int update = userService.UpdateUserName(userID, txtUsername.Text);

            if (update == 1)
            {
                MessageBox.Show("Username updated successfully!", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else 
            { 
                MessageBox.Show("Username already exists!", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//change name

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            UserService userService = new UserService();
            int update = userService.UpdatePassword(userID,txtPassword.Text);

            if (update == 1)
            {
                MessageBox.Show("Password updated successfully!", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Password update failed!", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }//class
}
