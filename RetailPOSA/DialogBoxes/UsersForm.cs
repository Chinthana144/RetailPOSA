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
using System.Xml.Linq;

namespace RetailPOSA.DialogBoxes
{
    public partial class UsersForm : Form
    {
        private Database db = new Database();

        public UsersForm()
        {
            InitializeComponent();
        }

        private void UsersForm_Load(object sender, EventArgs e)
        {
            loadRoles();
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

            service.InsertUser(users.role_id, users.username, users.password);

            this.Close();
        }//add user

        private void loadRoles()
        {
            Database db = new Database();

            string query = "SELECT * FROM roles ORDER BY id;";

            DataTable dt = db.ExecuteQuery(query);

            cmbRoles.DataSource = dt;

            cmbRoles.DisplayMember = "name";

            cmbRoles.ValueMember = "id";
        }//load roles

       
    }
}
