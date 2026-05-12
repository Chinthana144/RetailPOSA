using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailPOSA.Services
{
    internal class InventoryService
    {
        Database db = new Database();
        public int InsertInventory(int grnHeaderID, int productID, int initialQty, int currentQty, decimal purchasePrice, decimal sellingPrice, decimal discount, decimal finalPrice, decimal purchaseTotal, DateTime expiryDate, bool status)
        {
            string query = "INSERT INTO inventory(grn_header_id, product_id, initial_qty, current_qty, purchase_price, selling_price, discount, final_price, purchase_total, expiry_date, status) " +
                "VALUES(@grn_header_id, @product_id, @initial_qty, @current_qty, @purchase_price, @selling_price, @discount, @final_price, @purchase_total, @expiry_date, @status);";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@grn_header_id", grnHeaderID);
            parameters.Add("@product_id", productID);
            parameters.Add("@initial_qty", initialQty);
            parameters.Add("@current_qty", currentQty);
            parameters.Add("@purchase_price", purchasePrice);
            parameters.Add("@selling_price", sellingPrice);
            parameters.Add("@discount", discount);
            parameters.Add("@final_price", finalPrice);
            parameters.Add("@purchase_total", purchaseTotal);
            parameters.Add("@expiry_date", expiryDate);
            parameters.Add("@status", status);

            return db.ExecuteNonQuery(query, parameters);
        }//insert inventory

        public DataTable GetInventory(int limit, int offset)
        {
            string query = "SELECT inventory.id, grn_header_id, product_id, " +
                "barcode, products.name, second_name, initial_qty, current_qty, purchase_price, selling_price, discount, final_price " +
                "FROM inventory " +
                "INNER JOIN products ON products.id = inventory.product_id " +
                "LIMIT @limit OFFSET @offset;";
            
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@limit", limit);
            parameters.Add("@offset", offset);

            return db.ExecuteQuery(query, parameters);
        }//get inventory

        public DataTable SearchInventory(string searchTerm, int limit, int offset)
        {
            string query = "SELECT inventory.id, grn_header_id, product_id, " +
                "barcode, products.name, second_name, initial_qty, current_qty, purchase_price, selling_price, discount, final_price " +
                "FROM inventory " +
                "INNER JOIN products ON products.id = inventory.product_id " +
                "WHERE products.barcode LIKE @searchTerm OR products.name LIKE @searchTerm OR final_price LIKE @searchTerm " +
                "LIMIT @limit OFFSET @offset;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@searchTerm", "%" + searchTerm + "%");
            parameters.Add("@limit", limit);
            parameters.Add("@offset", offset);

            return db.ExecuteQuery(query, parameters);
        }//search inventory

    }//class
}
