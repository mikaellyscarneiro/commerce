using Commerce.Products.Domain.Repositories.Interfaces;
using Commerce.Products.Infrastructure.Database;
using Commerce.Products.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
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
    }
}
