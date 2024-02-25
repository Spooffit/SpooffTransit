using MassTransit;
using Microsoft.AspNetCore.Mvc;
using SpooffTransit.Common.Models;

namespace SpooffTransit.Publisher.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class PublisherController : ControllerBase
{
    private readonly IPublishEndpoint _publishEndpoint;
    public PublisherController(
        IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    [HttpPost]
    public async Task<IActionResult> SendMessage(CreateMessage transaction)
    {
        try
        {
            await _publishEndpoint.Publish(transaction);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Send message: {transaction.Content}");
            Console.ForegroundColor = default;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return BadRequest();
        }
        return Ok();
    }

}