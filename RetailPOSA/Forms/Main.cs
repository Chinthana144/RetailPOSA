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

namespace RetailPOSA.Forms
{
    public partial class Main : Form
    {
        private bool menuOpen = false;

        private Panel selectedPanel;

        private int catalogButtonY = 0;
        private int inventoryButtonY = 0;
        private int saleButtonY = 0;
        private int systemButtonY = 0;

        private int panelHeight = 120;

        private int panel = 1;

        PermissionService permissionService = new PermissionService();
        private int roleID = 0;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            ThemeManager.ApplyTheme(this);

            lblUsername.Text = Session.UserName;
            lblRole.Text = Session.RoleName;
            this.roleID = Session.RoleID;

            pnlSidebar.Dock = DockStyle.Left;

            initializeNavbar();

            loadShop();

            //check Dashboard access
            //dashboard page  = 1
            if (permissionService.CheckPermissionView(roleID, 1))
            {
                DashboardControl uc = new DashboardControl();
                loadControl(uc);
            }
            else
            {
                ProfileControl profileControl = new ProfileControl();
                loadControl(profileControl);
            }
        }//main load

        public void loadControl(UserControl uc)
        {
            pnlContent.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(uc);
        }//load control

        //=========================== Home ========================//
        private void navDashboard_Click(object sender, EventArgs e)
        {
            //dashboard page  = 1
            if (permissionService.CheckPermissionView(roleID, 1))
            {
                DashboardControl uc = new DashboardControl();
                loadControl(uc);
            }
            else
            {
                MessageBox.Show(
                    "Sorry, you don't have access to view this page.",
                    "Access Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                    );
            }//access denied
        }//dashboard
        private void navProfile_Click(object sender, EventArgs e)
        {
            /*
             * every user have access to profile
             * can change password
             */
            ProfileControl uc = new ProfileControl();
            loadControl(uc);
        }//profile
        //========================= Catalog =========================//
        private void navCategories_Click(object sender, EventArgs e)
        {
            //category page  = 3
            if (permissionService.CheckPermissionView(roleID, 3))
            {
                CategoryControl uc = new CategoryControl();
                loadControl(uc);
            }
            else
            {
                MessageBox.Show(
                    "Sorry, you don't have access to view this page.",
                    "Access Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                    );
            }//access denied
        }

        private void navProducts_Click(object sender, EventArgs e)
        {
            //product page  = 4
            if (permissionService.CheckPermissionView(roleID, 4))
            {
                ProductControl uc = new ProductControl();
                loadControl(uc);
            }
            else
            {
                MessageBox.Show(
                    "Sorry, you don't have access to view this page.",
                    "Access Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                    );
            }//access denied
        }//product page

        private void navSuppliers_Click(object sender, EventArgs e)
        {
            //supplier page  = 5
            if (permissionService.CheckPermissionView(roleID, 5))
            {
                SupplierControl uc = new SupplierControl();
                loadControl(uc);
            }
            else
            {
                MessageBox.Show(
                    "Sorry, you don't have access to view this page.",
                    "Access Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                    );
            }//access denied            
        }//supplier page

        //========================= Sales =========================//
        private void navPOS_Click(object sender, EventArgs e)
        {
            //pos page  = 10
            if (permissionService.CheckPermissionView(roleID, 10))
            {
                POSControl uc = new POSControl(0);
                loadControl(uc);
            }
            else
            {
                MessageBox.Show(
                    "Sorry, you don't have access to view this page.",
                    "Access Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                    );
            }//access denied             
        }//pos page

        private void navInvoices_Click(object sender, EventArgs e)
        {
            //invoice page  = 11
            if (permissionService.CheckPermissionView(roleID, 11))
            {
                InvoiceControl uc = new InvoiceControl();
                loadControl(uc);
            }
            else
            {
                MessageBox.Show(
                    "Sorry, you don't have access to view this page.",
                    "Access Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                    );
            }//access denied             
        }//invoice page
        private void navReturn_Click(object sender, EventArgs e)
        {
            //sales return page  = 12
            if (permissionService.CheckPermissionView(roleID, 12))
            {
                SaleReturnHeaderControl uc = new SaleReturnHeaderControl();
                loadControl(uc);
            }
            else
            {
                MessageBox.Show(
                    "Sorry, you don't have access to view this page.",
                    "Access Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                    );
            }//access denied             
        }//return page

        //========================= Inventory =========================//
        private void navGRN_Click(object sender, EventArgs e)
        {
            //grn page  = 6
            if (permissionService.CheckPermissionView(roleID, 6))
            {
                GrnHeaderControl uc = new GrnHeaderControl();
                loadControl(uc);
            }
            else
            {
                MessageBox.Show(
                    "Sorry, you don't have access to view this page.",
                    "Access Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                    );
            }//access denied             
        }//grn page

        private void navInventory_Click(object sender, EventArgs e)
        {
            //inventory page  = 7
            if (permissionService.CheckPermissionView(roleID, 7))
            {
                InventoryControl uc = new InventoryControl();
                loadControl(uc);
            }
            else
            {
                MessageBox.Show(
                    "Sorry, you don't have access to view this page.",
                    "Access Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                    );
            }//access denied             
        }//inventory page
        private void navAdjustment_Click(object sender, EventArgs e)
        {
            //adjustment page  = 8
            if (permissionService.CheckPermissionView(roleID, 8))
            {
                AdjustmentControl uc = new AdjustmentControl();
                loadControl(uc);
            }
            else
            {
                MessageBox.Show(
                    "Sorry, you don't have access to view this page.",
                    "Access Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                    );
            }//access denied             
        }//adjustment page
        private void navPriceChange_Click(object sender, EventArgs e)
        {
            //price change page  = 5
            if (permissionService.CheckPermissionView(roleID, 9))
            {
                PriceChangeHeaderControl uc = new PriceChangeHeaderControl();
                loadControl(uc);
            }
            else
            {
                MessageBox.Show(
                    "Sorry, you don't have access to view this page.",
                    "Access Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                    );
            }//access denied             
        }//price change

        //========================= System =========================//
        private void navReports_Click(object sender, EventArgs e)
        {
            //reports page  = 13
            if (permissionService.CheckPermissionView(roleID, 13))
            {
                ReportControl uc = new ReportControl();
                loadControl(uc);
            }
            else
            {
                MessageBox.Show(
                    "Sorry, you don't have access to view this page.",
                    "Access Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                    );
            }//access denied             
        }//report page
        private void navSettings_Click(object sender, EventArgs e)
        {
            //setting page  = 14
            if (permissionService.CheckPermissionView(roleID, 14))
            {
                SettingControl uc = new SettingControl();
                loadControl(uc);
            }
            else
            {
                MessageBox.Show(
                    "Sorry, you don't have access to view this page.",
                    "Access Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                    );
            }//access denied            
        }//settings page
        private void navUsers_Click(object sender, EventArgs e)
        {
            //users page  = 15
            if (permissionService.CheckPermissionView(roleID, 15))
            {
                UsersControl uc = new UsersControl();
                loadControl(uc);
            }
            else
            {
                MessageBox.Show(
                    "Sorry, you don't have access to view this page.",
                    "Access Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                    );
            }//access denied             
        }//users
        private void navAdminPanel_Click(object sender, EventArgs e)
        {
            if (roleID == 1)
            {
                AdminControl uc = new AdminControl();
                loadControl(uc);
            }
            else
            {
                MessageBox.Show(
                    "Sorry, you don't have access to view this page.",
                    "Access Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                    );
            }//access denied  
        }//admin page

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            //close the application when the main form is closed
            Application.Exit();
        }

        //=========================== Navigation Main Buttons ==========================//

        private void btnNavHome_Click(object sender, EventArgs e)
        {
            initializeNavbar();
            menuOpen = false;
            this.selectedPanel = pnlHome;
            this.panelHeight = 100;
            panel = 1;
            MenuTimer.Start();
        }
        private void btnNavCatalog_Click(object sender, EventArgs e)
        {
            initializeNavbar();
            menuOpen = false;
            this.selectedPanel = pnlCatalog;
            this.panelHeight = 150;
            panel = 2;
            MenuTimer.Start();
        }
        private void btnNavInventory_Click(object sender, EventArgs e)
        {
            initializeNavbar();
            menuOpen = false;
            this.selectedPanel = pnlInventory;
            this.panelHeight = 200;
            panel = 3;
            MenuTimer.Start();
        }
        private void btnNavSales_Click(object sender, EventArgs e)
        {
            initializeNavbar();
            menuOpen = false;
            this.selectedPanel = pnlSale;
            this.panelHeight = 150;
            panel = 4;
            MenuTimer.Start();
        }
        private void btnNavSystem_Click(object sender, EventArgs e)
        {
            initializeNavbar();
            menuOpen = false;
            this.selectedPanel = pnlSystem;
            this.panelHeight = 200;
            panel = 5;
            MenuTimer.Start();
        }
        private void MenuTimer_Tick(object sender, EventArgs e)
        {
            if (menuOpen == false)
            {
                selectedPanel.Height += 10;
                if (selectedPanel.Height >= panelHeight)
                {
                    MenuTimer.Stop();
                    menuOpen = true;
                }
            }
            else
            {
                selectedPanel.Height -= 10;
                if (selectedPanel.Height <= 0)
                {
                    MenuTimer.Stop();
                    menuOpen = false;
                }
            }
            switch (panel)
            {
                case 1: //Home
                    changeLocation(btnNavCatalog, selectedPanel.Height + catalogButtonY);
                    changeLocation(btnNavInventory, selectedPanel.Height + inventoryButtonY);
                    changeLocation(btnNavSales, selectedPanel.Height + saleButtonY);
                    changeLocation(btnNavSystem, selectedPanel.Height + systemButtonY);
                    break;

                case 2: //catalog
                    //changeLocation(btnNavCatalog, selectedPanel.Height + catalogButtonY);
                    changeLocation(btnNavInventory, selectedPanel.Height + inventoryButtonY);
                    changeLocation(btnNavSales, selectedPanel.Height + saleButtonY);
                    changeLocation(btnNavSystem, selectedPanel.Height + systemButtonY);
                    break;

                case 3: //catalog
                    //changeLocation(btnNavCatalog, selectedPanel.Height + catalogButtonY);
                    //changeLocation(btnNavInventory, selectedPanel.Height + inventoryButtonY);
                    changeLocation(btnNavSales, selectedPanel.Height + saleButtonY);
                    changeLocation(btnNavSystem, selectedPanel.Height + systemButtonY);
                    break;

                case 4: //catalog
                    //changeLocation(btnNavCatalog, selectedPanel.Height + catalogButtonY);
                    //changeLocation(btnNavInventory, selectedPanel.Height + inventoryButtonY);
                    //changeLocation(btnNavSales, selectedPanel.Height + saleButtonY);
                    changeLocation(btnNavSystem, selectedPanel.Height + systemButtonY);
                    break;

                default:
                break;
            } 
        }

        private void changeLocation(Button button, int height)
        { 
            button.Location = new Point(button.Location.X, height);
        }

        private void initializeNavbar()
        {
            pnlSidebar.Width = 204;
            pnlContent.Width = pnlContent.Width - 200;
            //panel height
            pnlHome.Height = 0;
            pnlCatalog.Height = 0;
            pnlInventory.Height = 0;
            pnlSale.Height = 0;
            pnlSystem.Height = 0;

            //panel widths
            pnlHome.Width = 200;
            pnlCatalog.Width = 200;
            pnlInventory.Width = 200;
            pnlSale.Width = 200;
            pnlSystem.Width = 200;

            int initx = 2;
            int inity = 120;
            int buttonHeight = 70;

            //position buttons
            btnNavHome.Location = new Point(initx, inity);
            btnNavCatalog.Location = new Point(initx, inity + buttonHeight);
            btnNavInventory.Location = new Point(initx, inity + buttonHeight * 2);
            btnNavSales.Location = new Point(initx, inity + buttonHeight * 3);
            btnNavSystem.Location = new Point(initx, inity + buttonHeight * 4);

            //button width
            btnNavHome.Width = 200;
            btnNavCatalog.Width = 200;
            btnNavInventory.Width = 200;
            btnNavSales.Width = 200;
            btnNavSystem.Width = 200;

            catalogButtonY = inity + buttonHeight;
            inventoryButtonY = inity + buttonHeight * 2;
            saleButtonY = inity + buttonHeight * 3;
            systemButtonY = inity + buttonHeight * 4;

            //panel position
            pnlHome.Location = new Point(initx, btnNavHome.Location.Y + 70);
            pnlCatalog.Location = new Point(initx, btnNavCatalog.Location.Y + 70);
            pnlInventory.Location = new Point(initx, btnNavInventory.Location.Y + 70);
            pnlSale.Location = new Point(initx, btnNavSales.Location.Y + 70);
            pnlSystem.Location = new Point(initx, btnNavSystem.Location.Y + 70);
        }//initialize navbar

        private void loadShop()
        {
            ShopService shopService = new ShopService();

            DataTable shopData = shopService.GetShop();

            if (shopData.Rows.Count != 0)
            {
                string shopLogo = shopData.Rows[0]["shop_logo"].ToString();

                //MessageBox.Show(shopLogo);
                picShopLogo.Image = Image.FromFile(shopLogo);
            }
        }

        
    }//class
}
