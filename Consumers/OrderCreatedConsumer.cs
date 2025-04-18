using Broker.Dtos;
using MassTransit;

namespace Broker.Consumers;

public class OrderCreatedConsumer : IConsumer<OrderCreatedEvent>
{
    public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
    {
        var message = context.Message;
        Console.WriteLine($"Received order: {message.OrderId}");
        await ProcessOrder(message);
    }

    private async Task ProcessOrder(OrderCreatedEvent order)
    {
        Console.WriteLine($"Processing order {order.OrderId}");

        await Task.FromResult(order);
    }
}
