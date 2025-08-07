using MediatR;

namespace ServiceDesk.Application.Features.Tickets.Commands.CreateTicket;
/// <summary>
///     Record do Tworzenia tiketa
/// </summary>
/// <param name="Title"></param>
/// <param name="Description"></param>
public record CreateTicketCommand(string Title, string Description) : IRequest<Guid>;