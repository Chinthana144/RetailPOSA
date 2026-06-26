using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace RetailPOSA.Services
{
    internal class UserService
    {
        Database db = new Database();

        //INSERT USER
        public int InsertUser(int roleId, string username, string password)
        {
            string query = "INSERT INTO users(role_id, username, password)" +
                "VALUES(@role_id, @username, @password);";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@role_id", roleId);
            parameters.Add("@username", username);
            parameters.Add("@password", password);

            return db.ExecuteNonQuery(query, parameters);
        }//insert user

        //UPDATE USER
        public int UpdateUser(int id, int roleId, string username)
        {
            string query = "UPDATE users SET role_id = @role_id, username = @username " +
                "WHERE user_id = @id;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@id", id);
            parameters.Add("@role_id", roleId);
            parameters.Add("@username", username);

            return db.ExecuteNonQuery(query, parameters);
        }//update user

        public int UpdateUserName(int id, string username)
        {
            string query = "SELECT * FROM users WHERE username = @userName;";
            Dictionary<string, object> userParameters = new Dictionary<string, object>();
            userParameters.Add("@username", username);

            DataTable dt = db.ExecuteQuery(query, userParameters);
            if (dt.Rows.Count > 0)
            {
                return 0;
            }
            else {
                string updateQuery = "UPDATE users SET username = @username WHERE user_id = 1;";
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@username", username);

                return db.ExecuteNonQuery(updateQuery, parameters);
            }
        }//update username

        public int UpdatePassword(int id, string password)
        {
            string updateQuery = "UPDATE users SET password = @password WHERE user_id = 1;";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@password", password);

            return db.ExecuteNonQuery(updateQuery, parameters);
        }//update password

        public DataTable GetAllUsers()
        { 
            string query = "SELECT user_id, roles.name, username FROM users" + 
                " INNER JOIN roles ON roles.id = users.role_id;";
            return db.ExecuteQuery(query);  
        }//get all users

        public DataTable GetUserById(int id)
        {
            string query = "SELECT user_id, role_id, roles.name as role_name, username, password FROM users " +
                "INNER JOIN roles ON roles.id = users.role_id "+
                "WHERE user_id = @id;";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);

            return db.ExecuteQuery(query, parameters);
        }//get user by id

        public DataTable GetRoles()
        {
            string query = "SELECT * FROM roles ORDER BY id;";

            return db.ExecuteQuery(query);
        }//get roles

    }//class
}
