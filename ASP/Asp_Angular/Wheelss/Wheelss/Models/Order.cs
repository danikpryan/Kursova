using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wheelss.Models
{
    public class Order
    {
        public string Id { get; set; }//per
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }

        public bool Shipped = false;
    }
}
