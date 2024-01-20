namespace Commerce.Products.Application.V1.Dtos.ProductContext.Request
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Sku { get; set; }
        public long Quantity { get; set; }
        public Guid BrandId { get; set; }
        public Guid CategoryId { get; set; }

        public CreateProductDto(string name,
            string description,
            string sku,
            long quantity,
            Guid brandId,
            Guid categoryId)
        {
            Name = name;
            Description = description;
            Sku = sku;
            Quantity = quantity;
            BrandId = brandId;
            CategoryId = categoryId;
        }
    }
}
