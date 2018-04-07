using ConApp.Model;
using System;
using System.IO;
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
            // stackalloc
            //TypeFilter
            //WeakReference
            //volatile
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
}