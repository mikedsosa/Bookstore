using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Mike05.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mike05
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //Add connection string to allow database connection
            services.AddDbContext<BookDbContext>(options =>
            {
                options.UseSqlite(Configuration["ConnectionStrings:BookConnection"]);
            });

            //add scoped to assist with database creation and repository
            services.AddScoped<IBookRepository, EFBookRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //if they type a category and page into the URL
                endpoints.MapControllerRoute(
                    "catpage",
                    "{category}/{page:int}",
                    new { Controller = "Home", Action = "Index" });

                //if they only type the page number
                endpoints.MapControllerRoute(
                    "page",
                    "{page:int}",
                    new { Controller = "Home", Action = "Index" });

                //if they type a category into the URL. Set the page to 1 since the user didn't provide it
                endpoints.MapControllerRoute(
                    "category",
                    "{category}",
                    new { Controller = "Home", Action = "Index", page = 1 });

                //if they type projects/page into the URL
                endpoints.MapControllerRoute(
                    "pagination",
                    "Projects/{page}",
                    new { Controller = "Home", Action = "Index" });

                //if what comes in doesn't match anything, use the default route setup (Home -> Index)
                endpoints.MapDefaultControllerRoute();
            });

            SeedData.EnsurePopulated(app);
        }
    }
}

