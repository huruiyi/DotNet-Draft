using ConApp.EnumModel;
using ConApp.Model;
using Microsoft.VisualBasic.FileIO;
using Microsoft.Win32;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Management;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Net;
using System.Net.Security;
using System.Reflection;
using System.Reflection.Emit;
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
    public class PSParam
    {
        public string Key { get; set; }

        public object Value { get; set; }
    }

    internal class Info
    {
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }
    }

    public struct XYZ
    {
        public int a;
        public int b;
        public int c;
    }

    internal class Player
    {
        public void Play()
        {
            //判断文件的类型 来找不同的解码器
            Console.WriteLine("播放文件");
        }
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

    internal class Program
    {
        private static void Main(string[] args)
        {
            FileSystem.MoveFile(args[0], args[1]);

            //Console.ReadLine();
            Console.ReadKey();
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

        private static void RunPSDemo1()
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

        private static void RunPSDemo2()
        {
            List<string> ps = new List<string>();
            ps.Add("Set-ExecutionPolicy RemoteSigned");//先执行启动安全策略，，使系统可以执行powershell脚本文件

            string path = Environment.CurrentDirectory;
            string pspath = System.IO.Path.Combine(path, "ps.ps1");

            ps.Add(pspath);//执行脚本文件

            Info psobj = new Info();
            psobj.x = 20;
            psobj.y = 10;

            PSParam par = new PSParam();
            par.Key = "arg";
            par.Value = psobj;

            RunScript(ps, new List<PSParam>() { par });

            Console.WriteLine(psobj.x + " + " + psobj.y + " = " + psobj.z);
        }

        public static void InvokeSystemPS(string cmd)
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

        public static void InvokeVMMPS()
        {
            RunspaceConfiguration rconfig = RunspaceConfiguration.Create();
            PSSnapInException Pwarn = new PSSnapInException();

            Runspace runspace = RunspaceFactory.CreateRunspace();
            string test = "Import-Module VirtualMachineManager\r\n";
            runspace = RunspaceFactory.CreateRunspace(rconfig); runspace.Open();
            Pipeline pipeline = runspace.CreatePipeline();
            pipeline.Commands.AddScript(test);
            try
            {
                var results = pipeline.Invoke();

                using (Pipeline pipe = runspace.CreatePipeline())
                {
                    //Get-VM -Name vm001
                    Command cmd = new Command("Get-VM");
                    cmd.Parameters.Add("Name", "vm001");
                    pipe.Commands.Add(cmd);
                    var result = pipe.Invoke();
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

        public static string RunScript(List<string> scripts, List<PSParam> pars)
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
        public static int m_sZ = 100;

        //普通数据成员，也是放在堆上了，查看指针时需用fixed固定
        public int m_nData = 100;

        //等价于C/C++的 #define 语句，不分配内存
        public const int PI = 31415;

        public static void RedisDemo()
        {
            var client = new RedisClient("127.0.0.1", 6379);

            #region get/set

            client.Set<string>("name", "huruiyi");
            Console.WriteLine(client.Get<string>("name"));

            //  client.Append("",);

            //client.Set("question", "What's your name");
            //string name = Encoding.UTF8.GetString(client.Get("question"));
            //Console.WriteLine(name);

            #endregion get/set

            #region SetEntryInHash

            //client.SetEntryInHash("id1", "name", "huruiyi");
            //client.SetEntryInHash("id1", "sex", "nan");
            //client.SetEntryInHash("id1", "age", "22");

            //for (int i = 0; i < client.GetHashCount("id1"); i++)
            //{
            //    Console.WriteLine("keys:" + client.GetHashKeys("id1")[i] + "\tvalue:" + client.GetHashValues("id1")[i]);
            //}

            #endregion SetEntryInHash

            #region SetEntry

            //client.SetEntry("name", "huruiyi");
            //string name = client.GetEntry("name");
            //Console.WriteLine(name);

            #endregion SetEntry

            //client.Lists["listid1"].Add("1");
            //client.Lists["listid1"].Add("2");
            //long listid1Count = client.GetListCount("listid1");
            //List<string> listEntry=client.Lists["listid1"].GetAll();
            //foreach (string t in listEntry)
            //{
            //    Console.WriteLine(t);
            //}

            Console.ReadKey();
        }

        public static void StringReplace1()
        {
            string greetingText = "Hello from all the guys at Wrox Press. ";
            greetingText += "We do hope you enjoy this book as much as we enjoyed writing it.";

            for (int i = (int)'z'; i >= (int)'a'; i--)
            {
                char old1 = (char)i;
                char new1 = (char)(i + 1);
                greetingText = greetingText.Replace(old1, new1);
            }

            for (int i = (int)'Z'; i >= (int)'A'; i--)
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

        public static void SqlDemo()
        {
            #region 获取插入WDModule表数据返回的ID

            List<string> listMoudleIdList = new List<string>();
            const string connectionString = "user id=TCLXSWD;password=I47kY7%vIK25@e$;DataBase=TCB2bTouristBasic;server=192.168.0.154,1441;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                const string sql = @"INSERT    INTO dbo.WDModule
                                ( Name, SortType, BasePath, DefaultOrder, GroupId, IfValid,
                                  IfHaveCategory )
                        OUTPUT    INSERTED.id,INSERTED.DefaultOrder
                        VALUES  ( '自助游', 1, '/wd/lines/type2/4_', 130, 100, 1, 0 ),
                                ( '出境游', 1, '/wd/lines/type2/3_', 131, 100, 1, 0 ),
                                ( '国内游', 1, '/wd/lines/type2/2_', 132, 100, 1, 0 ),
                                ( '周边游', 1, '/wd/lines/type2/1_', 133, 100, 1, 0 )
                          ";
                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    listMoudleIdList.Add(sqlDataReader[0].ToString());
                }
            }

            #endregion 获取插入WDModule表数据返回的ID

            #region 获取WdMenu表 --会员的数量及会员Id集合

            List<string> listB2bUserId = new List<string>();
            int b2bUserCount = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sql = @"DECLARE @tempTable TABLE
                                (
                                  rownumber INT IDENTITY(1, 1)
                                                PRIMARY KEY ,
                                  B2bUserId INT
                                )
                            INSERT  INTO @tempTable
                                    SELECT DISTINCT
                                            ( B2bUserId )
                                    FROM    dbo.WDMenu
                            SELECT rownumber ,B2bUserId FROM @tempTable";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    listB2bUserId.Add(dataReader["B2bUserId"].ToString());
                }
                b2bUserCount = listB2bUserId.Count;
            }

            #endregion 获取WdMenu表 --会员的数量及会员Id集合

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = string.Format(@"DECLARE @maxOrderNumber INT
                                            DECLARE @B2bUserId INT
                                            DECLARE @rowNumber INT
                                            SET @rowNumber = 1
                                            WHILE @rowNumber <= {0}
                                                BEGIN
                                                    SELECT  @B2bUserId = B2bUserId
                                                    FROM    @tempTable
                                                    WHERE   rownumber = @rowNumber
                                                    SELECT  @maxOrderNumber = MAX(ordernum)
                                                    FROM    dbo.WDMenu
                                                    WHERE   B2bUserId = @B2bUserId
                                                    INSERT  INTO dbo.WDMenu
                                                            ( B2bUserId, Name, ModuleId, LinkUrl, OrderNum, IfShow )
                                                    VALUES  ( @B2bUserId, N'自助游', 53, N'', @maxOrderNumber + 1, 1 )
                                                   ,        ( @B2bUserId, N'出境游', 54, N'', @maxOrderNumber + 2, 1 )
                                                   ,        ( @B2bUserId, N'国内游', 55, N'', @maxOrderNumber + 3, 1 )
                                                   ,        ( @B2bUserId, N'周边游', 56, N'', @maxOrderNumber + 4, 1 )
                                                    SET @rowNumber = @rowNumber + 1
                                                END", b2bUserCount);

                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
            }
        }

        public static void StopwatchDemo()
        {
            DataTable dt = GetMainTable();

            Stopwatch sw = new Stopwatch();
            int doCount = 0;
            var dataIEnum = dt.AsEnumerable();
            sw.Start();
            for (int i = 0; i < 50000; i++)
            {
                if (dataIEnum.Count() > 0)
                    doCount++;
            }
            sw.Stop();
            Console.WriteLine("Count() 耗費時間：" + sw.ElapsedMilliseconds / 1000d);

            sw.Reset();
            doCount = 0;
            sw.Start();
            for (int i = 0; i < 50000; i++)
            {
                if (dataIEnum.Any())
                    doCount++;
            }
            sw.Stop();
            Console.WriteLine("Any() 耗費時間：" + sw.ElapsedMilliseconds / 1000d);
            List<DataRow> dataList = dataIEnum.ToList();
            sw.Reset();
            doCount = 0;
            sw.Start();
            for (int i = 0; i < 50000; i++)
            {
                if (dataList.Count > 0)
                    doCount++;
            }
            sw.Stop();
            Console.WriteLine("List.Count 耗費時間：" + sw.ElapsedMilliseconds / 1000d);
        }

        public static DataTable GetMainTable()
        {
            DataTable dt = new DataTable();
            DataColumn dataColumn = new DataColumn("Id", typeof(int))
            {
                AutoIncrementSeed = 1,
                AutoIncrementStep = 1,
                AutoIncrement = true
            };
            dt.Columns.AddRange(new[]
            {
                dataColumn,
                new DataColumn("Name", typeof (string)), new DataColumn("Age", typeof (int)),
                new DataColumn("BirthDay", typeof (DateTime))
            });
            for (int i = 0; i < 100; i++)
            {
                dt.Rows.Add(i, "Name" + i, 2 * i, DateTime.Now);
            }
            return dt;
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

        public static void AttributeDemo1()
        {
            //如何以反射确定特性信息
            Type tp = typeof(MyTest);
            MemberInfo info = tp;
            var myAttribute = (MyselfAttribute)Attribute.GetCustomAttribute(info, typeof(MyselfAttribute));
            if (myAttribute != null)
            {
                //嘿嘿，在运行时查看注释内容，是不是很爽
                Console.WriteLine("Name: " + myAttribute.Name);
                Console.WriteLine("Age: " + myAttribute.Age);
                Console.WriteLine("Memo of  is " + myAttribute.Name, myAttribute.Memo);
                myAttribute.ShowName();
            }

            //多点反射
            object obj = Activator.CreateInstance(typeof(MyTest));

            MethodInfo mi = tp.GetMethod("SayHello");
            mi.Invoke(obj, null);
        }

        public static void AttributeDemo2()
        {
            var orderRequest = new OrderRequest
            {
                CommodityAmount = "1050",
                CommodityName = "Name",
                CommodityValue = "Value",
                CommodityWeight = "123",
                HopeArriveTime = "2014-06-10",
                OrderNo = "123456798",
                PayMent = "XX",
                Remark = "dadsad"
            };
            string checkMessage = GetValidateResult(orderRequest);

            if (!string.IsNullOrEmpty(checkMessage))
            {
                Console.WriteLine(checkMessage);
            }
        }

        public static void AttributeDemo3()
        {
            Type tp = typeof(MyTester);
            MemberInfo memberInfo = tp.GetMethod("CannotRun");
            var myAtt = (TestAttribute)Attribute.GetCustomAttribute(memberInfo, typeof(TestAttribute));
            myAtt.RunTest();

            MyTester tester = new MyTester();
            tester.Age = 10;
            Type type = tester.GetType();
            PropertyInfo propertyInfo = type.GetProperty("Age");
            ValidateAgeAttribute validateAgeAttribute = (ValidateAgeAttribute)Attribute.GetCustomAttribute(propertyInfo, typeof(ValidateAgeAttribute));
            Console.WriteLine(validateAgeAttribute.MaxAge);
            validateAgeAttribute.IsRight(tester.Age);
        }

        public static void AttributeDemo4()
        {
            Type type = typeof(MyTester3);
            MemberInfo memberInfo1 = type.GetMethod("Method1");
            bool isDef1 = Attribute.IsDefined(memberInfo1, typeof(ObsoleteAttribute));
            var objObsolete = (ObsoleteAttribute)Attribute.GetCustomAttribute(memberInfo1, typeof(ObsoleteAttribute));
            Console.WriteLine(objObsolete.Message);
            Console.WriteLine(isDef1);

            MemberInfo memberInfo2 = type.GetMethod("Method2");
            bool isDef2 = Attribute.IsDefined(memberInfo2, typeof(ObsoleteAttribute));
            Console.WriteLine(isDef2);
        }

        public static void AttributeDemo5()
        {
            var person = new MyTester4 { Name = "TT", Age = 20 };
            Type type = person.GetType();
            PropertyInfo propertyInfo = type.GetProperty("Age");
            var attr = (ValidateAgeComplexAttribute)Attribute.GetCustomAttribute(propertyInfo, typeof(ValidateAgeComplexAttribute));
            Console.WriteLine("允许的最大年龄：" + attr.MaxAge);
            attr.Validate(person.Age);
            Console.WriteLine(attr.ValidateResult);
        }

        public static void AttributeDemo6()
        {
            Type myType = typeof(MyTester);
            MemberInfo[] myMembers = myType.GetMembers();

            for (int i = 0; i < myMembers.Length; i++)
            {
                object[] myAttributes = myMembers[i].GetCustomAttributes(true);
                if (myAttributes.Length > 0)
                {
                    Console.WriteLine(myMembers[i]);
                    for (int j = 0; j < myAttributes.Length; j++)
                        Console.WriteLine("\t" + myAttributes[j]);
                }
            }
        }

        /// <summary>
        /// 验证实体对象的所有带验证特性的元素  并返回验证结果  如果返回结果为String.Empty 则说明元素符合验证要求
        /// </summary>
        /// <param name="entityObject">实体对象</param>
        /// <returns></returns>
        public static string GetValidateResult(object entityObject)
        {
            if (entityObject == null)
                throw new ArgumentNullException("entityObject");

            Type type = entityObject.GetType();
            PropertyInfo[] properties = type.GetProperties();

            string validateResult = string.Empty;

            foreach (PropertyInfo property in properties)
            {
                //获取验证特性
                object[] validateContent = property.GetCustomAttributes(typeof(ValidateAttribute), true);

                if (validateContent != null)
                {
                    //获取属性的值
                    object value = property.GetValue(entityObject, null);

                    foreach (ValidateAttribute validateAttribute in validateContent)
                    {
                        switch (validateAttribute.ValidateType)
                        {
                            //验证元素是否为空字串
                            case ValidateType.IsEmpty:
                                if (null == value || value.ToString().Length < 1)
                                    validateResult = string.Format("元素 {0} 不能为空", property.Name);
                                break;
                            //验证元素的长度是否小于指定最小长度
                            case ValidateType.MinLength:
                                if (null == value || value.ToString().Length < 1) break;
                                if (value.ToString().Length < validateAttribute.MinLength)
                                    validateResult = string.Format("元素 {0} 的长度不能小于 {1}", property.Name, validateAttribute.MinLength);
                                break;
                            //验证元素的长度是否大于指定最大长度
                            case ValidateType.MaxLength:
                                if (null == value || value.ToString().Length < 1) break;
                                if (value.ToString().Length > validateAttribute.MaxLength)
                                    validateResult = string.Format("元素 {0} 的长度不能大于{1}", property.Name, validateAttribute.MaxLength);
                                break;
                            //验证元素的长度是否符合指定的最大长度和最小长度的范围
                            case ValidateType.MinLength | ValidateType.MaxLength:
                                if (null == value || value.ToString().Length < 1) break;
                                if (value.ToString().Length > validateAttribute.MaxLength || value.ToString().Length < validateAttribute.MinLength)
                                    validateResult = string.Format("元素 {0} 不符合指定的最小长度和最大长度的范围,应该在 {1} 与 {2} 之间", property.Name, validateAttribute.MinLength, validateAttribute.MaxLength);
                                break;
                            //验证元素的值是否为值类型
                            case ValidateType.IsNumber:
                                if (null == value || value.ToString().Length < 1) break;
                                if (!Regex.IsMatch(value.ToString(), @"^\d+$"))
                                    validateResult = string.Format("元素 {0} 的值不是值类型", property.Name);
                                break;
                            //验证元素的值是否为正确的时间格式
                            case ValidateType.IsDateTime:
                                if (null == value || value.ToString().Length < 1) break;
                                if (!Regex.IsMatch(value.ToString(), @"(\d{2,4})[-/]?([0]?[1-9]|[1][12])[-/]?([0][1-9]|[12]\d|[3][01])\s*([01]\d|[2][0-4])?[:]?([012345]?\d)?[:]?([012345]?\d)?"))
                                    validateResult = string.Format("元素 {0} 不是正确的时间格式", property.Name);
                                break;
                            //验证元素的值是否为正确的浮点格式
                            case ValidateType.IsDecimal:
                                if (null == value || value.ToString().Length < 1) break;
                                if (!Regex.IsMatch(value.ToString(), @"^\d+[.]?\d+$"))
                                    validateResult = string.Format("元素 {0} 不是正确的金额格式", property.Name);
                                break;
                            //验证元素的值是否在指定的数据源中
                            case ValidateType.IsInCustomArray:
                                if (null == value || value.ToString().Length < 1) break;
                                if (null == validateAttribute.CustomArray || validateAttribute.CustomArray.Length < 1)
                                    validateResult = string.Format("系统内部错误：元素 {0} 指定的数据源为空或没有数据", property.Name);

                                bool isHas = Array.Exists<string>(validateAttribute.CustomArray, delegate (string str)
                                {
                                    return str == value.ToString();
                                }
                                );

                                if (!isHas)
                                    validateResult = string.Format("元素 {0} 的值设定不正确 , 应该为 {1} 中的一种", property.Name, string.Join(",", validateAttribute.CustomArray));
                                break;
                            //验证元素的值是否为固定电话号码格式
                            case ValidateType.IsTelphone:
                                if (null == value || value.ToString().Length < 1) break;
                                if (!Regex.IsMatch(value.ToString(), @"^(\d{3,4}-)?\d{6,8}$"))
                                    validateResult = string.Format("元素 {0} 不是正确的固定电话号码格式", property.Name);
                                break;
                            //验证元素的值是否为手机号码格式
                            case ValidateType.IsMobile:
                                if (null == value || value.ToString().Length < 1) break;
                                if (!Regex.IsMatch(value.ToString(), @"^[1]+[3,5]+\d{9}$"))
                                    validateResult = string.Format("元素 {0} 不是正确的手机号码格式", property.Name);
                                break;
                            //验证元素是否为空且符合指定的最小长度
                            case ValidateType.IsEmpty | ValidateType.MinLength:
                                if (null == value || value.ToString().Length < 1) goto case ValidateType.IsEmpty;
                                goto case ValidateType.MinLength;
                            //验证元素是否为空且符合指定的最大长度
                            case ValidateType.IsEmpty | ValidateType.MaxLength:
                                if (null == value || value.ToString().Length < 1)
                                    goto case ValidateType.IsEmpty;
                                goto case ValidateType.MaxLength;
                            //验证元素是否为空且符合指定的长度范围
                            case ValidateType.IsEmpty | ValidateType.MinLength | ValidateType.MaxLength:
                                if (null == value || value.ToString().Length < 1)
                                    goto case ValidateType.IsEmpty;
                                goto case ValidateType.MinLength | ValidateType.MaxLength;
                            //验证元素是否为空且值为数值型
                            case ValidateType.IsEmpty | ValidateType.IsNumber:
                                if (null == value || value.ToString().Length < 1)
                                    goto case ValidateType.IsEmpty;
                                goto case ValidateType.IsNumber;
                            //验证元素是否为空且值为浮点型
                            case ValidateType.IsEmpty | ValidateType.IsDecimal:
                                if (null == value || value.ToString().Length < 1)
                                    goto case ValidateType.IsEmpty;
                                goto case ValidateType.IsDecimal;
                            //验证元素是否为空且值为时间类型
                            case ValidateType.IsEmpty | ValidateType.IsDateTime:
                                if (null == value || value.ToString().Length < 1)
                                    goto case ValidateType.IsEmpty;
                                goto case ValidateType.IsDateTime;
                            //验证元素是否为空且值在指定的数据源中
                            case ValidateType.IsEmpty | ValidateType.IsInCustomArray:
                                if (null == value || value.ToString().Length < 1) goto case ValidateType.IsEmpty;
                                goto case ValidateType.IsInCustomArray;
                            //验证元素是否为空且值为固定电话号码格式
                            case ValidateType.IsEmpty | ValidateType.IsTelphone:
                                if (null == value || value.ToString().Length < 1) goto case ValidateType.IsEmpty;
                                goto case ValidateType.IsTelphone;
                            //验证元素是否为空且值为手机号码格式
                            case ValidateType.IsEmpty | ValidateType.IsMobile:
                                if (null == value || value.ToString().Length < 1) goto case ValidateType.IsEmpty;
                                goto case ValidateType.IsMobile;
                        }
                    }
                }

                if (!string.IsNullOrEmpty(validateResult))
                    break;
            }

            return validateResult;
        }

        public static void CDROMManagement()
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
            watcher.EventArrived += new EventArrivedEventHandler(CDREventArrived);
            watcher.Start();
            // Do something usefull,block thread for testing
            Console.ReadLine();
            watcher.Stop();
        }

        // Dump all properties
        public static void CDREventArrived(object sender, EventArrivedEventArgs e)
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

        public static List<MyTester5> GetList(bool isTrue)
        {
            if (isTrue)
            {
                List<MyTester5> list = new List<MyTester5>();
                MyTester5 t = new MyTester5();
                list.Add(t);
                return list;
            }
            else
            {
                return null;
            }
        }

        public static void TypeDemo()
        {
            List<MyTester5> list = GetList(true);
            if (list != null && list.Any())
            {
                Type listType = list.GetType();

                Console.WriteLine(listType.Name);
                Console.WriteLine(typeof(List<>).Name);
                Console.WriteLine("Hello");
            }
            else
            {
                Console.WriteLine("fuck");
            }
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

        private static Func<object, int> LmdGetProp; //Func<EmitData, int>

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
            LmdGetProp = Expression.Lambda<Func<object, int>>(body, param_obj).Compile();

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

        private static Action<object, object> LmdSetProp;

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
            LmdSetProp = Expression.Lambda<Action<object, object>>(body, param_obj, param_val).Compile();
        }

        #endregion 表达式树实现

        #region Emit动态方法实现

        public delegate void SetValueDelegateHandler(EmitData entity, object value);

        public static SetValueDelegateHandler EmitSetValue;

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
                LmdSetProp(d, i);
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
                LmdGetProp(d);
            }
            ts = DateTime.Now - time;
            Console.Write("表达式树取值方法:" + ts.TotalMilliseconds + "<br/>");
            Console.Write("v:" + LmdGetProp(d) + "<br/>");

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

      

       
    }
}