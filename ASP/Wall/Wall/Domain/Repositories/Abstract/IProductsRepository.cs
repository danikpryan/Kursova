using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wall.Domain.Entities;

namespace Wall.Domain.Repositories.Abstract
{
    public interface IProductsRepository
    {
        IEnumerable<Product> getProducts { get; }
        Product GetProductsbyId(Guid id);
        void SaveProduct(Product products);
        void DeleteProduct(Guid id);
    }
}






