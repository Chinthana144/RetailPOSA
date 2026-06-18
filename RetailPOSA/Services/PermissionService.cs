using Mysqlx.Expr;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailPOSA.Services
{
    internal class PermissionService
    {
        Database db = new Database();

        public int SyncPermission(int roleID, int pageID, int view, int add, int edit, int remove, int print, int status)
        {
            //check duplicates
            int permissionID = CheckDuplicate(roleID, pageID);

            if (permissionID == 0)
            {
                return InsertPermission(roleID, pageID, view, add, edit, remove, print, status);
            }//insert
            else
            {
                return UpdatePermission(permissionID, roleID, pageID, view, add, edit, remove, print, status);
            }//update

        }//update permission

        public int InsertPermission(int roleID, int pageID, int view, int add, int edit, int remove, int print, int status)
        {
            string query = "INSERT INTO role_permissions(role_id, page_id, view, role_permissions.add, edit, remove, print, status) " +
                "VALUES(@roleID, @pageID, @view, @add, @edit, @remove, @print, @status);";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@roleID", roleID);
            parameters.Add("@pageID", pageID);
            parameters.Add("@view", view);
            parameters.Add("@add", add);
            parameters.Add("@edit", edit);
            parameters.Add("@remove", remove);
            parameters.Add("@print", print);
            parameters.Add("@status", status);

            return db.ExecuteNonQuery(query, parameters);
        }

        public int UpdatePermission(int id, int roleID, int pageID, int view, int add, int edit, int remove, int print, int status)
        {
            string query = "UPDATE role_permissions SET role_id = @roleID, page_id = @pageID, view = @view, role_permissions.add = @add, edit = @edit, remove = @remove, print = @print, status = @status WHERE id = @id;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            parameters.Add("@roleID", roleID);
            parameters.Add("@pageID", pageID);
            parameters.Add("@view", view);
            parameters.Add("@add", add);
            parameters.Add("@edit", edit);
            parameters.Add("@remove", remove);
            parameters.Add("@print", print);
            parameters.Add("@status", status);

            return db.ExecuteNonQuery(query, parameters);
        }//update

        public bool CheckPermissionView(int roleID, int pageID)
        {
            string query = "SELECT * FROM role_permissions WHERE role_id = @roleID AND page_id = @pageID AND view = 1;";
            
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@roleID", roleID);
            parameters.Add("@pageID", pageID);

            DataTable dt = db.ExecuteQuery(query, parameters);

            //Admin permission
            if (roleID == 1)
            {
                return true;
            }
            else
            {
                return dt.Rows.Count > 0 ? true : false;
            }
        }//check permission

        public DataTable GetPermissions(int roleID, int pageID)
        {
            string query = "SELECT * FROM role_permissions WHERE role_id = @roleID AND page_id = @pageID;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@roleID", roleID);
            parameters.Add("@pageID", pageID);

            return db.ExecuteQuery(query, parameters);
        }

        public DataTable GetPermissionsByRoleID(int roleID)
        {
            string query = "SELECT role_permissions.id, " +
                "pages.name, role_id, page_id, view, role_permissions.add, edit, remove, print, role_permissions.status " +
                "FROM role_permissions " +
                "INNER JOIN pages ON pages.id = role_permissions.page_id  " +
                "WHERE role_id = @roleID;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@roleID", roleID);

            return db.ExecuteQuery(query,parameters);
        }//get permission by role id

        public DataTable GetPages()
        {
            string query = "SELECT * FROM pages ORDER BY id ASC;";
            return db.ExecuteQuery(query);
        }

        private int CheckDuplicate(int roleID, int pageID)
        {
            string query = "SELECT * FROM role_permissions WHERE role_id = @roleID AND page_id = @pageID;";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@roleID", roleID);
            parameters.Add("@pageID", pageID);

            DataTable dt = db.ExecuteQuery(query, parameters);

            return dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0]["id"]) : 0;            
        }
    }//class
}
