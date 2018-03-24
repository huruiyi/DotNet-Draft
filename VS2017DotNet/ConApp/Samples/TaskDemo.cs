using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConApp.Samples
{
    class TaskDemo
    {
        private static volatile int _number;

        public static void DoAction()
        {
            object obj = new object();
            Task task1 = Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 100000000; i++)
                {
                    lock (obj)
                    {
                        _number++;
                    }
                }
            });

            Task task2 = Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 100000000; i++)
                {
                    lock (obj)
                    {
                        _number++;
                    }
                }
            });

            Task.WaitAll(task1, task2);
            Console.WriteLine(_number);
        }
    }
}
