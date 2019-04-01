using System;

namespace 依赖倒置1
{
    public enum CarType
    {
        Ford, Honda
    };

    public class AutoSystem
    {
        private HondaCar hcar = new HondaCar();
        private FordCar fcar = new FordCar();
        private CarType type;

        public AutoSystem(CarType type)
        {
            this.type = type;
        }

        private void RunCar()
        {
            if (type == CarType.Ford)
            {
                fcar.Run();
            }
            else
            {
                hcar.Run();
            }
        }

        private void TurnCar()
        {
            if (type == CarType.Ford)
            {
                fcar.Turn();
            }
            else
            {
                hcar.Turn();
            }
        }

        private void StopCar()
        {
            if (type == CarType.Ford)
            {
                fcar.Stop();
            }
            else
            {
                hcar.Stop();
            }
        }
    }

    public class FordCar
    {
        public void Run()
        {
            Console.WriteLine("福特开始启动了");
        }

        public void Turn()
        {
            Console.WriteLine("福特开始转弯了");
        }

        public void Stop()
        {
            Console.WriteLine("福特开始停车了");
        }
    }

    public class HondaCar
    {
        public void Run()
        {
            Console.WriteLine("本田开始启动了");
        }

        public void Turn()
        {
            Console.WriteLine("本田开始转弯了");
        }

        public void Stop()
        {
            Console.WriteLine("本田开始停车了");
        }
    }

    public class Program
    {
        private static void Main(string[] args)
        {
        }
    }
}