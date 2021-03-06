﻿using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSendMsg
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SendMsg");
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
                        channel.QueueDeclare("hello", false, false, false, null);
                        string message = "Hello World" + i;
                        var body = Encoding.UTF8.GetBytes(message);
                        channel.BasicPublish("", "hello", null, body);
                        Console.WriteLine(" set {0}", message);
                    }
                }
            }
            Console.WriteLine("SendMsg END!");
            Console.ReadKey();

        }
    }
}
