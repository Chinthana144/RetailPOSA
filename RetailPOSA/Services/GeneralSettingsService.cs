using Google.Protobuf.WellKnownTypes;
using RetailPOSA.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

        public int SyncSetting(string settingKey, string settingValue, int status)
        {
            int settingID = CheckSettingExists(settingKey);
            string currentDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            if (settingID == 0)
            {
                return InsertSetting(settingKey, settingValue, currentDateTime, status);
            }//insert
            else 
            {
                return UpdateSetting(settingID, settingKey, settingValue, currentDateTime, status);
            }//update
        }//check and set setting

        private int InsertSetting(string settingKey, string settingValue, string updateDate, int status)
        {
            string query = "INSERT INTO general_settings(settings_key, settings_value, updated_at, status) "+
                "VALUES(@settingKey,@settingValue,@updateDate,@status)";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@settingKey", settingKey);
            parameters.Add("@settingValue", settingValue);
            parameters.Add("@updateDate", updateDate);
            parameters.Add("@status", status);

            return db.ExecuteNonQuery(query, parameters);
        }//insert

        private int UpdateSetting(int id, string settingKey, string settingValue, string updateDate, int status)
        {
            string query = "UPDATE general_settings SET settings_key = @settingKey, settings_value = @settingValue, updated_at = @updateDate, status = @status WHERE id = @id;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@id", id);
            parameters.Add("@settingKey", settingKey);
            parameters.Add("@settingValue", settingValue);
            parameters.Add("@updateDate", updateDate);
            parameters.Add("@status", status);

            return db.ExecuteNonQuery(query, parameters);
        }//update

        //check exist
        private int CheckSettingExists(string settingKey)
        {
            string query = "SELECT * FROM general_settings WHERE settings_key = @settingKey LIMIT 1;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("@settingKey", settingKey);

            DataTable dt = db.ExecuteQuery(query, parameters);

            return dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0]["id"]) : 0 ;
        }

        public DataTable GetAllSettings()
        {
            string query = "SELECT * FROM general_settings;";

            return db.ExecuteQuery(query);
        }//get all settings

        //get color by setting key
        public string GetColor(string colorType)
        {
            string query = "SELECT * FROM general_settings WHERE settings_key = @colorType;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@colorType", colorType);

            DataTable dt = db.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["settings_value"].ToString();
            }
            else
            {
                return "";
            }
        }
    }//class
}
