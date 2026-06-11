using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailPOSA.Services
{
    internal class PaymethodService
    {
        Database db = new Database();

        public int InsertPaymethod(string paymethod, int status)
        {
            string query = "INSERT INTO paymethods(paymethod, status) VALUES(@paymethod, @status);";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@paymethod", paymethod);
            parameters.Add("@status", status);

            return db.ExecuteNonQuery(query, parameters);
        }//insert

        public DataTable GetAllPaymethods()
        {
            string query = "SELECT * FROM paymethods;";

            return db.ExecuteQuery(query);
        }//get paymethods

        public DataTable GetActivePaymethods()
        {
            string query = "SELECT * FROM paymethods WHERE status = 1;";

            return db.ExecuteQuery(query);
        }//get paymethods
    }//class
}
