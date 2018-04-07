using System;
using System.Threading;

namespace ConApp
{
    public class TicketSeller
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

    public class StatusChecker
    {
        private int invokeCount;
        private int maxCount;

        public StatusChecker(int count)
        {
            invokeCount = 0;
            maxCount = count;
        }

        // This method is called by the timer delegate.
        public void CheckStatus(Object stateInfo)
        {
            AutoResetEvent autoEvent = (AutoResetEvent)stateInfo;
            Console.WriteLine("{0} Checking status {1,2}.",
                DateTime.Now.ToString("h:mm:ss.fff"),
                (++invokeCount).ToString());

            if (invokeCount == maxCount)
            {
                // Reset the counter and signal the waiting thread.
                invokeCount = 0;
                autoEvent.Set();
            }
        }
    }

    public class ThreadDemo
    {
        #region Demo1

        //存放要计算的数值的字段
        private static double _number1 = -1;

        private static double _number2 = -1;

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

        #endregion Demo1

        private static void Demo2()
        {
            new TicketSeller("1号台");
            new TicketSeller("2号台");
        }

        private static object objlock = new object();

        private void ThreadDemo1()
        {
            Thread t1 = new Thread(delegate ()
            {
                for (int i = 0; i < 1000; i++)
                {
                    Console.WriteLine("Hello" + i);
                }
            });
            t1.DisableComObjectEagerCleanup();
        }

        public static void DoTask(Object stateInfo)
        {
            lock (objlock)
            {
            }
        }

        public static void TdTimer1()
        {
            // Create an AutoResetEvent to signal the timeout threshold in the
            // timer callback has been reached.
            var autoEvent = new AutoResetEvent(false);

            var statusChecker = new StatusChecker(10);

            // Create a timer that invokes CheckStatus after one second,
            // and every 1/4 second thereafter.
            Console.WriteLine("{0:h:mm:ss.fff} Creating timer.\n", DateTime.Now);
            var stateTimer = new Timer(statusChecker.CheckStatus, autoEvent, 1000, 250);

            // When autoEvent signals, change the period to every half second.
            autoEvent.WaitOne();
            stateTimer.Change(0, 500);
            Console.WriteLine("\nChanging period to .5 seconds.\n");

            // When autoEvent signals the second time, dispose of the timer.
            autoEvent.WaitOne();
            stateTimer.Dispose();
        }

        public static void ThTimer()
        {
            using (Timer fTimer = new Timer(new TimerCallback(DoTask), new AutoResetEvent(false), 0, 1000))
            {
            }
        }

        public static void AsyncFuncDemo()
        {
            Func<bool> ascyRun = ProcessCount;
            IAsyncResult reslu = ascyRun.BeginInvoke(MyAsyncCallback, ascyRun);

            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(200);

                Console.WriteLine("End。。。。。。。。");
            }
        }

        public static void MyAsyncCallback(IAsyncResult ar)
        {
            Func<bool> pc = (Func<bool>)ar.AsyncState;
            var endInvoke = pc.EndInvoke(ar);
            Console.WriteLine(endInvoke ? "处理完成。。" : "处理失败。。");
        }

        public static bool ProcessCount()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i + "\t");
                Thread.Sleep(100);
            }
            return true;
        }
    }
}