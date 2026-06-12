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
    public partial class GeneralSettingsControl : UserControl
    {
        private GeneralSettingsService settingService = new GeneralSettingsService();
        public GeneralSettingsControl()
        {
            InitializeComponent();
        }

        private void GeneralSettingsControl_Load(object sender, EventArgs e)
        {
            loadSettings();
        }//load

        //=========================== Settings =========================//
        private void btnStockType_Click(object sender, EventArgs e)
        {
            int status = chkStockType.Checked ? 1 : 0;
            settingService.SyncSetting("stock_type", cmbStockType.Text, status);
            MessageBox.Show("Stock Added/Changed Successfully", "Stock Type", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }//stock type
        private void btnReportPath_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtReportPath.Text))
            {
                int status = chkReportPath.Checked ? 1 : 0;
                settingService.SyncSetting("report_path", txtReportPath.Text, status);
                MessageBox.Show(
                    "Report Path added successfully!",
                    "Report Path",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else {
                MessageBox.Show("Please enter valid input.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }//report path
        private void btnReceiptPrinter_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtReceiptPrinter.Text))
            {
                int status = chkReceiptPrinter.Checked ? 1 : 0;
                settingService.SyncSetting("receipt_printer", txtReceiptPrinter.Text, status);
                MessageBox.Show(
                    "Receipt Printer added successfully!",
                    "Receipt Printer",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please enter valid input.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }//receipt printer
        private void btnBarcodePrinter_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBarcodePrinter.Text))
            {
                int status = chkBarcodePrinter.Checked ? 1 : 0;
                settingService.SyncSetting("barcode_printer", txtBarcodePrinter.Text, status);
                MessageBox.Show(
                    "Barcode Printer added successfully!",
                    "Barcode Printer",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please enter valid input.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }//barcode printer
        private void btnAutobackup_Click(object sender, EventArgs e)
        {
            string backupStatus = chkAutoBackup.Checked ? "true" : "false";
            int status = chkAutoBackup.Checked? 1 : 0;
            settingService.SyncSetting("auto_backup", backupStatus, status);
            MessageBox.Show(
                    "Backup Status changed successfully!",
                    "Auto Backup",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }//auto backup
        private void btnBackupPath_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBackupPath.Text))
            {
                int status = chkBackupPath.Checked ? 1 : 0;
                settingService.SyncSetting("backup_path", txtBackupPath.Text, status);
                MessageBox.Show(
                    "Backup Path added successfully!",
                    "Backup Path",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please enter valid input.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }//backup path
        private void btnBackupFrequency_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBackupFrequency.Text))
            {
                int status = chkBackupFrequency.Checked ? 1 : 0;
                settingService.SyncSetting("backup_frequency", txtBackupFrequency.Text, status);
                MessageBox.Show(
                    "Backup Frequency added successfully!",
                    "Backup Path",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please enter valid input.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }//backup frequency
        private void btnNegativeStock_Click(object sender, EventArgs e)
        {
            string negativeStatus = chkNegativeStock.Checked ? "true" : "false";
            int status = chkNegativeStock.Checked ? 1 : 0;
            settingService.SyncSetting("negative_stock", negativeStatus, status);
            MessageBox.Show(
                    "Negative Stock Status changed successfully!",
                    "Negative Stock",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }
        private void btnSecondName_Click(object sender, EventArgs e)
        {
            string negativeStatus = chkSecondName.Checked ? "true" : "false";
            int status = chkSecondName.Checked ? 1 : 0;
            settingService.SyncSetting("second_name", negativeStatus, status);
            MessageBox.Show(
                    "Second Name Status changed successfully!",
                    "Negative Stock",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        //=========================== Get path ===========================//
        private void btnGetReportPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();

            folderBrowser.Description = "Select Report path";
            folderBrowser.ShowNewFolderButton = true;
            DialogResult result = folderBrowser.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrEmpty(folderBrowser.SelectedPath))
            { 
                string chosenPath = folderBrowser.SelectedPath;
                txtReportPath.Text = chosenPath;
            }
        }
        private void btnGetBackupPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();

            folderBrowser.Description = "Select Report path";
            folderBrowser.ShowNewFolderButton = true;
            DialogResult result = folderBrowser.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrEmpty(folderBrowser.SelectedPath))
            {
                string chosenPath = folderBrowser.SelectedPath;
                txtBackupPath.Text = chosenPath;
            }
        }

        //========================= Color Select ==========================//
        private void btnPrimaryColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorSelector = new ColorDialog();

            DialogResult result = colorSelector.ShowDialog();

            if (result == DialogResult.OK)
            {
                string hexColor = ColorTranslator.ToHtml(colorSelector.Color);
                pnlPrimaryColor.BackColor = ColorTranslator.FromHtml(hexColor);
                txtPrimaryColor.Text = hexColor;

                lblPrimaryColor.BackColor = ColorTranslator.FromHtml(hexColor);
                lblSecondarColor.BackColor = ColorTranslator.FromHtml(hexColor);
            }
        }//primary color
        private void btnSecondaryColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorSelector = new ColorDialog();

            DialogResult result = colorSelector.ShowDialog();

            if (result == DialogResult.OK)
            {
                string hexColor = ColorTranslator.ToHtml(colorSelector.Color);
                pnlSecondaryColor.BackColor = ColorTranslator.FromHtml(hexColor);
                txtSecondaryColor.Text = hexColor;

                lblPrimaryColor.ForeColor = ColorTranslator.FromHtml(hexColor);
                lblSecondarColor.ForeColor = ColorTranslator.FromHtml(hexColor);
            }
        }//secondary color
        private void btnSelectBackColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorSelector = new ColorDialog();

            DialogResult result = colorSelector.ShowDialog();

            if (result == DialogResult.OK)
            {
                string hexColor = ColorTranslator.ToHtml(colorSelector.Color);
                pnlBackColor.BackColor = ColorTranslator.FromHtml(hexColor);
                txtBackColor.Text = hexColor;

                btnBackColor.BackColor = ColorTranslator.FromHtml(hexColor);
                btnForeColor.BackColor = ColorTranslator.FromHtml(hexColor);
            }
        }//back color
        private void btnSelectForeColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorSelector = new ColorDialog();

            DialogResult result = colorSelector.ShowDialog();

            if (result == DialogResult.OK)
            {
                string hexColor = ColorTranslator.ToHtml(colorSelector.Color);
                pnlForeColor.BackColor = ColorTranslator.FromHtml(hexColor);
                txtForeColor.Text = hexColor;

                btnBackColor.ForeColor = ColorTranslator.FromHtml(hexColor);
                btnForeColor.ForeColor = ColorTranslator.FromHtml(hexColor);
            }
        }
        private void btnSelectAccentColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorSelector = new ColorDialog();
            DialogResult result = colorSelector.ShowDialog();
            if (result == DialogResult.OK)
            {
                string hexColor = ColorTranslator.ToHtml(colorSelector.Color);
                pnlAccentColor.BackColor = ColorTranslator.FromHtml(hexColor);
                txtAccentColor.Text = hexColor;
            }
        }
        private void btnSelectSuccessColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorSelector = new ColorDialog();
            DialogResult result = colorSelector.ShowDialog();
            if (result == DialogResult.OK)
            {
                string hexColor = ColorTranslator.ToHtml(colorSelector.Color);
                pnlSuccessColor.BackColor = ColorTranslator.FromHtml(hexColor);
                txtSuccessColor.Text = hexColor;
            }
        }
        private void btnSelectDangerColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorSelector = new ColorDialog();
            DialogResult result = colorSelector.ShowDialog();
            if (result == DialogResult.OK)
            {
                string hexColor = ColorTranslator.ToHtml(colorSelector.Color);
                pnlDangerColor.BackColor = ColorTranslator.FromHtml(hexColor);
                txtDangerColor.Text = hexColor;
            }
        }

        //============================= Buttons =============================//
        private void btnSavePrimaryColor_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPrimaryColor.Text))
            {
                GeneralSettingsService settingService = new GeneralSettingsService();
                int status = chkPrimaryColor.Checked ? 1 : 0;
                settingService.SyncSetting("primary_color", txtPrimaryColor.Text, status);
                MessageBox.Show(
                    "Primary Color added successfully!",
                    "System Colors",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else {
                MessageBox.Show("Please enter valid input.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void btnSaveSecondoryColor_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSecondaryColor.Text))
            {
                GeneralSettingsService settingService = new GeneralSettingsService();
                int status = chkSecondaryColor.Checked ? 1 : 0;
                settingService.SyncSetting("secondary_color", txtSecondaryColor.Text, status);
                MessageBox.Show(
                    "Secondary Color added successfully!",
                    "System Colors",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please enter valid input.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnBackColor_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBackColor.Text))
            {
                GeneralSettingsService settingService = new GeneralSettingsService();
                int status = chkBackColor.Checked ? 1 : 0;
                settingService.SyncSetting("back_color", txtBackColor.Text, status);
                MessageBox.Show(
                    "Back Color added successfully!",
                    "System Colors",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please enter valid input.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnForeColor_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtForeColor.Text))
            {
                GeneralSettingsService settingService = new GeneralSettingsService();
                int status = chkForeColor.Checked ? 1 : 0;
                settingService.SyncSetting("fore_color", txtForeColor.Text, status);
                MessageBox.Show(
                    "Fore Color added successfully!",
                    "System Colors",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please enter valid input.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnAccentColor_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtAccentColor.Text))
            {
                GeneralSettingsService settingService = new GeneralSettingsService();
                int status = chkAccentColor.Checked ? 1 : 0;
                settingService.SyncSetting("accent_color", txtAccentColor.Text, status);
                MessageBox.Show(
                    "Accent Color added successfully!",
                    "System Colors",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please enter valid input.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnSuccessColor_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSuccessColor.Text))
            {
                GeneralSettingsService settingService = new GeneralSettingsService();
                int status = chkSuccessColor.Checked ? 1 : 0;
                settingService.SyncSetting("success_color", txtSuccessColor.Text, status);
                MessageBox.Show(
                    "Success Color added successfully!",
                    "System Colors",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please enter valid input.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnDangerColor_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDangerColor.Text))
            {
                GeneralSettingsService settingService = new GeneralSettingsService();
                int status = chkDangerColor.Checked ? 1 : 0;
                settingService.SyncSetting("danger_color", txtDangerColor.Text, status);
                MessageBox.Show(
                    "Danger Color added successfully!",
                    "System Colors",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please enter valid input.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //========================== Load Settings ==========================//
        private void loadSettings()
        {
            DataTable settingsData = settingService.GetAllSettings();

            if (settingsData.Rows.Count > 0)
            {
                int invalidSettingCount = 0;
                foreach (DataRow row in settingsData.Rows)
                {
                    string settingKey = row["settings_key"].ToString();
                    switch (settingKey)
                    {
                        case "stock_type":
                            cmbStockType.Text = row["settings_value"].ToString();
                            chkStockType.Checked = Convert.ToInt32(row["status"]) == 1 ? true : false;
                        break;
                        case "report_path":
                            txtReportPath.Text = row["settings_value"].ToString();
                            chkReportPath.Checked = Convert.ToInt32(row["status"]) == 1 ? true : false;
                            break;
                        case "receipt_printer":
                            txtReceiptPrinter.Text = row["settings_value"].ToString();
                            chkReceiptPrinter.Checked = Convert.ToInt32(row["status"]) == 1 ? true : false;
                            break;
                        case "barcode_printer":
                            txtBarcodePrinter.Text = row["settings_value"].ToString();
                            chkBarcodePrinter.Checked = Convert.ToInt32(row["status"]) == 1 ? true : false;
                            break;
                        case "auto_backup":
                            chkAutoBackup.Checked = Convert.ToInt32(row["status"]) == 1 ? true : false;
                            break;
                        case "backup_path":
                            txtBackupPath.Text = row["settings_value"].ToString();
                            chkBackupPath.Checked = Convert.ToInt32(row["status"]) == 1 ? true : false;
                            break;
                        case "backup_frequency":
                            txtBackupFrequency.Text = row["settings_value"].ToString();
                            chkBackupFrequency.Checked = Convert.ToInt32(row["status"]) == 1 ? true : false;
                            break;
                        case "negative_stock":
                            chkNegativeStock.Checked = Convert.ToInt32(row["status"]) == 1 ? true : false;
                            break;
                        case "second_name":
                            chkSecondName.Checked = Convert.ToInt32(row["status"]) == 1 ? true : false;
                            break;
                        case "primary_color":
                            pnlPrimaryColor.BackColor = ColorTranslator.FromHtml(row["settings_value"].ToString());
                            txtPrimaryColor.Text = row["settings_value"].ToString();
                            chkPrimaryColor.Checked = Convert.ToInt32(row["status"]) == 1 ? true : false;
                            break;
                        case "secondary_color":
                            pnlSecondaryColor.BackColor = ColorTranslator.FromHtml(row["settings_value"].ToString());
                            txtSecondaryColor.Text = row["settings_value"].ToString();
                            chkSecondaryColor.Checked = Convert.ToInt32(row["status"]) == 1 ? true : false;
                            break;
                        case "back_color":
                            pnlBackColor.BackColor = ColorTranslator.FromHtml(row["settings_value"].ToString());
                            txtBackColor.Text = row["settings_value"].ToString();
                            chkBackColor.Checked = Convert.ToInt32(row["status"]) == 1 ? true : false;
                            break;
                        case "fore_color":
                            pnlForeColor.BackColor = ColorTranslator.FromHtml(row["settings_value"].ToString());
                            txtForeColor.Text = row["settings_value"].ToString();
                            chkForeColor.Checked = Convert.ToInt32(row["status"]) == 1 ? true : false;
                            break;
                        case "accent_color":
                            pnlAccentColor.BackColor = ColorTranslator.FromHtml(row["settings_value"].ToString());
                            txtAccentColor.Text = row["settings_value"].ToString();
                            chkAccentColor.Checked = Convert.ToInt32(row["status"]) == 1 ? true : false;
                            break;
                        case "success_color":
                            pnlSuccessColor.BackColor = ColorTranslator.FromHtml(row["settings_value"].ToString());
                            txtSuccessColor.Text = row["settings_value"].ToString();
                            chkSuccessColor.Checked = Convert.ToInt32(row["status"]) == 1 ? true : false;
                            break;
                        case "danger_color":
                            pnlDangerColor.BackColor = ColorTranslator.FromHtml(row["settings_value"].ToString());
                            txtDangerColor.Text = row["settings_value"].ToString();
                            chkDangerColor.Checked = Convert.ToInt32(row["status"]) == 1 ? true : false;
                            break;
                        default:
                            invalidSettingCount++;
                            break;
                    }
                }//foreach
                if (invalidSettingCount > 0)
                {
                    MessageBox.Show("There are " + invalidSettingCount + " Settings, please check", "Invelid Settings", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }//has data
            else
            {
                MessageBox.Show("There is no setting found, please add settings.", "Null Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }//load settings
    }//class
}
