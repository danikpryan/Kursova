using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wall.Domain.Entities
{
    public class Category
    {
        public int id { get; set; }
        public string categoryName { get; set; }
        public List<Product> products { set; get; }
    }
}
