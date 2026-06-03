using RetailPOSA.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RetailPOSA.Services
{
    internal class AdjustmentHeaderService
    {
        Database db = new Database();
        public int InsertAdjustmentHeader(string adjustmentType, string submittedDate, int itemCount, decimal purchasePrice, string note, int userID, int status)
        {
            string adjustmentNo = GetAdjustmentNo();
            string query = "INSERT INTO adjustment_header(adjustment_no, type, submitted_datetime, item_count, purchase_price, note, user_id, status) " +
                "VALUES(@adjustmentNo, @adjustmentType,@submittedDate,@itemCount,@purchasePrice,@note,@userID,@status);";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@adjustmentNo", adjustmentNo);
            parameters.Add("@adjustmentType", adjustmentType);
            parameters.Add("@submittedDate", submittedDate);
            parameters.Add("@itemCount", itemCount);
            parameters.Add("@purchasePrice", purchasePrice);
            parameters.Add("@note", note);
            parameters.Add("@userID", userID);
            parameters.Add("@status", status);

            return db.ExecuteNonQuery(query, parameters);
        }

        public int UpdateAdjustmentHeader(int id, string type, string note)
        {
            string query = "UPDATE adjustment_header SET type = @type, note = @note WHERE id = @id;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@type", type);
            parameters.Add("@note", note);
            parameters.Add("@id", id);

            return db.ExecuteNonQuery(query, parameters);
        }

        public int UpdateAdjustmentHeaderTotals(int id, int rowCount, decimal total, int userID, int status)
        {
            string query = "UPDATE adjustment_header SET item_count = @rowCount, purchase_price = @total, user_id = @userID, status = @status WHERE id  = @id;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@id", id);
            parameters.Add("@rowCount", rowCount);
            parameters.Add("@total", total);
            parameters.Add("@userID", userID);
            parameters.Add("@status", status);

            return db.ExecuteNonQuery(query, parameters);
        }

        public DataTable GetAdjustmentHeaderByID(int id)
        {
            string query = "SELECT * FROM adjustment_header WHERE id = @id;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@id", id);

            return db.ExecuteQuery(query, parameters);
        }//get adjustment header by id

        public DataTable GetAdjustmentByStatus(int status)
        {
            string query = "SELECT id, type, submitted_datetime, item_count, purchase_price, note, adjustment_header.user_id, status, username FROM adjustment_header  " +
                "INNER JOIN users ON users.user_id = adjustment_header.user_id " +
                "WHERE status = @status;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@status", status);

            return db.ExecuteQuery(query, parameters);

        }//get adjuestment

        public DataTable SearchAdjustmentHeader(string searchTerm, int status, int limit, int offset)
        {
            string query = "SELECT id, type, submitted_datetime, item_count, purchase_price, note, adjustment_header.user_id, status, username "+
                "FROM adjustment_header " +
                "INNER JOIN users ON users.user_id = adjustment_header.user_id "+
                "WHERE adjustment_header.status = @status AND (submitted_datetime LIKE @searchTerm OR adjustment_no LIKE @searchTerm OR note LIKE @searchTerm OR type LIKE @searchTerm) " +
                "LIMIT @limit OFFSET @offset;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@searchTerm", $"%{searchTerm}%");
            parameters.Add("@status", status);
            parameters.Add("@limit", limit);
            parameters.Add("@offset", offset);

            return db.ExecuteQuery(query, parameters);
        }//get all data

        public DataTable GetLastAdjustmentByUser(int userID)
        {
            string query = "SELECT * FROM adjustment_header WHERE user_id = @userID AND status = 0 ORDER BY id DESC LIMIT 1;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@userID", userID);

            return db.ExecuteQuery(query, parameters);
        }

        //get Adjustment no
        public string GetAdjustmentNo()
        {
            string query = "SELECT IFNULL(MAX(ID), 0) AS adjustment_count FROM  adjustment_header;";

            DataTable countData = db.ExecuteQuery(query);

            int nextAdjustmentNo = Convert.ToInt32(countData.Rows[0]["adjustment_count"]) + 1;

            return "ADJ_" + nextAdjustmentNo.ToString("D7");
        }
    }//class
}
