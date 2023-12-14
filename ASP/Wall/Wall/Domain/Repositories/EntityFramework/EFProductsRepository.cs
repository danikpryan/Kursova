using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wall.Domain.Entities;
using Wall.Domain.Repositories.Abstract;

namespace Wall.Domain.Repositories.EntityFramework
{
    public class EFProductsRepository :IProductsRepository
    {
        private readonly AppDbContext context;

        public EFProductsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Product> getProducts => context.Products.Include(c => c.category);

        public Product GetProductsbyId(Guid id)
        {
            return context.Products.FirstOrDefault(x => x.id == id);
        }

        public void SaveProduct(Product entity)
        {
            if (entity.id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteProduct(Guid id)
        {
            context.Products.Remove(new Product() { id = id });
            context.SaveChanges();
        }
    }
}
