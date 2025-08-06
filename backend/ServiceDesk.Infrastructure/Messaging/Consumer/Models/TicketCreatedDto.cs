namespace ServiceDesk.Infrastructure.Messaging.Consumer.Models;

/// <summary>
///     Model ticketa
/// </summary>
public class TicketCreatedDto
{
    /// <summary>
    ///     Id ticketa
    /// </summary>
    public Guid TickerId { get; set; } = new Guid();
    
    /// <summary>
    ///     Tytuł
    /// </summary>
    public string Title { get; set; } = String.Empty;
    
    /// <summary>
    ///     Data utworzenia
    /// </summary>
    public DateTime CreatedAt { get; set; } =  DateTime.Now;
}