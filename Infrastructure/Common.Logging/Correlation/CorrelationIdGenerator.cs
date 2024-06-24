namespace Common.Logging.Correlation;

public class CorrelationIdGenerator : ICorrelationIdGenerator
{
    private string _correlationId = Guid.NewGuid().ToString("0");
    
    public string Get() => _correlationId;

    public void Set(string correlationId)
    {
        
    }
}