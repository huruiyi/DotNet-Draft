using RabbitMQ.Client;
using System;
using System.Text;

namespace Producer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //创建连接工厂
            ConnectionFactory factory = new ConnectionFactory
            {
                UserName = "admin",//用户名
                Password = "admin",//密码
                HostName = "127.0.0.1"//rabbitmq ip
            };

            //创建连接
            var connection = factory.CreateConnection();
            //创建通道
            var channel = connection.CreateModel();
            //声明一个队列
            channel.QueueDeclare("hello", true, false, false, null);

            Console.WriteLine("\nRabbitMQ连接成功，请输入消息，输入exit退出！");

            IBasicProperties properties = channel.CreateBasicProperties();
            properties.DeliveryMode = 2;
            string input;
            do
            {
                input = Console.ReadLine();
                //发布消息
                channel.BasicPublish("", "hello", properties, Encoding.UTF8.GetBytes(input));
            }

            while (input.Trim().ToLower() != "exit");
            channel.Close();
            connection.Close();
        }
    }
}