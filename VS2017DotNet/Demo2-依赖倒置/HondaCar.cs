using System;

namespace Demo2
{
    public class HondaCar : ICar
    {
        public void Run()
        {
            Console.WriteLine("HondaCar run");
        }

        public void Stop()
        {
            Console.WriteLine("HondaCar stop");
        }

        public void Turn()
        {
            Console.WriteLine("HondaCar turn");
        }
    }
}