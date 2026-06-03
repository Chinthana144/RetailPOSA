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

        public bool CheckDuplicateInventory(int headerID, int inventoryID)
        {
            string query = "SELECT * FROM adjustment_detail WHERE adjustment_header_id = @headerID AND inventory_id = @inventoryID;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@headerID", headerID);
            parameters.Add("@inventoryID", inventoryID);

            DataTable dt = db.ExecuteQuery(query, parameters);

            return dt.Rows.Count > 0 ? true : false;
        }

        public DataTable GetAdjustmentDetailTotals(int adjustmentHeaderID)
        {
            string query = "SELECT "+
                "COUNT(*) AS row_count, SUM(total_value) as total "+
                "FROM adjustment_detail "+
                "WHERE adjustment_header_id = @adjustmentHeaderID;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@adjustmentHeaderID", adjustmentHeaderID);

            return db.ExecuteQuery(query, parameters);
        }

        public int RemoveAdjustmentDetail(int adjustmentDetailID)
        {
            string query = "DELETE FROM adjustment_detail WHERE id = @adjustmentDetailID;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@adjustmentDetailID", adjustmentDetailID);

            return db.ExecuteNonQuery(query, parameters);
        }

    }//class
}
