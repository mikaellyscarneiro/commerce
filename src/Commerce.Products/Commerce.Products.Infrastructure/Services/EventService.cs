using Commerce.Products.Application.V1.Dtos.External.EventContext.Request;
using Commerce.Products.Application.V1.Interfaces.External.Services;

namespace Commerce.Products.Infrastructure.Services
{
    public class EventService : IEventService
    {
        public Task PublishAsync<T>(PublishEventDto<T> request)
        {
            throw new NotImplementedException();
        }
    }
}
