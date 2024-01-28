using Commerce.Products.Application.V1.Dtos.External.EventContext.Request;

namespace Commerce.Products.Application.V1.Interfaces.External.Services
{
    public interface IEventService
    {
        public Task PublishAsync<T>(PublishEventDto<T> request); 
    }
}
