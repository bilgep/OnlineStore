using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Models
{
    /// <summary>
    /// Can be used when it's necessary to return an IQuerable collection of Products
    /// </summary>
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
    }
}
