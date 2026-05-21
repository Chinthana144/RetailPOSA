using RetailPOSA.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailPOSA.Services
{
    internal class AdjustmentHeaderService
    {
        Database db = new Database();
        public int InsertAdjustmentHeader(string adjustmentType, string submittedDate, int itemCount, decimal purchasePrice, string note, int userID, int status)
        {
            string query = "INSERT INTO adjustment_header(type, submitted_datetime, item_count, purchase_price, note, user_id, status) " +
                "VALUES(@adjustmentType,@submittedDate,@itemCount,@purchasePrice,@note,@userID,@status);";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@adjustmentType", adjustmentType);
            parameters.Add("@submittedDate", submittedDate);
            parameters.Add("@itemCount", itemCount);
            parameters.Add("@purchasePrice", purchasePrice);
            parameters.Add("@note", note);
            parameters.Add("@userID", userID);
            parameters.Add("@status", status);

            return db.ExecuteNonQuery(query, parameters);
        }

        public DataTable GetAdjustmentByStatus(int status)
        {
            string query = "SELECT * FROM adjustment_header WHERE status = @status;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@status", status);

            return db.ExecuteQuery(query, parameters);

        }//get adjuestment 
    }//class
}
