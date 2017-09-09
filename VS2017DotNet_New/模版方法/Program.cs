using System;

namespace 模版方法
{
    public class Coffee1 : CoffeeinBeverage1
    {
        public override void Brew()
        {
            Console.WriteLine("冲咖啡");
        }

        public override void AddCondiments()
        {
            Console.WriteLine("加糖和牛奶");
        }

        public override bool WantCondiments()
        {
            return false;
        }
    }

    public abstract class CoffeeinBeverage1
    {
        public void BoilWater()
        {
            Console.WriteLine("烧水");
        }

        public void PrepareRecipe()
        {
            BoilWater();
            Brew();
            PourInCup();
            //有个判断方法来添加调料
            if (WantCondiments())
            {
                AddCondiments();
            }
        }

        /// <summary>
        /// 加入一个方法，用来判断是否需要加调料
        /// </summary>
        /// <returns></returns>
        public virtual bool WantCondiments()
        {
            return true;
        }

        public void PourInCup()
        {
            Console.WriteLine("倒入杯子中");
        }

        public abstract void Brew();

        public abstract void AddCondiments();
    }

    public class Tea1 : CoffeeinBeverage1
    {
        public override void Brew()
        {
            Console.WriteLine("泡茶");
        }

        public override void AddCondiments()
        {
            Console.WriteLine("加柠檬");
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            CoffeeinBeverage1 coffeninBeverage = new Coffee1();
            coffeninBeverage.PrepareRecipe();
            Console.ReadKey();
        }
    }

    public class Coffee
    {
        public void PrepareRecipe()
        {
            //烧水
            BoilWater();
            //冲咖啡
            BrewCoffeeGrinds();
            //倒入茶杯中
            PourInCup();
            //加入糖和咖啡
            AddSugarAndMilk();
        }

        public void BoilWater()
        {
            Console.WriteLine("烧水");
        }

        public void BrewCoffeeGrinds()
        {
            Console.WriteLine("冲咖啡");
        }

        public void PourInCup()
        {
            Console.WriteLine("倒入杯子中");
        }

        public void AddSugarAndMilk()
        {
            Console.WriteLine("加糖和牛奶");
        }
    }

    public class Tea
    {
        public void PrepareRecipe()
        {
            //烧水
            BoilWater();
            //泡茶
            SteepTeaBag();
            //倒入茶杯中
            PourInCup();
            //加入柠檬
            AddLemon();
        }

        public void BoilWater()
        {
            Console.WriteLine("烧水");
        }

        public void SteepTeaBag()
        {
            Console.WriteLine("泡茶");
        }

        public void PourInCup()
        {
            Console.WriteLine("倒入杯子中");
        }

        public void AddLemon()
        {
            Console.WriteLine("加柠檬");
        }
    }
}