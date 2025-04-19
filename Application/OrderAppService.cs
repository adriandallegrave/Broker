using Broker.Dtos;
using Broker.Interfaces.Application;
using MassTransit;

namespace Broker.Application;

public class OrderAppService : IOrderAppService
{
    private readonly IBus _bus;

    public OrderAppService(IBus bus)
    {
        _bus = bus;
    }

    public async Task ProcessOrder(OrderCreatedEvent order)
    {
        Console.WriteLine($"Process state: [App service] - Id: [{order.Id}]");

        await Task.FromResult(order);

        var processingEvent = new StartProcessingEvent()
        {
            Id = order.Id
        };

        await _bus.Publish(processingEvent);
    }
}
