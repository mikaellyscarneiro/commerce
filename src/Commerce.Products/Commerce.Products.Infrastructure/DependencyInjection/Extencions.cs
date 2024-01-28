using Commerce.Products.Application.V1.Interfaces.External.Services;
using Commerce.Products.Domain.Interfaces.Repositories;
using Commerce.Products.Infrastructure.Configurations;
using Commerce.Products.Infrastructure.Database;
using Commerce.Products.Infrastructure.Repositories;
using Commerce.Products.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Commerce.Products.Infrastructure.DependencyInjection
{
    public static class Extencions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            var productsConnectionString = Environment.GetEnvironmentVariable("PostgreSQL__ConnectionStrings__DefaultConnection");

            // Configuração do Entity Framework.
            // IConfiguration puxa as informações do appsettings.json
            services.AddDbContext<ProductsDbContext>(options => options.UseNpgsql(productsConnectionString));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            return services;
        }

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IEventService, EventService>();

            return services;
        }

        public static IServiceCollection AddConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RabbitMqConfiguration>(configuration.GetSection("RabbitMQ"));

            return services;
        }
    }
}
