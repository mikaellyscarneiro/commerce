using Commerce.Products.Application.V1.Dtos.BrandContext.Response;
using Commerce.Products.Domain.Models;

namespace Commerce.Products.Application.V1.Extentions.Converters
{
    public static class BrandConverterExtensions
    {
        public static BrandDto? Convert(this Brand? brand)
        {
            if (brand == null)
                return null;

            var dto = new BrandDto(brand.Id,
                brand.Name,
                brand.CreatedAt,
                brand.UpdatedAt);

            return dto;
        }
    }
}
