using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventPlanning.Models;
using Microsoft.AspNetCore.Identity;

namespace EventPlanning
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string con = "Server=(localdb)\\mssqllocaldb;Database=eventPlanning;Trusted_Connection=True;";

            services.AddDbContext<EventContext>(options => options.UseSqlServer(con));

            /*
           services.AddIdentity<User, IdentityRole>()
               .AddEntityFrameworkStores<UserContext>();
           services.AddDbContext<EventPlanning.Models.UserContext>(options => options.UseSqlServer(con));

           services.AddIdentity<User, IdentityRole>()
               .AddEntityFrameworkStores<UserContext>()
               .AddDefaultTokenProviders();
           */
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseDefaultFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Events}/{action=get}/{id?}");
            });
        }
    }
}
