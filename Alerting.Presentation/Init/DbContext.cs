using Alerting.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alerting.Presentation.Init
{
    public static class DbContext
    {
        public static IServiceCollection AddCustomizedDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("ConnectionStrings:Connectionstring").Value;
            var migrationsAssembly = "Alerting.Infrastructure";
            services.AddDbContext<AlertingContext>(options =>
                        options.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(migrationsAssembly))
            );
            return services;
        }
    }
}
