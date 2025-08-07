using AutoMapper;
using MediatR;
using ServiceDesk.Domain.Tickets;
using ServiceDesk.Persistence.DbContext;

namespace ServiceDesk.Application.Features.Tickets.Commands.CreateTicket;

public class CreateTicketCommandHandler(ServiceDeskDbContext context) : IRequestHandler<CreateTicketCommand, Guid>
{
    public async Task<Guid> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = new Ticket
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            CreatedAt = DateTime.UtcNow
        };
        
        await context.Tickets.AddAsync(ticket, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        
        return ticket.Id;
    }
}