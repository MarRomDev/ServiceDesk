namespace ServiceDesk.Infrastructure.Messaging.Events;

/// <summary>
///     Klasa bazowa TicketEvent
/// </summary>
public abstract class TicketEvent
{
    /// <summary>
    ///     Id
    /// </summary>
    public Guid TicketId { get; set; } =  Guid.NewGuid();
    
    /// <summary>
    ///     Tytuł eventu
    /// </summary>
    public string Title { get; set; } =  string.Empty;
    
    /// <summary>
    ///     Id osoby tworzącej
    /// </summary>
    public int CreatedById { get; set; }
}