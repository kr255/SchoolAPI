using Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using LoggerService;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Entities;
using Repository;
using Microsoft.OpenApi.Models;

namespace SchoolAPI.Extensions
{
    public static class ServiceExtentions
    {

        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddScoped<ILoggerManager, LoggerManager>();

        public static void ConfigureSQLContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<RepositoryContext>(opts =>
                opts.UseSqlServer(configuration.GetConnectionString("sqlConnection"), b => 
                b.MigrationsAssembly("SchoolAPI")));
        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {

                s.SwaggerDoc("v1", new OpenApiInfo { Title = "School API", Version = "v1" });
                // s.SwaggerDoc("v2", new OpenApiInfo { Title = "Code Maze API", Version = "v2" });

            });
        }
        
    }


}