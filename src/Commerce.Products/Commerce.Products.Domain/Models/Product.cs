namespace Commerce.Products.Domain.Models
{
    public class Product
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
        public Category? Category { get; set; }
        public Brand? Brand { get; set; }

        public Product(Guid id,
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
    }
}
