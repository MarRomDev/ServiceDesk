using AutoMapper;
using ServiceDesk.Application.Features.Tickets.Dto;
using ServiceDesk.Domain.Tickets;

namespace ServiceDesk.Application.Features.Tickets.Mapping;

public class TicketMappingProfile : Profile
{
    public TicketMappingProfile()
    {
        CreateMap<Ticket, TicketDto>();
    }
}