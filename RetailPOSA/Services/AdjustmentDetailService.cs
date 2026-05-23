using RetailPOSA.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailPOSA.Services
{
    internal class AdjustmentDetailService
    {
        Database db = new Database();
        public int InsertAdjustmentDetail(int headerID, int inventoryID, int productID, decimal systemQty, decimal physicalQty, decimal adjustQty, decimal averageCost, decimal totalValue, int status)
        {
            string query = "INSERT INTO adjustment_detail(adjustment_header_id, inventory_id, product_id, system_qty, physical_qty, adjust_qty, average_cost, total_value, status) " +
                "VALUES(@headerID,@inventoryID,@productID,@systemQty,@physicalQty,@adjustQty,@averageCost,@totalValue,@status);";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@headerID", headerID);
            parameters.Add("@inventoryID", inventoryID);
            parameters.Add("@productID", productID);
            parameters.Add("@systemQty", systemQty);
            parameters.Add("@physicalQty", physicalQty);
            parameters.Add("@adjustQty", adjustQty);
            parameters.Add("@averageCost", averageCost);
            parameters.Add("@totalValue", totalValue);
            parameters.Add("@status", status);

            return db.ExecuteNonQuery(query, parameters);
        }//insert adjuetment detail

        public DataTable GetAdjustmentDetailByHeaderID(int headerID)
        { 
            string query = "SELECT "+
                "barcode, name, " +
                "adjustment_detail.id, adjustment_header_id, inventory_id, product_id, " +
                "system_qty, physical_qty, adjust_qty, average_cost, total_value " +
                "FROM adjustment_detail " +
                "INNER JOIN products ON products.id =  adjustment_detail.product_id "+
                "WHERE adjustment_header_id = @headerID;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@headerID", headerID);

            return db.ExecuteQuery(query, parameters);
        }//get details by header id

    }//class
}
