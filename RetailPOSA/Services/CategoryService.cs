using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailPOSA.Services
{
    internal class CategoryService
    {
        Database db = new Database();

        public int InsertCategory(string name, bool status)
        { 
            string query = "INSERT INTO categories(name, status) VALUES(@name, @status);";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@name", name);
            parameters.Add("@status", status);

            return db.ExecuteNonQuery(query, parameters);
        }

        public int UpdateCategory(int id, string name)
        {
            string query = "UPDATE categories SET name = @name WHERE id = @id;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@id", id);
            parameters.Add("@name", name);

            return db.ExecuteNonQuery(query, parameters);
        }//update category

        public DataTable GetAllCategories()
        {
            string query = "SELECT id, name FROM categories WHERE status = 1;";

            DataTable dt = db.ExecuteQuery(query);

            return dt;
        }//get all categories

        public DataTable GetCategoryByID(int id)
        {
            string query = "SELECT id, name FROM categories WHERE id = @id;";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);

            return db.ExecuteQuery(query, parameters);
        }//get category by id

    }//class
}
