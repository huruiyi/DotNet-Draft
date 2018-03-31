using ConApp.EnumModel;
using ConApp.Model;
using Microsoft.VisualBasic.FileIO;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq.Expressions;
using System.Management;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Net;
using System.Net.Security;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace ConApp
{
    /// <summary>
    /// 脚本参数
    /// </summary>
    public class PsParam
    {
        public string Key { get; set; }

        public object Value { get; set; }
    }

    internal class Info
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
    }

    public struct Xyz
    {
        public int A;
        public int B;
        public int C;
    }

    #region 原始:Notification类依赖Email类，这违反了DIP，而且当我们要发送短信/保存到数据库的时候，我们还要改变Notification类。

    //public class Email
    //{
    //    public void SendEmail()
    //    {
    //        // code
    //    }
    //}

    //public class Notification
    //{
    //    private readonly Email _email;
    //    public Notification()
    //    {
    //        _email = new Email();
    //    }

    //    public void PromotionalNotification()
    //    {
    //        _email.SendEmail();
    //    }
    //}

    #endregion 原始:Notification类依赖Email类，这违反了DIP，而且当我们要发送短信/保存到数据库的时候，我们还要改变Notification类。

    #region IMessageService 是一个接口，而Notification 类只要调用接口的方法/属性就可以了,同时，我们把Email对象的构造移到Notification 类外面去。

    public interface IMessageService
    {
        void SendMessage();
    }

    public class Email : IMessageService
    {
        public void SendMessage()
        {
            // code
        }
    }

    public class Notification
    {
        private readonly IMessageService _iMessageService;

        public Notification()
        {
            _iMessageService = new Email();
        }

        public void PromotionalNotification()
        {
            _iMessageService.SendMessage();
        }
    }

    #endregion IMessageService 是一个接口，而Notification 类只要调用接口的方法/属性就可以了,同时，我们把Email对象的构造移到Notification 类外面去。

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
            StreamWriter swConsole = new StreamWriter(Console.OpenStandardOutput(), Console.OutputEncoding);
            swConsole.AutoFlush = true;
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
        public static int Number0;
        public static int? Number1;

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
            //SortedList sortedList = new SortedList();
            //sortedList.Add(3, 1);
            //sortedList.Add(15, 5);
            //sortedList.Add(5, 55);
            //sortedList.Add(9, 55);
            //ParallelQuery pq = sortedList.AsParallel();
            //foreach (DictionaryEntry entry in sortedList)
            //{
            //    Console.WriteLine(entry.Key + " " + entry.Value);
            //}

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
                for (int i = 0; i < files.Length; i++)
                {
                    File.Delete(files[i]);
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

        private static void RegistryKeyDemo()
        {
            RegistryKey rk = Registry.ClassesRoot;
            string[] vn = rk.GetSubKeyNames();

            RegistryKey rk0 = Registry.CurrentConfig;
            string[] vn0 = rk0.GetSubKeyNames();

            RegistryKey rk1 = Registry.CurrentUser;
            string[] vn1 = rk1.GetSubKeyNames();

            RegistryKey rk2 = Registry.LocalMachine;
            string[] vn2 = rk2.GetSubKeyNames();

            RegistryKey rk3 = Registry.PerformanceData;
            string[] vn3 = rk3.GetSubKeyNames();

            RegistryKey rk4 = Registry.Users;
            string[] vn4 = rk4.GetSubKeyNames();
        }

        private static void PrintKeys(RegistryKey rkey)
        {
            // Retrieve all the subkeys for the specified key.
            string[] names = rkey.GetSubKeyNames();

            int icount = 0;

            Console.WriteLine("Subkeys of " + rkey.Name);
            Console.WriteLine("-----------------------------------------------");

            // Print the contents of the array to the console.
            foreach (string s in names)
            {
                Console.WriteLine(s);

                // The following code puts a limit on the number
                // of keys displayed.  Comment it out to print the
                // complete list.
                icount++;
                if (icount >= 10)
                    break;
            }
        }

        private static bool RemoteCertificateCallback(Object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        /// <summary>
        /// Post数据【参数1：网关地址，2：提交的XML消费交易数据，3：商户号，4商户密码，5：商户证书地址，6：商户证书密码】
        /// </summary>
        public string HttpPost(string sUrl, string sPostData, string sMerId, string sMerPW, string prikey_path, string prikey_password)
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
                string userNamePassword = sMerId + ":" + sMerPW;
                CredentialCache mycache = new CredentialCache();
                mycache.Add(new Uri(sUrl), "Basic", new NetworkCredential(sMerId, sMerPW));
                httpreq.Credentials = mycache;
                httpreq.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(new ASCIIEncoding().GetBytes(userNamePassword)));
                //加载证书
                X509Certificate2 objX509_2 = new X509Certificate2(prikey_path, prikey_password);
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

        private static void RunPsDemo1()
        {
            List<string> ps = new List<string>();
            ps.Add("Get-WmiObject -Class Win32_UserAccount");
            Runspace runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();
            Pipeline pipeline = runspace.CreatePipeline();
            foreach (var scr in ps)
            {
                pipeline.Commands.AddScript(scr);
            }
            pipeline.Invoke();

            Console.WriteLine(pipeline.Output);
            runspace.Close();
        }

        private static void RunPsDemo2()
        {
            List<string> ps = new List<string>();
            ps.Add("Set-ExecutionPolicy RemoteSigned");//先执行启动安全策略，，使系统可以执行powershell脚本文件

            string path = Environment.CurrentDirectory;
            string pspath = System.IO.Path.Combine(path, "ps.ps1");

            ps.Add(pspath);//执行脚本文件

            Info psobj = new Info();
            psobj.X = 20;
            psobj.Y = 10;

            PsParam par = new PsParam();
            par.Key = "arg";
            par.Value = psobj;

            RunScript(ps, new List<PsParam>() { par });

            Console.WriteLine(psobj.X + " + " + psobj.Y + " = " + psobj.Z);
        }

        public static void InvokeSystemPs(string cmd)
        {
            List<string> ps = new List<string>();
            ps.Add("Set-ExecutionPolicy RemoteSigned");
            ps.Add("Set-ExecutionPolicy -ExecutionPolicy Unrestricted");
            ps.Add("& " + cmd);
            Runspace runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();
            Pipeline pipeline = runspace.CreatePipeline();
            foreach (var scr in ps)
            {
                pipeline.Commands.AddScript(scr);
            }
            pipeline.Invoke();//Execute the ps script
            runspace.Close();
        }

        public static void InvokeVmmps()
        {
            RunspaceConfiguration rconfig = RunspaceConfiguration.Create();
            PSSnapInException pwarn = new PSSnapInException();

            string test = "Import-Module VirtualMachineManager\r\n";
            var runspace = RunspaceFactory.CreateRunspace(rconfig); runspace.Open();
            Pipeline pipeline = runspace.CreatePipeline();
            pipeline.Commands.AddScript(test);
            try
            {
                pipeline.Invoke();

                using (Pipeline pipe = runspace.CreatePipeline())
                {
                    //Get-VM -Name vm001
                    Command cmd = new Command("Get-VM");
                    cmd.Parameters.Add("Name", "vm001");
                    pipe.Commands.Add(cmd);
                    pipe.Invoke();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static Collection<PSObject> RunPowershell(string filePath, string parameters)
        {
            RunspaceConfiguration runspaceConfiguration = RunspaceConfiguration.Create();
            Runspace runspace = RunspaceFactory.CreateRunspace(runspaceConfiguration);
            runspace.Open();
            RunspaceInvoke scriptInvoker = new RunspaceInvoke(runspace);
            Pipeline pipeline = runspace.CreatePipeline();
            Command scriptCommand = new Command(filePath);
            Collection<CommandParameter> commandParameters = new Collection<CommandParameter>();

            string[] tempParas = parameters.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < tempParas.Length; i += 2)
            {
                CommandParameter commandParm = new CommandParameter(tempParas[i], tempParas[i + 1]);
                commandParameters.Add(commandParm);
                scriptCommand.Parameters.Add(commandParm);
            }

            pipeline.Commands.Add(scriptCommand);
            Collection<PSObject> psObjects;
            psObjects = pipeline.Invoke();

            if (pipeline.Error.Count > 0)
            {
                throw new Exception("脚本执行失败");
            }

            runspace.Close();

            return psObjects;
        }

        public static string RunScript(List<string> scripts, List<PsParam> pars)
        {
            Runspace runspace = RunspaceFactory.CreateRunspace();

            runspace.Open();

            Pipeline pipeline = runspace.CreatePipeline();
            foreach (var scr in scripts)
            {
                pipeline.Commands.AddScript(scr);
            }

            //注入参数
            if (pars != null)
            {
                foreach (var par in pars)
                {
                    runspace.SessionStateProxy.SetVariable(par.Key, par.Value);
                }
            }

            //返回结果
            var results = pipeline.Invoke();
            runspace.Close();
            StringBuilder stringBuilder = new StringBuilder();
            foreach (PSObject obj in results)
            {
                stringBuilder.AppendLine(obj.ToString());
            }
            return stringBuilder.ToString();
        }

        //静态变量存储在堆上，查看指针时需用fixed固定
        public static int MSz = 100;

        //普通数据成员，也是放在堆上了，查看指针时需用fixed固定
        public int MnData = 100;

        //等价于C/C++的 #define 语句，不分配内存
        public const int PI = 31415;

        public static void StringReplace1()
        {
            string greetingText = "Hello from all the guys at Wrox Press. ";
            greetingText += "We do hope you enjoy this book as much as we enjoyed writing it.";

            for (int i = 'z'; i >= 'a'; i--)
            {
                char old1 = (char)i;
                char new1 = (char)(i + 1);
                greetingText = greetingText.Replace(old1, new1);
            }

            for (int i = 'Z'; i >= 'A'; i--)
            {
                char old1 = (char)i;
                char new1 = (char)(i + 1);
                greetingText = greetingText.Replace(old1, new1);
            }

            Console.WriteLine("Encoded:\n" + greetingText);
        }

        public static void StringReplace2()
        {
            StringBuilder greetingBuilder = new StringBuilder("Hello from all the guys at Wrox Press. ", 150);
            greetingBuilder.Append("We do hope you enjoy this book as much as we enjoyed writing it");

            for (int i = (int)'z'; i >= (int)'a'; i--)
            {
                char old1 = (char)i;
                char new1 = (char)(i + 1);
                greetingBuilder = greetingBuilder.Replace(old1, new1);
            }

            for (int i = (int)'Z'; i >= (int)'A'; i--)
            {
                char old1 = (char)i;
                char new1 = (char)(i + 1);
                greetingBuilder = greetingBuilder.Replace(old1, new1);
            }

            Console.WriteLine("Encoded:\n" + greetingBuilder);
        }

        public static void StringReplace3()
        {
            string greetingText = "Hello from all the guys at Wrox Press. ";

            greetingText += "We do hope you enjoy this book as much as we enjoyed writing it.";

            for (int i = 'z'; i >= (int)'a'; i--)
            {
                char Old = (char)i;
                char New = (char)(i + 1);
                greetingText = greetingText.Replace(Old, New);
            }

            for (int i = 'Z'; i >= (int)'A'; i--)
            {
                char Old = (char)i;
                char New = (char)(i + 1);
                greetingText = greetingText.Replace(Old, New);
            }
            Console.WriteLine("Encoded:\n" + greetingText);

            StringBuilder greetingBuilder = new StringBuilder("Hello from all the guys at Wrox Press. ", 150);
            greetingBuilder.Append("We do hope you enjoy this book as much as we enjoyed writing it");

            for (int i = (int)'z'; i >= (int)'a'; i--)
            {
                char Old = (char)i;
                char New = (char)(i + 1);
                greetingBuilder = greetingBuilder.Replace(Old, New);
            }

            for (int i = (int)'Z'; i >= (int)'A'; i--)
            {
                char Old = (char)i;
                char New = (char)(i + 1);
                greetingBuilder = greetingBuilder.Replace(Old, New);
            }
            Console.WriteLine("Encoded:\n" + greetingBuilder);
        }

        public static void Find1()
        {
            const string text = @"XML has made a major impact in almost every aspect of
            software development. Designed as an open, extensible, self-describing
            language, it has become the standard for data and document delivery on
            the web. The panoply of XML-related technologies continues to develop
            at breakneck speed, to enable validation, navigation, transformation,
            linking, querying, description, and messaging of data.";
            const string pattern = @"\bn\S*ion\b";
            MatchCollection matches = Regex.Matches(text, pattern, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.ExplicitCapture);
            WriteMatches(text, matches);
        }

        public static void Find2()
        {
            const string text = @"XML has made a major impact in almost every aspect of
            software development. Designed as an open, extensible, self-describing
            language, it has become the standard for data and document delivery on
            the web. The panoply of XML-related technologies continues to develop
            at breakneck speed, to enable validation, navigation, transformation,
            linking, querying, description, and messaging of data.";
            MatchCollection matches = Regex.Matches(text, @"\bn", RegexOptions.IgnoreCase);
            WriteMatches(text, matches);
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
                Console.WriteLine("处理完成。。" + endInvoke);
            }
            else
            {
                Console.WriteLine("处理失败。。" + endInvoke);
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
            PropertyData pd = e.NewEvent.Properties["TargetInstance"];
            if (pd != null)
            {
                ManagementBaseObject mbo = pd.Value as ManagementBaseObject;

                // if CD removed VolumeName == null
                if (mbo.Properties["VolumeName"].Value != null)
                {
                    Console.WriteLine("CD has been inserted");
                }
                else
                {
                    Console.WriteLine("CD has been ejected");
                }
            }
        }

        public static void EnumDemo()
        {
            Type weekdays = typeof(Days);
            Type boiling = typeof(BoilingPoints);
            foreach (string s in Enum.GetNames(weekdays))
            {
                Console.WriteLine("{0,-11}= {1}", s, Enum.Format(weekdays, Enum.Parse(weekdays, s), "d"));
            }
            foreach (string s in Enum.GetNames(boiling))
            {
                Console.WriteLine("{0,-11}= {1}", s, Enum.Format(boiling, Enum.Parse(boiling, s), "d"));
            }
            Colors myColors = Colors.Red | Colors.Blue | Colors.Yellow;
            Console.WriteLine("myColors holds a combination of colors. Namely: {0}", myColors);
        }

        public static void StackTraceDemo1()
        {
            string className = MethodBase.GetCurrentMethod().ReflectedType.Name;
            StackTrace trace = new StackTrace();
            MethodBase methodName = trace.GetFrame(1).GetMethod();
            Console.WriteLine(className + "  " + methodName.Name);
        }

        public static string StackTraceDemo2(string author, string sqlDesc)
        {
            StackFrame stackFrame = new StackTrace(true).GetFrame(1);
            int fileColumnNumber = stackFrame.GetFileColumnNumber();
            int fileLineNumber = stackFrame.GetFileLineNumber();
            string fileName = stackFrame.GetFileName();
            int ilOffset = stackFrame.GetILOffset();
            MethodBase mb = stackFrame.GetMethod();
            int no = stackFrame.GetNativeOffset();
            return string.Format("/*Author:{0}/For:{1}/File:///{2}/Fun:{3}*/", author, sqlDesc, stackFrame.GetFileName(), stackFrame.GetMethod().Name);
        }

        public static void StackTraceDemo3()
        {
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            Trace.AutoFlush = true;
            Trace.Indent();
            Trace.WriteLine("Entering Main");
            Console.WriteLine("Hello World.");
            Trace.WriteLine("Exiting Main");
            Trace.Unindent();
            Trace.Assert(123 > 100);
        }

        public static void CollectionDemo()
        {
            // Create and initialize a new CollectionBase.

            Int16Collection myI16 = new Int16Collection();

            // Add elements to the collection.
            myI16.Add((Int16)1);
            myI16.Add((Int16)2);
            myI16.Add((Int16)3);
            myI16.Add((Int16)5);
            myI16.Add((Int16)7);

            // Display the contents of the collection using foreach. This is the preferred method.
            Console.WriteLine("Contents of the collection (using foreach):");
            PrintValues1(myI16);

            // Display the contents of the collection using the enumerator.
            Console.WriteLine("Contents of the collection (using enumerator):");
            PrintValues2(myI16);

            // Display the contents of the collection using the Count property and the Item property.
            Console.WriteLine("Initial contents of the collection (using Count and Item):");
            PrintIndexAndValues(myI16);

            // Search the collection with Contains and IndexOf.
            Console.WriteLine("Contains 3: {0}", myI16.Contains(3));
            Console.WriteLine("2 is at index {0}.", myI16.IndexOf(2));
            Console.WriteLine();

            // Insert an element into the collection at index 3.
            myI16.Insert(3, (Int16)13);
            Console.WriteLine("Contents of the collection after inserting at index 3:");
            PrintIndexAndValues(myI16);

            // Get and set an element using the index.
            myI16[4] = 123;
            Console.WriteLine("Contents of the collection after setting the element at index 4 to 123:");
            PrintIndexAndValues(myI16);

            // Remove an element from the collection.
            myI16.Remove((Int16)2);

            // Display the contents of the collection using the Count property and the Item property.
            Console.WriteLine("Contents of the collection after removing the element 2:");
            PrintIndexAndValues(myI16);
        }

        // Uses the Count property and the Item property.
        public static void PrintIndexAndValues(Int16Collection myCol)
        {
            for (int i = 0; i < myCol.Count; i++)
                Console.WriteLine("   [{0}]:   {1}", i, myCol[i]);
            Console.WriteLine();
        }

        // Uses the foreach statement which hides the complexity of the enumerator.
        // NOTE: The foreach statement is the preferred way of enumerating the contents of a collection.
        public static void PrintValues1(Int16Collection myCol)
        {
            foreach (Int16 i16 in myCol)
                Console.WriteLine("   {0}", i16);
            Console.WriteLine();
        }

        // Uses the enumerator.
        // NOTE: The foreach statement is the preferred way of enumerating the contents of a collection.
        public static void PrintValues2(Int16Collection myCol)
        {
            System.Collections.IEnumerator myEnumerator = myCol.GetEnumerator();
            while (myEnumerator.MoveNext())
            {
                Console.WriteLine("   {0}", myEnumerator.Current);
            }
            Console.WriteLine();
        }

        public static void DataTypeDemo0()
        {
            SByte sby = -123;
            sbyte xby = 123;
            Console.WriteLine(sbyte.MinValue + "\t\t\t\t" + sbyte.MaxValue);
            Console.WriteLine(sizeof(sbyte));
            Console.WriteLine(sby);
            Console.WriteLine(xby);
            Byte db = 123;
            byte xb = 123;
            Console.WriteLine(db);
            Console.WriteLine(xb);

            Console.WriteLine(byte.MinValue + "\t\t\t\t" + byte.MaxValue);
            Console.WriteLine(sizeof(byte));

            Int16 i16_1 = 123;
            short i16_2 = 123;
            Console.WriteLine(Int16.MinValue + "\t\t\t\t" + Int16.MaxValue);
            Console.WriteLine(sizeof(Int16));
            Console.WriteLine(i16_1);
            Console.WriteLine(i16_2);

            UInt16 uint16 = 123;
            ushort ui16 = 123;
            Console.WriteLine(UInt16.MinValue + "\t\t\t\t" + UInt16.MaxValue);
            Console.WriteLine(sizeof(UInt16));
            Console.WriteLine(uint16);
            Console.WriteLine(ui16);

            Int32 i32 = 123;
            int i321 = 123;
            Console.WriteLine(Int32.MinValue + "\t\t\t\t" + Int32.MaxValue);
            Console.WriteLine(sizeof(Int32));
            Console.WriteLine(i32);
            Console.WriteLine(i321);

            uint uintx32 = 123;
            UInt32 uint32 = 123;
            Console.WriteLine(UInt32.MinValue + "\t\t\t\t" + UInt32.MaxValue);
            Console.WriteLine(sizeof(UInt32));
            Console.WriteLine(uintx32);
            Console.WriteLine(uint32);

            Int64 i64 = 123;
            long i641 = 123;
            Console.WriteLine(Int64.MinValue + "\t\t\t\t" + Int64.MaxValue);
            Console.WriteLine(sizeof(Int64));
            Console.WriteLine(i64);
            Console.WriteLine(i641);

            UInt64 uint64 = 123;
            ulong ulong64 = 123;
            Console.WriteLine(uint64);
            Console.WriteLine(ulong64);

            Console.WriteLine(UInt64.MinValue + "\t\t\t\t" + UInt64.MaxValue);

            string xs = "string";
            String ds = "String";

            Char dc = 'A';
            char cc = 'A';

            float fl = 123.123F;
            decimal du = 123.123M;
            Console.WriteLine(xs);
            Console.WriteLine(ds);
            Console.WriteLine(dc);
            Console.WriteLine(cc);
            Console.WriteLine(fl);
            Console.WriteLine(du);
        }

        public static void DataTypeDemo1()
        {
            List<DataType> DataTypeList = new List<DataType>();
            DataTypeList.Add(new DataType { TypeName = "sbyte", ByteCount = sizeof(sbyte), Min = sbyte.MinValue, Max = sbyte.MaxValue, Type = typeof(sbyte) });
            DataTypeList.Add(new DataType { TypeName = "SByte", ByteCount = sizeof(SByte), Min = SByte.MinValue, Max = SByte.MaxValue, Type = typeof(SByte) });

            DataTypeList.Add(new DataType { TypeName = "byte", ByteCount = sizeof(byte), Min = byte.MinValue, Max = byte.MaxValue, Type = typeof(byte) });
            DataTypeList.Add(new DataType { TypeName = "Byte", ByteCount = sizeof(Byte), Min = Byte.MinValue, Max = Byte.MaxValue, Type = typeof(Byte) });

            DataTypeList.Add(new DataType { TypeName = "char", ByteCount = sizeof(char), Min = char.MinValue, Max = char.MaxValue, Type = typeof(char) });
            DataTypeList.Add(new DataType { TypeName = "Char", ByteCount = sizeof(Char), Min = char.MinValue, Max = Char.MaxValue, Type = typeof(Char) });

            DataTypeList.Add(new DataType { TypeName = "short", ByteCount = sizeof(short), Min = short.MinValue, Max = short.MaxValue, Type = typeof(short) });
            DataTypeList.Add(new DataType { TypeName = "ushort", ByteCount = sizeof(ushort), Min = ushort.MinValue, Max = ushort.MaxValue, Type = typeof(ushort) });
            DataTypeList.Add(new DataType { TypeName = "Int16", ByteCount = sizeof(Int16), Min = Int16.MinValue, Max = Int16.MaxValue, Type = typeof(Int16) });
            DataTypeList.Add(new DataType { TypeName = "UInt16", ByteCount = sizeof(UInt16), Min = UInt16.MinValue, Max = UInt16.MaxValue, Type = typeof(UInt16) });

            DataTypeList.Add(new DataType { TypeName = "int", ByteCount = sizeof(int), Min = int.MinValue, Max = int.MaxValue, Type = typeof(int) });
            DataTypeList.Add(new DataType { TypeName = "uint", ByteCount = sizeof(uint), Min = uint.MinValue, Max = uint.MaxValue, Type = typeof(uint) });
            DataTypeList.Add(new DataType { TypeName = "Int32", ByteCount = sizeof(Int32), Min = Int32.MinValue, Max = Int32.MaxValue, Type = typeof(Int32) });
            DataTypeList.Add(new DataType { TypeName = "UInt32", ByteCount = sizeof(UInt32), Min = UInt32.MinValue, Max = UInt32.MaxValue, Type = typeof(UInt32) });

            DataTypeList.Add(new DataType { TypeName = "long", ByteCount = sizeof(long), Min = long.MinValue, Max = long.MaxValue, Type = typeof(long) });
            DataTypeList.Add(new DataType { TypeName = "ulong", ByteCount = sizeof(ulong), Min = ulong.MinValue, Max = ulong.MaxValue, Type = typeof(ulong) });
            DataTypeList.Add(new DataType { TypeName = "Int64", ByteCount = sizeof(Int64), Min = Int64.MinValue, Max = Int64.MaxValue, Type = typeof(Int64) });
            DataTypeList.Add(new DataType { TypeName = "UInt64", ByteCount = sizeof(UInt64), Min = UInt64.MinValue, Max = UInt64.MaxValue, Type = typeof(UInt64) });

            DataTypeList.Add(new DataType { TypeName = "float", ByteCount = sizeof(float), Min = float.MinValue, Max = float.MaxValue, Type = typeof(float) });
            DataTypeList.Add(new DataType { TypeName = "double", ByteCount = sizeof(double), Min = double.MinValue, Max = double.MaxValue, Type = typeof(double) });
            DataTypeList.Add(new DataType { TypeName = "decimal", ByteCount = sizeof(decimal), Min = double.MinValue, Max = double.MaxValue, Type = typeof(decimal) });

            foreach (DataType item in DataTypeList)
            {
                item.TypeFullName = item.Type.FullName;
            }
            StringBuilder strBuilder = new StringBuilder();

            strBuilder.Append("<table>");
            foreach (DataType item in DataTypeList)
            {
                strBuilder.Append("<tr>");
                strBuilder.Append($"<td>{item.TypeName}</td>");
                strBuilder.Append($"<td>{item.TypeFullName}</td>");
                strBuilder.Append($"<td>{item.ByteCount}</td>");
                strBuilder.Append($"<td>{item.Min}</td>");
                strBuilder.Append($"<td>{item.Max}</td>");
                strBuilder.Append("</tr>");
            }
            strBuilder.Append("</table>");
        }

        public static void GetDriveInfo()
        {
            System.IO.DriveInfo[] drives = System.IO.DriveInfo.GetDrives();
            foreach (System.IO.DriveInfo drive in drives)
            {
                long totalSize = drive.TotalSize / (1024 * 1024 * 1024);
                Console.WriteLine($"{drive.Name} {totalSize}G {drive.DriveFormat} {drive.DriveType} {drive.IsReady} {drive.RootDirectory} {drive.VolumeLabel}");
            }
        }

        #region 泛型委托实现

        public delegate T PropertyGetter<T>();

        public delegate void PropertySetter<T>(T value);

        public static PropertyGetter<int> PropGet;

        public static PropertySetter<int> PropSet;

        public static void BuildSetMethod(EmitData td)
        {
            Type t = td.GetType();
            PropertyInfo pi = t.GetProperty("Name");
            MethodInfo setter = pi.GetSetMethod();

            PropSet = (PropertySetter<int>)Delegate.CreateDelegate(typeof(PropertySetter<int>), td, setter);

            //string value = strPropGetter();
        }

        public static void BuildGetMethod(EmitData td)
        {
            Type t = td.GetType();
            PropertyInfo pi = t.GetProperty("Name");
            MethodInfo getter = pi.GetGetMethod();

            PropGet = (PropertyGetter<int>)Delegate.CreateDelegate(typeof(PropertyGetter<int>), td, getter);

            //string value = strPropGetter();
        }

        #endregion 泛型委托实现

        #region 表达式树实现

        private static Func<object, int> _lmdGetProp; //Func<EmitData, int>

        public static void LmdGet(Type entityType, string propName)
        {
            #region 通过方法取值

            var p = entityType.GetProperty(propName);
            //对象实例
            var param_obj = Expression.Parameter(typeof(object), "obj");
            //值
            //var param_val = Expression.Parameter(typeof(object), "val");
            //转换参数为真实类型
            var body_obj = Expression.Convert(param_obj, entityType);

            //调用获取属性的方法
            var body = Expression.Call(body_obj, p.GetGetMethod());
            _lmdGetProp = Expression.Lambda<Func<object, int>>(body, param_obj).Compile();

            #endregion 通过方法取值

            #region 表达式取值

            //var p = entityType.GetProperty(propName);
            ////lambda的参数u
            //var param_u = Expression.Parameter(entityType, "u");
            ////lambda的方法体 u.Age
            //var pGetter = Expression.Property(param_u, p);
            ////编译lambda
            //LmdGetProp = Expression.Lambda<Func<EmitData, int>>(pGetter, param_u).Compile();

            #endregion 表达式取值
        }

        private static Action<object, object> _lmdSetProp;

        public static void LmdSet(Type entityType, string propName)
        {
            var p = entityType.GetProperty(propName);
            //对象实例
            var param_obj = Expression.Parameter(typeof(object), "obj");
            //值
            var param_val = Expression.Parameter(typeof(object), "val");
            //转换参数为真实类型
            var body_obj = Expression.Convert(param_obj, entityType);
            var body_val = Expression.Convert(param_val, p.PropertyType);
            //调用给属性赋值的方法
            var body = Expression.Call(body_obj, p.GetSetMethod(), body_val);
            _lmdSetProp = Expression.Lambda<Action<object, object>>(body, param_obj, param_val).Compile();
        }

        #endregion 表达式树实现

        #region Emit动态方法实现

        public delegate void SetValueDelegateHandler(EmitData entity, object value);

        public static SetValueDelegateHandler EmitSetValue;

        public Program(int mNData)
        {
            MnData = mNData;
        }

        public static void BuildEmitMethod(Type entityType, string propertyName)
        {
            //Type entityType = entity.GetType();
            Type parmType = typeof(object);
            // 指定函数名
            string methodName = "set_" + propertyName;
            // 搜索函数，不区分大小写 IgnoreCase
            var callMethod = entityType.GetMethod(methodName, BindingFlags.Instance | BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.NonPublic);
            // 获取参数
            var para = callMethod.GetParameters()[0];
            // 创建动态函数
            DynamicMethod method = new DynamicMethod("EmitCallable", null, new Type[] { entityType, parmType }, entityType.Module);
            // 获取动态函数的 IL 生成器
            var il = method.GetILGenerator();
            // 创建一个本地变量，主要用于 Object Type to Propety Type
            var local = il.DeclareLocal(para.ParameterType, true);
            // 加载第 2 个参数【(T owner, object value)】的 value
            il.Emit(OpCodes.Ldarg_1);
            if (para.ParameterType.IsValueType)
            {
                il.Emit(OpCodes.Unbox_Any, para.ParameterType);// 如果是值类型，拆箱 string = (string)object;
            }
            else
            {
                il.Emit(OpCodes.Castclass, para.ParameterType);// 如果是引用类型，转换 Class = object as Class
            }
            il.Emit(OpCodes.Stloc, local);// 将上面的拆箱或转换，赋值到本地变量，现在这个本地变量是一个与目标函数相同数据类型的字段了。
            il.Emit(OpCodes.Ldarg_0); // 加载第一个参数 owner
            il.Emit(OpCodes.Ldloc, local);// 加载本地参数
            il.EmitCall(OpCodes.Callvirt, callMethod, null);//调用函数
            il.Emit(OpCodes.Ret); // 返回
                                  /* 生成的动态函数类似：
                                  * void EmitCallable(T owner, object value)
                                  * {
                                  * T local = (T)value;
                                  * owner.Method(local);
                                  * }
                                  */

            EmitSetValue = method.CreateDelegate(typeof(SetValueDelegateHandler)) as SetValueDelegateHandler;
        }

        public static void EmitDemo()
        {
            Console.Write("当前framework版本：" + Environment.Version.Major + "<br/>");
            int max = 1000000;
            Console.Write("循环次数：" + max + "<br/>");

            //基本方法
            DateTime time = DateTime.Now;
            EmitData d = new EmitData();
            for (int i = 0; i < max; i++)
            {
                d.Name = i;
            }
            TimeSpan ts = DateTime.Now - time;
            Console.Write("基本方法:" + ts.TotalMilliseconds + "<br/>");

            //反射方法
            Type type = d.GetType();
            PropertyInfo pi = type.GetProperty("Name");
            time = DateTime.Now;
            for (int i = 0; i < max; i++)
            {
                pi.SetValue(d, i, null);
            }
            ts = DateTime.Now - time;
            Console.Write("反射方法:" + ts.TotalMilliseconds + "<br/>");

            //dynamic动态类型方法
            dynamic dobj = Activator.CreateInstance<EmitData>();
            time = DateTime.Now;
            for (int i = 0; i < max; i++)
            {
                dobj.Name = i;
            }
            ts = DateTime.Now - time;
            Console.Write("dynamic动态类型方法:" + ts.TotalMilliseconds + "<br/>");

            //泛型委托赋值方法
            d.Name = -1;
            BuildSetMethod(d);
            time = DateTime.Now;
            for (int i = 0; i < max; i++)
            {
                PropSet(i);
            }
            ts = DateTime.Now - time;
            Console.Write("泛型委托赋值方法:" + ts.TotalMilliseconds + "<br/>");
            Console.Write("v:" + d.Name + "<br/>");

            //泛型委托取值方法
            d.Name = -1;
            BuildGetMethod(d);
            time = DateTime.Now;
            for (int i = 0; i < max; i++)
            {
                PropGet();
            }
            ts = DateTime.Now - time;
            Console.Write("泛型委托取值方法:" + ts.TotalMilliseconds + "<br/>");
            Console.Write("v:" + d.Name + "<br/>");

            //表达式树赋值方法
            d.Name = -1;
            LmdSet(typeof(EmitData), "Name");
            time = DateTime.Now;
            for (int i = 0; i < max; i++)
            {
                _lmdSetProp(d, i);
            }
            ts = DateTime.Now - time;
            Console.Write("表达式树赋值方法:" + ts.TotalMilliseconds + "<br/>");
            Console.Write("v:" + d.Name + "<br/>");

            //表达式树取值方法
            d.Name = -132;
            LmdGet(typeof(EmitData), "Name");
            time = DateTime.Now;
            for (int i = 0; i < max; i++)
            {
                _lmdGetProp(d);
            }
            ts = DateTime.Now - time;
            Console.Write("表达式树取值方法:" + ts.TotalMilliseconds + "<br/>");
            Console.Write("v:" + _lmdGetProp(d) + "<br/>");

            //EMIT动态方法赋值
            d.Name = -1;
            BuildEmitMethod(d.GetType(), "Name");
            time = DateTime.Now;
            for (int i = 0; i < max; i++)
            {
                EmitSetValue(d, i);
            }
            ts = DateTime.Now - time;
            Console.Write("EMIT动态方法:" + ts.TotalMilliseconds + "<br/>");
            Console.Write("v:" + d.Name + "<br/>");
        }

        #endregion Emit动态方法实现

        public static void Md5Demo()
        {
            string source = "Hello World!";

            using (MD5 md5Hash = MD5.Create())
            {
                string hashPwd = GetMd5Hash(md5Hash, source);

                Console.WriteLine("The MD5 hash of " + source + " is: " + hashPwd + ".");

                Console.WriteLine("Verifying the hash...");

                if (VerifyMd5Hash(md5Hash, source, hashPwd))
                {
                    Console.WriteLine("The hashes are the same.");
                }
                else
                {
                    Console.WriteLine("The hashes are not same.");
                }
            }
        }

        private static string GetMd5Hash(MD5 md5Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        private static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
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

        private static void PerformanceDemo()
        {
            Console.Title = ("Simple CPU Monitor");
            Console.ForegroundColor = ConsoleColor.Green;
            PerformanceCounter perfCounter = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");

            while (true)
            {
                Thread.Sleep(1000);
                Console.Beep();
                Console.WriteLine("CPU Load: {0}%", perfCounter.NextValue());
            }
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