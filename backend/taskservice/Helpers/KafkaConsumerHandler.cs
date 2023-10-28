using Confluent.Kafka;

namespace taskservice.Helpers;

public class KafkaConsumerHandler : IHostedService
{
    private readonly string topic = "task_tracking_topic";

    public Task StartAsync(CancellationToken cancellationToken)
    {
        var thread = new Thread(() =>
        {
            var conf = new ConsumerConfig
            {
                    GroupId = "task_tracking_group",
                    BootstrapServers = "kafka:9092",
                    AutoOffsetReset = AutoOffsetReset.Earliest
            };
            using (var builder = new ConsumerBuilder<Ignore,
                           string>(conf).Build())
            {
                builder.Subscribe(topic);
                var cancelToken = new CancellationTokenSource();
                try
                {
                    while (true)
                    {
                        var consumer = builder.Consume(cancelToken.Token);
                        Console.WriteLine(
                                $"Message: {consumer.Message.Value} received from {consumer.TopicPartitionOffset}");
                    }
                }
                catch (Exception)
                {
                    builder.Close();
                }
            }
        });

        thread.Start();

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}