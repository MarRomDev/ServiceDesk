using MediatR;
using Microsoft.AspNetCore.Mvc;
using ServiceDesk.Api.Features.Tickets.Dto;
using ServiceDesk.Application.Features.Tickets.Commands.CreateTicket;
using ServiceDesk.Application.Features.Tickets.Queries.GetTicketById;

namespace ServiceDesk.Api.Features.Tickets.Controllers;

[ApiController]
[Route("api/tickets")]
public class TicketController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody]CreateTicketCommand command)
    {
        var id = await mediator.Send(command);
        return Ok(id);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TicketDto>> GetById(Guid id)
    {
        var ticket = await mediator.Send(new GetTicketByIdQuery(id));
        return Ok(ticket);
    }
}