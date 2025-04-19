namespace Broker.Dtos;

public class OrderCreatedEvent
{
    public OrderCreatedEvent()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }
}
