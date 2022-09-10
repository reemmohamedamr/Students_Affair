using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OData.Edm;
using Students.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Students.DAL.IRepositories;
using Students.DAL.Repositories;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using Students.Model.CustomModels;

namespace Students.Service
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
            services.AddScoped<DbContext, StudentsContext>();
            services.AddDbContext<StudentsContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DBEntities"));
            });
            services.AddControllers()
                 .AddOData(opt => {
                     opt.AddRouteComponents("odata", EdmModelBuilder.Build());
                 });
            services.AddControllers();

            services.ConfigureCORS();
            services.ConfigureAutoMapper();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.ConfigureRepositories();
            services.ConfigureManagers();
            services.ConfigureManagerFactories();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("AllowOrigin");
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
