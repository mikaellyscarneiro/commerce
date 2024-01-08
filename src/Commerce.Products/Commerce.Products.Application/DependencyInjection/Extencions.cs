using Commerce.Products.Application.V1.Services;
using Commerce.Products.Application.V1.Services.Interfaces;
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
