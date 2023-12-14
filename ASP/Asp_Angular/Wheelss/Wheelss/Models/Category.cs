using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wheelss.Models
{
    public class Category
    {
        public int categoryId { get; set; }
        public string categoryName { get; set; }

        public List<Product> products;
    }
}
