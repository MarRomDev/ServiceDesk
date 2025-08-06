namespace ServiceDesk.Infrastructure.Messaging.Events;

/// <summary>
///     Klasa do tworzenia eventu
/// </summary>
public class TicketCreatedEvent : TicketEvent
{
    /// <summary>
    ///     Data utworzenia
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
}