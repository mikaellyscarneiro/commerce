using Commerce.Products.Application.V1.Dtos.CategoryContext.Response;
using Commerce.Products.Domain.Models;

namespace Commerce.Products.Application.V1.Extentions.Converters
{
    public static class CategoryConverterExtensions
    {
        public static CategoryDto? Convert(this Category? category)
        {
            if (category == null)
                return null;

            var dto = new CategoryDto(category.Id,
                category.Name,
                category.CreatedAt,
                category.UpdatedAt);

            return dto;
        }
    }
}
