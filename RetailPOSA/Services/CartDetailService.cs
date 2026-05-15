using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailPOSA.Services
{
    internal class CartDetailService
    {
        Database db = new Database();
        public int InsertCartDetail(int cartHeaderID, int inventoryID, int productID, decimal unitPrice, decimal qty, decimal totalPrice)
        {
            string query = "INSERT INTO cart_detail(cart_header_id, inventory_id, product_id, unit_price, qty, total_price) " +
                "VALUES(@cartHeaderID, @inventoryID, @productID,@unitPrice,@qty,@total_price);";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@cartHeaderID", cartHeaderID);
            parameters.Add("@inventoryID", inventoryID);
            parameters.Add("@productID", productID);
            parameters.Add("@unitPrice", unitPrice);
            parameters.Add("@qty", qty);
            parameters.Add("@total_price", totalPrice);

            return db.ExecuteNonQuery(query, parameters);
        }

        public int AddToCart(int cartHeaderID, int inventoryID, int productID, decimal unitPrice, decimal qty, decimal totalPrice)
        {
            //check cart with 
            string query = "SELECT cart_detail.id, cart_header_id, inventory_id, product_id, unit_price, qty, total_price, barcode, name, second_name, is_weighted, has_expiry, minimum_stock, status " +
                "FROM cart_detail " +
                "INNER JOIN products ON products.id = cart_detail.product_id " +
                "WHERE cart_header_id = @cartHeaderID AND inventory_id = @inventoryID AND is_weighted = 0 " + 
                "LIMIT 1;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@cartHeaderID", cartHeaderID);
            parameters.Add("@inventoryID", inventoryID);

            DataTable dt = db.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                int id = Convert.ToInt32(dt.Rows[0]["id"]);

                //update row
                string updateQuery = "UPDATE cart_detail SET qty = qty+1, total_price = unit_price * qty WHERE id = @id;";
                Dictionary<string, object> updatePara = new Dictionary<string, object>();
                updatePara.Add("@id", id);

                return db.ExecuteNonQuery(updateQuery, updatePara);
            }
            else
            {
                //insert to row
                string insertQuery = "INSERT INTO cart_detail(cart_header_id, inventory_id, product_id, unit_price, qty, total_price) " +
                "VALUES(@cartHeaderID, @inventoryID, @productID,@unitPrice,@qty,@total_price);";

                Dictionary<string, object> insertPara = new Dictionary<string, object>();
                insertPara.Add("@cartHeaderID", cartHeaderID);
                insertPara.Add("@inventoryID", inventoryID);
                insertPara.Add("@productID", productID);
                insertPara.Add("@unitPrice", unitPrice);
                insertPara.Add("@qty", qty);
                insertPara.Add("@total_price", totalPrice);

                return db.ExecuteNonQuery(insertQuery, insertPara);
            }
        }//add to cart

        public int UpdateCartDetailQty(int cartDetailID, decimal qty, decimal totalPrice)
        {
            string query = "UPDATE cart_detail SET qty = @qty, total_price = @totalPrice WHERE id = @cartDetailID; ";
            
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@cartDetailID", cartDetailID);
            parameters.Add("@qty", qty);
            parameters.Add("@totalPrice", totalPrice);

            return db.ExecuteNonQuery(query, parameters);
        }//update qty

        public DataTable GetCartByHeaderID(int headerID)
        {
            string query = "SELECT cart_detail.id, cart_header_id, product_id,  barcode, name, unit_price, qty, total_price, second_name, is_weighted, has_expiry, minimum_stock, status " +
                "FROM cart_detail " +
                "INNER JOIN products ON products.id = cart_detail.product_id " +
                "WHERE cart_header_id = @headerID;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@headerID", headerID);

            return db.ExecuteQuery(query, parameters);
        }//get cart by header id

        public DataTable GetCartByID(int cartDetailID)
        {
            string query = "SELECT cart_detail.id, cart_header_id, inventory_id, product_id,  barcode, name, unit_price, qty, total_price, second_name, is_weighted, has_expiry, minimum_stock, status " +
                "FROM cart_detail " +
                "INNER JOIN products ON products.id = cart_detail.product_id " +
                "WHERE cart_detail.id = @cartDetailID;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@cartDetailID", cartDetailID);

            return db.ExecuteQuery(query, parameters);
        }//get cart detail by Id

        public DataTable GetCartTotals(int headerID)
        {
            string query = "SELECT count(*) as row_count, sum(total_price) as cart_total FROM cart_detail " +
                "WHERE cart_header_id = @headerID;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@headerID", headerID);

            return db.ExecuteQuery(query, parameters);
        }//get cart totals

        public int ClearCart(int headerID)
        {
            string query = "DELETE FROM cart_detail WHERE cart_header_id = @cartHeaderID;";

            Dictionary<string, object> deletePara = new Dictionary<string, object>();
            deletePara.Add("@cartHeaderID", headerID);

            return db.ExecuteNonQuery(query, deletePara);
        }//clear cart
    }//class
}
