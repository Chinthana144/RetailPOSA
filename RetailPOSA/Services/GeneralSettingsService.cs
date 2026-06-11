using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailPOSA.Services
{
    internal class GeneralSettingsService
    {
        Database db = new Database();

        public DataTable GetActiveSettings()
        {
            string query = "SELECT * FROM general_settings WHERE status = 1;";

            return db.ExecuteQuery(query);
        }//get active settings

    }//class
}
