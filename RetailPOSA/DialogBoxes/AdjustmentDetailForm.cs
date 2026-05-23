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

namespace RetailPOSA.DialogBoxes
{
    public partial class AdjustmentDetailForm : Form
    {
        private int adjustmentHeaderID = 0;
        private int inventoryID = 0;
        private int productID = 0;
        private decimal systemQty = 0;
        private decimal averageCost = 0;
        public AdjustmentDetailForm(int adjustmentHeaderID, int inventoryID)
        {
            InitializeComponent();

            this.adjustmentHeaderID = adjustmentHeaderID;
            this.inventoryID = inventoryID;
        }

        private void AdjustmentDetailForm_Load(object sender, EventArgs e)
        {
            loadInventory();
        }

        private void loadInventory()
        { 
            InventoryService inventoryService = new InventoryService();

            DataTable inventoryData = inventoryService.GetInventoryByID(this.inventoryID);

            this.productID = Convert.ToInt32(inventoryData.Rows[0]["product_id"]);
            string barcode = inventoryData.Rows[0]["barcode"].ToString();
            string product = inventoryData.Rows[0]["name"].ToString();
            this.systemQty = Convert.ToDecimal(inventoryData.Rows[0]["current_qty"]);
            decimal purchaseTotal = Convert.ToDecimal(inventoryData.Rows[0]["purchase_total"]);
            decimal initialQty = Convert.ToDecimal(inventoryData.Rows[0]["initial_qty"]);

            decimal averageCost = purchaseTotal / initialQty;
            this.averageCost = averageCost;

            lblBarcode.Text = "Barcode: " + barcode;
            lblProductName.Text = "Product: " + product;

            txtPhysicalQty.Text = systemQty.ToString();

            lblSystemQty.Text = "System Qty: " + systemQty.ToString();
            lblAverageCost.Text = "Average Cost : " + averageCost.ToString();

        }

        private void txtPhysicalQty_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtPhysicalQty.Text ?? "0", out decimal result))
            {
                //calculate adjust qty
                decimal adjustQty = result - systemQty;

                decimal totalValue = adjustQty * this.averageCost;

                lblAdjustQty.Text = "Adjust Qty: " + adjustQty.ToString();
                lblTotalValue.Text = "Total Value: " + totalValue.ToString();
            }
            else
            {
                MessageBox.Show("Invalid number input.", "Error Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPhysicalQty.Text = "";
                return;
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            AdjustmentDetailService service = new AdjustmentDetailService();
            if (decimal.TryParse(txtPhysicalQty.Text, out decimal result))
            { 
                decimal adjustQty = result - systemQty;
                decimal totalValue = adjustQty * this.averageCost;
                service.InsertAdjustmentDetail(this.adjustmentHeaderID, this.inventoryID, this.productID, this.systemQty, result, adjustQty, this.averageCost, totalValue, 1);

                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid number input.", "Error Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPhysicalQty.Text = "";
                return;
            }
        }
    }//class
}
