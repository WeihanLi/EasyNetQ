using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace EasyNetQ.Consumer;

internal sealed class NoopDefaultConsumer : IBasicConsumer, IAsyncBasicConsumer
{
    internal static readonly NoopDefaultConsumer Instance = new();

    private NoopDefaultConsumer() { }

    public IChannel Channel => throw new NotSupportedException();

    event AsyncEventHandler<ConsumerEventArgs> IAsyncBasicConsumer.ConsumerCancelled
    {
        add { }
        remove { }
    }

    event EventHandler<ConsumerEventArgs> IBasicConsumer.ConsumerCancelled
    {
        add { }
        remove { }
    }

    void IBasicConsumer.HandleBasicCancel(string consumerTag)
    {
    }

    void IBasicConsumer.HandleBasicCancelOk(string consumerTag)
    {
    }

    void IBasicConsumer.HandleBasicConsumeOk(string consumerTag)
    {
    }

    Task IBasicConsumer.HandleBasicDeliverAsync(
        string consumerTag,
        ulong deliveryTag,
        bool redelivered,
        string exchange,
        string routingKey,
        ReadOnlyBasicProperties properties,
        ReadOnlyMemory<byte> body
    )
    {
        return Task.CompletedTask;
    }


    void IBasicConsumer.HandleChannelShutdown(object model, ShutdownEventArgs reason)
    {
    }

    Task IAsyncBasicConsumer.HandleBasicCancel(string consumerTag) => Task.CompletedTask;

    Task IAsyncBasicConsumer.HandleBasicCancelOk(string consumerTag) => Task.CompletedTask;

    Task IAsyncBasicConsumer.HandleBasicConsumeOk(string consumerTag) => Task.CompletedTask;

    Task IAsyncBasicConsumer.HandleBasicDeliver(
        string consumerTag,
        ulong deliveryTag,
        bool redelivered,
        string exchange,
        string routingKey,
        ReadOnlyBasicProperties properties,
        ReadOnlyMemory<byte> body
    ) => Task.CompletedTask;

    Task IAsyncBasicConsumer.HandleChannelShutdown(object model, ShutdownEventArgs reason) => Task.CompletedTask;
}
