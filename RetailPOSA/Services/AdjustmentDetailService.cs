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
        public int InsertAdjustmentDetail(int headerID, int inventoryID, int productID, decimal qty, decimal purchasePrice, decimal sellingPrice, decimal discount, decimal finalPrice, decimal purchaseTotal, string expireDate, int status)
        {
            string query = "INSERT INTO adjustment_detail(adjustment_header_id, inventory_id, product_id, qty, purchase_price, selling_price, discount, final_price, purchase_total, expire_date, status) "+
                "VALUES(" +
                "@headerID,@inventoryID,@productID,@qty,@purchasePrice,@sellingPrice,@discount,@finalPrice,@purchaseTotal,@expireDate,@status);";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@headerID", headerID);
            parameters.Add("@inventoryID", inventoryID);
            parameters.Add("@productID", productID);
            parameters.Add("@qty", qty);
            parameters.Add("@purchasePrice", purchasePrice);
            parameters.Add("@sellingPrice", sellingPrice);
            parameters.Add("@finalPrice", finalPrice);
            parameters.Add("@purchaseTotal", purchaseTotal);
            parameters.Add("@expireDate", expireDate);
            parameters.Add("@status", status);

            return db.ExecuteNonQuery(query, parameters);
        }//insert adjuetment detail

        public DataTable GetAdjustmentDetailByHeaderID(int headerID)
        { 
            string query = "SELECT "+
                "adjustment_detail.id, adjustment_header_id, inventory_id, product_id, "+
                "qty, purchase_price, selling_price, discount, final_price, purchase_total, expire_date, " +
                "products.barcode, products.name " +
                "FROM adjustment_detail " +
                "INNER JOIN products ON products.id =  adjustment_detail.product_id "+
                "WHERE adjustment_header_id = @headerID;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@headerID", headerID);

            return db.ExecuteQuery(query, parameters);
        }//get details by header id

    }//class
}
