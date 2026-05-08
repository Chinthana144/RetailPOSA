using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailPOSA.Models
{
    public class Users
    {
        public int user_id { get; set; }
        public int role_id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
