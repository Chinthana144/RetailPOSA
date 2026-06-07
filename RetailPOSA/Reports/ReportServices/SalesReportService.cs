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
            string query = "SELECT * FROM invoice_header" +
                "WHERE issued_date BETWEEN @startDate AND @endDate;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@startDate", startDate);
            parameters.Add("@endDate", endDate);

            return db.ExecuteQuery(query, parameters);
        }//get Daily sale for reportss

    }//class
}
