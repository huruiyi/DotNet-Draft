using System;

namespace Demo2
{
    public class FordCar : ICar
    {
        public void Run()
        {
            Console.WriteLine("FordCar run");
        }

        public void Stop()
        {
            Console.WriteLine("FordCar stop");
        }

        public void Turn()
        {
            Console.WriteLine("FordCar turn");
        }
    }
}