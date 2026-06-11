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

        public int InsertSaleReturnDetail(int salesReturnHeaderID, int inventoryID, int invoiceDetailID, int productID, decimal unitPrice, decimal qty, decimal sellingPrice, decimal discount, decimal finalPrice, int status)
        {
            string query = "INSERT INTO sale_return_detail(sale_return_header_id, inventory_id, invoice_detail_id, product_id, unit_price, qty, selling_price, discount, final_price, status) " +
                "VALUES(@salesReturnHeaderID, @inventoryID, @invoiceDetailID,@productID,@unitPrice,@qty,@sellingPrice,@discount,@finalPrice,@status);";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@salesReturnHeaderID", salesReturnHeaderID);
            parameters.Add("@inventoryID", inventoryID);
            parameters.Add("@invoiceDetailID", invoiceDetailID);
            parameters.Add("@productID", productID);
            parameters.Add("@unitPrice", unitPrice);
            parameters.Add("@qty", qty);
            parameters.Add("@sellingPrice", sellingPrice);
            parameters.Add("@discount", discount);
            parameters.Add("@finalPrice", finalPrice);
            parameters.Add("@status", status);

            return db.ExecuteNonQuery(query, parameters);
        }//insert sale return detail

        public int RemoveReturnDetail(int returnDetailID)
        {
            string query = "DELETE FROM sale_return_detail WHERE id = @returnDetailID;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@returnDetailID", returnDetailID);

            return db.ExecuteNonQuery(query, parameters);
        }//remove item from cart

        public DataTable GetReturnDetailByHeaderID(int headerID)
        {
            string query = "SELECT sale_return_detail.id, sale_return_header_id, inventory_id, invoice_detail_id, product_id, " +
                "barcode, name, " +
                "unit_price, qty, selling_price, discount, final_price, sale_return_detail.status " +
                "FROM sale_return_detail " +
                "INNER JOIN products ON products.id = sale_return_detail.product_id " +
                "WHERE sale_return_header_id = @headerID;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@headerID", headerID);

            return db.ExecuteQuery(query, parameters);
        }//get return detail by header id

        public DataTable GetTotalByHeaderID(int returnHeaderID)
        {
            string query = "SELECT COUNT(*) AS row_count, sum(qty) AS item_count, sum(final_price) AS total FROM sale_return_detail "+
                "WHERE sale_return_header_id = @returnHeaderID;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@returnHeaderID", returnHeaderID);

            return db.ExecuteQuery(query, parameters);
        }//get total by header id

        public bool CheckDublicateID(int returnHeaderID, int invoiceDetailID)
        {
            string query = "SELECT * FROM sale_return_detail WHERE sale_return_header_id = @returnHeaderID AND invoice_detail_id = @invoiceDetailID;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@returnHeaderID", returnHeaderID);
            parameters.Add("@invoiceDetailID", invoiceDetailID);

            DataTable data = db.ExecuteQuery(query, parameters);

            return data.Rows.Count > 0 ? true : false;

        }//check duplicates

    }//class
}
