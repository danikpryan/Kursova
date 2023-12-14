using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wall.Domain.Entities;

namespace Wall.Models
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> getAllProducts { get; set; }
        public string currCategory { get; set; }
    }
}
