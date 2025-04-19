namespace Broker.Dtos;

public class OutboundEvent
{
    public Guid Id { get; set; }
    public string Description { get; set; } = "Event that is published outbound";
}
