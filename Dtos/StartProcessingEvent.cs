namespace Broker.Dtos;

public class StartProcessingEvent
{
    public Guid Id { get; set; }
    public string Description { get; set; } = "Event that kickstarts the saga";
}
