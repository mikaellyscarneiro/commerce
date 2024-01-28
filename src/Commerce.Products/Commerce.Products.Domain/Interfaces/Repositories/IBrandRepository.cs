using Commerce.Products.Domain.Models;

namespace Commerce.Products.Domain.Interfaces.Repositories
{
    public interface IBrandRepository
    {
        Task<Brand?> GetByIdAsync(Guid id);
        Task<Brand> CreateAsync(Brand brand);
        Task<Brand> UpdateAsync(Brand brand);
        Task DeleteAsync(Guid id);
    }
}
