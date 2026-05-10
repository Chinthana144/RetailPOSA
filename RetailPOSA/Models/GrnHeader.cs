using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailPOSA.Models
{
    internal class GrnHeader
    {
        public int id { get; set; }
        public int supplier_id { get; set; }
        public string invoice_no { get; set; }
        public DateTime date_submitted { get; set; }
        public int item_count { get; set; }
        public decimal purchase_price { get; set; }
        public decimal selling_price { get; set; }
        public bool status { get; set; }
        public int user_id { get; set; }
    }
}
