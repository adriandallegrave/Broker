namespace Broker.Dtos;

public class ResponseEvent
{
    public Guid Id { get; set; }
    public string Description { get; set; } = "Event with the final response";
}
