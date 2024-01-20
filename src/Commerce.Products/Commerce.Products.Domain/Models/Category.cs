namespace Commerce.Products.Domain.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public IList<Product> Products { get; set; } = new List<Product>();

        public Category(Guid id, string name, DateTimeOffset createdAt, DateTimeOffset? updatedAt)
        {
            Id = id;
            Name = name;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public static Category CreateNew(string name)
        {
            var newCategory = new Category(id: default,
                name,
                createdAt: default,
                updatedAt: default);

            return newCategory;
        }

        public Category Update(string name)
        {
            Name = name;
            return this;
        }
    }
}