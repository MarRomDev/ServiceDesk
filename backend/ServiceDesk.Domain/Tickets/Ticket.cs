namespace ServiceDesk.Domain.Tickets;

/// <summary>
///     Encja tiketu
/// </summary>
public class Ticket
{
    /// <summary>
    ///     Id
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    ///     Tytuł
    /// </summary>
    public string Title { get; set; } = String.Empty;
    
    /// <summary>
    ///     Opis
    /// </summary>
    public string Description { get; set; } = String.Empty;
    
    /// <summary>
    ///     Data i czas utworzenia
    /// </summary>
    public DateTime CreatedAt { get; set; }
}