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
        public int InsertCartDetail(int cartHeaderID, int inventoryID, int productID, decimal unitPrice, decimal qty, decimal totalPrice, decimal discount, decimal finalPrice)
        {
            string query = "INSERT INTO cart_detail(cart_header_id, inventory_id, product_id, unit_price, qty, total_price, discount, final_price) " +
                "VALUES(@cartHeaderID, @inventoryID, @productID,@unitPrice,@qty,@total_price, @discount, @finalPrice);";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@cartHeaderID", cartHeaderID);
            parameters.Add("@inventoryID", inventoryID);
            parameters.Add("@productID", productID);
            parameters.Add("@unitPrice", unitPrice);
            parameters.Add("@qty", qty);
            parameters.Add("@total_price", totalPrice);
            parameters.Add("@discount", discount);
            parameters.Add("@finalPrice", finalPrice);

            return db.ExecuteNonQuery(query, parameters);
        }

        public int AddToCart(int cartHeaderID, int inventoryID, int productID, decimal unitPrice, decimal qty, decimal totalPrice, decimal unitDiscount, decimal finalPrice)
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
                qty = Convert.ToDecimal(dt.Rows[0]["qty"]);
                decimal newQty = qty + 1;
                decimal newTotalPrice = unitPrice * newQty;
                decimal discount = unitDiscount * newQty;
                finalPrice = newTotalPrice - discount;

                //update row
                string updateQuery = "UPDATE cart_detail SET qty = @newQty, total_price = @newTotalPrice, discount = @discount, final_price = @finalPrice WHERE id = @id;";
                Dictionary<string, object> updatePara = new Dictionary<string, object>();
                updatePara.Add("@newQty", newQty);
                updatePara.Add("@newTotalPrice", newTotalPrice);
                updatePara.Add("@discount", discount);
                updatePara.Add("@finalPrice", finalPrice);
                updatePara.Add("@id", id);

                return db.ExecuteNonQuery(updateQuery, updatePara);
            }
            else
            {
                decimal newTotalPrice = unitPrice * qty;
                decimal discount = unitDiscount * qty;
                finalPrice = newTotalPrice - discount;
                //insert to row
                string insertQuery = "INSERT INTO cart_detail(cart_header_id, inventory_id, product_id, unit_price, qty, total_price, discount, final_price) " +
                "VALUES(@cartHeaderID, @inventoryID, @productID,@unitPrice,@qty,@newTotalPrice, @discount, @finalPrice);";

                Dictionary<string, object> insertPara = new Dictionary<string, object>();
                insertPara.Add("@cartHeaderID", cartHeaderID);
                insertPara.Add("@inventoryID", inventoryID);
                insertPara.Add("@productID", productID);
                insertPara.Add("@unitPrice", unitPrice);
                insertPara.Add("@qty", qty);
                insertPara.Add("@newTotalPrice", newTotalPrice);
                insertPara.Add("@discount", discount);
                insertPara.Add("@finalPrice", finalPrice);

                return db.ExecuteNonQuery(insertQuery, insertPara);
            }
        }//add to cart

        public int UpdateCartDetailQty(int cartDetailID, decimal qty, decimal totalPrice, decimal discount, decimal finalPrice)
        {
            string query = "UPDATE cart_detail SET qty = @qty, total_price = @totalPrice, discount = @discount, final_price = @finalPrice WHERE id = @cartDetailID; ";
            
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@cartDetailID", cartDetailID);
            parameters.Add("@qty", qty);
            parameters.Add("@totalPrice", totalPrice);
            parameters.Add("@discount", discount);
            parameters.Add("@finalPrice", finalPrice);

            return db.ExecuteNonQuery(query, parameters);
        }//update qty

        public DataTable GetCartByHeaderID(int headerID)
        {
            string query = "SELECT cart_detail.id, cart_header_id, inventory_id, product_id,  barcode, name, unit_price, qty, total_price, discount, final_price, second_name, is_weighted, has_expiry, minimum_stock, status " +
                "FROM cart_detail " +
                "INNER JOIN products ON products.id = cart_detail.product_id " +
                "WHERE cart_header_id = @headerID;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@headerID", headerID);

            return db.ExecuteQuery(query, parameters);
        }//get cart by header id

        public DataTable GetCartByID(int cartDetailID)
        {
            string query = "SELECT cart_detail.id, cart_header_id, inventory_id, product_id,  barcode, name, unit_price, qty, total_price, discount, final_price, second_name, is_weighted, has_expiry, minimum_stock, status " +
                "FROM cart_detail " +
                "INNER JOIN products ON products.id = cart_detail.product_id " +
                "WHERE cart_detail.id = @cartDetailID;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@cartDetailID", cartDetailID);

            return db.ExecuteQuery(query, parameters);
        }//get cart detail by Id

        public DataTable GetCartTotals(int headerID)
        {
            string query = "SELECT count(*) as row_count, sum(discount) as total_discount, sum(total_price) as total_price, sum(final_price) as final_total FROM cart_detail " +
                "WHERE cart_header_id = @headerID;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@headerID", headerID);

            return db.ExecuteQuery(query, parameters);
        }//get cart totals

        public int DeleteCartItem(int cartDetailID)
        {
            string query = "DELETE FROM cart_detail WHERE id = @cartDetailID;";

            Dictionary<string, object> deletePara = new Dictionary<string, object>();
            deletePara.Add("@cartDetailID", cartDetailID);

            return db.ExecuteNonQuery(query, deletePara);
        }//delete cart item

        public int ClearCart(int headerID)
        {
            string query = "DELETE FROM cart_detail WHERE cart_header_id = @cartHeaderID;";

            Dictionary<string, object> deletePara = new Dictionary<string, object>();
            deletePara.Add("@cartHeaderID", headerID);

            return db.ExecuteNonQuery(query, deletePara);
        }//clear cart
    }//class
}
