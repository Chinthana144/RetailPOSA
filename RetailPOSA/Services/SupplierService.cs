using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailPOSA.Services
{
    internal class SupplierService
    {
        Database db = new Database();
        public int InsertSupplier(string companyName, string supplierName, string contactNo, bool status)
        { 
            string query = "INSERT INTO suppliers (company_name, supplier_name, contact_no, status) VALUES " +
                "(@company_name, @supplier_name, @contact_no, @status);";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@company_name", companyName);
            parameters.Add("@supplier_name", supplierName);
            parameters.Add("@contact_no", contactNo);
            parameters.Add("@status", status);

            return db.ExecuteNonQuery(query, parameters);
        }//insert supplier

        public int UpdateSupplier(int id, string companyName, string supplierName, string contactNo, bool status)
        {
            string query = "UPDATE suppliers SET company_name = @company_name, supplier_name = @supplier_name, " +
                "contact_no = @contact_no, status = @status WHERE id = @id;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@id", id);
            parameters.Add("@company_name", companyName);
            parameters.Add("@supplier_name", supplierName);
            parameters.Add("@contact_no", contactNo);
            parameters.Add("@status", status);

            return db.ExecuteNonQuery(query, parameters);
        }//update supplier

        public DataTable GetAllSuppliers(int limit, int offset)
        {
            string query = "SELECT id, company_name, supplier_name, contact_no FROM suppliers " +
                "WHERE status = 1 " +
                "LIMIT @limit OFFSET @offset;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@limit", limit);
            parameters.Add("@offset", offset);

            return db.ExecuteQuery(query, parameters);
        }//get all suppliers

        public DataTable GetSupplierByID(int id)
        {
            string query = "SELECT id, company_name, supplier_name, contact_no FROM suppliers " +
                "WHERE id = @id;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);

            return db.ExecuteQuery(query, parameters);
        }//get supplier by id

    }//class
}
