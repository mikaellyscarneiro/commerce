using Commerce.Products.Domain.Models;

namespace Commerce.Products.Presentation.Dtos.V1.Products.Response
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Sku { get; set; }
        public long Quantity { get; set; }
        public Guid BrandId { get; set; }
        public Guid CategoryId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }

        public ProductDto(Guid id,
            string name,
            string description,
            string sku,
            long quantity,
            Guid brandId,
            Guid categoryId,
            DateTimeOffset createdAt,
            DateTimeOffset? updatedAt)
        {
            Id = id;
            Name = name;
            Description = description;
            Sku = sku;
            Quantity = quantity;
            BrandId = brandId;
            CategoryId = categoryId;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public static ProductDto Convert(Product product)
        {
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
