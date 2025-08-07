namespace ServiceDesk.Infrastructure.Messaging.Events;

/// <summary>
///     Klasa do zakańczania eventu
/// </summary>
public record TicketClosedEvent : TicketEvent
{
    /// <summary>
    ///     Data zakończenia eventu
    /// </summary>
    public DateTime ClosedAt { get; set; } = DateTime.UtcNow;
    
    
    /// <summary>
    ///     Powód zamknięcia
    /// </summary>
    public string Reason { get; set; } = String.Empty;
}