using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailPOSA.Services
{
    internal class ProductService
    {
        Database db = new Database();
        public int InsertProduct(int categoryId, string barcode, string name, string secondName, bool isWeighted, bool hasExpiry, int minimumStock, bool status)
        {
            string query = "INSERT INTO products (category_id, barcode, name, second_name,  is_weighted, has_expiry, minimum_stock, status) " +
                " VALUES (@category_id, @barcode, @name, @second_name, @is_weighted, @has_expiry, @minimum_stock, @status)";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@category_id", categoryId);
            parameters.Add("@barcode", barcode);
            parameters.Add("@name", name);
            parameters.Add("@second_name", secondName);
            parameters.Add("@is_weighted", isWeighted);
            parameters.Add("@has_expiry", hasExpiry);
            parameters.Add("@minimum_stock", minimumStock);
            parameters.Add("@status", status);

            return db.ExecuteNonQuery(query, parameters);
        }//insert product

        public int UpdateProduct(int id, int categoryId, string barcode, string name, string secondName, bool isWeighted, bool hasExpiry, int minimumStock, bool status)
        {
            string query = "UPDATE products SET " +
                "category_id = @category_id, " +
                "barcode = @barcode, " +
                "name = @name, " +
                "second_name = @second_name, " +
                "is_weighted = @is_weighted, " +
                "has_expiry = @has_expiry, " +
                "minimum_stock = @minimum_stock, " +
                "status = @status " +
                "WHERE id = @id";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@id", id);
            parameters.Add("@category_id", categoryId);
            parameters.Add("@barcode", barcode);
            parameters.Add("@name", name);
            parameters.Add("@second_name", secondName);
            parameters.Add("@is_weighted", isWeighted);
            parameters.Add("@has_expiry", hasExpiry);
            parameters.Add("@minimum_stock", minimumStock);
            parameters.Add("@status", status);

            return db.ExecuteNonQuery(query, parameters);
        }//update product

        public DataTable GetAllProducts(int limit, int offset)
        {
            string query = "SELECT " +
                "products.id, " +
                "categories.name as category, " +
                "products.barcode, " +
                "products.name as product, " +
                "products.second_name, " +
                "products.is_weighted, " +
                "products.has_expiry, " +
                "products.minimum_stock " +
                "FROM products " +
                "INNER JOIN categories ON categories.id = products.category_id " +
                "WHERE products.status = 1 " +
                "LIMIT @limit OFFSET @offset;";
            
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@limit", limit);
            parameters.Add("@offset", offset);

            return db.ExecuteQuery(query, parameters);
        }//get all products

        public DataTable GetProductByID(int id)
        {
            string query = "SELECT " +
                "products.id, " +
                "products.category_id, " +
                "categories.name as category, " +
                "products.barcode, " +
                "products.name as product, " +
                "products.second_name, " +
                "products.is_weighted, " +
                "products.has_expiry, " +
                "products.minimum_stock " +
                "FROM products " +
                "INNER JOIN categories ON categories.id = products.category_id " +
                "WHERE products.status = 1 AND products.id = @id;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@id", id);

            return db.ExecuteQuery(query, parameters);
        }//get product by id

        public DataTable SearchProducts(string searchTerm)
        { 
            string query = "SELECT " +
                "products.id, " +
                "categories.name as category, " +
                "products.barcode, " +
                "products.name as product, " +
                "products.second_name, " +
                "products.is_weighted, " +
                "products.has_expiry, " +
                "products.minimum_stock " +
                "FROM products " +
                "INNER JOIN categories ON categories.id = products.category_id " +
                "WHERE products.status = 1 AND (products.name LIKE @searchTerm OR products.barcode LIKE @searchTerm);";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@searchTerm", $"%{searchTerm}%");

            return db.ExecuteQuery(query, parameters);
        }//search products
    }//class
}
