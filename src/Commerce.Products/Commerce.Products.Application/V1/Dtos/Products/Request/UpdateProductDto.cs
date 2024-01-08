namespace Commerce.Products.Application.V1.Dtos.Products.Request
{
    public class UpdateProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Sku { get; set; }
        public long Quantity { get; set; }
        public Guid BrandId { get; set; }
        public Guid CategoryId { get; set; }

        public UpdateProductDto(Guid id,
            string name,
            string description,
            string sku,
            long quantity,
            Guid brandId,
            Guid categoryId)
        {
            Id = id;
            Name = name;
            Description = description;
            Sku = sku;
            Quantity = quantity;
            BrandId = brandId;
            CategoryId = categoryId;
        }
    }

}
