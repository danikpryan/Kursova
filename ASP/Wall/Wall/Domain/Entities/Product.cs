using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wall.Domain.Entities
{
    public class Product
    {
        [Required]
        public Guid id { get; set; }
        [Display(Name ="Название")]
        public string name { get; set; }
        [Display(Name = "Опис")]
        public string desc { get; set; }
        [Display(Name = "Матеріал")]
        public string material { get; set; }
        [Display(Name = "Стать")]
        [StringLength(maximumLength:1)]
        public string sex { get; set; }
        public string img { get; set; }
        public ushort price { get; set; }
        public string size { get; set; }
        public string color { get; set; }
        public int value { get; set; }
        public int categoryId { get; set; }
        public virtual Category category { get; set; }
    }
}
