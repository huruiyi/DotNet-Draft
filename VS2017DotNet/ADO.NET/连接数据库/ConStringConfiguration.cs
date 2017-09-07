using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 连接数据库
{
    class ConStringConfiguration
    {
        public static string ConString3 = "server=.;database=ExampleDb;uid=sa;Pwd=sa";
        public static string ConString4 = "Data Source=.;Initial Catalog=ExampleDb;InteGrated Security=true";
        public static string GetConstring1()
        {
            SqlConnectionStringBuilder s = new SqlConnectionStringBuilder();
            s.DataSource = ".";
            s.InitialCatalog = "ExampleDb";
            s.IntegratedSecurity = true;
            string ConString1 = s.ConnectionString;
            return ConString1;
        }
        public static string GetConstring2()
        {
            SqlConnectionStringBuilder s = new SqlConnectionStringBuilder();
            s.DataSource = ".";
            s.InitialCatalog = "ExampleDb";
            s.UserID = "sa";
            s.Password = "sa";
            string ConString2 = s.ConnectionString;
            return ConString2;
        }

        public static string GetConstring3()
        {
            return ConfigurationManager.AppSettings["ConString5"];
        }

        public static string GetConstring4()
        {
            return ConfigurationManager.ConnectionStrings["ConString6"].ToString();
        }
        public static string GetConstring5()
        {
            return Properties.Settings.Default.ConString7;
        }
    }
}
