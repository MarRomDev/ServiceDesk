using MediatR;
using ServiceDesk.Application.Features.Tickets.Dto;

namespace ServiceDesk.Application.Features.Tickets.Queries.GetTicketById;

public record GetTicketByIdQuery(Guid Id) : IRequest<TicketDto>;