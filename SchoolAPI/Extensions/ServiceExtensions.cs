using Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using LoggerService;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Entities;

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
        
    }


}