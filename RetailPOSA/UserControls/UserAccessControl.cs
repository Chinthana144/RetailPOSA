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
    public partial class UserAccessControl : UserControl
    {
        private int roleID = 1;
        private int pageID = 1;
        public UserAccessControl()
        {
            InitializeComponent();
        }

        private void UserAccessControl_Load(object sender, EventArgs e)
        {
            loadRoles();
            loadPages();

            loadRolePermissions();
        }

        private void Role_Click(object sender, EventArgs e)
        { 
            Button btn = (Button)sender;

            int roleID = Convert.ToInt32(btn.Tag); 
            string role = btn.Text;

            this.roleID = roleID;
            lblRoleName.Text = role;
            loadRolePermissions();
        }

        private void Page_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            int pageID = Convert.ToInt32(btn.Tag);
            string pageName = btn.Text;

            this.pageID = pageID;
            lblPageName.Text = pageName;
            loadRolePermissions();
        }

        private void loadRoles()
        {
            UserService userService = new UserService();

            DataTable roles = userService.GetRoles();

            foreach (DataRow row in roles.Rows)
            {
                Button btn = new Button();

                btn.Text = row["name"].ToString();
                btn.Width = 150;
                btn.Height = 40;
                btn.Font = new Font("Calibri", 11);
                btn.ForeColor = Color.White;
                btn.BackColor = Color.FromArgb(112, 112, 90);

                btn.Tag = row["id"];
                btn.Click += Role_Click;

                flpRoles.Controls.Add(btn);
            }//foreach
        }//load roles

        private void loadPages()
        {
            PermissionService permissionService = new PermissionService();
            DataTable pages = permissionService.GetPages();

            foreach (DataRow row in pages.Rows)
            {
                Button btn = new Button();

                btn.Text = row["name"].ToString();
                btn.Width = 120;
                btn.Height = 40;
                btn.Font = new Font("Calibri", 11);
                btn.ForeColor = Color.White;
                btn.BackColor = Color.FromArgb(112, 112, 90);

                btn.Tag = row["id"];
                btn.Click += Page_Click;

                flpPages.Controls.Add(btn);
            }//foreach
        }//load pages

        private void loadRolePermissions()
        {
            PermissionService permissionService = new PermissionService();

            DataTable permissions = permissionService.GetPermissions(roleID, pageID);

            if (permissions.Rows.Count > 0)
            {
                int canView = Convert.ToInt32(permissions.Rows[0]["view"] ?? 0);
                int canAdd = Convert.ToInt32(permissions.Rows[0]["add"] ?? 0);
                int canEdit = Convert.ToInt32(permissions.Rows[0]["edit"] ?? 0);
                int canDelete = Convert.ToInt32(permissions.Rows[0]["remove"] ?? 0);
                int canPrint = Convert.ToInt32(permissions.Rows[0]["print"] ?? 0);

                if (canView == 1) { chkView.Checked = true; } else { chkView.Checked = false; }
                if (canAdd == 1) { chkAdd.Checked = true; } else { chkAdd.Checked = false; }
                if (canEdit == 1) { chkEdit.Checked = true; } else { chkEdit.Checked = false; }
                if (canDelete == 1) { chkDelete.Checked = true; } else { chkDelete.Checked = false; }
                if (canPrint == 1) { chkPrint.Checked = true; } else { chkPrint.Checked = false; }
            }
            else
            { 
                chkView.Checked = false;
                chkAdd.Checked = false;
                chkEdit.Checked = false;
                chkDelete.Checked = false;
                chkPrint.Checked = false;
            }

            //get all permission by role
            DataTable permissionData = permissionService.GetPermissionsByRoleID(roleID);

            dgvPermissions.DataSource = permissionData;

            dgvPermissions.Columns["role_id"].Visible = false;
            dgvPermissions.Columns["page_id"].Visible = false;
            dgvPermissions.Columns["status"].Visible = false;

            dgvPermissions.Columns["name"].HeaderText = "Page";
            dgvPermissions.Columns["view"].HeaderText = "View";
            dgvPermissions.Columns["add"].HeaderText = "Add";
            dgvPermissions.Columns["edit"].HeaderText = "Edit";
            dgvPermissions.Columns["remove"].HeaderText = "Remove";
            dgvPermissions.Columns["print"].HeaderText = "Print";

        }//load role permission

        private void btnUserAccess_Click(object sender, EventArgs e)
        {
            PermissionService permissionService = new PermissionService();

            int canView = chkView.Checked ? 1 : 0;
            int canAdd = chkAdd.Checked ? 1 : 0;
            int canEdit = chkEdit.Checked ? 1 : 0;
            int canDelete = chkDelete.Checked ? 1 : 0;
            int canPrint = chkPrint.Checked ? 1 : 0;

            permissionService.SyncPermission(this.roleID, this.pageID, canView, canAdd, canEdit, canDelete, canPrint, 1);
            
            loadRolePermissions();

            MessageBox.Show("Permission updated successfully!", "Permissions", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvPermissions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PermissionService permissionService = new PermissionService();
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPermissions.Rows[e.RowIndex];
                int roleID = Convert.ToInt32(row.Cells["role_id"].Value);
                int pageID = Convert.ToInt32(row.Cells["page_id"].Value);
                string pageName = row.Cells["name"].Value.ToString();

                lblPageName.Text = pageName;
                this.pageID = pageID;

                //load input
                DataTable permissions = permissionService.GetPermissions(roleID, pageID);

                if (permissions.Rows.Count > 0)
                {
                    int canView = Convert.ToInt32(permissions.Rows[0]["view"] ?? 0);
                    int canAdd = Convert.ToInt32(permissions.Rows[0]["add"] ?? 0);
                    int canEdit = Convert.ToInt32(permissions.Rows[0]["edit"] ?? 0);
                    int canDelete = Convert.ToInt32(permissions.Rows[0]["remove"] ?? 0);
                    int canPrint = Convert.ToInt32(permissions.Rows[0]["print"] ?? 0);

                    if (canView == 1) { chkView.Checked = true; } else { chkView.Checked = false; }
                    if (canAdd == 1) { chkAdd.Checked = true; } else { chkAdd.Checked = false; }
                    if (canEdit == 1) { chkEdit.Checked = true; } else { chkEdit.Checked = false; }
                    if (canDelete == 1) { chkDelete.Checked = true; } else { chkDelete.Checked = false; }
                    if (canPrint == 1) { chkPrint.Checked = true; } else { chkPrint.Checked = false; }
                }
                else
                {
                    chkView.Checked = false;
                    chkAdd.Checked = false;
                    chkEdit.Checked = false;
                    chkDelete.Checked = false;
                    chkPrint.Checked = false;
                }
            }
        }//table cell click
    }//class
}
