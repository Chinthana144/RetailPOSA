using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailPOSA
{
    public class Database
    {
        private string connectionString = "server=localhost;database=retail_pos_a;uid=root;pwd=bluecat4";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }//get connection

        // SELECT queries
        public DataTable ExecuteQuery(string query, Dictionary<string, object> parameters = null)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, conn);

                // Add parameters
                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(
                            param.Key,
                            param.Value
                        );
                    }
                }

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                adapter.Fill(dt);

                return dt;
            }
        }//execute query
        //        MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);

        //        DataTable dt = new DataTable();

        //        adapter.Fill(dt);

        //        return dt;
        //    }
        //}//execute query

        // INSERT UPDATE DELETE
        public int ExecuteNonQuery(string query, Dictionary<string, object> parameters)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, conn);

                // Add parameters
                foreach (var param in parameters)
                {
                    cmd.Parameters.AddWithValue(
                        param.Key,
                        param.Value
                    );
                }

                return cmd.ExecuteNonQuery();
            }
        }//execute non query
    }//class
}//namespace
