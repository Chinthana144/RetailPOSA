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
            string query = "SELECT invoice_header.id, issued_datetime, invoice_no, item_count, total, discounts, return_amount, sub_total, paymethod_id, paid_amount, balance, invoice_header.status, " +
                "paymethod, username " + 
                "FROM invoice_header " +
                "INNER JOIN paymethods ON paymethods.id = invoice_header.paymethod_id " +
                "INNER JOIN users ON users.user_id = invoice_header.user_id " +
                "WHERE issued_datetime BETWEEN @startDate AND @endDate;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@startDate", startDate);
            parameters.Add("@endDate", endDate);

            return db.ExecuteQuery(query, parameters);
        }//get Daily sale for reportss

        public DataTable GetDailySummary(string startDate, string endDate)
        {
            string query = "SELECT count(*) as row_count, " +
                "invoice_date, SUM(total) as sale, " +
                "SUM(discounts) as discounts, " +
                "SUM(return_amount) as return_amount, " +
                "SUM(sub_total) as sub_total " +
                "FROM invoice_header " +
                "WHERE invoice_date BETWEEN @startDate AND @endDate " +
                "GROUP BY invoice_date;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@startDate", startDate);
            parameters.Add("@endDate", endDate);

            return db.ExecuteQuery(query, parameters);
        }//get daiy summary

        public DataTable GetUserSales(string startDate, string endDate)
        {
            string query = "SELECT "+
                "count(*) as row_count, username, SUM(total) as sale_total,  SUM(discounts) as total_discounts, SUM(return_amount) as total_returns, SUM(sub_total) as sub_total "+
                "FROM invoice_header "+
                "INNER JOIN users ON users.user_id = invoice_header.user_id "+
                "WHERE invoice_date BETWEEN @startDate AND @endDate " +
                "GROUP BY invoice_header.user_id;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@startDate", startDate);
            parameters.Add("@endDate", endDate);

            return db.ExecuteQuery(query, parameters);
        }//get user sale

    }//class
}
