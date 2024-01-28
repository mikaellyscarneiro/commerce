namespace Commerce.Products.Application.V1.Dtos.External.EventContext.Common
{
    public class NotifiableEventDto
    {
        public string Type { get; set; }
        public string SerializedValue { get; set; }

        public NotifiableEventDto(string type, string serializedValue)
        {
            Type = type;
            SerializedValue = serializedValue;
        }
    }
}
