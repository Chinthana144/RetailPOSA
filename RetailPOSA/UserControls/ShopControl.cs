using RetailPOSA.DialogBoxes;
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
    public partial class ShopControl : UserControl
    {
        int selectedID = 0;
        public ShopControl()
        {
            InitializeComponent();
        }

        private void ShopControl_Load(object sender, EventArgs e)
        {
            loadShops();
        }

        private void btnAddShop_Click(object sender, EventArgs e)
        {
            ShopForm shopForm = new ShopForm(0);
            shopForm.ShowDialog();

            loadShops();
        }

        private void dgvShops_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            { 
                DataGridViewRow row = dgvShops.Rows[e.RowIndex];

                int shopID = Convert.ToInt32(row.Cells["id"].Value);
                this.selectedID = shopID;

                ShopForm shopForm = new ShopForm(shopID);
                shopForm.ShowDialog();

                loadShops();
            }   
        }//cell click

        private void loadShops()
        { 
            ShopService shopService = new ShopService();

            DataTable shopsData = shopService.GetAllShops();

            dgvShops.DataSource = shopsData;

        }

        
    }//class
}
