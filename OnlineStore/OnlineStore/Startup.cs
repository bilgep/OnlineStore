using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using OnlineStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace OnlineStore
{

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }



        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDbContext<LocalDbContext>(options =>
            {
                options.UseSqlServer(Configuration["Data:OnlineStore:ConnectionString"]);
            });

            services.AddTransient<IProductRepository, EFLocalDbProductRepository>();

            //services.AddTransient<IProductRepository, FakeProductRepository>(); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // TODO in prod
            }

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});

            app.UseMvc(routes => {
                routes.MapRoute(name:"default", template:"{controller=Product}/{action=List}/{id?}");
                routes.MapRoute(name:"pagination", template:"Products/Page{productPage}", defaults:new { Controller="Product",action="List"});
            });
            app.UseStaticFiles();
            app.UseStatusCodePages();

            // Appending IProductReposity data to the current app (IApplicationBuilder =  Configuration)
            SeedData.EnsurePopulated(app);
            
        }
    }
}
