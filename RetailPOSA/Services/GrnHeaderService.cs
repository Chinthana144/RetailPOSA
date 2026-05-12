using Mysqlx.Crud;
using Org.BouncyCastle.Pqc.Crypto.Saber;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailPOSA.Services
{
    internal class GrnHeaderService
    {
        Database db = new Database();
        public int InsertGrnHeader(int supplierID, string invoiceNo, string dateCreated, string dateSubmitted, int itemCount, decimal purchasePrice, decimal sellingPrice, int status, int userID)
        {
            string query = "INSERT INTO grn_header (supplier_id, invoice_no, date_created, date_submitted, item_count, purchase_price, selling_price, status, user_id) VALUES " + 
                "(@supplierID, @invoiceNo, @dateCreated, @dateSubmitted, @itemCount, @purchasePrice, @sellingPrice, @status, @userID)";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@supplierID", supplierID);
            parameters.Add("@invoiceNo", invoiceNo);
            parameters.Add("@dateCreated", dateCreated);
            parameters.Add("@dateSubmitted", dateSubmitted);
            parameters.Add("@itemCount", itemCount);
            parameters.Add("@purchasePrice", purchasePrice);
            parameters.Add("@sellingPrice", sellingPrice);
            parameters.Add("@status", status);
            parameters.Add("@userID", userID);

            return db.ExecuteNonQuery(query, parameters);
        }//insert grn header

        public int UpdateGrnHeader(int id, int supplierID, string invoiceNo, string dateCreated, string dateSubmitted, int itemCount, decimal purchasePrice, decimal sellingPrice, int status, int userID)
        {
            string query = "UPDATE grn_header SET " +
                "supplier_id = @supplierID, " +
                "invoice_no = @invoiceNo, " +
                "date_created = @dateCreated, " +
                "date_submitted = @dateSubmitted, " +
                "item_count = @itemCount, " +
                "purchase_price = @purchasePrice, " +
                "selling_price = @sellingPrice, " +
                "status = @status, " +
                "user_id = @userID " +
                "WHERE id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@id", id);
            parameters.Add("@supplierID", supplierID);
            parameters.Add("@invoiceNo", invoiceNo);
            parameters.Add("@dateCreated", dateCreated);
            parameters.Add("@dateSubmitted", dateSubmitted);
            parameters.Add("@itemCount", itemCount);
            parameters.Add("@purchasePrice", purchasePrice);
            parameters.Add("@sellingPrice", sellingPrice);
            parameters.Add("@status", status);
            parameters.Add("@userID", userID);

            return db.ExecuteNonQuery(query, parameters);
        }//update grn header

        public int UpdateGrnHeaderStatus(int id, int status)
        {
            string query = "UPDATE grn_header SET status = @status WHERE id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            parameters.Add("@status", status);
            return db.ExecuteNonQuery(query, parameters);
        }//update grn header status

        public DataTable GetAllGrnHeaders(int limit, int offset)
        {
            string query = "SELECT " +
                "grn_header.id, " +
                "grn_header.date_submitted, " +
                "grn_header.invoice_no, " +
                "grn_header.item_count, " +
                "grn_header.purchase_price, " +
                "grn_header.status, " +
                "suppliers.company_name, " +
                "users.username " +
                "FROM grn_header " +
                "INNER JOIN suppliers ON suppliers.id = grn_header.supplier_id " +
                "INNER JOIN users ON users.user_id = grn_header.user_id " +
                "WHERE grn_header.status = 1 " +
                "ORDER BY grn_header.id DESC " +
                "LIMIT @limit OFFSET @offset;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@limit", limit);
            parameters.Add("@offset", offset);

            return db.ExecuteQuery(query, parameters);
        }

        public DataTable GetGrnHeaderByStatus(int status, int limit, int offset)
        {
            string query = "SELECT " +
                "grn_header.id, " +
                "grn_header.date_submitted, " +
                "grn_header.invoice_no, " +
                "grn_header.item_count, " +
                "grn_header.purchase_price, " +
                "grn_header.status, " +
                "suppliers.company_name, " +
                "users.username " +
                "FROM grn_header " +
                "INNER JOIN suppliers ON suppliers.id = grn_header.supplier_id " +
                "INNER JOIN users ON users.user_id = grn_header.user_id " +
                "WHERE grn_header.status = @status " +
                "ORDER BY grn_header.id DESC " +
                "LIMIT @limit OFFSET @offset;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@limit", limit);
            parameters.Add("@offset", offset);
            parameters.Add("@status", status);

            return db.ExecuteQuery(query, parameters);
        }

        public DataTable GetGrnHeaderByID(int id)
        {
            string query = "SELECT " +
                "grn_header.id, " +
                "grn_header.supplier_id, " +
                "grn_header.date_submitted, " +
                "grn_header.invoice_no, " +
                "grn_header.item_count, " +
                "grn_header.purchase_price, " +
                "grn_header.status, " +
                "suppliers.company_name, " +
                "suppliers.supplier_name, " +
                "suppliers.contact_no, " +
                "users.username " +
                "FROM grn_header " +
                "INNER JOIN suppliers ON suppliers.id = grn_header.supplier_id " +
                "INNER JOIN users ON users.user_id = grn_header.user_id " +
                "WHERE grn_header.id = @id;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);

            return db.ExecuteQuery(query, parameters);
        }
    }//class
}
