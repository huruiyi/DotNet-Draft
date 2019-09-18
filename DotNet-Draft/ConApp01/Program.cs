using System;
using System.Collections.Generic;

namespace ConApp01
{
    internal class Program
    {
        private static bool FindText(string str)
        {
            return string.CompareOrdinal(str, "7") >= 0;
        }

        public static void Demo3()
        {
            List<string> list = new List<string>
            {
                "3","4","7","9","11"
            };
            var lists1 = list.MyFindAll<string>(FindText);
            lists1.ForEach((item) =>
            {
                Console.WriteLine(item);
            });

            var lists2 = list.MyFindAll(str =>
            {
                return string.CompareOrdinal(str, "7") >= 0;
            });
            lists2.ForEach((item) =>
            {
                Console.WriteLine(item);
            });
        }

        public static int Number0;
        public static int? Number1;

        public static void Demo4()
        {
            int? ni = new int?(12);
            ni = 123456;
            Console.WriteLine(ni);
            ni = null;
            Console.WriteLine(ni);

            Console.WriteLine(Number0);
            Console.WriteLine(Number1 == null ? 123 : 456);
        }

        public static void Demo5()
        {
            Data01 data1 = new Data01 { ID = 1, Name = "UserName" };
            Data02 data2 = new Data02 { ID = 1, Name = "UserName" };
            Console.WriteLine(data1.Equals(data2));
            Console.WriteLine(data1 == data2);
        }

        private static void Main(string[] args)
        {
            Demo5();
        }
    }
}