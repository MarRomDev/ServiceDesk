namespace ServiceDesk.Infrastructure.Messaging.Settings;

/// <summary>
///     Klasa ustawień RabbitMq
/// </summary>
public class RabbitMqSettings
{
    public string Host { get; set; } = String.Empty;
    public int Port { get; set; }
    public string Username { get; set; } = String.Empty;
    public string Password { get; set; } = String.Empty;
    
    public string PasswordExchange { get; set; } = String.Empty;
    public string Exchange { get; set; } = String.Empty;
}