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
        private int selectedId = 0;

        public UsersControl()
        {
            InitializeComponent();
        }

        private void UsersControl_Load(object sender, EventArgs e)
        {
            LoadUserTable();

            btnEditUser.Enabled = false;

        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            UsersForm uf = new UsersForm(0);

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

            dgvUsers.Columns[0].Width = 50;

        }//load users table

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUsers.Rows[e.RowIndex];

                selectedId = Convert.ToInt32(row.Cells["user_id"].Value);

                if (selectedId > 0) { btnEditUser.Enabled = true; }

            }
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (selectedId > 0)
            {
                UsersForm uf = new UsersForm(selectedId);
                uf.ShowDialog();
                LoadUserTable();

                btnEditUser.Enabled = false;
            }
        }
    }//class
}
