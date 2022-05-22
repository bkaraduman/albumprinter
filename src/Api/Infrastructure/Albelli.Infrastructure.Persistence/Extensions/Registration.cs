using Albelli.Infrastructure.Persistence.Context;
using Albelli.Infrastructure.Persistence.Repositories;
using Albelli.Infrastructure.Persistence.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Albelli.Infrastructure.Persistence.Extensions
{
    public static class Registration
    {
        public static IServiceCollection AddInfrastructureRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AlbelliContext>(options =>
            {
                var connStr = configuration["AlbelliDbConnectionString"].ToString();

                options.UseSqlServer(connStr, opt =>
                {
                    opt.EnableRetryOnFailure();
                });
            });

            var seedData = new SeedData();

            seedData.SeedAsync(configuration).GetAwaiter().GetResult();

            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}
