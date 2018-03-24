using StackExchange.Redis;
using System;
using System.Threading;

namespace ConApp.Samples
{
    internal class RedisDemo
    {
        public static ConnectionMultiplexer Redis = ConnectionMultiplexer.Connect("localhost");

        public static IDatabase RDattabase => Redis.GetDatabase();

        #region String

        public static void StringDemo1_Get_Set_Append()
        {
            string value = "abcdefg";
            RDattabase.StringSet("a", value);
            Console.WriteLine(RDattabase.StringGet("a"));

            RDattabase.StringAppend("a", "hijklmn");
            Console.WriteLine(RDattabase.StringGet("a"));

            RDattabase.StringAppendAsync("a", "opqrst");
            Console.WriteLine(RDattabase.StringGet("a"));

            RDattabase.StringAppendAsync("a", "uvwxyz");

            Console.WriteLine(RDattabase.StringBitCount("a"));
        }

        public static void String_Inccre_Decre()
        {
            RedisValue oldValue = RDattabase.StringGetSet("a", "1234567890");
            Console.WriteLine(oldValue);
            Console.WriteLine(RDattabase.StringGet("a"));
        }

        public static void String_Incre_Decre()
        {
            RDattabase.StringSet("number", 1);
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
                RDattabase.StringDecrement("number");
            }
            for (int i = 0; i < 20; i++)
            {
                Thread.Sleep(1000);
                RDattabase.StringIncrement("number");
            }
        }

        #endregion String

        #region List

        public static int ListCount = 20;

        //队列
        public static void ListDemo_LPush_RPop()
        {
            Console.WriteLine("ListDemo_LPush_RPop");
            for (int i = 0; i < ListCount; i++)
            {
                RDattabase.ListLeftPush("list", i);
            }
            for (int i = 0; i < ListCount; i++)
            {
                RedisValue val = RDattabase.ListRightPop("list");
                Console.Write(val + " ");
            }
            Console.WriteLine();
        }

        //队列
        public static void ListDemo_RPush_LPop()
        {
            Console.WriteLine("ListDemo_RPush_LPop");
            for (int i = 0; i < ListCount; i++)
            {
                RDattabase.ListRightPush("rlist", i);
            }
            for (int i = 0; i < ListCount; i++)
            {
                RedisValue val = RDattabase.ListLeftPop("rlist");
                Console.Write(val + " ");
            }
            Console.WriteLine();
        }

        //栈
        public static void ListDemo_LPush_LPop()
        {
            Console.WriteLine("ListDemo_LPush_LPop");
            for (int i = 0; i < ListCount; i++)
            {
                RDattabase.ListLeftPush("list", i);
            }
            for (int i = 0; i < ListCount; i++)
            {
                RedisValue val = RDattabase.ListLeftPop("list");
                Console.Write(val + " ");
            }
            Console.WriteLine();
        }

        //栈
        public static void ListDemo_RPush_RPop()
        {
            Console.WriteLine("ListDemo_RPush_RPop");
            for (int i = 0; i < ListCount; i++)
            {
                RDattabase.ListRightPush("rlist", i);
            }
            for (int i = 0; i < ListCount; i++)
            {
                RedisValue val = RDattabase.ListRightPop("rlist");
                Console.Write(val + " ");
            }
            Console.WriteLine();
        }

        public static void ListDemo_()
        {
            for (int i = 1; i <= 20; i++)
            {
                RDattabase.ListLeftPush("list", i);
                //rDb.ListRightPush("list", i);
                RDattabase.ListLeftPushAsync("list", i);
            }
            Console.WriteLine(RDattabase.ListGetByIndex("list", 6));
        }

        #endregion List
    }
}