using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OnlineStore.Models
{
    public class SeedData
    {
        // IApplicationBuilder is interface used in the Configure method of Startup
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            List<Product> products = new List<Product>() {
                new Product{ Name="Red Skirt", Description="Red Skirt With Buttons", Category="Skirts", Price=15},
                new Product{ Name="Blue Skirt", Description="Blue Maxi Skirt ", Category="Skirts", Price=20},
                new Product{ Name="Casual Shirt", Description="Casual White Shirt", Category="Shirts", Price=30},
                new Product{ Name="Black Coat", Description="Black Coat For Men", Category="Outwear", Price=65 },
                new Product{ Name="Brown Hat", Description="Classic Hat For Men", Category="Hats", Price=10},
            };

            // GetRequiredServices method is a member of DependencyInjection lib - Microsoft.Extensions.DependencyInjection must be added as reference
            LocalDbContext myAppContext = app.ApplicationServices.GetRequiredService<LocalDbContext>();

            myAppContext.Database.Migrate();

            if (!myAppContext.LocalDbProducts.Any())
            {
                myAppContext.LocalDbProducts.AddRange(products);
            }
 
            myAppContext.SaveChanges();

        }
    }
}
