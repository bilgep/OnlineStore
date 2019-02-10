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

        public ViewResult List() => View(repository.Products);
    
    }                                                                       
}