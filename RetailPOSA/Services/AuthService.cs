using RetailPOSA.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailPOSA.Services
{
    internal class AuthService
    {
        Database db = new Database();
        public int Login(string username, string password)
        { 
            string query = "SELECT u.user_id, u.username, r.id as role_id, r.name AS role_name " +
                "FROM users u " +
                "JOIN roles r ON u.role_id = r.id " +
                "WHERE u.username = @username AND u.password = @password;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@username", username);
            parameters.Add("@password", password);

            DataTable dt = db.ExecuteQuery(query, parameters);

            if(dt.Rows.Count > 0)
            {
                //initialize session values
                Session.UserID = Convert.ToInt32(dt.Rows[0]["user_id"]);
                Session.UserName = dt.Rows[0]["username"].ToString();
                Session.RoleID = Convert.ToInt32(dt.Rows[0]["role_id"]);
                Session.RoleName = dt.Rows[0]["role_name"].ToString();

                return 1; // Login successful
            }
            else
            {
                return -1; // Login failed
            }
        }

    }//class
}
