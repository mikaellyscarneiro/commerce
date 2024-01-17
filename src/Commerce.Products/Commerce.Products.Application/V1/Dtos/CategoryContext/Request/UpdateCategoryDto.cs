namespace Commerce.Products.Application.V1.Dtos.CategoryContext.Request
{
    public class UpdateCategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public UpdateCategoryDto(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }

}