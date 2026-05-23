using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailPOSA.Models
{
    internal class Category
    {
        public int id { get; set; }

        public string name { get; set; }

        public bool status { get; set; } = false;
    }//class
}
