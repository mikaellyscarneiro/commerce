namespace Commerce.Products.Application.V1.Dtos.BrandContext.Request
{
    public class UpdateBrandDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }

        public UpdateBrandDto(Guid id, string name, DateTimeOffset createdAt, DateTimeOffset? updatedAt)
        {
            Id = id;
            Name = name;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }

}