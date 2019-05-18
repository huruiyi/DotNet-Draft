using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ConApp01
{
    internal class Program
    {
        private static List<long> PerformListExistsTest<T>(Random rnd, int pickLength, int[] amountsOfData, CompareMethod compareMethod) where T : User, new()
        {
            var list = new List<T>();
            var results = new List<long>(amountsOfData.Length);
            var sw = new Stopwatch();
            ("Compare method " + compareMethod).ToConsole();
            foreach (var amt in amountsOfData)
            {
                int manyData = amt;
                "".ToConsole();
                GetMeAlistWithManyData(rnd, list, pickLength, manyData);

                "Get 25 % of data, each element delete or not at random from list".ToConsole();
                int aboutTwentyFivePct = (int)(manyData * 0.25);
                var arr = new T[aboutTwentyFivePct];
                for (int i = 0; i < aboutTwentyFivePct; i++)
                {
                    int pos = rnd.Next(0, list.Count());
                    arr[i] = list[pos];
                    if (rnd.Next(0, 1) == 1)
                    {
                        list.Remove(arr[i]);
                    }
                }
                "Testing to add each element, but only if it does not exist".ToConsole();
                sw.Start();
                foreach (T data in arr)
                {
                    if (compareMethod == CompareMethod.LinqAnyBothEquals)
                    {
                        if (!list.Any(s => s.ID == data.ID && s.Name == data.Name))
                            list.Add(data);
                    }
                    else if (compareMethod == CompareMethod.Contains)
                    {
                        if (!list.Contains(data))
                            list.Add(data);
                    }
                    else
                    {
                        throw new NotImplementedException("This method is not implemented, comparemethod " + compareMethod);
                    }
                }
                sw.Stop();
                ("The process took " + sw.ElapsedMilliseconds + " ms").ToConsole();
                results.Add(sw.ElapsedMilliseconds);
            }
            return results;
        }

        public static void TestScript()
        {
            var sw = new Stopwatch();
            var rnd = new Random();

            var list = new List<Data01>();
            int pickLength = Letters.Length - 1;

            DemonstrateReferenceEqualityCompareProblem(rnd, list, pickLength);

            "So we cannot use Contains for looking for one with the same values, which we very often need".ToConsole();
            "But what if we could, would it matter?".ToConsole();
            var amountsOfData = new[] { 1000, 10000, 100000 };

            var results1 = PerformListExistsTest<Data01>(rnd, pickLength, amountsOfData, CompareMethod.LinqAnyBothEquals);
            var results2 = PerformListExistsTest<Data02>(rnd, pickLength, amountsOfData, CompareMethod.Contains);

            "now with data the first takehome:".ToConsole();
            ("using linq any compare we spent totally :" + results1.Sum() + " ms").ToConsole();
            ("using the Equality and contains comparer :" + results2.Sum() + " ms").ToConsole();
            ("This means that by implementing IEqualityComparer i've speeded up performaning the same searches SIGNIFICANTLY => you should always implement these interfaces on your dataclasses if working with lists and checking for existence").ToConsole();

            "\r\nEach data amount is 10 times larger than the previous.".ToConsole();
            "The durations however are respectively per increment: ".ToConsole();
            for (int i = 0; i < amountsOfData.GetUpperBound(0); i++)
            {
                int x = i + 1;
                (x + ". (any) increment " + ((int)(results1[x] / results1[i])) + " times larger than previous, total ms: " + results1[x]).ToConsole();
                (x + ". (Contains) increment " + ((int)(results2[x] / results2[i])) + " times larger than previous, total ms: " + results2[x]).ToConsole();
                ("improvement is " + (results1[x] / (decimal)results2[x]).ToString("0.00") + " times").ToConsole();
            }
            "\r\nTakehome two: The improvements manifest even with pretty small lists and is largest in the beginning".ToConsole();

            "\r\nTakehome three: Lists are for small amounts of data, if you have to check for existence - It should also be clear that the search is by no way linear, because each element will have to be compared with each element before and so the time will grow with the size, even when it's faster, it's not fast enough when the amounts of elements increase much beyond the 1000, so if you have to check for inclusion. Consider not using a list anyway.".ToConsole();

            "\r\nA very nice way of implementing such requirements instead by another collection which can also yield the IEqualityComparer, the hashset..".ToConsole();
            var results3 = PerformHashsetExistsTest<Data02>(rnd, pickLength, amountsOfData, CompareMethod.Contains);
            "\r\nPretty warp speed actually, isn't it?\r\nThat is takehome four: Consider using HashSets if you need to check for existence only, it is very good at searching too.\r\nBut remember that this will only work if you're implementing the EqualityComparer, or compare would compare something else, right?\r\n(yes!) and in which case you'd be stuck with a same performance more or less".ToConsole();
            var results4 = PerformHashsetExistsTest<Data01>(rnd, pickLength, amountsOfData, CompareMethod.LinqAnyBothEquals);

            "\r\nWith HashSet though this not a rule of nature, because you can actually specify your equality comparer, even if you cannot extend the data class..".ToConsole();
            var results5 = PerformHashsetExistsTest<Data01>(rnd, pickLength, amountsOfData, CompareMethod.Contains, true);
            "... which is nearly as good".ToConsole();
        }

        private const string Letters = "ABCDEFGHIJKLMNOPQRSTUVXYZabcdefghijklmnopqrstuvxyz";

        private static void DemonstrateReferenceEqualityCompareProblem(Random rnd, List<Data01> list, int pickLength)
        {
            "First making a little list to demonstrate a point while we're at it with lists".ToConsole();
            for (int i = 0; i < 3; i++)
            {
                Data01 objX = GetNewData<Data01>(rnd, pickLength);
                list.Add(objX);
            }
            var objValueCopy = new Data01 { ID = list[2].ID, Name = list[2].Name };
            if (list.Contains(objValueCopy))
            {
                "As we might expect, it's there".ToConsole();
            }
            else
            {
                "No, because lacking an Equality comparer, it's going to look at references, and our new instance reference ANOTHER object with the same values only".ToConsole();
            }
            list.Clear();
        }

        private static T GetNewData<T>(Random rnd, int pickLength) where T : User, new()
        {
            var objX = new T { ID = rnd.Next() };
            for (int x = 0; x < 10; x++)
            {
                objX.Name += Letters[rnd.Next(0, pickLength)];
            }

            return objX;
        }

        private static void GetMeAlistWithManyData<T>(Random rnd, List<T> list, int pickLength, int itemsRequested = 10000) where T : User, new()
        {
            ("Generating test data " + itemsRequested + " and priming a List with them").ToConsole();
            for (int i = 0; i < itemsRequested; i++)
            {
                T objX = GetNewData<T>(rnd, pickLength);
                list.Add(objX);
            }
            "Data ready".ToConsole();
        }

        private static void GetMeAHashsetWithManyData<T>(Random rnd, HashSet<T> hashSet, int pickLength, int itemsRequested = 10000) where T : User, new()
        {
            ("Generating test data " + itemsRequested + " and priming a Hashset with them").ToConsole();
            for (int i = 0; i < itemsRequested; i++)
            {
                T objX = GetNewData<T>(rnd, pickLength);
                hashSet.Add(objX);
            }
            "Data ready".ToConsole();
        }

        private static List<long> PerformHashsetExistsTest<T>(Random rnd, int pickLength, int[] amountsOfData, CompareMethod compareMethod, bool useWouldDoComparer = false) where T : User, new()
        {
            var hashSet = new HashSet<T>();

            if (useWouldDoComparer)
            {
                hashSet = new HashSet<T>(new EqualityComparer());
            }
            var results = new List<long>(amountsOfData.Length);
            var sw = new Stopwatch();
            ("Compare method " + compareMethod).ToConsole();
            foreach (var amt in amountsOfData)
            {
                int manyData = amt;
                "".ToConsole();
                GetMeAHashsetWithManyData(rnd, hashSet, pickLength, manyData);

                "Get 25 % of data, each element delete or not at random from list".ToConsole();
                int aboutTwentyFivePct = (int)(manyData * 0.25);
                var arr = new T[aboutTwentyFivePct];
                var dataAsArray = hashSet.ToArray();
                for (int i = 0; i < aboutTwentyFivePct; i++)
                {
                    int pos = rnd.Next(0, hashSet.Count());
                    arr[i] = dataAsArray[pos];
                    if (rnd.Next(0, 1) == 1)
                    {
                        hashSet.Remove(arr[i]);
                    }
                }
                "Testing to add each element, but only if it does not exist".ToConsole();
                sw.Start();
                foreach (T data in arr)
                {
                    if (compareMethod == CompareMethod.LinqAnyBothEquals)
                    {
                        if (!hashSet.Any(s => s.ID == data.ID && s.Name == data.Name))
                            hashSet.Add(data);
                    }
                    else if (compareMethod == CompareMethod.Contains)
                    {
                        if (!hashSet.Contains(data))
                            hashSet.Add(data);
                    }
                    else
                    {
                        throw new NotImplementedException("This method is not implemented, comparemethod " + compareMethod);
                    }
                }
                sw.Stop();
                ("The process took " + sw.ElapsedMilliseconds + " ms").ToConsole();
                results.Add(sw.ElapsedMilliseconds);
            }
            return results;
        }

        #region MyRegion

        private static bool FindText(string str)
        {
            return String.CompareOrdinal(str, "7") >= 0;
        }

        public static void Demo3()
        {
            List<string> list = new List<string>
            {
                "3","4","7","9","11"
            };
            var lists = list.MyFindAll<string>(FindText);
            lists.ForEach((item) =>
            {
                Console.WriteLine(item);
            });
        }

        #endregion MyRegion

        public static int Number0;
        public static int? Number1;

        private static void Main(string[] args)
        {
            int? ni = new int?(12);
            ni = 123456;
            Console.WriteLine(ni);
            ni = null;
            Console.WriteLine(ni);
            Console.WriteLine(Number0);
            Console.WriteLine(Number1 == null ? 123 : 456);
        }
    }
}