using Commerce.Products.Application.V1.Dtos.ProductContext.Request;
using Commerce.Products.Application.V1.Dtos.ProductContext.Response;
using Commerce.Products.Application.V1.Services.Interfaces;
using Commerce.Products.Domain.Models;
using Commerce.Products.Domain.Repositories.Interfaces;
using Commerce.Products.Application.V1.Extentions.Converters;

namespace Commerce.Products.Application.V1.Services
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductRepository _productRepository;

        public ProductAppService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDto> CreateAsync(CreateProductDto request)
        {
            // Convertendo o DTO da controller para um objeto de domínio, evitando expor o domínio para manter a integridade do software.
            var productToCreate = Product.CreateNew(request.Name, request.Description, request.Sku, request.Quantity, request.BrandId, request.CategoryId);

            var createdProduct = await _productRepository.CreateAsync(productToCreate);

            var dto = createdProduct.Convert() ?? throw new InvalidOperationException("Erro ao converter objeto.");

            return dto;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _productRepository.DeleteAsync(id);
        }

        public async Task<ProductDto?> GetByIdAsync(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            var dto = product.Convert();

            return dto;
        }

        public async Task<ProductDto> UpdateAsync(UpdateProductDto request)
        {
            var productFromDatabase = await _productRepository.GetByIdAsync(request.Id) ?? throw new InvalidOperationException($"Não foi possível atualizar o produto, pois não foi encontrado produto com o ID: {request.Id}");
            
            productFromDatabase.Update(request.Name, request.Description, request.Sku, request.Quantity, request.BrandId, request.CategoryId);

            var updateProduct = await _productRepository.UpdateAsync(productFromDatabase);

            var dto = updateProduct.Convert() ?? throw new InvalidOperationException("Erro ao converter objeto.");

            return dto;
        }
    }
}
