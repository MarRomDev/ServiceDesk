using Microsoft.AspNetCore.Mvc;
using ServiceDesk.Infrastructure.Messaging.Publisher;

namespace ServiceDesk.Api.Controllers;

[Route("api/[controller]")]
public class TestRabbitController(IRabbitMqPublisher publisher) : ControllerBase
{
    [HttpPost]
    public IActionResult SendTest()
    {
        var testMessage = new { TicketId = 123, Title = "Test RabbitMq" };
        publisher.Publish(testMessage, "ticket.created");
        return Ok("Message send to RabbitMq");
    }
}