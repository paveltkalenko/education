using System;
using System.Text;
using System.Threading;
using RabbitMQ.Client;

namespace publisher
{
  class Program
  {
    static void Main(string[] args)
    {
      var factory = new ConnectionFactory() { HostName = "rabbit" };
      using (var connection = factory.CreateConnection())
      using (var channel = connection.CreateModel())
      {
        channel.QueueDeclare(queue: "hello",
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

        string message = args.Length > 0 ? string.Join(' ', args) : "Hello World!";
        var body = Encoding.UTF8.GetBytes(message);
        while (true)
        {
          channel.BasicPublish(exchange: "",
                               routingKey: "hello",
                               basicProperties: null,
                               body: body);
          Console.WriteLine(" [x] Sent {0}", message);
          Thread.Sleep(5000);
        }
      }
    }
  }
}
