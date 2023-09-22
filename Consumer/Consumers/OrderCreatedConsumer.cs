using MassTransit;
using Newtonsoft.Json;
using SharedModels;

namespace Consumer.Consumers;

public class OrderCreatedConsumer : IConsumer<IOrderCreated>
{
    public Task Consume(ConsumeContext<IOrderCreated> context)
    {
        var jsonMessage = JsonConvert.SerializeObject(context.Message);
        Console.WriteLine($"OrderCreated message: {jsonMessage}");

        return Task.CompletedTask;
    }
}