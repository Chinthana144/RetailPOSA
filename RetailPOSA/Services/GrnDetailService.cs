using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailPOSA.Services
{
    internal class GrnDetailService
    {
        Database db = new Database();
        public int InsertGrnDetail(int grnHeaderID, int productId, decimal qty, decimal freeQty, decimal purchasePrice, decimal sellingPrice, decimal discount, decimal finalPrice, string expiryDate, int status)
        {
            string query = "INSERT INTO grn_details (grn_header_id, product_id, qty, free_qty, purchase_price, selling_price, discount, final_price, expiry_date, status) " +
                " VALUES (@grn_header_id, @product_id, @qty, @free_qty, @purchase_price, @selling_price, @discount, @final_price, @expiry_date, @status)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@grn_header_id", grnHeaderID);
            parameters.Add("@product_id", productId);
            parameters.Add("@qty", qty);
            parameters.Add("@free_qty", freeQty);
            parameters.Add("@purchase_price", purchasePrice);
            parameters.Add("@selling_price", sellingPrice);
            parameters.Add("@discount", discount);
            parameters.Add("@final_price", finalPrice);
            parameters.Add("@expiry_date", expiryDate);
            parameters.Add("@status", status);            

            return db.ExecuteNonQuery(query, parameters);
        }//insert grn detail

    }//class
}
