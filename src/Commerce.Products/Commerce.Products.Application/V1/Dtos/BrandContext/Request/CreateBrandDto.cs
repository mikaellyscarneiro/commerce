namespace Commerce.Products.Application.V1.Dtos.BrandContext.Request
{
    public class CreateBrandDto
    {
        public string Name { get; set; }

        public CreateBrandDto(string name)
        {
            Name = name;
        }
    }
}
