using BigonApp.Infrastructure.Commons;
using BigonApp.Infrastructure.Commons.Concretes;
using BigonApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigonApp.Data
{
    public static class DataServiceInjection
    {
        public static IServiceCollection InstallDataServices(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<DbContext, DataContext>(cfg =>
            {
                cfg.UseSqlServer(configuration.GetConnectionString("cString"),
                   opt =>
                   {
                       opt.MigrationsHistoryTable("Migrations");
                   });
            });

            var repoInterfaceType = typeof(IRepository<>);

            var concretRepositoryAsembly = typeof(DataServiceInjection).Assembly;

            var repositoryPairs = repoInterfaceType.Assembly
                .GetTypes()
                .Where(m => m.IsInterface
                && m.GetInterfaces()
                .Any(i => i.IsGenericType
                && i.GetGenericTypeDefinition() == repoInterfaceType))
                .Select(m => new
                {
                    AbstractRepository = m,
                    ConcrateRepository = concretRepositoryAsembly.GetTypes()
                    .FirstOrDefault(r => r.IsClass && m.IsAssignableFrom(r)),
                })
                .Where(m => m.ConcrateRepository != null);


            foreach (var item in repositoryPairs)
            {
                services.AddScoped(item.AbstractRepository, item.ConcrateRepository!);
            }
            return services;
        }
    }
}
