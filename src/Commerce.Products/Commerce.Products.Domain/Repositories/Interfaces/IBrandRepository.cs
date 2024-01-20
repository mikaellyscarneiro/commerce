using Commerce.Products.Domain.Models;

namespace Commerce.Products.Domain.Repositories.Interfaces
{
    public interface IBrandRepository
    {
        Task<Brand?> GetByIdAsync(Guid id);
        Task<Brand> CreateAsync(Brand brand);
        Task<Brand> UpdateAsync(Brand brand);
        Task DeleteAsync(Guid id);
    }
}
