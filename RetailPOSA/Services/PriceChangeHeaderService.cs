using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RetailPOSA.Services
{
    internal class PriceChangeHeaderService
    {
        Database db = new Database();

        public int InsertPriceChangeHeader(string note, string submitDate, int itemCount, decimal totalPrice, int userID, int status)
        {
            string priceChangeNo = GetPriceChangeNo();
            string query = "INSERT INTO price_change_header(price_change_no, note, submitted_datetime, item_count, total_price, user_id, status) "+
                "VALUES(@priceChangeNo, @note, @submitDate, @itemCount, @totalPrice, @userID, @status);";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@priceChangeNo", priceChangeNo);
            parameters.Add("@note", note);
            parameters.Add("@submitDate", submitDate);
            parameters.Add("@itemCount", itemCount);
            parameters.Add("@totalPrice", totalPrice);
            parameters.Add("@userID", userID);
            parameters.Add("@status", status);

            return db.ExecuteNonQuery(query, parameters);

        }//insert price change header

        public int UpdatePriceChangeNote(int id, string note)
        {
            string query = "UPDATE price_change_header SET note = @note WHERE id = @id;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@id", id);
            parameters.Add("@note", note);

            return db.ExecuteNonQuery(query, parameters);
        }//update note

        public int UpdatePriceChangeTotals(int id, string submitDate, int itemCount, decimal totalPrice, int userID, int status)
        {
            string query = "UPDATE price_change_header SET submitted_datetime = @submitDate,  item_count = @itemCount, total_price = @totalPrice, user_id = @userID, status = @status WHERE id = @id;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@id", id);
            parameters.Add("@submitDate", submitDate);
            parameters.Add("@itemCount", itemCount);
            parameters.Add("@totalPrice", totalPrice);
            parameters.Add("@userID", userID);
            parameters.Add("@status", status);

            return db.ExecuteNonQuery(query, parameters);
        }//update totals after submit

        public DataTable SearchPriceChangeHeader(string searchTerm, int status, int limit, int offset)
        {
            string query = "SELECT " +
                "price_change_header.id, price_change_no, note, submitted_datetime, item_count, total_price, price_change_header.user_id, status, username " +
                "FROM price_change_header " +
                "INNER JOIN users ON users.user_id = price_change_header.user_id " +
                "WHERE price_change_header.status = @status AND (price_change_no LIKE @searchTerm OR note LIKE @searchTerm OR submitted_datetime LIKE @searchTerm OR users.username LIKE @searchTerm) " + 
                "ORDER BY id DESC " +
                "LIMIT @limit OFFSET @offset;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@searchTerm", $"%{searchTerm}%");
            parameters.Add("@status", status);
            parameters.Add("@limit", limit);
            parameters.Add("@offset", offset);

            return db.ExecuteQuery(query, parameters);
        }

        public DataTable GetPriceChangeByID(int id)
        {
            string query = "SELECT * FROM price_change_header WHERE id = @id;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);

            return db.ExecuteQuery(query, parameters);
        }

        public DataTable GetLastPriceChangeByUserID(int userID)
        {
            string query = "SELECT * FROM price_change_header WHERE user_id = @userID ORDER BY id DESC LIMIT 1;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@userID", userID);

            return db.ExecuteQuery(query, parameters);
        }

        private string GetPriceChangeNo()
        {
            string query = "SELECT IFNULL(MAX(ID), 0) AS price_change_count FROM  price_change_header;";

            DataTable countData = db.ExecuteQuery(query);

            int nextPriceChangeNo = Convert.ToInt32(countData.Rows[0]["price_change_count"]) + 1;

            return "PCH_" + nextPriceChangeNo.ToString("D7");
        }
    }//class
}
