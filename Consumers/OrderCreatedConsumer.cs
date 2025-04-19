using Broker.Dtos;
using Broker.Interfaces.Application;
using MassTransit;

namespace Broker.Consumers;

public class OrderCreatedConsumer : IConsumer<OrderCreatedEvent>
{
    private readonly IOrderAppService _orderAppService;

    public OrderCreatedConsumer(IOrderAppService appService)
    {
        _orderAppService = appService;
    }

    public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
    {
        Console.WriteLine($"Process state: [Consumer] - Id: [{context.Message.Id}]");

        await _orderAppService.ProcessOrder(context.Message);
    }
}
