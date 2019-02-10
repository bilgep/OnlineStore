using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Models
{
    /// <summary>
    /// Provides a fake set of Product data in IQueryable collection format
    /// </summary>
    public class FakeProductRepository : IProductRepository
    {
        public IQueryable<Product> Products =>  new List<Product> {
            new Product { Name = "Knitwear", Price=15},
            new Product { Name = "Skirt", Price=20},
            new Product { Name = "Dress", Price=50}
        }.AsQueryable<Product>();
    }
}
