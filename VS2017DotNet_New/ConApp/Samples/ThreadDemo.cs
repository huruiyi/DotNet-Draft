using System;
using System.Threading;

namespace ConApp
{

    class StatusChecker
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
            Console.WriteLine("{0:h:mm:ss.fff} Creating timer.\n",
                              DateTime.Now);
            var stateTimer = new Timer(statusChecker.CheckStatus,
                                       autoEvent, 1000, 250);

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
            using (Timer fTimer = new Timer(new TimerCallback(ThreadDemo.DoTask), new AutoResetEvent(false), 0, 1000))
            {

            }
        }
    }
}