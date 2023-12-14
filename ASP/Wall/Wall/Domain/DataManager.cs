using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wall.Domain.Repositories.Abstract;

namespace Wall.Domain
{
    public class DataManager
    {
        public IProductsRepository product { get; set; }

        public DataManager(IProductsRepository productsRepository)
        {
            product = productsRepository;
        }
    }
}
