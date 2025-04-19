using Broker.Dtos;

namespace Broker.Interfaces.Application;

public interface IOrderAppService
{
    public Task ProcessOrder(OrderCreatedEvent order);
}
