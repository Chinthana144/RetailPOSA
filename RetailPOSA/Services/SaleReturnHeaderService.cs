using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailPOSA.Services
{
    internal class SaleReturnHeaderService
    {
        Database db = new Database();

        public int InsertSaleReturnHeader(int invoiceID, string submittedDateTime, string returnType, string reason, int itemCount, decimal total, int userID, int status)
        {
            string saleReturnNo = GetSaleReturnNo();
            string query = "INSERT INTO sale_return_header(sale_return_no, invoice_id, submitted_datetime, return_type, reason, item_count, return_total, user_id, status) " +
                "VALUES(@saleReturnNo, @invoiceID, @submittedDateTime, @returnType, @reason, @itemCount, @total, @userID, @status);";
            
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@saleReturnNo", saleReturnNo);
            parameters.Add("@invoiceID", invoiceID);
            parameters.Add("@submittedDateTime", submittedDateTime);
            parameters.Add("@returnType", returnType);
            parameters.Add("@reason", reason);
            parameters.Add("@itemCount", itemCount);
            parameters.Add("@total", total);
            parameters.Add("@userID", userID);
            parameters.Add("@status", status);

            return db.ExecuteNonQuery(query, parameters);

        }//insert sale return header

        public int UpdateSaleReturnInvoice(int id, int invoiceID, string submittedDate, string returnType, string reason, int userID, int status)
        {
            string query = "UPDATE sale_return_header SET invoice_id = @invoiceID, submitted_datetime = @submittedDate, return_type = @returnType, reason = @reason, user_id = @userID, status = @status WHERE id = @id;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@id", id);
            parameters.Add("@invoiceID", invoiceID);
            parameters.Add("@submittedDate", submittedDate);
            parameters.Add("@returnType", returnType);
            parameters.Add("@reason", reason);
            parameters.Add("@userID", userID);
            parameters.Add("@status", status);

            return db.ExecuteNonQuery(query, parameters);
        }//update invoice_no, reson, type

        public int UpdateSaleReturnHeaderTotals(int id, string submittedDate, int itemCount, decimal returnTotal, int userID, int status)
        {
            string query = "UPDATE sale_return_header SET submitted_datetime = @submittedDate, item_count = @itemCount, return_total = @returnTotal, user_id = @userID, status = @status WHERE id = @id;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@id", id);
            parameters.Add("@submittedDate", submittedDate);
            parameters.Add("@itemCount", itemCount);
            parameters.Add("@returnTotal", returnTotal);
            parameters.Add("@userID", userID);
            parameters.Add("@status", status);

            return db.ExecuteNonQuery(query, parameters);
        }//update return header

        public DataTable GetSaleReturnHeader(int limit, int offset)
        {
            string query = "SELECT sale_return_header.id, sale_return_no, " +
                "invoice_id, invoice_header.invoice_no, invoice_header.sub_total, " +
                "submitted_datetime, return_type, reason, sale_return_header.item_count, return_total, sale_return_header.user_id, sale_return_header.status, " +
                "users.username " +
                "FROM sale_return_header " +
                "INNER JOIN invoice_header ON invoice_header.id = sale_return_header.invoice_id " +
                "INNER JOIN  users ON users.user_id = sale_return_header.user_id " +
                "ORDER BY id DESC " +
                "LIMIT @limit OFFSET @offset;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@limit", limit);
            parameters.Add("@offset", offset);

            return db.ExecuteQuery(query, parameters);
        }//get sale return header with pagination

        public DataTable GetSaleReturnHeaderByID(int id)
        {
            string query = "SELECT sale_return_header.id, sale_return_no, " +
                "invoice_id, invoice_header.invoice_no, invoice_header.sub_total, " +
                "submitted_datetime, return_type, reason, sale_return_header.item_count, return_total, sale_return_header.user_id, sale_return_header.status, " +
                "users.username " +
                "FROM sale_return_header " +
                "INNER JOIN invoice_header ON invoice_header.id = sale_return_header.invoice_id " +
                "INNER JOIN  users ON users.user_id = sale_return_header.user_id " +
                "WHERE sale_return_header.id = @id;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);

            return db.ExecuteQuery(query, parameters);
        }//get return header by id

        public DataTable SearchSaleReturnHeader(string searchTerm, int status, int limit, int offset)
        {
            string query = "SELECT sale_return_header.id, sale_return_no, " +
                "invoice_id, invoice_header.invoice_no, invoice_header.sub_total, " +
                "submitted_datetime, return_type, reason, sale_return_header.item_count, return_total, sale_return_header.user_id, sale_return_header.status, " +
                "users.username " +
                "FROM sale_return_header " +
                "INNER JOIN invoice_header ON invoice_header.id = sale_return_header.invoice_id " +
                "INNER JOIN users ON users.user_id = sale_return_header.user_id " +
                "WHERE sale_return_header.status = @status AND (sale_return_no LIKE @searchTerm OR invoice_no LIKE @searchTerm OR submitted_datetime LIKE @searchTerm OR return_type LIKE @searchTerm OR reason LIKE @searchTerm OR username LIKE @searchTerm) " +
                "ORDER BY id DESC " +
                "LIMIT @limit OFFSET @offset;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@searchTerm", $"%{searchTerm}%");
            parameters.Add("@status", status);
            parameters.Add("@limit", limit);
            parameters.Add("@offset", offset);

            return db.ExecuteQuery(query, parameters);
        }//search sale return header

        public DataTable GetLastSaleReturnByUserID(int userID)
        {
            string query = "SELECT * FROM sale_return_header WHERE user_id = @userID ORDER BY id DESC LIMIT 1;";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@userID", userID);
            return db.ExecuteQuery(query, parameters);
        }//get last sale return by user id

        public string GetSaleReturnNo()
        {
            string query = "SELECT IFNULL(MAX(ID), 0) AS sale_return_count FROM  sale_return_header;";

            DataTable countData = db.ExecuteQuery(query);

            int nextSaleReturnNo = Convert.ToInt32(countData.Rows[0]["sale_return_count"]) + 1;

            return "RTN_" + nextSaleReturnNo.ToString("D7");
        }//get sale return no

    }//class
}   
