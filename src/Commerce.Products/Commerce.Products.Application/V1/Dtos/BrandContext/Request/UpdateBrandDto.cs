namespace Commerce.Products.Application.V1.Dtos.BrandContext.Request
{
    public class UpdateBrandDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public UpdateBrandDto(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }

}