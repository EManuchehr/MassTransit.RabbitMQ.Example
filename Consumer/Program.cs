﻿using Consumer.Consumers;
using MassTransit;

var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
{
    cfg.ReceiveEndpoint("order-created-event", e =>
    {
        e.Consumer<OrderCreatedConsumer>();
    });
    
    cfg.ReceiveEndpoint("note-created-event", e =>
    {
        e.Consumer<NoteCreatedConsumer>();
    });

});

await busControl.StartAsync(new CancellationToken());

try
{
    Console.WriteLine("Press enter to exit");

    await Task.Run(Console.ReadLine);
}
finally
{
    await busControl.StopAsync();
}
