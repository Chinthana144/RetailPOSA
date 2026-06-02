using Mysqlx.Crud;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailPOSA.Services
{
    internal class PriceChangeDetailService
    {
        Database db = new Database();

        public int InsertPriceChangeDetail(int headerID, int inventoryID, int productID, decimal qty, decimal oldPrice, decimal sellingPrice, decimal discount, decimal newPrice, decimal totalPrice, int status)
        {
            string query = "INSERT INTO price_change_detail(price_change_header_id, inventory_id, product_id, qty, old_price, selling_price, discount, new_price, total_price, status) " +
                "VALUES(@headerID, @inventoryID, @productID, @qty, @oldPrice, @sellingPrice, @discount, @newPrice, @totalPrice, @status);";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@headerID", headerID);
            parameters.Add("@inventoryID", inventoryID);
            parameters.Add("@productID", productID);
            parameters.Add("@qty", qty);
            parameters.Add("@oldPrice", oldPrice);
            parameters.Add("@sellingPrice", sellingPrice);
            parameters.Add("@discount", discount);
            parameters.Add("@newPrice", newPrice);
            parameters.Add("@totalPrice", totalPrice);
            parameters.Add("@status", status);

            return db.ExecuteNonQuery(query, parameters);
        }//insert

        public int RemovePriceChangeDetail(int id)
        {
            string query = "DELETE FROM price_change_detail WHERE id = @id;";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            return db.ExecuteNonQuery(query, parameters);
        }//remove
        public bool CheckDuplicateInventory(int headerID, int inventoryID)
        {
            string query = "SELECT * FROM price_change_detail WHERE price_change_header_id = @headerID AND inventory_id = @inventoryID;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@headerID", headerID);
            parameters.Add("@inventoryID", inventoryID);

            DataTable dt = db.ExecuteQuery(query, parameters);

            return dt.Rows.Count > 0 ? true : false;
        }

        public DataTable GetPriceChangeDetailByHeaderID(int headerID)
        {
            string query = "SELECT " +
                "price_change_detail.id, price_change_header_id, inventory_id, product_id, " +
                "barcode, products.name, " +
                "qty, selling_price, discount, old_price, new_price, total_price, price_change_detail.status " +                
                "FROM price_change_detail " +
                "INNER JOIN products ON products.id = price_change_detail.product_id " +
                "WHERE price_change_header_id = @headerID;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@headerID", headerID);

            return db.ExecuteQuery(query, parameters);

        }//get details by header id

        public DataTable GetPriceChangeTotalsByHeaderID(int headerID)
        {
            string query = "SELECT COUNT(*) AS row_count, SUM(total_price) AS total_price FROM price_change_detail WHERE price_change_header_id = @headerID;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@headerID", headerID);

            return db.ExecuteQuery(query, parameters);
        }//get totals by header id
    }//class
}
