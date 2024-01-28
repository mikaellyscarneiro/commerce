using Commerce.Products.Domain.Interfaces.Repositories;
using Commerce.Products.Domain.Models;
using Commerce.Products.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Commerce.Products.Infrastructure.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly ProductsDbContext _dbContext;
        private readonly DbSet<Brand> _brand;

        public BrandRepository(ProductsDbContext dbContext)
        {
            _dbContext = dbContext;
            _brand= _dbContext.Set<Brand>();
        }

        public async Task<Brand> CreateAsync(Brand brand)
        {
            var createdBrand = await _brand.AddAsync(brand);
            await _dbContext.SaveChangesAsync();
            return createdBrand.Entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            var brand = await _brand.FindAsync(id);

            if (brand == null)
                return;

            _brand.Remove(brand);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Brand?> GetByIdAsync(Guid id)
        {
            return await _brand.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Brand> UpdateAsync(Brand brand)
        {
            var updatedBrand = _brand.Update(brand);
            await _dbContext.SaveChangesAsync();
            return await Task.FromResult(updatedBrand.Entity);
        }
    }
}
