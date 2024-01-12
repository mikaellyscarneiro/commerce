using Commerce.Products.Application.V1.Dtos.ProductContext.Request;

namespace Commerce.Products.Application.V1.Services.Interfaces
{
    public interface IProductAppService
    {
        Task<ProductDto?> GetByIdAsync(Guid id);
        Task<ProductDto> CreateAsync(CreateProductDto request);
        Task<ProductDto> UpdateAsync(UpdateProductDto request);
        Task DeleteAsync(Guid id);
    }
}
