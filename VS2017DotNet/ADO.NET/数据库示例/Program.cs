using System;
using System.Data;
using System.Data.SqlClient;

namespace 数据库示例
{
    internal class Program
    {
        private const string ConnectionString = @"server=.;Initial Catalog=ExampleDb;uid=sa;pwd=sa";

        private static void Main(string[] args)
        {
            ExecuteNonQueryDemo2();

            Console.ReadKey();
        }

        public static void ExecuteScalarDemo1()
        {
            Console.WriteLine("请输入用户名：");
            string UserName = Console.ReadLine();
            Console.WriteLine("请输入密码：");
            string PassWord = Console.ReadLine();
            using (SqlConnection con3 = new SqlConnection(ConnectionString))
            {
                string sql = "select count(*) from Admin where UserName=@UserName and Password=@Password";
                using (SqlCommand cmd = new SqlCommand(sql, con3))
                {
                    con3.Open();
                    SqlParameter sp1 = new SqlParameter("@UserName", UserName);
                    cmd.Parameters.Add(sp1);
                    SqlParameter sp2 = new SqlParameter("@Password", PassWord);
                    cmd.Parameters.Add(sp2);

                    int Result = (int)cmd.ExecuteScalar();
                    if (Result > 0)
                    {
                        Console.WriteLine("登陆成功！！");
                    }
                    else
                    {
                        Console.WriteLine("登录失败！！");
                    }
                }
            }
        }

        public static void ExecuteScalarDemo2()
        {
            Console.WriteLine("请输入要插入用户名：");
            string username = Console.ReadLine();
            Console.WriteLine("请输入要插入密码：");
            string password = Console.ReadLine();
            using (SqlConnection con3 = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = con3.CreateCommand();
                cmd.CommandText = string.Format("insert into Admin (UserName,Password)  values('{0}','{1}');select @@identity", username, password);
                con3.Open();
                int result = (int)cmd.ExecuteScalar();
                if (result > 0)
                {
                    Console.WriteLine("数据插入成功");
                }
                else
                {
                    Console.WriteLine("数据插入失败");
                }
            }
        }

        public static void ExecuteScalarDemo3()
        {
            Console.WriteLine("请输入要插入用户名：");
            string username = Console.ReadLine();
            Console.WriteLine("请输入要插入密码：");
            string password = Console.ReadLine();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = string.Format(@"insert into Admin (UserName,Password)  output inserted.ID values('{0}','{1}')", username, password);
                con.Open();
                int result = (int)cmd.ExecuteScalar();
                if (result > 0)
                {
                    Console.WriteLine("数据插入成功");
                }
                else
                {
                    Console.WriteLine("数据插入失败");
                }
            }
        }

        //执行登陆功能  注入登陆：  1' or '1'='1
        public static void ExecuteScalarDemo4()
        {
            Console.WriteLine("请输入用户名：");
            string username = Console.ReadLine();
            Console.WriteLine("请输入密码：");
            string password = Console.ReadLine();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = string.Format("select count(*) from Admin where UserName='{0}'and Password='{1}'", username, password);
                con.Open();
                int result = (int)cmd.ExecuteScalar();
                if (result > 0)
                {
                    Console.WriteLine("成功");
                }
                else
                {
                    Console.WriteLine("失败");
                }
            }
        }

        public static void ExecuteScalarDemo5()
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = ConnectionString;
                SqlCommand cmd = new SqlCommand();
                string commandText = "select 1 from Admin where ID=1";

                cmd.Connection = con;
                cmd.CommandText = commandText;
                con.Open();
                string result = cmd.ExecuteScalar().ToString();
                if (Convert.ToInt32(result) > 0)
                {
                    Console.WriteLine("成功");
                }
                else
                {
                    Console.WriteLine("失败");
                }
            }
        }

        public static void ExecuteScalarDemo6()
        {
            using (SqlConnection con2 = new SqlConnection())
            {
                con2.ConnectionString = ConnectionString;

                string sql2 = "select count(*) from Admin ";

                SqlCommand cmd = con2.CreateCommand();
                cmd.CommandText = sql2;
                con2.Open();
                int Result = (int)cmd.ExecuteScalar();
                Console.WriteLine(Result);
            }
        }

        public static void ExecuteReaderDemo1()
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = ConnectionString;
                SqlCommand cmd = new SqlCommand();
                string commandText = "select UserName,Password from Admin";

                cmd.Connection = con;
                cmd.CommandText = commandText;
                con.Open();
                SqlDataReader sdr1 = cmd.ExecuteReader();
                while (sdr1.Read())
                {
                    //Console.WriteLine("用户名："+sdr1[0]);
                    //Console.WriteLine("密码："+sdr1[1]);

                    //Console.WriteLine("用户名：" + sdr1["UserName"]);
                    //Console.WriteLine("密码：" + sdr1["Password"]);

                    //Console.WriteLine("用户名：" + sdr1.GetString(sdr1.GetOrdinal("UserName")));
                    //Console.WriteLine("密码：" + sdr1.GetString(sdr1.GetOrdinal("Password")));

                    Console.WriteLine("用户名：" + sdr1.GetString(0));
                    Console.WriteLine("密码：" + sdr1.GetString(1));

                    Console.WriteLine();
                }
            }
        }

        public static void ExecuteReaderDemo2()
        {
            using (SqlConnection con2 = new SqlConnection(ConnectionString))
            {
                string sql2 = string.Format("select * from Admin where ID=1");
                SqlCommand cmd2 = new SqlCommand(sql2, con2);
                con2.Open();
                SqlDataReader sdt = cmd2.ExecuteReader();
                while (sdt.Read())
                {
                    Console.WriteLine("用户名：" + sdt["UserName"] + ",密码：" + sdt["Password"]);
                }
            }
        }

        public static void ExecuteNonQueryDemo1()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                Console.WriteLine("请输入要删除的用户名Id：");
                string userId = Console.ReadLine();
                int intUserId = Convert.ToInt32(userId);
                string cmdText = string.Format("delete from Admin where Id={0}", intUserId);
                SqlCommand cmd = new SqlCommand(cmdText, con);
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("删除数据成功");
                }
                else
                {
                    Console.WriteLine("删除数据失败");
                }
            }
        }

        public static void ExecuteNonQueryDemo2()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                Console.WriteLine("请输入要添加的用户名：");
                string username = Console.ReadLine();
                Console.WriteLine("请输入用户密码：");
                string password = Console.ReadLine();
                string cmdText = string.Format("insert into Admin (UserName,Password) values ('{0}','{1}')", username, password);
                SqlCommand cmd = new SqlCommand(cmdText, con);
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("数据添加成功");
                }
                else
                {
                    Console.WriteLine("数据添加失败");
                }
            }
        }

        public static void SqlDataAdapterDemo()
        {
            string commandText = "select UserName,Password from Admin";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(commandText, con);
                con.Open();
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "Admin");
                foreach (DataRow row in dataSet.Tables["Admin"].Rows)
                {
                    Console.WriteLine("UserName:{0},Password:{1}", row["UserName"], row["Password"]);
                }
                Console.ReadKey();
            }
        }
    }
}