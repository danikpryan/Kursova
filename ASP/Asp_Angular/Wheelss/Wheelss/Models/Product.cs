using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wheelss.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Descrit { get; set; }
        public int Price { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public int Value { get; set; }
        public int categoryId { get; set; }
        public string img { get; set; }
        public string img2 { get; set; }
        public bool isFavorite { get; set; }
    }
}
