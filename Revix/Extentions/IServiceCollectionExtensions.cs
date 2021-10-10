using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Revix.Data;
using Revix.Data.Interfaces;
using Revix.Data.IRepositories;
using Revix.Data.Repositories;
using Revix.Services.Contracts;
using Revix.Services.Services;

namespace Revix.Extentions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            // Configure DbContext with Scoped lifetime
            services.AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseSqlite("Data Source=Revix.db");
                }
            );

            services.AddScoped<Func<ApplicationDbContext>>((provider) => () => provider.GetService<ApplicationDbContext>());
            services.AddScoped<DbFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped(typeof(IRepository<>), typeof(Repository<>))
                .AddScoped<ICryptoListingRepo, CryptoListingRepo>();
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
            .AddScoped<ICryptoService, CryptoService>();
        }
    }
}