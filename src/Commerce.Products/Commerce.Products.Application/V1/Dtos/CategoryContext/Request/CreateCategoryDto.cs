namespace Commerce.Products.Application.V1.Dtos.CategoryContext.Request
{
    public class CreateCategoryDto
    {
        public string Name { get; set; }

        public CreateCategoryDto(string name)
        {
            Name = name;
        }
    }
}
