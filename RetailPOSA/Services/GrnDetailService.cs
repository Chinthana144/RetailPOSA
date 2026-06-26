using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailPOSA.Services
{
    internal class GrnDetailService
    {
        Database db = new Database();
        public int InsertGrnDetail(int grnHeaderID, int productId, decimal qty, decimal freeQty, decimal purchasePrice, decimal sellingPrice, decimal discount, decimal finalPrice, string expiryDate, decimal purchaseTotal, int status)
        {
            string query = "INSERT INTO grn_details (grn_header_id, product_id, qty, free_qty, purchase_price, selling_price, discount, final_price, expiry_date, purchase_total, status) " +
                " VALUES (@grn_header_id, @product_id, @qty, @free_qty, @purchase_price, @selling_price, @discount, @final_price, @expiry_date, @purchase_total, @status)";
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
            parameters.Add("@purchase_total", purchaseTotal);
            parameters.Add("@status", status);            

            return db.ExecuteNonQuery(query, parameters);
        }//insert grn detail

        public DataTable GetGrnDetailsByGrnHeaderID(int grnHeaderID)
        {
            string query = "SELECT gd.id, gd.grn_header_id, gd.product_id, p.barcode, p.name AS product_name, gd.qty, gd.free_qty, gd.purchase_price, gd.selling_price, gd.discount, gd.final_price, gd.expiry_date, gd.purchase_total " +
                "FROM grn_details gd " +
                "JOIN products p ON gd.product_id = p.id " +
                "WHERE gd.grn_header_id = @grn_header_id;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@grn_header_id", grnHeaderID);

            return db.ExecuteQuery(query, parameters);
        }//get grn details by grn header id

        public int DeleteGrnDetail(int grnDetailID)
        {
            string query = "DELETE FROM grn_details WHERE id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", grnDetailID);
            return db.ExecuteNonQuery(query, parameters);
        }//delete grn detail

    }//class
}
