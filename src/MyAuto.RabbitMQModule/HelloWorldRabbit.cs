using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyAuto.RabbitMQModule
{
    public class HelloWorldRabbit : IRabbitMQMethod
    {
        public void SendMsg(string queuename, string queuemsg)
        {
            var factory = new ConnectionFactory();
            factory.HostName = "localhost";
            factory.UserName = "guest";
            factory.Password = "guest";
            for (int i = 0; i < 10; i++)
            {
                using (var connection = factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        channel.QueueDeclare(queuename, false, false, false, null);
                        var msgbody = Encoding.UTF8.GetBytes(queuemsg);
                        channel.BasicPublish("", queuename, null, msgbody);
                        Console.WriteLine("{0} set {1}", queuename, queuemsg);
                    }
                }
            }
        }
        public void SendMsg()
        {
            SendMsg("defaultqueue","hello rabbitmq message");
        }
        public void ReceiveMsg()
        {
            ReceiveMsg("defaultqueue");
        }
        public void ReceiveMsg(string queuename)
        {
            var factory = new ConnectionFactory() { HostName = "localhost", UserName = "guest", Password = "guest" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: queuename, durable: false, exclusive: false, autoDelete: false, arguments: null);
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(" {0} Received {1}", queuename, message);
                };
                channel.BasicConsume(queue: queuename, autoAck: true, consumer: consumer);
                Thread.Sleep(2000);
                Console.WriteLine("Received END.");
            }
        }
        public void ReceiveMsg(string queuename, string type)
        {
            var factory = new ConnectionFactory() { HostName = "localhost", UserName = "guest", Password = "guest" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queuename, false, false, false, null);
                    var consumer = new QueueingBasicConsumer(channel);
                    channel.BasicConsume(queuename, true, consumer);

                    Console.WriteLine(" waiting for message.");
                    while (true)
                    {
                        var ea = (BasicDeliverEventArgs)consumer.Queue.Dequeue();
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine("{0} Received {1}", queuename, message);
                        Thread.Sleep(2000);
                    }
                }
            }
        }

    }
}
