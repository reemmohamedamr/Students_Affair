using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Students.BL.IManager;
using Students.BL.Manager;
using Students.DAL.IRepositories;
using Students.DAL.Repositories;
using Students.Model.CustomModels;
using Students.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Students.Service
{
    public static class ServiceExtensions
    {
        
        public static void ConfigureCORS(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder => builder
                    .SetIsOriginAllowed(origin => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
        }
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
        public static void ConfigureManagerFactories(this IServiceCollection services)
        {
        }
        public static void ConfigureManagers(this IServiceCollection services)
        {
            services.AddScoped<IStudentManager, StudentManager>();
            services.AddScoped<IStudentSubjectManager, StudentSubjectManager>();
            services.AddScoped<ISubjectManager, SubjectManager>();
            services.AddScoped<IStudentClassManager, StudentClassManager>();
        }
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IStudentSubjectRepository, StudentSubjectRepository>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<IStudentClassRepository, StudentClassRepository>();
        }
    }
    public static class EdmModelBuilder
    {
        public static IEdmModel Build()
        {
            ODataModelBuilder builder = new ODataConventionModelBuilder();

            builder.EntitySet<StudentModel>("StudentOData").EntityType.HasKey(x => x.Student_ID)
                .Count(true).Filter(true).OrderBy(true).Expand().Select().Page(100, 100);
            builder.EntitySet<StudentSubjectModel>("StudentSubjectOData").EntityType.HasKey(x => x.ID)
                .Count(true).Filter(true).OrderBy(true).Expand().Select().Page(100, 100);
            //builder.EntitySet<StudentSubjectModel>("SubjectOData").EntityType.HasKey(x => x.Subject_ID)
            //    .Count(true).Filter(true).OrderBy(true).Expand().Select().Page(100, 100);

            return builder.GetEdmModel();
        }
    }
}
