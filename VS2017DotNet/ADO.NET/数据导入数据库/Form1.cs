using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace 数据导入数据库
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ConStr = "Data Source=.;Initial Catalog=ExampleDb;uid=sa;pwd=sa";
            openFileDialog1.Filter = "文本文件|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (SqlConnection con = new SqlConnection(ConStr))
                {
                    con.Open();
                    int i = 0;
                    string[] lines = File.ReadAllLines(openFileDialog1.FileName, Encoding.Default);
                    foreach (var item in lines)
                    {
                        string[] info = item.Split('，', ',');
                        string sql = string.Format("insert into Admin (LoginID,LoginPwd) values ('{0}','{1}')", info[0], info[1]);
                        using (SqlCommand cmd = new SqlCommand(sql, con))
                        {
                            cmd.ExecuteNonQuery();
                            i++;
                        }
                    }

                    MessageBox.Show(i.ToString());
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connStr = "Data Source=.;Initial Catalog=ExampleDb;uid=sa;pwd=sa";
            openFileDialog1.Filter = "文本文件|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] lines = File.ReadAllLines(openFileDialog1.FileName, Encoding.Default);
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        //sb连接多个sql语句
                        StringBuilder sb = new StringBuilder();
                        foreach (var line in lines)
                        {
                            string[] arr = line.Split(',', '，');

                            if (arr.Length == 2)
                            {
                                sb.Append(string.Format("insert into [Admin] (LoginID,LoginPwd) values('{0}','{1}');", arr[0], arr[1]));
                            }
                        }
                        conn.Open();
                        cmd.CommandText = sb.ToString();
                        int n = cmd.ExecuteNonQuery();
                        MessageBox.Show(n.ToString());
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            string connStr = "Data Source=.;Initial Catalog=ExampleDb;uid=sa;pwd=sa";
            openFileDialog1.Filter = "文本文件|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] lines = File.ReadAllLines(openFileDialog1.FileName, Encoding.Default);
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        int i = 0;
                        foreach (var line in lines)
                        {
                            string[] arr = line.Split(new char[] { ',', '，' });
                            if (arr.Length == 2)
                            {
                                string sql = "insert into [Admin](LoginID,LoginPwd) values(@name,@pwd)";
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@name", arr[0]);
                                cmd.Parameters.AddWithValue("@pwd", arr[1]);
                                cmd.CommandText = sql;
                                i++;
                                cmd.ExecuteNonQuery();
                            }
                        }
                        MessageBox.Show("添加了" + i);
                    }
                }
            }



        }













    }
}
