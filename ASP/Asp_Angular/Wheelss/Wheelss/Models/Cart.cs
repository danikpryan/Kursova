using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wheelss.Models
{
    public class Cart
    {
        public Cart cart { get; set; }
        public int ProductId {get;set;}
        public string Name {get;set;}
        public List<Product> products { get; set; }

        
    }
}