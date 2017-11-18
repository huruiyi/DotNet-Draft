using System;
using System.Threading;

namespace ThreadPoolDemo
{
    internal class TicketSeller
    {
        public static int TicketCount = 100;
        public static object locker = new object();

        public TicketSeller(string name)
        {
            Thread th = new Thread(Seller)
            {
                IsBackground = true
            };
            bool ipt = th.IsThreadPoolThread;
            th.Name = name;
            th.Start();
        }

        private void Seller()
        {
            while (TicketCount > 0)
            {
                lock (locker)
                {
                    TicketCount--;
                    Console.WriteLine("{1},剩余:{0}", TicketCount, Thread.CurrentThread.Name);
                }
            }
        }
    }

    internal class Program
    {
        //存放要计算的数值的字段
        private static double _number1 = -1;

        private static double _number2 = -1;

        private static void Main(string[] args)
        {
            Demo2();
            Console.Read();
        }

        private static void Demo1()
        {
            //获取线程池的最大线程数和维护的最小空闲线程数

            ThreadPool.GetMaxThreads(out var maxThreadNum, out _);
            ThreadPool.GetMinThreads(out var minThreadNum, out _);
            Console.WriteLine("最大线程数：{0}", maxThreadNum);
            Console.WriteLine("最小线程数：{0}", minThreadNum);

            //函数变量值
            int x = 15600;
            //启动第一个任务：计算x的8次方
            Console.WriteLine("启动第一个任务：计算{0}的8次方。", x);
            ThreadPool.QueueUserWorkItem(TaskProc1, x);

            //启动第二个任务：计算x的8次方根
            Console.WriteLine("启动第二个任务：计算{0}的8次方根。", x);
            ThreadPool.QueueUserWorkItem(TaskProc2, x);

            //等待，直到两个数值都完成计算
            while (_number1 == -1 || _number2 == -1) ;
            //打印计算结果
            Console.WriteLine("y({0}) = {1}", x, _number1 + _number2);
        }

        private static void Demo2()
        {
            new TicketSeller("1号台");
            new TicketSeller("2号台");
        }

        //启动第一个任务：计算x的8次方
        private static void TaskProc1(object o)
        {
            _number1 = Math.Pow(Convert.ToDouble(o), 8);
        }

        //启动第二个任务：计算x的8次方根
        private static void TaskProc2(object o)
        {
            _number2 = Math.Pow(Convert.ToDouble(o), 1.0 / 8.0);
        }
    }
}