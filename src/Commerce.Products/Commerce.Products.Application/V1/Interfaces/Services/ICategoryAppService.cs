using Commerce.Products.Application.V1.Dtos.CategoryContext.Request;
using Commerce.Products.Application.V1.Dtos.CategoryContext.Response;

namespace Commerce.Products.Application.V1.Interfaces.Services
{
    public interface ICategoryAppService
    {
        Task<CategoryDto?> GetByIdAsync(Guid id);
        Task<CategoryDto> CreateAsync(CreateCategoryDto request);
        Task<CategoryDto> UpdateAsync(UpdateCategoryDto request);
        Task DeleteAsync(Guid id);
    }
}
