using Commerce.Products.Application.Services;
using Commerce.Products.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Commerce.Products.Application.DependencyInjection
{
    public static class Extencions
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {

            services.AddScoped<IProductAppService, ProductAppService>();
            return services;
        }
    }
}
