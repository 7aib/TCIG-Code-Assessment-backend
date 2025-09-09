
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TCIG.Application.Interfaces;
using TCIG.Application.Services;
using TCIG.Domain.Interfaces;
using TCIG.Infrastructure.Repositories;

namespace TCIG.Infrastructure.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")
                    ));

            // Register repositories
            services.AddScoped<IProductRepository, ProductRepoitory>();

            // Register service
            services.AddScoped<IProductService, ProductService>();

            return services;

        }
    }
}