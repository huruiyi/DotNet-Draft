using System;

namespace TemplateMethodDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            CoffeeinBeverage1 coffeninBeverage = new Coffee1();
            coffeninBeverage.PrepareRecipe();
            Console.ReadKey();
        }
    }

    //public class Coffee
    //{
    //    public  void PrepareRecipe()
    //    {
    //        //烧水
    //        BoilWater();
    //        //冲咖啡
    //        BrewCoffeeGrinds();
    //        //倒入茶杯中
    //        PourInCup();
    //        //加入糖和咖啡
    //        AddSugarAndMilk();
    //    }
    //    public void BoilWater()
    //    {
    //        Console.WriteLine("烧水");
    //    }

    //    public void BrewCoffeeGrinds()
    //    {
    //        Console.WriteLine("冲咖啡");
    //    }

    //    public void PourInCup()
    //    {
    //        Console.WriteLine("倒入杯子中");
    //    }

    //    public void AddSugarAndMilk()
    //    {
    //        Console.WriteLine("加糖和牛奶");
    //    }
    //}

    //public class Tea
    //{
    //    public void PrepareRecipe()
    //    {
    //        //烧水
    //        BoilWater();
    //        //泡茶
    //        SteepTeaBag();
    //        //倒入茶杯中
    //        PourInCup();
    //        //加入柠檬
    //        AddLemon();
    //    }
    //    public void BoilWater()
    //    {
    //        Console.WriteLine("烧水");
    //    }

    //    public void SteepTeaBag()
    //    {
    //        Console.WriteLine("泡茶");
    //    }

    //    public void PourInCup()
    //    {
    //        Console.WriteLine("倒入杯子中");
    //    }

    //    public void AddLemon()
    //    {
    //        Console.WriteLine("加柠檬");
    //    }
    //}
}