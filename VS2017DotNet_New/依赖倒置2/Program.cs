using System;

namespace 依赖倒置2
{
    public class AutoSystem
    {
        private ICar car;

        public AutoSystem(ICar car)
        {
            this.car = car;
        }

        public void RunCar()
        {
            car.Run();
        }

        public void StopCar()
        {
            car.Stop();
        }

        public void TurnCar()
        {
            car.Turn();
        }
    }

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

    public interface ICar
    {
        void Run();

        void Stop();

        void Turn();
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
        }
    }
}