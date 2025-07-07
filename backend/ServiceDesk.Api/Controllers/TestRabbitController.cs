using Microsoft.AspNetCore.Mvc;
using ServiceDesk.Infrastructure.Messaging.Publisher;

namespace ServiceDesk.Api.Controllers;

[Route("api/[controller]")]
public class TestRabbitController : ControllerBase
{
    private readonly IRabbitMqPublisher _publisher;

    public TestRabbitController(IRabbitMqPublisher publisher)
    {
        _publisher = publisher;
    }

    [HttpPost]
    public IActionResult SendTest()
    {
        var testMessage = new { TicketId = 123, Title = "Test RabbitMq" };
        _publisher.Publish(testMessage, "ticket.created");
        return Ok("Message send to RabbitMq");
    }
}