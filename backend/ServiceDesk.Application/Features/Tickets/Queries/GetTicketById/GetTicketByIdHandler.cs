using AutoMapper;
using MediatR;
using ServiceDesk.Application.Features.Tickets.Dto;
using ServiceDesk.Persistence.DbContext;

namespace ServiceDesk.Application.Features.Tickets.Queries.GetTicketById;

public class GetTicketByIdHandler(IMapper mapper, ServiceDeskDbContext context) : IRequestHandler<GetTicketByIdQuery, TicketDto>
{
    public async Task<TicketDto> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await context.Tickets.FindAsync(request.Id, cancellationToken);

        if (entity == null)
        {
            return null;
        }
        
        return mapper.Map<TicketDto>(entity);
    }
}