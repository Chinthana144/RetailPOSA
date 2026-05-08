using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace RetailPOSA
{
    public class Database
    {
        private string connectionString = "server=localhost;database=retail_pos_a;uid=root;pwd=bluecat4";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }//get connection
    }//class
}
