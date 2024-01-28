using Commerce.Products.Domain.Interfaces.Repositories;
using Commerce.Products.Domain.Models;
using Commerce.Products.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Commerce.Products.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ProductsDbContext _dbContext;
        private readonly DbSet<Category> _category;

        public CategoryRepository(ProductsDbContext dbContext)
        {
            _dbContext = dbContext;
            _category = _dbContext.Set<Category>();
        }

        public async Task<Category> CreateAsync(Category category)
        {
            var createdCategory = await _category.AddAsync(category);
            await _dbContext.SaveChangesAsync();
            return createdCategory.Entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            var category = await _category.FindAsync(id);

            if (category == null)
                return;

            _category.Remove(category);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Category?> GetByIdAsync(Guid id)
        {
            return await _category.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            var updatedCategory = _category.Update(category);
            await _dbContext.SaveChangesAsync();
            return await Task.FromResult(updatedCategory.Entity);
        }


    }
}
