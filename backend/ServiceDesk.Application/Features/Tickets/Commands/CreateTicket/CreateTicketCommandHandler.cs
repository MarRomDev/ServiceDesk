using MediatR;

namespace ServiceDesk.Application.Features.Tickets.Commands.CreateTicket;

public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, Guid>
{
    public Task<Guid> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
    {
        //TODO: późniejsza logika zapisu do bazy itd.
        return Task.FromResult(Guid.NewGuid());
    }
}