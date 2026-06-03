using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailPOSA.Services
{
    internal class SaleReturnDetailService
    {
        Database db = new Database();

        public int InsertSaleReturnDetail(int salesReturnHeaderID, int inventoryID, int productID, decimal unitPrice, int qty, decimal sellingPrice, decimal discount, decimal finalPrice, int status)
        {
            string query = "INSERT INTO sale_return_detail(sale_return_header_id, inventory_id, product_id, unit_price, qty, selling_price, discount, final_price, status) "+
                "VALUES(@salesReturnHeaderID,@inventoryID,@productID,@unitPrice,@qty,@sellingPrice,@discount,@finalPrice,@status);";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@salesReturnHeaderID", salesReturnHeaderID);
            parameters.Add("@inventoryID", inventoryID);
            parameters.Add("@productID", productID);
            parameters.Add("@unitPrice", unitPrice);
            parameters.Add("@qty", qty);
            parameters.Add("@sellingPrice", sellingPrice);
            parameters.Add("@discount", discount);
            parameters.Add("@finalPrice", finalPrice);
            parameters.Add("@status", status);

            return db.ExecuteNonQuery(query, parameters);
        }//insert sale return detail

        public DataTable GetReturnDetailByHeaderID(int headerID)
        {
            string query = "SELECT sale_return_detail.id, sale_return_header_id, inventory_id, product_id, " +
                "barcode, name, " +
                "unit_price, qty, selling_price, discount, final_price, sale_return_detail.status " +
                "FROM sale_return_detail " +
                "INNER JOIN products ON products.id = sale_return_detail.product_id " +
                "WHERE sale_return_header_id = @headerID;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@headerID", headerID);

            return db.ExecuteQuery(query, parameters);
        }//get return detail by header id

    }//class
}
