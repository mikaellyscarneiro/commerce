using Commerce.Products.Domain.Models;

namespace Commerce.Products.Application.V1.Dtos.BrandContext.Response
{
    public class BrandDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }

        public BrandDto(Guid id, string name, DateTimeOffset createdAt, DateTimeOffset? updatedAt)
        {
            Id = id;
            Name = name;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public static BrandDto? Convert(Brand? brand)
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
