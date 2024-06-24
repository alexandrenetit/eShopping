namespace EventBus.Messages.Events;

public class BaseIntegrationEvent
{
    //CO-Relation Id
    public Guid CorrelationId { get; set; }
    public DateTime CreationDate { get; private set; }

    public BaseIntegrationEvent()
    {
        CorrelationId = Guid.NewGuid();
        CreationDate = DateTime.UtcNow;
    }

    public BaseIntegrationEvent(Guid id, DateTime creationDate)
    {
        CorrelationId = id;
        CreationDate = creationDate;
    }
}