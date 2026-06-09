using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailPOSA.Reports.ReportServices
{
    internal class SalesReportService
    {
        Database db = new Database();

        public DataTable GetDailySales(string startDate, string endDate)
        {
            string query = "SELECT invoice_header.id, issued_date, invoice_no, item_count, total, discounts, return_amount, sub_total, paymethod_id, paid_amount, balance, invoice_header.status, " +
                "paymethod, username " + 
                "FROM invoice_header " +
                "INNER JOIN paymethods ON paymethods.id = invoice_header.paymethod_id " +
                "INNER JOIN users ON users.user_id = invoice_header.user_id " +
                "WHERE issued_date BETWEEN @startDate AND @endDate;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@startDate", startDate);
            parameters.Add("@endDate", endDate);

            return db.ExecuteQuery(query, parameters);
        }//get Daily sale for reportss

    }//class
}
