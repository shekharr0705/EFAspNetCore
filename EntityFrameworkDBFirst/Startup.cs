using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using EntityFrameworkDBFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Routing;
using EntityFrameworkDBFirst.Services;

namespace EntityFrameworkDBFirst
{
    public class Startup
    {
        private readonly IConfiguration config;

        public Startup(IConfiguration config)
        {
            this.config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CompanyContext>(options=> options.UseSqlServer(config.GetConnectionString("CompanyDbContext")));
            services.AddMvc();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(configRoutes);

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }

        private void configRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("Defaul","{controller=Employee}/{action=Index}/{id?}");
        }
    }
}
