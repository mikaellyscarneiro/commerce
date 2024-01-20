using Commerce.Products.Application.V1.Dtos.CategoryContext.Request;
using Commerce.Products.Application.V1.Dtos.CategoryContext.Response;

namespace Commerce.Products.Application.V1.Services.Interfaces
{
    public interface ICategoryAppService
    {
        Task<CategoryDto?> GetByIdAsync(Guid id);
        Task<CategoryDto> CreateAsync(CreateCategoryDto request);
        Task<CategoryDto> UpdateAsync(UpdateCategoryDto request);
        Task DeleteAsync(Guid id);
    }
}
