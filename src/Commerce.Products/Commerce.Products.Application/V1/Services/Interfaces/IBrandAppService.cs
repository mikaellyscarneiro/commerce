using Commerce.Products.Application.V1.Dtos.BrandContext.Request;
using Commerce.Products.Application.V1.Dtos.BrandContext.Response;

namespace Commerce.Products.Application.V1.Services.Interfaces
{
    public interface IBrandAppService
    {
        Task<BrandDto?> GetByIdAsync(Guid id);
        Task<BrandDto> CreateAsync(CreateBrandDto request);
        Task<BrandDto> UpdateAsync(UpdateBrandDto request);
        Task DeleteAsync(Guid id);
    }
}
