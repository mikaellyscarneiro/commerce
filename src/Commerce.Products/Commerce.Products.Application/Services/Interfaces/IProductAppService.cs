using Commerce.Products.Domain.Models;

namespace Commerce.Products.Application.Services.Interfaces
{
    public interface IProductAppService
    {
        Task<Product> GetByIdAsync(Guid id);
        Task<Product> CreateAsync(Product product);
        Task<Product> UpdateAsync(Product product);
        Task DeleteAsync(Guid id);
    }
}
