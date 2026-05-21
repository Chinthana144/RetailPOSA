using RetailPOSA.Models;
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
        private Panel openedPanel;

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

            //panel height
            pnlHome.Height = 0;
            pnlCatalog.Height = 0;
            pnlInventory.Height = 0;
            pnlSale.Height = 0;
            pnlSystem.Height = 0;

            int initx = 200;
            int inity = 120;
            int buttonHeight = 70;

            //position buttons
            btnNavHome.Location = new Point(initx, inity);
            btnNavCatalog.Location = new Point(initx, inity+ buttonHeight);
            btnNavInventory.Location = new Point(initx, inity+ buttonHeight * 2);
            btnNavSales.Location = new Point(initx, inity + buttonHeight * 3);
            btnNavSystem.Location = new Point(initx, inity + buttonHeight * 4);

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
        }

        public void loadControl(UserControl uc)
        { 
            pnlContent.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(uc);
        }//load control

        private void btnNavCategories_Click(object sender, EventArgs e)
        {
            CategoryControl uc = new CategoryControl();
            loadControl(uc);
        }

        private void btnNavProducts_Click(object sender, EventArgs e)
        {
            ProductControl pc = new ProductControl();
            loadControl(pc);
        }//products

        private void btnNavSuppliers_Click(object sender, EventArgs e)
        {
            SupplierControl uc = new SupplierControl();
            loadControl(uc);
        }//suppliers

        private void btnNavGRN_Click(object sender, EventArgs e)
        {
            GrnHeaderControl uc = new GrnHeaderControl();
            loadControl(uc);
        }//grn

        private void btnNavAdjustment_Click(object sender, EventArgs e)
        {
            AdjustmentControl uc = new AdjustmentControl();
            loadControl(uc);
        }

        private void btnNavPOS_Click(object sender, EventArgs e)
        {
            POSControl uc = new POSControl();
            loadControl(uc);
        }

        private void btnNavInvoice_Click(object sender, EventArgs e)
        {
            InvoiceControl uc = new InvoiceControl();
            loadControl(uc);
        }

        private void btnNavSettings_Click(object sender, EventArgs e)
        {
            SettingControl uc = new SettingControl();
            loadControl(uc);
        }      

        private void btnNavUsers_Click_1(object sender, EventArgs e)
        {
            UsersControl uc = new UsersControl();
            loadControl(uc);
        }

        private void btnNavAdmin_Click(object sender, EventArgs e)
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
            this.selectedPanel = pnlHome;
            this.panelHeight = 100;
            panel = 1;
            MenuTimer.Start();
        }
        private void btnNavCatalog_Click(object sender, EventArgs e)
        {
            this.selectedPanel = pnlCatalog;
            this.panelHeight = 180;
            panel = 2;
            MenuTimer.Start();
        }
        private void btnNavInventory_Click(object sender, EventArgs e)
        {
            this.selectedPanel = pnlInventory;
            this.panelHeight = 240;
            panel = 3;
            MenuTimer.Start();
        }
        private void btnNavSales_Click(object sender, EventArgs e)
        {
            this.selectedPanel = pnlSale;
            this.panelHeight = 120;
            panel = 4;
            MenuTimer.Start();
        }
        private void btnNavSystem_Click(object sender, EventArgs e)
        {
            this.selectedPanel = pnlSystem;
            this.panelHeight = 240;
            panel = 5;
            MenuTimer.Start();
        }

        private void MenuTimer_Tick(object sender, EventArgs e)
        {
            if (openedPanel != null && openedPanel.Height >= 0)
            {
                openedPanel.Height = 0;
            }
            if (menuOpen == false)
            {
                selectedPanel.Height += 10;
                if (selectedPanel.Height >= panelHeight)
                {
                    MenuTimer.Stop();
                    menuOpen = true;
                    openedPanel = selectedPanel;
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

        
    }//class
}
