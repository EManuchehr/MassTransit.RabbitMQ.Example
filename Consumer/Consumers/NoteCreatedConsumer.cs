using MassTransit;
using Newtonsoft.Json;
using SharedModels;

namespace Consumer.Consumers;

public class NoteCreatedConsumer : IConsumer<INote>
{
    public Task Consume(ConsumeContext<INote> context)
    {
        var jsonMessage = JsonConvert.SerializeObject(context.Message);
        Console.WriteLine($"NoteCreated message: {jsonMessage}");

        return Task.CompletedTask;
    }
}