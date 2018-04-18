using RabbitMQ.Client;
using RabbitMQ.Client.Content;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConApp
{
    internal class RabbitMQDemo
    {
        public static void InitProducerMQ()
        {
            //定义要链接的rabbitmq-server地址（基于amqp协议）
            Uri uri = new Uri("amqp://10.1.148.77:5672/");

            //定义交换方式
            string exchange = "ex1";
            string exchangeType = "direct";
            string routingKey = "m1";

            //使用ConnectionFactory创建连接，虽然创建时指定了多个server address，
            //但每个connection只与一个物理的server进行连接。
            ConnectionFactory cf = new ConnectionFactory
            {
                UserName = "test",
                Password = "test",
                VirtualHost = "yiriyou",
                RequestedHeartbeat = 0,
                Endpoint = new AmqpTcpEndpoint(uri)
            };

            Console.Write("\n 请输入发送消息键值 ！\n");
            string strMessageKey = Console.ReadLine();//从控制台读入输入

            //实例化IConnection对象，并设置交换方式
            using (IConnection conn = cf.CreateConnection())
            {
                using (IModel ch = conn.CreateModel())
                {
                    //设置发送消息的实体
                    ch.ExchangeDeclare(exchange, exchangeType);

                    //设置接收消息的实体
                    ch.QueueDeclare(strMessageKey, true, false, false, null);

                    //封装消息的路由信息
                    ch.QueueBind(strMessageKey, exchange, routingKey);

                    //构造消息实体对象并发布到消息队列上
                    IMapMessageBuilder b = new MapMessageBuilder(ch);

                    Console.Write("\n 请输入消息内容！\n");
                    string strMessage = Console.ReadLine();//从控制台读入输入

                    IDictionary<string, object> targetBody = b.Body;
                    targetBody["body"] = strMessage;

                    // 持久化操作
                    ((IBasicProperties)b.GetContentHeader()).DeliveryMode = 2;
                    //IBasicProperties properties=new BasicProperties
                    //{
                    //    Persistent = true,
                    //    DeliveryMode = 2
                    //};
                    ch.BasicPublish(exchange, routingKey, (IBasicProperties)b.GetContentHeader(), b.GetContentBody());
                }
            }
        }

        public static void InitCustmerMq()
        {
            //创建一个连接实例
            ConnectionFactory cf = new ConnectionFactory();

            //设置用户名和密码
            cf.UserName = "test";
            cf.Password = "test";
            //设置MQ虚拟主机
            cf.VirtualHost = "yiriyou";
            cf.RequestedHeartbeat = 0;

            Console.Write("\n 请输入接受消息键值 ！\n");
            string strMessageKey = Console.ReadLine();//从控制台读入输入

            using (IConnection conn = cf.CreateConnection())
            {
                //接受实体
                using (IModel ch = conn.CreateModel())
                {
                    //普通使用方式BasicGet
                    //noAck = true，不需要回复，接收到消息后，queue上的消息就会清除
                    //noAck = false，需要回复，接收到消息后，queue上的消息不会被清除，
                    BasicGetResult res = ch.BasicGet(strMessageKey, false);
                    if (res != null)
                    {
                        string str = Encoding.UTF8.GetString(res.Body);
                        Console.WriteLine("接受到的消息内容是：\n" + str);

                        //queue上的消息才会被清除 ，在当前连接断开以前，其它客户端将不能收到此queue上的消息
                        ch.BasicAck(res.DeliveryTag, false);
                    }
                    else
                    {
                        Console.WriteLine("No message！");
                    }
                }
            }

            Console.ReadLine();
        }
    }
}
