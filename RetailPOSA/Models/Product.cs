using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailPOSA.Models
{
    internal class Product
    {
        public int id { get; set; }
        public int category_id { get; set; }
        public string barcode { get; set; }
        public string name { get; set; }
        public string second_name { get; set; } = string.Empty;
        public bool is_weighted { get; set; }
        public bool has_expory { get; set; }
        public int minimum_stock { get; set; } = 0;
        public bool status { get; set; } = true;

    }//class
}
