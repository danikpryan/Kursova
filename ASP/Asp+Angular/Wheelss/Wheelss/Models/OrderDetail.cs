using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wheelss.Models
{
    public class OrderDetail
    {
        public string DetailId { get; set; }//per
        public string OrderId { get; set; }//per
        public string ProductId { get; set; }
    }
}
