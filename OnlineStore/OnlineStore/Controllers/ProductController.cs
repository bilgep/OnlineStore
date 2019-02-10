using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models;

namespace OnlineStore.Controllers
{
    public class ProductController : Controller
    {
        #region Initializing the Controller with a data collection by using a construction method
        private IProductRepository repository;
        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }
        #endregion


        public int PageSize = 2;

        // productPage = 1 (displays first page as default if the page is not specified
        public ViewResult List(int productPage = 1) => View(repository.Products
            .OrderBy(x => x.Name)
            .Skip((productPage-1) * PageSize)
            .Take(PageSize));
    
    }                                                                       
}