using ConApp.Model;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections;
using System.Collections.Generic;
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
    public struct Xyz
    {
        public int A;
        public int B;
        public int C;
    }

    internal class DocTreeHelper
    {
        /// <summary>
        /// 输出目录结构树
        /// </summary>
        /// <param name="dirpath">被检查目录</param>
        public static void PrintTree(string dirpath)
        {
            if (!Directory.Exists(dirpath))
            {
                Directory.CreateDirectory(dirpath);
            }
            if (!Directory.Exists(dirpath))
            {
                throw new Exception("文件夹不存在");
            }

            PrintDirectory(dirpath, 0, "");
        }

        /// <summary>
        /// 将目录结构树输出到指定文件
        /// </summary>
        /// <param name="dirpath">被检查目录</param>
        /// <param name="outputpath">输出到的文件</param>
        public static void PrintTree(string dirpath, string outputpath)
        {
            if (!Directory.Exists(dirpath))
            {
                throw new Exception("文件夹不存在");
            }

            //将输出流定向到文件 outputpath
            StringWriter swOutput = new StringWriter();
            Console.SetOut(swOutput);

            PrintDirectory(dirpath, 0, "");

            //将输出流输出到文件 outputpath
            File.WriteAllText(outputpath, swOutput.ToString());

            //将输出流重新定位回文件 outputpath
            StreamWriter swConsole =
                new StreamWriter(Console.OpenStandardOutput(), Console.OutputEncoding) { AutoFlush = true };
            Console.SetOut(swConsole);
        }

        /// <summary>
        /// 打印目录结构
        /// </summary>
        /// <param name="dirpath">目录</param>
        /// <param name="depth">深度</param>
        /// <param name="prefix">前缀</param>
        private static void PrintDirectory(string dirpath, int depth, string prefix)
        {
            DirectoryInfo dif = new DirectoryInfo(dirpath);

            //打印当前目录
            if (depth == 0)
            {
                Console.WriteLine(prefix + dif.Name);
            }
            else
            {
                Console.WriteLine(prefix.Substring(0, prefix.Length - 2) + "| ");
                Console.WriteLine(prefix.Substring(0, prefix.Length - 2) + "|-" + dif.Name);
            }

            //打印目录下的目录信息
            for (int counter = 0; counter < dif.GetDirectories().Length; counter++)
            {
                DirectoryInfo di = dif.GetDirectories()[counter];
                if (counter != dif.GetDirectories().Length - 1 ||
                    dif.GetFiles().Length != 0)
                {
                    PrintDirectory(di.FullName, depth + 1, prefix + "| ");
                }
                else
                {
                    PrintDirectory(di.FullName, depth + 1, prefix + "  ");
                }
            }

            //打印目录下的文件信息
            for (int counter = 0; counter < dif.GetFiles().Length; counter++)
            {
                FileInfo f = dif.GetFiles()[counter];
                if (counter == 0)
                {
                    Console.WriteLine(prefix + "|");
                }
                Console.WriteLine(prefix + "|-" + f.Name);
            }
        }
    }

    public class Program
    {
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

        public static void Main(string[] args)
        {
            //FileSystem.MoveFile(args[0], args[1]);

            Console.ReadKey();
        }

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

        public static void PrintTree()
        {
            string str = File.ReadAllText("E:\\aaa.txt", Encoding.Default);
            str = Regex.Replace(str, "\r|\n", "");
            Console.WriteLine(str);
            Console.WriteLine(DateTime.Today);
            Console.Read();
            SortedList sortedList = new SortedList
            {
                {3, 1},
                {15, 5},
                {5, 55},
                {9, 55}
            };
            ParallelQuery pq = sortedList.AsParallel();
            foreach (DictionaryEntry entry in sortedList)
            {
                Console.WriteLine(entry.Key + " " + entry.Value);
            }

            #region 写入文本

            //StreamWriter sw = new StreamWriter(@"ConsoleOutput.txt");
            //Console.SetOut(sw);

            //Console.WriteLine("Here is the result:");
            //Console.WriteLine("Processing......");
            //Console.WriteLine("OK!");
            //for (int i = 0; i <= 255; i++)
            //{
            //    if (i % 4 == 0)
            //    {
            //        Console.WriteLine();
            //    }
            //    Console.Write("{0} {1} \t", i.ToString().PadLeft(3, '0'), Convert.ToString(i, 2).PadLeft(8, '0'));
            //}

            //sw.Flush();
            //sw.Close();

            #endregion 写入文本

            //string dirpath = @"D:\MyPrograms\Program4Use\DocumentTree";
            //string outputpath = @"output.txt";

            //DocTreeHelper.PrintTree(dirpath);
            //DocTreeHelper.PrintTree(dirpath, outputpath);

            //Console.WriteLine("Output Finished");
            //Console.WriteLine("输出完毕");
        }

        private static void DeleteRecentDemo()
        {
            string recentPath = Environment.GetFolderPath(Environment.SpecialFolder.Recent);

            string[] files = Directory.GetFiles(recentPath);

            if (files.Length > 0)
            {
                foreach (var file in files)
                {
                    File.Delete(file);
                }

                Console.WriteLine("清理完成................");
            }
            else
            {
                Console.WriteLine("干干净净的,无需清理");
            }
        }

        private static void DeletFileeDemo()

        {
            Console.WriteLine("删除文件到回收站");
            string filepath = @"D:\xxx.rar";
            FileSystem.DeleteFile(filepath, UIOption.OnlyErrorDialogs, RecycleOption.DeletePermanently);
            Console.WriteLine("删除文件完成");

            ////Console.WriteLine("删除文件夹到回收站");
            ////string dirpath = "leaver";
            ////FileSystem.DeleteDirectory(dirpath, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
            ////Console.WriteLine("删除文件夹完成");
        }

        // stackalloc
        //TypeFilter
        //WeakReference
        //volatile

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

        public static void AsyncFuncDemo()
        {
            Func<bool> ascyRun = ProcessCount;
            IAsyncResult reslu = ascyRun.BeginInvoke(MyAsyncCallback, ascyRun);

            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(200);

                Console.WriteLine("End。。。。。。。。");
            }
        }

        public static void MyAsyncCallback(IAsyncResult ar)
        {
            Func<bool> pc = (Func<bool>)ar.AsyncState;
            var endInvoke = pc.EndInvoke(ar);
            if (endInvoke)
            {
                Console.WriteLine("处理完成。。");
            }
            else
            {
                Console.WriteLine("处理失败。。");
            }
        }

        public static bool ProcessCount()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i + "\t");
                Thread.Sleep(100);
            }
            return true;
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
            ManagementEventWatcher watcher = null;
            WqlEventQuery q;
            ManagementOperationObserver observer = new ManagementOperationObserver();
            // Bind to local machine
            ConnectionOptions opt = new ConnectionOptions();
            opt.EnablePrivileges = true; //sets required privilege
            ManagementScope scope = new ManagementScope("root\\CIMV2", opt);
            q = new WqlEventQuery();
            q.EventClassName = "__InstanceModificationEvent";
            q.WithinInterval = new TimeSpan(0, 0, 1);
            // DriveType - 5: CDROM
            q.Condition = @"TargetInstance ISA 'Win32_LogicalDisk' and TargetInstance.DriveType = 5";
            watcher = new ManagementEventWatcher(scope, q);
            // register async. event handler
            watcher.EventArrived += new EventArrivedEventHandler(CdrEventArrived);
            watcher.Start();
            // Do something usefull,block thread for testing
            Console.ReadLine();
            watcher.Stop();
        }

        // Dump all properties
        public static void CdrEventArrived(object sender, EventArrivedEventArgs e)
        {
            // Get the Event object and display it
            PropertyData propertyData = e.NewEvent.Properties["TargetInstance"];
            ManagementBaseObject mbo = propertyData.Value as ManagementBaseObject;

            // if CD removed VolumeName == null
            Console.WriteLine(mbo?.Properties["VolumeName"].Value != null
                ? "CD has been inserted"
                : "CD has been ejected");
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
            while (!workerThread.IsAlive) ;

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

        private static void Calc()
        {
            Thread th = new Thread(() =>
            {
                Console.WriteLine();
            });
            // [Obsolete("Thread.Resume has been deprecated.  Please use other classes in System.Threading,
            // such as Monitor, Mutex, Event, and Semaphore,
            //to synchronize Threads or protect resources.  http://go.microsoft.com/fwlink/?linkid=14202", false)]
            th.Resume();
        }

        private static void Index()
        {
            IndexClass ic = new IndexClass
            {
                ListPerson = new List<PersonClass>
                {
                    new PersonClass {Id = 1, Name = "User1"},
                    new PersonClass {Id = 2, Name = "User2"},
                    new PersonClass {Id = 3, Name = "User3"}
                }
            };
            Console.WriteLine(ic[2].Name);
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