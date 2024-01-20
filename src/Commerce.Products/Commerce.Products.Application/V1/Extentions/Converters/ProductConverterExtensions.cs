using Commerce.Products.Application.V1.Dtos.ProductContext.Response;
using Commerce.Products.Domain.Models;

namespace Commerce.Products.Application.V1.Extentions.Converters
{
    public static class ProductConverterExtensions
    {
        public static ProductDto? Convert(this Product? product)
        {
            if (product == null)
                return null;

            var dto = new ProductDto(product.Id,
                product.Name,
                product.Description,
                product.Sku,
                product.Quantity,
                product.BrandId,
                product.CategoryId,
                product.CreatedAt,
                product.UpdatedAt);

            return dto;
        }
    }
}
