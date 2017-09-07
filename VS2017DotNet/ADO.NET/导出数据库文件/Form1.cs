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

namespace WindowsFormsApplication1
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
            saveFileDialog1.Filter = "文本文件|*.txt|cs文件|*.cs|所有文件|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path=saveFileDialog1.FileName;
                using (SqlConnection conn=new SqlConnection(ConStr))
                {
                    string sql = string.Format("select * from Admin");
                    using (SqlCommand cmd=new SqlCommand(sql,conn))
                    {
                        conn.Open();
                        using (SqlDataReader dr=cmd.ExecuteReader())
                        {
                            List<string> users = new List<string>();
                            while (dr.Read())
                            {
                                string name = dr["LoginID"].ToString();
                                string pwd = dr["LoginPwd"].ToString();
                                users.Add(name + "," + pwd);
                            }
                            File.WriteAllLines(path, users.ToArray());
                            MessageBox.Show("保存了"+users.Count+"条数据");
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ConStr = "Data Source=.;Initial Catalog=ExampleDb;uid=sa;pwd=sa";
            saveFileDialog1.Filter = "文本文件|*.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog1.FileName;
                using (SqlConnection conn = new SqlConnection(ConStr))
                {
                    string sql = "select * from [Admin]";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                      
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                       
                            List<string> users = new List<string>();
                            while (dr.Read())
                            {
                                
                                string name = dr["LoginID"].ToString();
                              
                                string pwd = dr["LoginPwd"].ToString();
                             
                                users.Add(name + "," + pwd);
                            }
                           
                            File.WriteAllLines(path, users.ToArray());
                            MessageBox.Show("保存了" + users.Count);
                        }
                    }
                }
            }
        }
    }
}
