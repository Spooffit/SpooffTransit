using MassTransit;
using SpooffTransit.Consumer.Consumers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<CreateMessageConsumer>();
    
    x.UsingRabbitMq((context, config) =>
    {
        config.Host("rabbitmq://localhost", c =>
        {
            c.Username("guest");
            c.Password("guest");
        });
        
        config.ClearSerialization();
        config.UseRawJsonSerializer();
        config.ConfigureEndpoints(context);
    });
});

var app = builder.Build();

app.Run();