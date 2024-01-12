namespace Commerce.Products.Domain.Models
{
    public class Brand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public IList<Product> Products { get; set; } = new List<Product>();

        public Brand(Guid id, string name, DateTimeOffset createdAt, DateTimeOffset? updatedAt)
        {
            Id = id;
            Name = name;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public static Brand CreateNew(string name)
        {
            var newBrand = new Brand(id: default,
                name,
                createdAt: default,
                updatedAt: default);

            return newBrand;
        }

        public Brand Update(string name)
        {
            Name = name;
            return this;
        }
    }
}
