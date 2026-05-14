using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailPOSA.Services
{
    internal class CartHeaderService
    {
        Database db = new Database();
        public int InsertCartHeader(int userID, DateTime createdAt, int status)
        {
            //get new cart no
            string queryCartNo = "SELECT id FROM cart_header ORDER BY id DESC LIMIT 1;";
            DataTable dt = db.ExecuteQuery(queryCartNo);
            int newCartNo = dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0]["id"]) +1  : 1;

            string query = "INSERT INTO cart_header (cart_no, user_id, created_at, status)" +
                "VALUES(@cart_no, @user_id, @created_at, @status);";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@cart_no", newCartNo);
            parameters.Add("@user_id", userID);
            parameters.Add("@created_at", createdAt);
            parameters.Add("@status", status);

            return db.ExecuteNonQuery(query, parameters);
        }//insert cart header

        public DataTable GetCartHeader(int userID)
        {
            string query = "SELECT * FROM cart_header WHERE status = 1 AND user_id = @userID LIMIT 1;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@userID", userID);

            return db.ExecuteQuery(query, parameters);
        }//get cart header

    }//class
}
