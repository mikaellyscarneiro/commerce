namespace Commerce.Products.Application.V1.Dtos.External.EventContext.Request
{
    public class PublishEventDto<T>
    {
        public string Type { get; set; }
        public T Value { get; set; }

        public PublishEventDto(string type, T value)
        {
            Type = type;
            Value = value;
        }
    }
}
