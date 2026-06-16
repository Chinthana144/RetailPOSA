using Org.BouncyCastle.Tls;
using RetailPOSA.Forms;
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

namespace RetailPOSA.DialogBoxes
{
    public partial class PriceChangeHeaderForm : Form
    {
        private int headerID = 0;
        public PriceChangeHeaderForm(int headerID)
        {
            InitializeComponent();

            this.headerID = headerID;
        }

        private void PriceChangeHeaderForm_Load(object sender, EventArgs e)
        {
            ThemeManager.ApplyTheme(this);
            btnPriceChange.Text = headerID > 0 ? "Update Price Change" : "Create Price Change";

            if (headerID > 0)
            {
                loadPriceChange();
            }
        }//load

        private void btnPriceChange_Click(object sender, EventArgs e)
        {
            PriceChangeHeaderService priceChangeService = new PriceChangeHeaderService();
            string submitDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            int userID = Session.UserID;

            if (headerID > 0)
            {
                priceChangeService.UpdatePriceChangeNote(headerID, txtNote.Text);
            }//update
            else
            {
                priceChangeService.InsertPriceChangeHeader(txtNote.Text, submitDate, 0, 0, userID, 0);

                //get last Id
                DataTable dt = priceChangeService.GetLastPriceChangeByUserID(userID);
                headerID = Convert.ToInt32(dt.Rows[0]["id"]);

                PriceChangeDetailControl detailControl = new PriceChangeDetailControl(headerID);
                //load detail control with headerID
                Main mainForm = (Main)Application.OpenForms["Main"];
                mainForm.loadControl(detailControl);
            }
            this.Close();
        }

        private void loadPriceChange()
        {
            if (headerID > 0)
            {
                PriceChangeHeaderService service = new PriceChangeHeaderService();

                DataTable dt = service.GetPriceChangeByID(headerID);

                string note = dt.Rows[0]["note"].ToString();

                txtNote.Text = note;
            }            
        }//load note

        
    }//class
}
