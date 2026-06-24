using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailPOSA.Reports.ReportServices
{
    internal class InventoryReportService
    {
        Database db = new Database();

        public DataTable GetCurrentStock()
        {
            string query = "SELECT "+
                "inventory.id, grn_header_id, product_id, initial_qty, current_qty, purchase_price, selling_price, discount, final_price, purchase_total, expiry_date, barcode, name, second_name " +
                "FROM inventory " +
                "INNER JOIN products ON products.id = inventory.product_id " +
                "WHERE current_qty > 0;";

            return db.ExecuteQuery(query);
        }//get current stock

    }//class
}
