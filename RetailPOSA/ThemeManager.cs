using RetailPOSA.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RetailPOSA
{
    public static class ThemeManager
    {
        public static void ApplyTheme(Control parent)
        {
            //get colors
            GeneralSettingsService settingsService = new GeneralSettingsService();

            string primaryColorName = settingsService.GetColor("primary_color") ?? "#2d2d2d";
            string secondaryColorName = settingsService.GetColor("secondary_color") ?? "#4d4d4d";
            string backColorName = settingsService.GetColor("back_color") ?? "#3d3d3d";
            string foreColorName = settingsService.GetColor("fore_color") ?? "#fefefe";
            string accentColorName = settingsService.GetColor("accent_color") ?? "#b4ef22";
            string successColorName = settingsService.GetColor("success_color") ?? "#23cf17";
            string dangerColorName = settingsService.GetColor("danger_color") ?? "#f52f50";

            Color primaryColor = ColorTranslator.FromHtml(primaryColorName);
            Color secondaryColor = ColorTranslator.FromHtml(secondaryColorName);
            Color backColor = ColorTranslator.FromHtml(backColorName);
            Color foreColor = ColorTranslator.FromHtml(foreColorName);
            Color accentColor = ColorTranslator.FromHtml(accentColorName);
            Color successColor = ColorTranslator.FromHtml(successColorName);
            Color dangerColor = ColorTranslator.FromHtml(dangerColorName);

            //parent color
            parent.BackColor = primaryColor;

            foreach (Control ctrl in parent.Controls)
            {
                //labels
                if (ctrl is Label)
                {
                    ctrl.BackColor = primaryColor;
                    ctrl.ForeColor = foreColor;
                }
                //text box
                else if (ctrl is TextBox)
                {
                    ctrl.BackColor = secondaryColor;
                    ctrl.ForeColor = foreColor;
                }
                //combo box
                else if (ctrl is ComboBox cmb)
                {
                    cmb.BackColor = secondaryColor;
                    cmb.ForeColor = foreColor;

                    cmb.FlatStyle = FlatStyle.Flat;
                }
                //button
                else if (ctrl is Button btn)
                {
                    btn.BackColor = backColor;
                    btn.ForeColor = foreColor;

                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderColor = accentColor;
                }
                //DataGridView
                else if (ctrl is DataGridView dgv)
                {
                    dgv.BackgroundColor = secondaryColor;

                    dgv.BorderStyle = BorderStyle.None;
                    dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

                    dgv.ColumnHeadersDefaultCellStyle.BackColor = secondaryColor;
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = foreColor;

                    dgv.DefaultCellStyle.BackColor = secondaryColor;
                    dgv.DefaultCellStyle.ForeColor = foreColor;

                    dgv.DefaultCellStyle.SelectionBackColor = accentColor;
                    dgv.DefaultCellStyle.SelectionForeColor = foreColor;
                }

                //apply for child
                if (ctrl.HasChildren)
                { 
                    ApplyTheme(ctrl);
                }
            }//foreach control

        }//apply theme

    }//class
}
