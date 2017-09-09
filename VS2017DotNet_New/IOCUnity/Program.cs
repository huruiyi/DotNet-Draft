using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Configuration;

namespace IOCUnity
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IUnityContainer mycontainer = new UnityContainer();

            //已有对象实例的配置容器注册
            // MysqlHelper d = new MysqlHelper();
            //mycontainer.RegisterInstance<ISqlHelper>(d);

            //类型的配置容器注册
            //mycontainer.RegisterType<ISqlHelper, MysqlHelper>();

            //配置文件注册
            UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            section.Configure(mycontainer);
            //mycontainer.LoadConfiguration();

            //调用依赖
            ISqlHelper mysql = mycontainer.Resolve<ISqlHelper>();
            Console.WriteLine(mysql.SqlConnection());

            //构造函数注入
            mycontainer.RegisterType<IOtherHelper, MyOtherHelper>();
            IOtherHelper other = mycontainer.Resolve<IOtherHelper>();
            Console.WriteLine(other.GetSqlConnection());

            Console.ReadKey();
        }
    }
}