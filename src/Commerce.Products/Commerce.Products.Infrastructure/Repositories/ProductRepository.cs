using Commerce.Products.Domain.Models;
using Commerce.Products.Domain.Repositories.Interfaces;
using Commerce.Products.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Commerce.Products.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductsDbContext _dbContext;
        private readonly DbSet<Product> _products;

        public ProductRepository(ProductsDbContext dbContext)
        {
            _dbContext = dbContext;
            _products = _dbContext.Set<Product>();
        }

        public async Task<Product> CreateAsync(Product product)
        {
            var createdProduct = await _products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return createdProduct.Entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            var product = await _products.FindAsync(id);

            if (product == null)
                return;

            _products.Remove(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            return await _products.FirstAsync(p => p.Id == id);
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            var updatedProduct = _products.Update(product);
            await _dbContext.SaveChangesAsync();
            return await Task.FromResult(updatedProduct.Entity);
        }
    }
}
