using MassTransit;
using SpooffTransit.Common.Models;

namespace SpooffTransit.Consumer.Consumers;

public class CreateMessageConsumer : IConsumer<CreateMessage>
{
    private readonly ILogger<CreateMessageConsumer> _logger;
    public CreateMessageConsumer(
        ILogger<CreateMessageConsumer> logger
        )
    {
        _logger = logger;
    }
    public async Task Consume(ConsumeContext<CreateMessage> context)
    {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine($"Received message: {context.Message.Content}");
        Console.ForegroundColor = default;
    }
}