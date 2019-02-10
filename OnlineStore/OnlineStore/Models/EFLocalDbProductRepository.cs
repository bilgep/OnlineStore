using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Models
{
    public class EFLocalDbProductRepository : IProductRepository
    {
        private LocalDbContext myContext;

        public EFLocalDbProductRepository(LocalDbContext ctx)
        {
            myContext = ctx;
        }

        public IQueryable<Product> Products => myContext.LocalDbProducts;

    }
}
