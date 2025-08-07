namespace ServiceDesk.Application.Features.Tickets.Dto;

/// <summary>
///     Dto dla tiketa
/// </summary>
public class TicketDto
{
    /// <summary>
    ///     Identyfikator
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    ///     Tytuł
    /// </summary>
    public string Title { get; set; } = string.Empty;
    
    /// <summary>
    ///     Opis
    /// </summary>
    public string Description { get; set; } = string.Empty;
    
    /// <summary>
    ///     Data utworzenia
    /// </summary>
    public DateTime CreatedAt { get; set; }
}