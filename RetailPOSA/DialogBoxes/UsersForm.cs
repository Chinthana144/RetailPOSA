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
using System.Xml.Linq;

namespace RetailPOSA.DialogBoxes
{
    public partial class UsersForm : Form
    {
        private Database db = new Database();
        private int userID = 0;

        public UsersForm(int id)
        {
            InitializeComponent();

            userID = id;
        }

        private void UsersForm_Load(object sender, EventArgs e)
        {
            loadRoles();

            loadUserData();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            Users users = new Users();

            users.role_id = Convert.ToInt32(cmbRoles.SelectedValue);
            users.username = txtUsername.Text;
            users.password = txtPassword.Text;

            //check null
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            { 
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UserService service = new UserService();

            if (userID > 0)
            { 
                service.UpdateUser(userID, users.role_id, users.username);
            }
            else
            {
                service.InsertUser(users.role_id, users.username, users.password);
            }

            this.Close();
        }//add user

        private void loadRoles()
        {
            string query = "SELECT * FROM roles ORDER BY id;";

            DataTable dt = db.ExecuteQuery(query);

            cmbRoles.DataSource = dt;

            cmbRoles.DisplayMember = "name";

            cmbRoles.ValueMember = "id";
        }//load roles

        private void loadUserData()
        { 
            UserService service = new UserService();

            DataTable dt = service.GetUserById(userID);

            btnAddUser.Text = "Update User";

            if (dt.Rows.Count > 0)
            {
                //MessageBox.Show(dt.Rows[0]["role_id"].ToString());
                cmbRoles.SelectedValue = Convert.ToInt32(dt.Rows[0]["role_id"].ToString());
                txtUsername.Text = dt.Rows[0]["username"].ToString();

                txtPassword.Visible = false;
                lblPassword.Visible = false;
            }
        }//load user data
    }
}
