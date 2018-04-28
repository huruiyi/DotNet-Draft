using ConApp.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace ConApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = "1851 1999 1950 1905 2003";
            string pattern = @"(?<=19)\d{2}\b";

            foreach (Match match in Regex.Matches(input, pattern))
            {
                Console.WriteLine(match.Value);
            }
            Console.ReadKey();
            
            
            //string s = "例如：http://www.asd.com,http://wwww.gongjuji.net?name=zhangsan&age=10,http://md5.gongjuji.net/dencrypt/";
            //Regex re = new Regex(@"(?<urladdress>http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?)");
            //MatchCollection mc = re.Matches(s);
            //foreach (Match m in mc)
            //{
            //    string url = m.Result("${urladdress}");
            //    Console.WriteLine(url);
            //}
            //Console.ReadKey();


            WebClient webClient = new WebClient();
            byte[] bytes = webClient.DownloadData("https://github.com/mono");

            string result = Encoding.Default.GetString(bytes);

            Regex re = new Regex("ref=\"(//mono//.*?)\" item");
            MatchCollection mc = re.Matches(result);
            foreach (Match match in mc)
            {
                //string url = match.Result("${urladdress}");
                //Console.WriteLine(url);

                Console.WriteLine(match.Value);

            }

            Console.WriteLine("++++++++++++++++++++++++++++++");
            Console.ReadKey();


            //  ref="/golang/.*?" item

            // stackalloc
            //TypeFilter
            //WeakReference
            //volatile
        }

        private static bool FindText(string str)
        {
            return str.CompareTo("7") >= 0;
        }

        public static void Demo3()
        {
            List<string> list = new List<string>()
            {
                "3","4","7","9","11"
            };
            var temp = list.MyFindAll<string>(FindText);
        }

        private const string Letters = "ABCDEFGHIJKLMNOPQRSTUVXYZabcdefghijklmnopqrstuvxyz";

        public static void TestScript()
        {
            var sw = new Stopwatch();
            var rnd = new Random();

            var list = new List<Data1>();
            int pickLength = Letters.Length - 1;

            DemonstrateReferenceEqualityCompareProblem(rnd, list, pickLength);

            "So we cannot use Contains for looking for one with the same values, which we very often need".ToConsole();
            "But what if we could, would it matter?".ToConsole();
            var amountsOfData = new[] { 1000, 10000, 100000 };

            var results1 = PerformListExistsTest<Data1>(rnd, pickLength, amountsOfData, CompareMethod.LinqAnyBothEquals);
            var results2 = PerformListExistsTest<Data2>(rnd, pickLength, amountsOfData, CompareMethod.Contains);

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
            var results3 = PerformHashsetExistsTest<Data2>(rnd, pickLength, amountsOfData, CompareMethod.Contains);
            "\r\nPretty warp speed actually, isn't it?\r\nThat is takehome four: Consider using HashSets if you need to check for existence only, it is very good at searching too.\r\nBut remember that this will only work if you're implementing the EqualityComparer, or compare would compare something else, right?\r\n(yes!) and in which case you'd be stuck with a same performance more or less".ToConsole();
            var results4 = PerformHashsetExistsTest<Data1>(rnd, pickLength, amountsOfData, CompareMethod.LinqAnyBothEquals);

            "\r\nWith HashSet though this not a rule of nature, because you can actually specify your equality comparer, even if you cannot extend the data class..".ToConsole();
            var results5 = PerformHashsetExistsTest<Data1>(rnd, pickLength, amountsOfData, CompareMethod.Contains, true);
            "... which is nearly as good".ToConsole();
        }

        private static void DemonstrateReferenceEqualityCompareProblem(Random rnd, List<Data1> list, int pickLength)
        {
            "First making a little list to demonstrate a point while we're at it with lists".ToConsole();
            for (int i = 0; i < 3; i++)
            {
                Data1 objX = GetNewData<Data1>(rnd, pickLength);
                list.Add(objX);
            }
            var objValueCopy = new Data1 { ID = list[2].ID, Name = list[2].Name };
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

        public enum CompareMethod
        {
            LinqAnyBothEquals = 0,
            Contains = 1,
        }

        private static List<long> PerformListExistsTest<T>(Random rnd, int pickLength, int[] amountsOfData, CompareMethod compareMethod) where T : TestData, new()
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

        private static List<long> PerformHashsetExistsTest<T>(Random rnd, int pickLength, int[] amountsOfData, CompareMethod compareMethod, bool useWouldDoComparer = false) where T : TestData, new()
        {
            var hashSet = new HashSet<T>();

            if (useWouldDoComparer)
            {
                hashSet = new HashSet<T>(new TestDataEqualityComparer());
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

        private static void GetMeAlistWithManyData<T>(Random rnd, List<T> list, int pickLength, int itemsRequested = 10000) where T : TestData, new()
        {
            ("Generating test data " + itemsRequested + " and priming a List with them").ToConsole();
            for (int i = 0; i < itemsRequested; i++)
            {
                T objX = GetNewData<T>(rnd, pickLength);
                list.Add(objX);
            }
            "Data ready".ToConsole();
        }

        private static void GetMeAHashsetWithManyData<T>(Random rnd, HashSet<T> hashSet, int pickLength, int itemsRequested = 10000) where T : TestData, new()
        {
            ("Generating test data " + itemsRequested + " and priming a Hashset with them").ToConsole();
            for (int i = 0; i < itemsRequested; i++)
            {
                T objX = GetNewData<T>(rnd, pickLength);
                hashSet.Add(objX);
            }
            "Data ready".ToConsole();
        }

        private static T GetNewData<T>(Random rnd, int pickLength) where T : TestData, new()
        {
            var objX = new T { ID = rnd.Next() };
            for (int x = 0; x < 10; x++)
            {
                objX.Name += Letters[rnd.Next(0, pickLength)];
            }

            return objX;
        }

        public Program(int mNData)
        {
            MnData = mNData;
        }

        public static int Number0;
        public static int? Number1;

        //静态变量存储在堆上，查看指针时需用fixed固定
        public static int MSz = 100;

        //普通数据成员，也是放在堆上了，查看指针时需用fixed固定
        public int MnData = 100;

        //等价于C/C++的 #define 语句，不分配内存
        public const int PI = 31415;

        public static void NullNum()
        {
            int? ni = new int?(12);
            ni = 123456;
            Console.WriteLine(ni);
            ni = null;
            Console.WriteLine(ni);
            Console.WriteLine(Number0);
            Console.WriteLine(Number1 == null ? 123 : 456);
        }

        private static bool RemoteCertificateCallback(Object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        /// <summary>
        /// Post数据【参数1：网关地址，2：提交的XML消费交易数据，3：商户号，4商户密码，5：商户证书地址，6：商户证书密码】
        /// </summary>
        public string HttpPost(string sUrl, string sPostData, string sMerId, string sMerPw, string prikeyPath, string prikeyPassword)
        {
            try
            {
                //将输入的xml内容转化为byte数组，
                byte[] data = Encoding.UTF8.GetBytes(sPostData);
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
                ServicePointManager.ServerCertificateValidationCallback = RemoteCertificateCallback;
                //使用webrequest发送http消息，模拟浏览器提交的效果
                HttpWebRequest httpreq = (HttpWebRequest)WebRequest.Create(new Uri(sUrl));
                //设置http的方法是post，post/get二种方法
                httpreq.Method = "POST";
                //模拟form的类型，一般来说用这种类型的form
                httpreq.ContentType = "application/x-www-form-urlencoded";
                //数据长度，https要求
                httpreq.ContentLength = data.Length;
                //获取或设置请求的身份验证信息
                httpreq.Credentials = CredentialCache.DefaultCredentials;
                //获取需要的商户验证信息
                string userNamePassword = sMerId + ":" + sMerPw;
                CredentialCache mycache = new CredentialCache();
                mycache.Add(new Uri(sUrl), "Basic", new NetworkCredential(sMerId, sMerPw));
                httpreq.Credentials = mycache;
                httpreq.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(new ASCIIEncoding().GetBytes(userNamePassword)));
                //加载证书
                X509Certificate2 objX509_2 = new X509Certificate2(prikeyPath, prikeyPassword);
                httpreq.ClientCertificates.Add(objX509_2);
                //利用二进制流发送数据
                Stream newStream = httpreq.GetRequestStream();
                //发送数据
                newStream.Write(data, 0, data.Length);
                newStream.Close();
                //得到http的返回结果
                HttpWebResponse res = (HttpWebResponse)httpreq.GetResponse();
                //分析返回结果
                StreamReader reader = new StreamReader(res.GetResponseStream(), Encoding.UTF8);
                //得到返回值
                string rtnRes = reader.ReadToEnd();
                reader.Close();
                return rtnRes; //返回TR2数据
            }
            catch (Exception ex)
            {
                string sStr = ex.Message;
                return sStr; //返回错误
            }
        }

        public static void WriteMatches(string text, MatchCollection matches)
        {
            Console.WriteLine("Original text was: \n\n" + text + "\n");
            Console.WriteLine("No. of matches: " + matches.Count);
            foreach (Match nextMatch in matches)
            {
                int index = nextMatch.Index;
                string result = nextMatch.ToString();
                int charsBefore = (index < 5) ? index : 5;
                int fromEnd = text.Length - index - result.Length;
                int charsAfter = (fromEnd < 5) ? fromEnd : 5;
                int charsToDisplay = charsBefore + charsAfter + result.Length;

                Console.WriteLine("Index: {0}, \tString: {1}, \t{2}", index, result, text.Substring(index - charsBefore, charsToDisplay));
            }
        }

        public static void VectorDemo()
        {
            CSVector v1 = new CSVector(1, 32, 5);
            CSVector v2 = new CSVector(845.4, 54.3, -7.8);
            Console.WriteLine("\nIn IJK format,\nv1 is {0,30:IJK}\nv2 is {1,30:IJK}", v1, v2);
            Console.WriteLine("\nIn default format,\nv1 is {0,30}\nv2 is {1,30}", v1, v2);
            Console.WriteLine("\nIn VE format\nv1 is {0,30:VE}\nv2 is {1,30:VE}", v1, v2);
            Console.WriteLine("\nNorms are:\nv1 is {0,20:N}\nv2 is {1,20:N}", v1, v2);
        }

        public static void CdromManagement()
        {
            WqlEventQuery q;
            ManagementOperationObserver observer = new ManagementOperationObserver();
            // Bind to local machine
            ConnectionOptions opt = new ConnectionOptions
            {
                EnablePrivileges = true
            };
            //sets required privilege
            ManagementScope scope = new ManagementScope("root\\CIMV2", opt);
            q = new WqlEventQuery
            {
                EventClassName = "__InstanceModificationEvent",
                WithinInterval = new TimeSpan(0, 0, 1),
                Condition = @"TargetInstance ISA 'Win32_LogicalDisk' and TargetInstance.DriveType = 5"
            };
            // DriveType - 5: CDROM
            var watcher = new ManagementEventWatcher(scope, q);
            // register async. event handler
            watcher.EventArrived += (sender, e) =>
            {
                // Get the Event object and display it
                PropertyData propertyData = e.NewEvent.Properties["TargetInstance"];
                ManagementBaseObject mbo = propertyData.Value as ManagementBaseObject;

                // if CD removed VolumeName == null
                Console.WriteLine(mbo?.Properties["VolumeName"].Value != null
                    ? "CD has been inserted"
                    : "CD has been ejected");
            };
            watcher.Start();
            // Do something usefull,block thread for testing
            Console.ReadLine();
            watcher.Stop();
        }

        public static void VolatileTest()
        {
            // Create the worker thread object. This does not start the thread.
            Worker workerObject = new Worker();
            Thread workerThread = new Thread(workerObject.DoWork);

            // Start the worker thread.
            workerThread.Start();
            Console.WriteLine("Main thread: starting worker thread...");

            // Loop until the worker thread activates.
            while (!workerThread.IsAlive)
            {
            }

            // Put the main thread to sleep for 1 millisecond to
            // allow the worker thread to do some work.
            Thread.Sleep(1);

            // Request that the worker thread stop itself.
            workerObject.RequestStop();

            // Use the Thread.Join method to block the current thread
            // until the object's thread terminates.
            workerThread.Join();
            Console.WriteLine("Main thread: worker thread has terminated.");
        }

        private static void StrongBoxInt(StrongBox<int> sint)
        {
            sint.Value = 456789;
        }

        private static void StrongBoxDemo()
        {
            StrongBox<int> sint = new StrongBox<int>(123465);
            Console.WriteLine(sint.Value);
            StrongBoxInt(sint);
            Console.WriteLine(sint.Value);
        }
    }

    public class TestData
    {
        public int ID { get; set; }
        public string Name { get; set; }
    };

    /// <summary>
    /// Plain vanilla dataclass with nothing special to help
    /// </summary>
    public class Data1 : TestData
    {
    }

    /// <summary>
    /// Implementing IEqualityComparer to help
    /// </summary>
    public class Data2 : Data1, IEqualityComparer, IEqualityComparer<Data2>
    {
        public bool Equals(Data2 x, Data2 y)
        {
            return x.ID == y.ID && x.Name == y.Name;
        }

        public new bool Equals(object x, object y)
        {
            if (x is Data2)
            {
                if (y is Data2)
                {
                    return Equals((Data2)x, (Data2)y);
                }
            }
            return false;
        }

        public int GetHashCode(Data2 obj)
        {
            return (ID + Name).GetHashCode();
        }

        public int GetHashCode(object obj)
        {
            if (obj is Data2)
            {
                return (obj as Data2).GetHashCode();
            }
            return obj.GetHashCode();
        }
    }

    public class TestDataEqualityComparer : IEqualityComparer<TestData>
    {
        public bool Equals(TestData x, TestData y)
        {
            return x.ID == y.ID && x.Name == y.Name;
        }

        public int GetHashCode(TestData obj)
        {
            return (obj.ID + obj.Name).GetHashCode();
        }
    }

    public static class MeExtend
    {
        //扩展方法三要素：  静态类型，静态方法，this关键字。
        public delegate bool MyPreDel<T>(T text);

        public static void ToConsole(this string toWrite)
        {
            Console.WriteLine(toWrite);
        }

        //扩展方法要求第一个参数必须使用this标识，this后面的类型就是要扩展的类型。this后面类型实例就是咱们扩展方法调用者。
        public static List<T> MyFindAll<T>(this List<T> list, MyPreDel<T> del)
        {
            List<T> result = new List<T>();
            foreach (var item in list)
            {
                if (del(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }
    }
}
