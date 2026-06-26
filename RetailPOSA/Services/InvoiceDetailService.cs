using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailPOSA.Services
{
    internal class InvoiceDetailService
    {
        Database db = new Database();

        public DataTable GetInvoiceDetailByID(int id)
        {
            string query = "SELECT invoice_details.id, invoice_id, inventory_id, product_id, " +
                "barcode, name, " +
                "unit_price, qty, selling_price, discount, final_price, invoice_details.status " +
                "FROM invoice_details "+
                "INNER JOIN products ON products.id = invoice_details.product_id "+
                "WHERE invoice_details.id = @id;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);

            return db.ExecuteQuery(query, parameters);
        }//get invoice detail by id

        public DataTable GetTopSellingProducts(string limitDate)
        {
            string query = "SELECT count(*) as count, categories.name  as category, products.barcode, products.name, SUM(invoice_details.qty) as total_qty, products.minimum_stock FROM invoice_details " +
                "INNER JOIN invoice_header ON invoice_header.id = invoice_details.invoice_id "+
                "INNER JOIN products ON products.id = invoice_details.product_id "+
                "INNER JOIN categories ON categories.id = products.category_id  "+
                "WHERE invoice_header.invoice_date > @limitDate " +
                "GROUP BY product_id "+
                "ORDER BY total_qty DESC LIMIT 10;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@limitDate", limitDate);

            return db.ExecuteQuery(query, parameters);
        }//get top selling 

    }//class
}
