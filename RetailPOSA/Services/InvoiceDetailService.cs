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

    }//class
}
