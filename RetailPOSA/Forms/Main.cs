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
    
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            lblUsername.Text = Session.UserName;
            lblRole.Text = Session.RoleName;

            pnlSidebar.Dock = DockStyle.Left;

            initializeNavbar();

            loadShop();
        }

        public void loadControl(UserControl uc)
        {
            pnlContent.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(uc);
        }//load control

        //========================= Navigation =========================//
        private void navCategories_Click(object sender, EventArgs e)
        {
            CategoryControl uc = new CategoryControl();
            loadControl(uc);
        }

        private void navProducts_Click(object sender, EventArgs e)
        {
            ProductControl uc = new ProductControl();
            loadControl(uc);
        }

        private void navSuppliers_Click(object sender, EventArgs e)
        {
            SupplierControl uc = new SupplierControl();
            loadControl(uc);
        }
        private void navPOS_Click(object sender, EventArgs e)
        {
            POSControl uc = new POSControl();
            loadControl(uc);
        }

        private void navInvoices_Click(object sender, EventArgs e)
        {
            InvoiceControl uc = new InvoiceControl();
            loadControl(uc);
        }

        private void navGRN_Click(object sender, EventArgs e)
        {
            GrnHeaderControl uc = new GrnHeaderControl();
            loadControl(uc);
        }

        private void navInventory_Click(object sender, EventArgs e)
        {
            InventoryControl uc = new InventoryControl();
            loadControl(uc);
        }
        private void navAdjustment_Click(object sender, EventArgs e)
        {
            AdjustmentControl uc = new AdjustmentControl();
            loadControl(uc);
        }
        private void navSettings_Click(object sender, EventArgs e)
        {
            SettingControl uc = new SettingControl();
            loadControl(uc);
        }
        private void navUsers_Click(object sender, EventArgs e)
        {
            UsersControl uc = new UsersControl();
            loadControl(uc);
        }
        private void navAdminPanel_Click(object sender, EventArgs e)
        {
            AdminControl uc = new AdminControl();
            loadControl(uc);
        }

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
            this.panelHeight = 100;
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

            string shopLogo = shopData.Rows[0]["shop_logo"].ToString();

            //MessageBox.Show(shopLogo);
            picShopLogo.Image = Image.FromFile(shopLogo);
        }

        
    }//class
}
