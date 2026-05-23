using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailPOSA.Models
{
    internal class Supplier
    {
        public int ID { get; set; }
        public string company_name { get; set; }
        public string supplier_name { get; set; }
        public string contact_no { get; set; } 
        public bool status { get; set; }
    }//class
}
