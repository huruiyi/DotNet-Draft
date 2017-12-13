using Microsoft.Practices.Unity.Configuration;
using System;
using System.Configuration;
using Unity;

namespace ConApp
{
    public interface IOtherHelper
    {
        string GetSqlConnection();
    }

    public class MyOtherHelper : IOtherHelper
    {
        private readonly ISqlHelper sql;

        public MyOtherHelper(ISqlHelper sql)
        {
            this.sql = sql;
        }

        public string GetSqlConnection()
        {
            return this.sql.SqlConnection();
        }
    }

    public interface ISqlHelper
    {
        string SqlConnection();
    }

    public class MssqlHelper : ISqlHelper
    {
        public string SqlConnection()
        {
            return "this mssql.";
        }
    }

    public class MysqlHelper : ISqlHelper
    {
        public string SqlConnection()
        {
            return "this mysql.";
        }
    }

    public class IOCUnity
    {
        public static void Demo1()
        {
            IUnityContainer mycontainer = new UnityContainer();

            //mysql
            mycontainer.RegisterType<ISqlHelper, MysqlHelper>();
            ISqlHelper mysql = mycontainer.Resolve<ISqlHelper>();
            Console.WriteLine(mysql.SqlConnection());

            //mssql
            mycontainer.RegisterType<ISqlHelper, MssqlHelper>();
            ISqlHelper mssql = mycontainer.Resolve<ISqlHelper>();
            Console.WriteLine(mssql.SqlConnection());
        }

        public static void Demo2()
        {
            IUnityContainer mycontainer = new UnityContainer();

            //mysql
            mycontainer.RegisterType<ISqlHelper, MysqlHelper>();
            mycontainer.RegisterType<IOtherHelper, MyOtherHelper>();
            IOtherHelper mysql = mycontainer.Resolve<IOtherHelper>();
            Console.WriteLine(mysql.GetSqlConnection());

            //mssql
            mycontainer.RegisterType<ISqlHelper, MssqlHelper>();
            mycontainer.RegisterType<IOtherHelper, MyOtherHelper>();
            IOtherHelper mssql = mycontainer.Resolve<IOtherHelper>();
            Console.WriteLine(mssql.GetSqlConnection());
        }

        public static void Demo3()
        {
            IUnityContainer mycontainer = new UnityContainer();

            //mysql
            mycontainer.RegisterInstance<ISqlHelper>(new MysqlHelper());
            mycontainer.RegisterType<IOtherHelper, MyOtherHelper>();
            IOtherHelper mysql = mycontainer.Resolve<IOtherHelper>();
            Console.WriteLine(mysql.GetSqlConnection());

            //mssql
            mycontainer.RegisterInstance<ISqlHelper>(new MssqlHelper());
            mycontainer.RegisterType<IOtherHelper, MyOtherHelper>();
            IOtherHelper mssql = mycontainer.Resolve<IOtherHelper>();
            Console.WriteLine(mssql.GetSqlConnection());
        }

        public static void Demo4()
        {
            #region 配置文件注册-未完待续

            IUnityContainer mycontainer = new UnityContainer();
            //配置文件注册
            UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            section.Configure(mycontainer);
            mycontainer.LoadConfiguration();

            #endregion 配置文件注册-未完待续
        }
    }
}