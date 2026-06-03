using Mysqlx.Crud;
using RetailPOSA.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailPOSA.Services
{
    internal class InvoiceService
    {
        Database db = new Database();

        public int InsertInvoiceHeader(string issuedDate, int itemCount, decimal total, decimal discounts, decimal subTotal, decimal paymethodID, decimal paidAmount, decimal balance, int userID, int status)
        {
            string invoiceNo = GetInvoiceNo();
            string query = "INSERT INTO invoice_header(issued_date, invoice_no, item_count, total, discounts, sub_total, paymethod_id, paid_amount, balance, user_id, status) " +
                "VALUES(@issuedDate, @invoiceNo, @itemCount, @total, @discounts, @subTotal, @paymethodID, @paidAmount, @balance, @userID, @status);";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@issuedDate", issuedDate);
            parameters.Add("@invoiceNo", invoiceNo);
            parameters.Add("@itemCount", itemCount);
            parameters.Add("@total", total);
            parameters.Add("@discounts", discounts);
            parameters.Add("@subTotal", subTotal);
            parameters.Add("@paymethodID", paymethodID);
            parameters.Add("@paidAmount", paidAmount);
            parameters.Add("@balance", balance);
            parameters.Add("@userID", userID);
            parameters.Add("@status", status);

            return db.ExecuteNonQuery(query, parameters);
        }//insert invoice

        public int InsertInvoiceDetail(int invoiceID, int inventoryID, int productID, decimal unitPrice, decimal qty, decimal sellingPrice, decimal discount, decimal finalPrice, int status)
        {
            string query = "INSERT INTO invoice_details(invoice_id, inventory_id, product_id, unit_price, qty, selling_price, discount, final_price, status) "+
                "VALUES(@invoiceID, @inventoryID, @productID, @unitPrice, @qty, @sellingPrice, @discount, @finalPrice, @status)";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@invoiceID", invoiceID);
            parameters.Add("@inventoryID", inventoryID);
            parameters.Add("@productID", productID);
            parameters.Add("@unitPrice", unitPrice);
            parameters.Add("@qty", qty);
            parameters.Add("@sellingPrice", sellingPrice);
            parameters.Add("@discount", discount);
            parameters.Add("@finalPrice", finalPrice);
            parameters.Add("@status", status);

            return db.ExecuteNonQuery(query, parameters);

        }//insert invoice detail

        public int UpdateInvoiceHeader(int id, int itemCount, decimal totalPrice, decimal discounts, decimal finalTotal, int paymethodID, decimal paidAmount, decimal balance, int status)
        {
            string query = "UPDATE invoice_header SET " +
                "item_count = @itemCount, " +
                "total = @totalPrice, " +
                "discounts = @discounts, " +
                "sub_total = @finalTotal, " +
                "paymethod_id = @paymethodID, " +
                "paid_amount = @paidAmount, " +
                "balance = @balance, " +
                "status = @status " +
                "WHERE id = @id;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@id", id);
            parameters.Add("@itemCount", itemCount);
            parameters.Add("@totalPrice", totalPrice);
            parameters.Add("@discounts", discounts);
            parameters.Add("@finalTotal", finalTotal);
            parameters.Add("@paymethodID", paymethodID);
            parameters.Add("@paidAmount", paidAmount);
            parameters.Add("@balance", balance);
            parameters.Add("@status", status);

            return db.ExecuteNonQuery(query, parameters);
        }//update invoice header

        public int GetActiveInvoicebyUserID(int userID)
        {
            string query = "SELECT * FROM invoice_header WHERE user_id = @userID AND status = 1 " +
                "LIMIT 1 ;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@userID", userID);

            DataTable dt = db.ExecuteQuery(query, parameters);

            return Convert.ToInt32(dt.Rows[0]["id"]); 
        }

        public DataTable GetInvoiceDetailByHeaderID(int headerID)
        {
            string query = "SELECT invoice_details.id, invoice_id, inventory_id, product_id, " +
                "category_id, barcode, name, second_name, " +
                "unit_price, qty, selling_price, discount, final_price, invoice_details.status " +
                "FROM invoice_details " +
                "INNER JOIN products ON products.id = invoice_details.product_id "+
                "WHERE invoice_id = @headerID;";
            
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@headerID", headerID);

            return db.ExecuteQuery(query, parameters);
        }//get invoice detail by header id

        public string GetInvoiceNo()
        {
            string query = "SELECT IFNULL(MAX(ID), 0) as invoice_count FROM invoice_header;";

            DataTable countData = db.ExecuteQuery(query);

            int nextInvoiceNo = Convert.ToInt32(countData.Rows[0]["invoice_count"]) + 1;

            return "INV_" + nextInvoiceNo.ToString("D7");
        }//test method

        public DataTable GetInvoiceHeader(int limit, int offset)
        {
            string query = "SELECT "+
                "invoice_header.id, "+
                "issued_date, " +
                "invoice_no, " +
                "item_count, " +
                "total, " +
                "discounts, " +
                "sub_total, " +
                "paid_amount, " +
                "balance, " +
                "paymethod," +
                "username " +
                "FROM invoice_header " +
                "INNER JOIN paymethods ON paymethods.id = invoice_header.paymethod_id "+
                "INNER JOIN users ON users.user_id = invoice_header.user_id "+
                "ORDER BY id DESC " +
                "LIMIT @limit OFFSET @offset;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@limit", limit);
            parameters.Add("@offset", offset);

            return db.ExecuteQuery(query, parameters);

        }//get invoice header

        public DataTable SearchProducts(string searchTerm)
        {
            string query = "SELECT " +
                "invoice_header.id, " +
                "issued_date, " +
                "invoice_no, " +
                "item_count, " +
                "total, " +
                "discounts, " +
                "sub_total, " +
                "paid_amount, " +
                "balance, " +
                "paymethod," +
                "username " +
                "FROM invoice_header " +
                "INNER JOIN paymethods ON paymethods.id = invoice_header.paymethod_id " +
                "INNER JOIN users ON users.user_id = invoice_header.user_id " +
                "WHERE issued_date LIKE @searchTerm OR invoice_no LIKE @searchTerm OR username LIKE @searchTerm " +
                "ORDER BY id DESC ";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@searchTerm", $"%{searchTerm}%");

            return db.ExecuteQuery(query, parameters);
        }

        public DataTable GetInvoiceByInvoiceNo(string invoiceNo)
        {
            string query = "SELECT " +
                "invoice_header.id, " +
                "issued_date, " +
                "invoice_no, " +
                "item_count, " +
                "total, " +
                "discounts, " +
                "sub_total, " +
                "paid_amount, " +
                "balance, " +
                "paymethod," +
                "username " +
                "FROM invoice_header " +
                "INNER JOIN paymethods ON paymethods.id = invoice_header.paymethod_id " +
                "INNER JOIN users ON users.user_id = invoice_header.user_id " +
                "WHERE invoice_header.invoice_no = @invoiceNo";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@invoiceNo", invoiceNo);

            return db.ExecuteQuery(query, parameters);
        }//get invoice by invoice no

        public DataTable GetPaymethods()
        {
            string query = "SELECT * FROM paymethods WHERE status = 1;";

            return db.ExecuteQuery(query);
        }
    }//class
}
