using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailPOSA.Services
{
    internal class InvoiceService
    {
        Database db = new Database();
        public DataTable GetPaymethods()
        {
            string query = "SELECT * FROM paymethods WHERE status = 1;";

            return db.ExecuteQuery(query);
        }
    }//class
}
