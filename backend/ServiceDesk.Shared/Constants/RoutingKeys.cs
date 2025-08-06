namespace ServiceDesk.Shared.Constants;

/// <summary>
///     Klasa do deklaracji kluczy kolejki
/// </summary>
public class RoutingKeys
{
    /// <summary>
    ///     Klucz utworzenia tiketa
    /// </summary>
    public const string TicketCreated =  "ticket.created";
    
    /// <summary>
    ///     Klucz zamknięcia tiketa
    /// </summary>
    public const string TicketClosed =  "ticket.closed";
}