using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RetailPOSA.DialogBoxes;
using RetailPOSA.Services;

namespace RetailPOSA.UserControls
{
    public partial class UsersControl : UserControl
    {
        public UsersControl()
        {
            InitializeComponent();
        }

        private void UsersControl_Load(object sender, EventArgs e)
        {
            LoadUserTable();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            UsersForm uf = new UsersForm();

            uf.ShowDialog();

            LoadUserTable();
            //uf.Dispose();
        }

        private void LoadUserTable()
        { 
            UserService userService = new UserService();
            DataTable usersTable = userService.GetAllUsers();
            // Assuming you have a DataGridView named dgvUsers
            dgvUsers.DataSource = usersTable;

            dgvUsers.Columns[0].HeaderText = "ID";
            dgvUsers.Columns[1].HeaderText = "Role";
            dgvUsers.Columns[2].HeaderText = "Username";

        }//load users table

    }//class
}
