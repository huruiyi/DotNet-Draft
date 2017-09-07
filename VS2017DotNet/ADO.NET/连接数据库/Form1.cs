using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace 连接数据库
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Con2();
        }

        public static void Con1()
        {
            string connectionString = ConStringConfiguration.GetConstring1();
            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = connectionString;
            con1.Open();
            MessageBox.Show(con1.State.ToString(), "数据库状态");
        }

        public static void Con2()
        {
            string connectionString = ConStringConfiguration.GetConstring2();
            SqlConnection con2 = new SqlConnection();
            con2.ConnectionString = connectionString;
            con2.Open();
            MessageBox.Show(con2.State.ToString(), "数据库状态");
        }

        public static void Con3()
        {
            string connectionString = ConStringConfiguration.ConString3;
            SqlConnection con3 = new SqlConnection();
            con3.ConnectionString = connectionString;
            con3.Open();
            MessageBox.Show(con3.State.ToString(), "数据库状态");
        }

        public static void Con4()
        {
            string connectionString = ConStringConfiguration.ConString4;
            SqlConnection con4 = new SqlConnection();
            con4.ConnectionString = connectionString;
            con4.Open();
            MessageBox.Show(con4.State.ToString(), "数据库状态");
        }

        public static void Con5()
        {
            string connectionString = ConStringConfiguration.GetConstring3();
            SqlConnection con5 = new SqlConnection(connectionString);
            con5.Open();
            MessageBox.Show(con5.State.ToString(), "数据库状态");
        }

        public static void Con6()
        {
            string connectionString = ConStringConfiguration.GetConstring4();
            SqlConnection con6 = new SqlConnection();
            con6.ConnectionString = connectionString;
            con6.Open();
            MessageBox.Show(con6.State.ToString(), "数据库状态");
        }

        public static void Con7()
        {
            string connectionString = ConStringConfiguration.GetConstring5();
            SqlConnection con7 = new SqlConnection(connectionString);
            con7.Open();
            MessageBox.Show(con7.State.ToString(), "数据库状态");
        }
    }
}