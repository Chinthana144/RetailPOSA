using RetailPOSA.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RetailPOSA.Services
{
    internal class ShopService
    {
        Database db = new Database();
        public int InsertShop(string name, string address, string phone, string shopLogo, string receiptLogo, string invoicePrefix, string currency, int status)
        {
            string query = "INSERT INTO shop(name, address, phone, shop_logo, receipt_logo, invoice_prefix, currency, status) "+
                "VALUES(@name,@address,@phone,@shopLogo,@receiptLogo,@invoicePrefix,@currency,@status);";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@name", name);
            parameters.Add("@address", address);
            parameters.Add("@phone", phone);
            parameters.Add("@shopLogo", shopLogo);
            parameters.Add("@receiptLogo", receiptLogo);
            parameters.Add("@invoicePrefix", invoicePrefix);
            parameters.Add("@currency", currency);
            parameters.Add("@status", status);

            return db.ExecuteNonQuery(query, parameters);
        }

        public int UpdateShop(int id, string name, string address, string phone, string shopLogo, string receiptLogo, string invoicePrefix, string currency)
        {
            string query = "UPDATE shop SET " +
                "name = @name, " +
                "address = @address, " +
                "phone = @phone, " +
                "shop_logo = @shopLogo, " +
                "receipt_logo = @receiptLogo," +
                "invoice_prefix = @invoicePrefix, " +
                "currency = @currency " +
                "WHERE id = @id;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@id", id);
            parameters.Add("@name", name);
            parameters.Add("@address", address);
            parameters.Add("@phone", phone);
            parameters.Add("@shopLogo", shopLogo);
            parameters.Add("@receiptLogo", receiptLogo);
            parameters.Add("@invoicePrefix", invoicePrefix);
            parameters.Add("@currency", currency);

            return db.ExecuteNonQuery(query, parameters);
        }//update shop

        public DataTable GetShop()
        {
            string query = "SELECT * FROM shop WHERE status = 1 LIMIT 1;";

            return db.ExecuteQuery(query);
        }//get shop

    }//class
}
