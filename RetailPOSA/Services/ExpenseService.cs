using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RetailPOSA.Services
{
    internal class ExpenseService
    {
        Database db = new Database();
        //============================= Expenses ===========================//
        public int InsertExpense(string dateTime, string categoryName, string description, decimal amount, int userID, int status)
        {
            DataTable categoryData = getCategoryByName(categoryName);
            int categoryID = categoryData != null ? Convert.ToInt32(categoryData.Rows[0]["id"]) : 1;

            string query = "INSERT INTO expenses(datetime, category_id, description, amount, user_id, status) "+
                "VALUES(@dateTime,@categoryID,@description,@amount,@userID,@status);";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@dateTime", dateTime);
            parameters.Add("@categoryID", categoryID);
            parameters.Add("@description", description);
            parameters.Add("@amount", amount);
            parameters.Add("@userID", userID);
            parameters.Add("@status", status);

            return db.ExecuteNonQuery(query, parameters);
        }//insert

        public int UpdateExpense(int id, string dateTime, string categoryName, string description, decimal amount, int userID)
        {
            DataTable categoryData = getCategoryByName(categoryName);
            int categoryID = categoryData != null ? Convert.ToInt32(categoryData.Rows[0]["id"]) : 1;

            string query = "UPDATE expenses SET datetime = @dateTime, category_id = @categoryID, description = @description, amount = @amount, user_id = @userID WHERE id = @id;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@id", id);
            parameters.Add("@dateTime", dateTime);
            parameters.Add("@categoryID", categoryID);
            parameters.Add("@description", description);
            parameters.Add("@amount", amount);
            parameters.Add("@userID", userID);

            return db.ExecuteNonQuery(query, parameters);
        }//update

        public DataTable searchExpenses(string searchText, int limit, int offset)
        {
            string query = "SELECT expenses.id, datetime, category_id, category_name, description, amount, expenses.user_id, expenses.status, username " +
                "FROM expenses " +
                "INNER JOIN expense_categories ON expense_categories.id = expenses.category_id " +
                "INNER JOIN users ON users.user_id = expenses.user_id " +
                "WHERE datetime LIKE @searchText OR description LIKE @searchText OR category_name LIKE @searchText OR username LIKE @searchText " +
                "ORDER BY datetime DESC " +
                "LIMIT @limit OFFSET @offset;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@searchText", $"%{searchText}%");
            parameters.Add("@limit", limit);
            parameters.Add("@offset", offset);

            return db.ExecuteQuery(query, parameters);
        }//search expenses

        public DataTable GetExpenseByID(int id)
        {
            string query = "SELECT * FROM expenses WHERE id  = @id;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);

            return db.ExecuteQuery(query, parameters);
        }//get expense by ID

        //============================= Categories ============================//
        public int InsertExpenseCategory(string categoryName, int status)
        {
            //check duplicates
            if (!checkCategoryDuplicates(categoryName))
            {
                string query = "INSERT INTO expense_categories(category_name, status) VALUES(@categoryName, @status);";

                Dictionary<string, object> parameters = new Dictionary<string, object>();

                parameters.Add("@categoryName", categoryName);
                parameters.Add("@status", status);

                return db.ExecuteNonQuery(query, parameters);
            }//no duplicates
            else
            {
                return 0;
            }
        }//insert

        public int UpdateExpenseCategory(int id, string categoryName)
        {
            //check duplicates
            if (!checkCategoryDuplicates(categoryName))
            {
                string query = "UPDATE expense_categories SET category_name = @categoryName WHERE id = @id;";

                Dictionary<string, object> parameters = new Dictionary<string, object>();

                parameters.Add("@id", id);
                parameters.Add("@categoryName", categoryName);

                return db.ExecuteNonQuery(query, parameters);
            }//no duplicates
            else 
            {
                return 0;
            }//duplicate
        }//update

        public DataTable GetExpenseCategories()
        {
            string query = "SELECT * FROM expense_categories WHERE status = 1;";

            return db.ExecuteQuery(query);
        }

        public DataTable getCategoryByName(string categoryName)
        {
            string query = "SELECT * FROM expense_categories WHERE category_name = @categoryName;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@categoryName", categoryName);

            DataTable dt = db.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                return db.ExecuteQuery(query, parameters);
            }
            else { 
                return null; 
            }
        }//get category by name

        public bool checkCategoryDuplicates(string categoryName)
        {
            string query = "SELECT * FROM expense_categories WHERE category_name = @categoryName;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@categoryName", categoryName);

            DataTable dt = db.ExecuteQuery(query, parameters);

            return dt.Rows.Count > 0 ? true : false;
          
        }//check duplicates
    }//class
}
