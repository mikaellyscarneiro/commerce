﻿using Commerce.Products.Domain.Models;

namespace Commerce.Products.Domain.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category?> GetByIdAsync(Guid id);
        Task<Category> CreateAsync(Category category);
        Task<Category> UpdateAsync(Category category);
        Task DeleteAsync(Guid id);
    }
}
